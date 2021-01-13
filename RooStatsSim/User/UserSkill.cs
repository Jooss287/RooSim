using System;
using System.Windows.Media.Imaging;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Collections.Specialized;
using System.Text.Json.Serialization;
using RooStatsSim.DB.Skill;
using RooStatsSim.UI.SkillWindow;
using RooStatsSim.Extension;

namespace RooStatsSim.User
{
    [Serializable]
    public class UserSkill
    {
        [Serializable]
        public class UserSkillInfo : INotifyPropertyChanged
        {
            string _name;
            string _name_kor;
            int _level;
            int _max_level;
            BitmapImage _image;

            public UserSkillInfo() { }
            public UserSkillInfo(string name, int level = 0, int max_level = 0)
            {
                if (!SkillWindow._skill_db.Dic.ContainsKey(name))
                    return;

                SkillInfo skill = SkillWindow._skill_db.Dic[name];
                Name = skill.NAME;
                Name_Kor = skill.NAME_KOR;
                if (max_level == 0)
                    Max_Level = skill.MAX_LV;
                Level = level;
            }

            #region Property
            public string Name
            {
                get { return _name; }
                set
                {
                    SkillInfo skill = SkillWindow._skill_db.Dic[value];
                    _name = skill.NAME;
                    Name_Kor = skill.NAME_KOR;
                    Detail = skill;
                    Max_Level = skill.MAX_LV;
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
            [JsonIgnore]public string Name_Kor
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
            [JsonIgnore]public string Show_Level
            {
                get { return string.Format("({0}/{1})", Level, Max_Level); }
            }
            [JsonIgnore]public SkillInfo Detail { get; set; }
            [JsonIgnore]public BitmapImage ImageFile
            {
                get { return _image; }
            }

            private void GetImage()
            {
                if (_name == null)
                    return;
                string resource_name = "Resources/Skills/" + _name + ".png";
                _image = new BitmapImage(ResourceExtension.GetAssemblyUri(resource_name));
            }
            private void SetName(string name)
            {

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
        public ObservableCollection<UserSkillInfo> List { get; set; }
        public UserSkill()
        {
            List = new ObservableCollection<UserSkillInfo>();
            List.CollectionChanged += OnListChanged;
        }

        #region UserCommand
        public void InitSkills(params Dictionary<string, SkillInfo>[] skills)
        {
            List.Clear();
            foreach(Dictionary<string, SkillInfo> jobskill in skills)
            {
                foreach (KeyValuePair<string, SkillInfo> skill in jobskill)
                {
                    List.Add(new UserSkillInfo(skill.Key));
                }
            }
        }
        public void AddSkill(KeyValuePair<string, SkillInfo> skill)
        {
            if ( FindSkillInfo(skill.Key) == null)
            {
                List.Add(new UserSkillInfo(skill.Key));
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

            foreach (UserSkillInfo skill in List)
            {
                if (skill.Level == 0)
                    continue;
                if (skill.Detail.OPTION.Count == 0)
                    continue;
                option += skill.Detail.OPTION[skill.Level-1];
            }
            return option;
        }
        #endregion
        #region EventHandler
        private void OnListChanged(object sender, NotifyCollectionChangedEventArgs args)
        {
            //if (Convert.ToInt32(args.NewItems[0]) < 0)
            //{
            //    List[args.NewStartingIndex] = Convert.ToInt32(args.OldItems[0]);
            //}
        }
        #endregion
    }
}
