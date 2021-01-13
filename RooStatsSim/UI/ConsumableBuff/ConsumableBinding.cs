using System;
using System.Windows.Media.Imaging;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Collections.Specialized;
using System.Text.Json.Serialization;
using RooStatsSim.DB.ConsumableItem;
using RooStatsSim.User;
using RooStatsSim.Extension;

namespace RooStatsSim.UI.ConsumableBuff
{
    public class ConsumableBinding : ObservableCollection<ConsumableBindingInfo>
    {
        public ConsumableBinding(UserData user_data, params Dictionary<string, ConsumableBuffInfo>[] buff_list)
        {
            if (user_data == null) return;

            foreach (Dictionary<string, ConsumableBuffInfo> consumable in buff_list)
            {
                foreach (KeyValuePair<string, ConsumableBuffInfo> buff in consumable)
                {
                    int level = 0;
                    int max_level = buff.Value.MAX_LV;
                    if (user_data.User_ConBuff.Dic.ContainsKey(buff.Key))
                    { 
                        level = user_data.User_ConBuff.Dic[buff.Key].Level;
                        max_level = user_data.User_ConBuff.Dic[buff.Key].Max_Level;
                    }
                    Add(new ConsumableBindingInfo(buff.Key, level, max_level));
                }
            }
        }

        private void OnListChanged(object sender, NotifyCollectionChangedEventArgs args)
        {
            //if (Convert.ToInt32(args.NewItems[0]) < 0)
            //{
            //    List[args.NewStartingIndex] = Convert.ToInt32(args.OldItems[0]);
            //}
        }
    }

    public class ConsumableBindingInfo : INotifyPropertyChanged
    {
        string _name;
        string _name_kor;
        int _level;
        int _max_level;
        BitmapImage _image;

        public ConsumableBindingInfo() { }
        public ConsumableBindingInfo(string name, int level = 0, int max_level = 0)
        {
            if (!ConsumableBuffWindow._consumable_buff_db.Dic.ContainsKey(name))
                return;

            ConsumableBuffInfo buff = ConsumableBuffWindow._consumable_buff_db.Dic[name];
            Name = buff.NAME;
            Name_Kor = buff.NAME_KOR;
            if (max_level == 0)
                Max_Level = buff.MAX_LV;
            Level = level;
        }

        #region Properties
        public string Name
        {
            get { return _name; }
            set
            {
                ConsumableBuffInfo buff = ConsumableBuffWindow._consumable_buff_db.Dic[value];
                _name = buff.NAME;
                Name_Kor = buff.NAME_KOR;
                Detail = buff;
                Max_Level = buff.MAX_LV;
                OnPropertyChanged("Name");
                GetImage();
            }
        }
        public int Level
        {
            get { return _level; }
            set
            {
                if (value > Max_Level)
                    return;
                if (value < 0)
                    return;
                _level = value;
                OnPropertyChanged("Level");
                OnPropertyChanged("Show_Level");
            }
        }
        public string Name_Kor
        {
            get { return _name_kor; }
            set
            {
                _name_kor = value;
                OnPropertyChanged("Name_Kor");
            }
        }
        public int Max_Level
        {
            get { return _max_level; }
            set
            {
                if (value > Detail.MAX_LV)
                    return;
                _max_level = value;
                OnPropertyChanged("Max_Level");
            }
        }
        public string Show_Level
        {
            get { return new string('★', Level); }
        }
        public ConsumableBuffInfo Detail { get; set; }
        public BitmapImage ImageFile
        {
            get { return _image; }
        }
        void GetImage()
        {
            if (_name == null)
                return;
            string resource_name = "Resources/ConsumableBuff/" + _name + ".png";
            _image = new BitmapImage(ResourceExtension.GetAssemblyUri(resource_name));
        }
        #endregion
        #region EventHandler
        public event PropertyChangedEventHandler PropertyChanged;

        public override string ToString() => _name;

        protected void OnPropertyChanged(string info)
        {
            var handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(info));
        }
        #endregion
    }
}

