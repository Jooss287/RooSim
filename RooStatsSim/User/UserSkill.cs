using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows.Media;
using MaterialDesignThemes.Wpf;
using System.Text.Json.Serialization;
using RooStatsSim.DB;
using RooStatsSim.DB.Table;
using RooStatsSim.UI.Equipment;
using RooStatsSim.DB.Skill;

namespace RooStatsSim.User
{
    [Serializable]
    public class UserSkill
    {
        public class UserSkillInfo
        {
            public string Name { get; set; }
            public int Level { get; set; }
            [JsonIgnore]public SkillInfo Detail { get; set; }
            
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
        public void InitSkills(Dictionary<string, SkillInfo> skills)
        {
            List.Clear();
            foreach(KeyValuePair<string, SkillInfo> skill in skills)
            {
                UserSkillInfo user_skill = new UserSkillInfo();
                user_skill.Name = skill.Key;
                user_skill.Level = 0;
                user_skill.Detail = skill.Value;
                List.Add(user_skill);
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
