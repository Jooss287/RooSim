using System;
using System.Windows.Media.Imaging;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Collections.Specialized;
using System.Text.Json.Serialization;
using RooStatsSim.DB.ConsumableItem;
using RooStatsSim.Extension;

namespace RooStatsSim.User
{
    [Serializable]
    public class UserConsumableBuff
    {
        public class UserConsumableBuffnfo : INotifyPropertyChanged
        {
            string _name;
            string _name_kor;
            int _level;
            int _max_level;
            BitmapImage _image;

            public string Name
            {
                get { return _name; }
                set
                {
                    _name = value;
                    OnPropertyChanged("Name");
                    GetImage();
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
            public int Level
            {
                get { return _level; }
                set
                {
                    if (value > _max_level)
                        return;
                    if (value < 0)
                        return;
                    _level = value;
                    OnPropertyChanged("Level");
                    OnPropertyChanged("Show_Level");
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
            [JsonIgnore]public ConsumableBuffInfo Detail { get; set; }
            [JsonIgnore]public BitmapImage ImageFile
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

            public event PropertyChangedEventHandler PropertyChanged;

            public override string ToString() => _name;

            protected void OnPropertyChanged(string info)
            {
                var handler = PropertyChanged;
                handler?.Invoke(this, new PropertyChangedEventArgs(info));
            }
        }

        public ObservableCollection<UserConsumableBuffnfo> List { get; }
        public UserConsumableBuff()
        {
            List = new ObservableCollection<UserConsumableBuffnfo>();
            List.CollectionChanged += OnListChanged;
        }
        private void OnListChanged(object sender, NotifyCollectionChangedEventArgs args)
        {
            //if (Convert.ToInt32(args.NewItems[0]) < 0)
            //{
            //    List[args.NewStartingIndex] = Convert.ToInt32(args.OldItems[0]);
            //}
        }
        public void InitBuffs(params Dictionary<string, ConsumableBuffInfo>[] buff_list)
        {
            List.Clear();
            foreach(Dictionary<string, ConsumableBuffInfo> consumable in buff_list)
            {
                foreach (KeyValuePair<string, ConsumableBuffInfo> buff in consumable)
                {
                    UserConsumableBuffnfo user_buff = new UserConsumableBuffnfo();
                    user_buff.Name = buff.Key;
                    user_buff.Name_Kor = buff.Value.NAME_KOR;
                    user_buff.Detail = buff.Value;
                    user_buff.Level = 0;
                    user_buff.Max_Level = buff.Value.MAX_LV;
                    List.Add(user_buff);
                }
            }
        }
        public UserItem GetOption()
        {
            UserItem option = new UserItem();

            foreach (UserConsumableBuffnfo buff in List)
            {
                if (buff.Level == 0)
                    continue;
                option += buff.Detail.OPTION[buff.Level-1];
            }
            return option;
        }
    }
}
