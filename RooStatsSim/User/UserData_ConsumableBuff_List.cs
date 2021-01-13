using System;
using System.Windows.Media.Imaging;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Collections.Specialized;
using System.Text.Json.Serialization;
using RooStatsSim.DB.ConsumableItem;
using RooStatsSim.UI.ConsumableBuff;
using RooStatsSim.Extension;

namespace RooStatsSim.User
{
    [Serializable]
    public class UserConsumableBuff
    {
        [Serializable]
        public class UserConsumableBuffnfo
        {
            string _name;
            int _level;
            int _max_level;

            public UserConsumableBuffnfo() { }
            public UserConsumableBuffnfo(string name, int level = 0, int max_level = 0)
            {
                if (!ConsumableBuffWindow._consumable_buff_db.Dic.ContainsKey(name))
                    return;

                ConsumableBuffInfo buff = ConsumableBuffWindow._consumable_buff_db.Dic[name];
                Name = buff.NAME;
                if (max_level == 0)
                    Max_Level = buff.MAX_LV;
                Level = level;
            }

            public string Name
            {
                get { return _name; }
                set
                {
                    ConsumableBuffInfo buff = ConsumableBuffWindow._consumable_buff_db.Dic[value];
                    _name = buff.NAME;
                    Max_Level = buff.MAX_LV;
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
                set
                {
                    _max_level = value;
                }
            }
        }

        public Dictionary<string, UserConsumableBuffnfo> Dic { get; }
        public UserConsumableBuff()
        {
            Dic = new Dictionary<string, UserConsumableBuffnfo>();
        }

        public void SetSkillLevel(string name, int level, int max_level = 0)
        {
            if (level == 0)
            { 
                if (Dic.ContainsKey(name))
                    Dic.Remove(name);
                return;
            }
            else
                Dic[name] = new UserConsumableBuffnfo(name, level, max_level);
        }
        public UserItem GetOption()
        {
            UserItem option = new UserItem();
            foreach (KeyValuePair<string, UserConsumableBuffnfo> buff in Dic)
                option += ConsumableBuffWindow._consumable_buff_db.Dic[buff.Key].OPTION[buff.Value.Level-1];
            return option;
        }
    }
}
