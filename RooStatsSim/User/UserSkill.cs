using System;
using System.Windows.Media.Imaging;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Collections.Specialized;
using System.Text.Json.Serialization;
using RooStatsSim.DB.Job;
using RooStatsSim.UI.SkillWindow;
using RooStatsSim.Extension;

namespace RooStatsSim.User
{
    [Serializable]
    public class UserSkill
    {
        [Serializable]
        public class UserSkillInfo
        {
            string _name;
            int _level;
            int _max_level;

            public UserSkillInfo() { }
            public UserSkillInfo(string name, int level = 0, int max_level = 0)
            {
                if (!SkillWindow._skill_db.Dic.ContainsKey(name))
                    return;

                SkillInfo skill = SkillWindow._skill_db.Dic[name];
                Name = skill.NAME;
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
                    Max_Level = skill.MAX_LV;
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
                }
            }
            public int Max_Level
            {
                get { return _max_level; }
                set { _max_level = value; }
            }
            #endregion
        }
        public Dictionary<string, UserSkillInfo> Dic { get; set; }
        public UserSkill()
        {
            Dic = new Dictionary<string, UserSkillInfo>();
        }

        #region UserCommand
        //public UserSkillInfo FindSkillInfo(string skill_name)
        //{
        //    foreach(UserSkillInfo skill in Dic)
        //        if ( skill.Name == skill_name)
        //            return skill;
        //    return null;
        //}
        public void SetSkillLevel(string name, int level, int max_level = 0)
        {
            if (level == 0)
            {
                if (Dic.ContainsKey(name))
                    Dic.Remove(name);
                return;
            }
            else
                Dic[name] = new UserSkillInfo(name, level, max_level);
        }
        public List<UserSkillInfo> GetActiveSkills()
        {
            List<UserSkillInfo> ret = new List<UserSkillInfo>();
            foreach(KeyValuePair<string, UserSkillInfo> info in Dic)
            {
                SkillInfo skill = SkillWindow._skill_db.Dic[info.Key];
                if (skill.TYPE == SKILL_TYPE.ACTIVE)
                    ret.Add(info.Value);
            }
            return ret;
        }
        public UserItem GetOption()
        {
            UserItem option = new UserItem();

            foreach (KeyValuePair<string,UserSkillInfo> skill in Dic)
            {
                if (SkillWindow._skill_db.Dic[skill.Key].OPTION.Count == 0)
                    continue;
                option += SkillWindow._skill_db.Dic[skill.Key].OPTION[skill.Value.Level - 1];
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
