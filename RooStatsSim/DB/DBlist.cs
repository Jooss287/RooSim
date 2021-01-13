using System;
using System.Windows;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using RooStatsSim.Extension;
using RooStatsSim.DB.Table;

namespace RooStatsSim.DB
{
    [Serializable]
    public class DBlist
    {
        public Dictionary<int, MonsterDB> _mob_db = new Dictionary<int, MonsterDB>();
        public Dictionary<int, Dictionary<int, ItemDB>> _equip_db = new Dictionary<int, Dictionary<int, ItemDB>>();
        public Dictionary<int, ItemDB> _set_equip_db = new Dictionary<int, ItemDB>();
        public Dictionary<int, ItemDB> _card_db = new Dictionary<int, ItemDB>();
        public Dictionary<int, ItemDB> _enchant_db = new Dictionary<int, ItemDB>();
        public Dictionary<int, ItemDB> _gear_db = new Dictionary<int, ItemDB>();
        public Dictionary<int, ItemDB> _monster_research_db = new Dictionary<int, ItemDB>();
        public Dictionary<int, ItemDB> _dress_style_db = new Dictionary<int, ItemDB>();
        public Dictionary<int, ItemDB> _sticker_db = new Dictionary<int, ItemDB>();

        #region Properties
        public Dictionary<int, MonsterDB> Mob_db
        {
            get { return _mob_db; }
            set { _mob_db = value; }
        }
        [JsonIgnore] public Dictionary<int, Dictionary<int, ItemDB>> Equip_db
        {
            get { return _equip_db; }
            set { _equip_db = value; }
        }
        public Dictionary<int, ItemDB> Equip_head_db
        {
            get {
                if (!Equip_db.ContainsKey((int)EQUIP_DB_ENUM.HEAD))
                    Equip_db[(int)EQUIP_DB_ENUM.HEAD] = new Dictionary<int, ItemDB>();
                    return Equip_db[(int)EQUIP_DB_ENUM.HEAD]; }
            set { Equip_db[(int)EQUIP_DB_ENUM.HEAD] = value; }
        }
        public Dictionary<int, ItemDB> Equip_weapon_db
        {
            get {
                if (!Equip_db.ContainsKey((int)EQUIP_DB_ENUM.WEAPON))
                    Equip_db[(int)EQUIP_DB_ENUM.WEAPON] = new Dictionary<int, ItemDB>();
                    return Equip_db[(int)EQUIP_DB_ENUM.WEAPON]; }
            set { Equip_db[(int)EQUIP_DB_ENUM.WEAPON] = value; }
        }
        public Dictionary<int, ItemDB> Equip_armor_db
        {
            get {
                if (!Equip_db.ContainsKey((int)EQUIP_DB_ENUM.ARMOR))
                    Equip_db[(int)EQUIP_DB_ENUM.ARMOR] = new Dictionary<int, ItemDB>();
                    return Equip_db[(int)EQUIP_DB_ENUM.ARMOR]; }
            set { Equip_db[(int)EQUIP_DB_ENUM.ARMOR] = value; }
        }
        public Dictionary<int, ItemDB> Equip_sub_weapon_db
        {
            get {
                if (!Equip_db.ContainsKey((int)EQUIP_DB_ENUM.SUB_WEAPON))
                    Equip_db[(int)EQUIP_DB_ENUM.SUB_WEAPON] = new Dictionary<int, ItemDB>();
                    return Equip_db[(int)EQUIP_DB_ENUM.SUB_WEAPON]; }
            set { Equip_db[(int)EQUIP_DB_ENUM.SUB_WEAPON] = value; }
        }
        public Dictionary<int, ItemDB> Equip_cloak_db
        {
            get {
                if (!Equip_db.ContainsKey((int)EQUIP_DB_ENUM.CLOAK))
                    Equip_db[(int)EQUIP_DB_ENUM.CLOAK] = new Dictionary<int, ItemDB>();
                    return Equip_db[(int)EQUIP_DB_ENUM.CLOAK]; }
            set { Equip_db[(int)EQUIP_DB_ENUM.CLOAK] = value; }
        }
        public Dictionary<int, ItemDB> Equip_shoes_db
        {
            get {
                if (!Equip_db.ContainsKey((int)EQUIP_DB_ENUM.SHOES))
                    Equip_db[(int)EQUIP_DB_ENUM.SHOES] = new Dictionary<int, ItemDB>();
                    return Equip_db[(int)EQUIP_DB_ENUM.SHOES]; }
            set { Equip_db[(int)EQUIP_DB_ENUM.SHOES] = value; }
        }
        public Dictionary<int, ItemDB> Equip_accessories_db
        {
            get {
                if (!Equip_db.ContainsKey((int)EQUIP_DB_ENUM.ACC))
                    Equip_db[(int)EQUIP_DB_ENUM.ACC] = new Dictionary<int, ItemDB>();
                    return Equip_db[(int)EQUIP_DB_ENUM.ACC]; }
            set { Equip_db[(int)EQUIP_DB_ENUM.ACC] = value; }
        }
        public Dictionary<int, ItemDB> Equip_costume_db
        {
            get {
                if (!Equip_db.ContainsKey((int)EQUIP_DB_ENUM.COSTUME))
                    Equip_db[(int)EQUIP_DB_ENUM.COSTUME] = new Dictionary<int, ItemDB>();
                    return Equip_db[(int)EQUIP_DB_ENUM.COSTUME]; }
            set { Equip_db[(int)EQUIP_DB_ENUM.COSTUME] = value; }
        }
        public Dictionary<int, ItemDB> Equip_back_deco_db
        {
            get {
                if (!Equip_db.ContainsKey((int)EQUIP_DB_ENUM.BACK_DECO))
                    Equip_db[(int)EQUIP_DB_ENUM.BACK_DECO] = new Dictionary<int, ItemDB>();
                    return Equip_db[(int)EQUIP_DB_ENUM.BACK_DECO]; }
            set { Equip_db[(int)EQUIP_DB_ENUM.BACK_DECO] = value; }
        }
        public Dictionary<int, ItemDB> Set_Equip_db
        {
            get { return _set_equip_db; }
            set { _set_equip_db = value; }
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
        #endregion
        
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
        const string file_relative_root = "Database\\";
        public static void SaveDataBase(ref DBlist DB)
        {
            SaveDataBase<Dictionary<int, MonsterDB>>(DB.Mob_db, "Mob_db.roo");
            SaveDataBase<Dictionary<int, ItemDB>>(DB.Card_db, "Card_db.roo");
            SaveDataBase<Dictionary<int, ItemDB>>(DB.Enchant_db, "Enchant_db.roo");
            SaveDataBase<Dictionary<int, ItemDB>>(DB.Gear_db, "Gear_db.roo");
            SaveDataBase<Dictionary<int, ItemDB>>(DB.Mob_research_db, "Mob_research_db.roo");
            SaveDataBase<Dictionary<int, ItemDB>>(DB.Dress_style_db, "Dress_style_db.roo");
            SaveDataBase<Dictionary<int, ItemDB>>(DB.Sticker_db, "Sticker_db.roo");
            SaveDataBase<Dictionary<int, ItemDB>>(DB.Set_Equip_db, "Set_Item_db.roo");
            foreach(EQUIP_DB_ENUM db_enum in Enum.GetValues(typeof(EQUIP_DB_ENUM)))
            {
                string name = Enum.GetName(typeof(EQUIP_DB_ENUM), db_enum);
                SaveDataBase<Dictionary<int, ItemDB>>(DB.Equip_db[(int)db_enum], "Equip_" + name + "_db.roo");
            }
        }
        public static void SaveDataBase<T>(T DB, string name)
        {
            var serializeOptions = new JsonSerializerOptions();
            serializeOptions.Converters.Add(new JsonConvertExt_Dic_int_DB());
            serializeOptions.Converters.Add(new JsonConvertExt_Dic_Enum_BasicType());
            serializeOptions.Converters.Add(new JsonConvertExt_List_class_DB());
            serializeOptions.WriteIndented = true;

            string jsonString;
            jsonString = JsonSerializer.Serialize(DB, serializeOptions);
            File.WriteAllText(file_relative_root + name, jsonString);
        }
        public static void ReadDB(ref DBlist DB)
        {
            DB.Mob_db = LoadDataBase<Dictionary<int, MonsterDB>>("Mob_db.roo");
            if (DB.Mob_db == null) DB.Mob_db = new Dictionary<int, MonsterDB>();
            DB.Card_db = LoadDataBase<Dictionary<int, ItemDB>>("Card_db.roo");
            if (DB.Card_db == null) DB.Card_db = new Dictionary<int, ItemDB>();
            DB.Enchant_db = LoadDataBase<Dictionary<int, ItemDB>>("Enchant_db.roo");
            if (DB.Enchant_db == null) DB.Enchant_db = new Dictionary<int, ItemDB>();
            DB.Gear_db = LoadDataBase<Dictionary<int, ItemDB>>("Gear_db.roo");
            if (DB.Gear_db == null) DB.Gear_db = new Dictionary<int, ItemDB>();
            DB.Mob_research_db = LoadDataBase<Dictionary<int, ItemDB>>("Mob_research_db.roo");
            if (DB.Mob_research_db == null) DB.Mob_research_db = new Dictionary<int, ItemDB>();
            DB.Dress_style_db = LoadDataBase<Dictionary<int, ItemDB>>("Dress_style_db.roo");
            if (DB.Dress_style_db == null) DB.Dress_style_db = new Dictionary<int, ItemDB>();
            DB.Sticker_db = LoadDataBase<Dictionary<int, ItemDB>>("Sticker_db.roo");
            if (DB.Sticker_db == null) DB.Sticker_db = new Dictionary<int, ItemDB>();
            DB.Set_Equip_db = LoadDataBase<Dictionary<int, ItemDB>>("Set_Item_db.roo");
            if (DB.Set_Equip_db == null) DB.Set_Equip_db = new Dictionary<int, ItemDB>();
            foreach (EQUIP_DB_ENUM db_enum in Enum.GetValues(typeof(EQUIP_DB_ENUM)))
            {
                string name = Enum.GetName(typeof(EQUIP_DB_ENUM), db_enum);
                DB.Equip_db[(int)db_enum] = LoadDataBase<Dictionary<int, ItemDB>>("Equip_" + name + "_db.roo");
                if (DB.Equip_db[(int)db_enum] == null) DB.Equip_db[(int)db_enum] = new Dictionary<int, ItemDB>();
            }

        }
        public static T LoadDataBase<T>(string name)
        {
            if (!ResourceExtension.IsFileExists(file_relative_root + name))
            {
                return default;
            }
            var serializeOptions = new JsonSerializerOptions();
            serializeOptions.Converters.Add(new JsonConvertExt_Dic_int_DB());
            serializeOptions.Converters.Add(new JsonConvertExt_Dic_Enum_BasicType());
            serializeOptions.Converters.Add(new JsonConvertExt_List_class_DB());
            serializeOptions.WriteIndented = true;

            string jsonString = File.ReadAllText(file_relative_root + name);
            T DB = JsonSerializer.Deserialize<T>(jsonString, serializeOptions);
            return DB;
        }
    }
}
