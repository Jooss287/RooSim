using System;
using System.Windows.Media.Imaging;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Collections.Specialized;
using System.Text.Json.Serialization;
using RooStatsSim.DB.Skill;
using RooStatsSim.Extension;

namespace RooStatsSim.User
{
    [Serializable]
    public class UserSkill
    {
        public class UserSkillInfo : INotifyPropertyChanged
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
                get { return string.Format("({0}/{1})", Level, Max_Level); }
            }
            [JsonIgnore]public SkillInfo Detail { get; set; }
            [JsonIgnore]public BitmapImage ImageFile
            {
                get { return _image; }
            }
            void GetImage()
            {
                if (_name == null)
                    return;
                string resource_name = "Resources/Skills/" + _name + ".png";
                _image = new BitmapImage(ResourceExtension.GetUri(resource_name));
            }

            public event PropertyChangedEventHandler PropertyChanged;

            public override string ToString() => _name;

            protected void OnPropertyChanged(string info)
            {
                var handler = PropertyChanged;
                handler?.Invoke(this, new PropertyChangedEventArgs(info));
            }
        }

        public ObservableCollection<UserSkillInfo> List { get; }
        public UserSkill()
        {
            List = new ObservableCollection<UserSkillInfo>();
            List.CollectionChanged += OnListChanged;
        }
        private void OnListChanged(object sender, NotifyCollectionChangedEventArgs args)
        {
            //if (Convert.ToInt32(args.NewItems[0]) < 0)
            //{
            //    List[args.NewStartingIndex] = Convert.ToInt32(args.OldItems[0]);
            //}
        }
        public void InitSkills(params Dictionary<string, SkillInfo>[] skills)
        {
            List.Clear();
            foreach(Dictionary<string, SkillInfo> jobskill in skills)
            {
                foreach (KeyValuePair<string, SkillInfo> skill in jobskill)
                {
                    UserSkillInfo user_skill = new UserSkillInfo();
                    user_skill.Name = skill.Key;
                    user_skill.Name_Kor = skill.Value.NAME_KOR;
                    user_skill.Detail = skill.Value;
                    user_skill.Level = 0;
                    user_skill.Max_Level = skill.Value.MAX_LV;
                    List.Add(user_skill);
                }
            }
        }
        public void AddSkill(KeyValuePair<string, SkillInfo> skill)
        {
            if ( FindSkillInfo(skill.Key) == null)
            {
                UserSkillInfo user_skill = new UserSkillInfo();
                user_skill.Name = skill.Key;
                user_skill.Level = 0;
                user_skill.Detail = skill.Value;
                List.Add(user_skill);
            }    
        }
        public UserSkillInfo FindSkillInfo(string skill_name)
        {
            foreach(UserSkillInfo skill in List)
                if ( skill.Name == skill_name)
                    return skill;
            return null;
        }
        public UserItem GetOption()
        {
            UserItem option = new UserItem();

            //foreach (UserSkillInfo equipment in List)
            //{
            //    if (equipment.Equip == null)
            //        continue;
            //    foreach (ItemDB card in equipment.Card)
            //        option += card;
            //    foreach (ItemDB enchant in equipment.Enchant)
            //        option += enchant;
            //    option += equipment.Equip;
            //}
            return option;
        }
    }
}
