using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using RooStatsSim.Extension;

namespace RooStatsSim.DB
{
    [Serializable]
    public class DBlist
    {
        public Dictionary<int, MonsterDB> _mob_db = new Dictionary<int, MonsterDB>();
        public Dictionary<int, ItemDB> _equip_db = new Dictionary<int, ItemDB>();
        public Dictionary<int, ItemDB> _card_db = new Dictionary<int, ItemDB>();
        public Dictionary<int, ItemDB> _enchant_db = new Dictionary<int, ItemDB>();
        public Dictionary<int, ItemDB> _gear_db = new Dictionary<int, ItemDB>();
        public Dictionary<int, ItemDB> _monster_research_db = new Dictionary<int, ItemDB>();
        public Dictionary<int, ItemDB> _dress_style_db = new Dictionary<int, ItemDB>();
        public Dictionary<int, ItemDB> _sticker_db = new Dictionary<int, ItemDB>();

        public Dictionary<int, MonsterDB> Mob_db
        {
            get { return _mob_db; }
            set { _mob_db = value; }
        }
        public Dictionary<int, ItemDB> Equip_db
        {
            get { return _equip_db; }
            set { _equip_db = value; }
        }
        public Dictionary<int, ItemDB> Card_db
        {
            get { return _card_db; }
            set { _card_db = value; }
        }
        public Dictionary<int, ItemDB> Enchant_db
        {
            get { return _enchant_db; }
            set { _enchant_db = value; }
        }
        public Dictionary<int, ItemDB> Gear_db
        {
            get { return _gear_db; }
            set { _gear_db = value; }
        }
        public Dictionary<int, ItemDB> Mob_research_db
        {
            get { return _monster_research_db; }
            set { _monster_research_db = value; }
        }
        public Dictionary<int, ItemDB> Dress_style_db
        {
            get { return _dress_style_db; }
            set { _dress_style_db = value; }
        }
        public Dictionary<int, ItemDB> Sticker_db
        {
            get { return _sticker_db; }
            set { _sticker_db = value; }
        }

        public DBlist() { }

        public void AddMonsterDB(MonsterDB monsterDB)
        {
            _mob_db[monsterDB.MobId] = monsterDB;
        }

        public void AddItemDB(ref Dictionary<int, ItemDB> now_DB, ItemDB DB)
        {
            now_DB[DB.Id] = DB;
        }
    }
    
    class DBSerializer
    {
        const string file_name = "DB.roo";
        public static void SaveDataBase(ref DBlist DB)
        {
            var serializeOptions = new JsonSerializerOptions();
            serializeOptions.Converters.Add(new JsonConvertExt_Dic_int_DB());
            serializeOptions.Converters.Add(new JsonConvertExt_Dic_Enum_BasicType());
            serializeOptions.WriteIndented = true;

            string jsonString;
            jsonString = JsonSerializer.Serialize(DB, serializeOptions);
            File.WriteAllText(file_name, jsonString);
        }

        public static void ReadDB(ref DBlist DB)
        {
            if (!IsFileAvailable())
            {
                DB = new DBlist();
                return;
            }
                

            var serializeOptions = new JsonSerializerOptions();
            serializeOptions.Converters.Add(new JsonConvertExt_Dic_int_DB());
            serializeOptions.Converters.Add(new JsonConvertExt_Dic_Enum_BasicType());
            serializeOptions.WriteIndented = true;

            string jsonString = File.ReadAllText(file_name);
            DB = JsonSerializer.Deserialize<DBlist>(jsonString, serializeOptions);
        }

        public static bool IsFileAvailable()
        {
            FileInfo fi = new FileInfo(file_name);
            if (fi.Exists)
                return true;
            else
                return false;
        }
    }
}
