using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace DbManager.DB
{
    [Serializable]
    public class DBlist
    {
        public Dictionary<int, MonsterDB> _mob_db = new Dictionary<int, MonsterDB>();
        public Dictionary<int, ItemDB> _equip_db = new Dictionary<int, ItemDB>();
        public Dictionary<int, ItemDB> _card_db = new Dictionary<int, ItemDB>();
        public Dictionary<int, ItemDB> _monster_research_db = new Dictionary<int, ItemDB>();
        public Dictionary<int, ItemDB> _dress_style_db = new Dictionary<int, ItemDB>();
        public Dictionary<int, ItemDB> _stiker_db = new Dictionary<int, ItemDB>();
        //List<ItemDB> ItemDB;

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
        public Dictionary<int, ItemDB> Stiker_db
        {
            get { return _stiker_db; }
            set { _stiker_db = value; }
        }



        public DBlist() { }
        public DBlist(DBlist db)
        {
            if (db._mob_db != null) _mob_db = db._mob_db;
            if (db._equip_db != null) _equip_db = db._equip_db;
            if (db._card_db != null) _card_db = db._card_db;
            if (db._monster_research_db != null) _monster_research_db = db._monster_research_db;
            if (db._dress_style_db != null) _dress_style_db = db._dress_style_db;
            if (db._stiker_db != null) _stiker_db = db._stiker_db;
        }
        
        public void AddMonsterDB(MonsterDB monsterDB)
        {
            _mob_db[monsterDB.MobId] = monsterDB;
        }

        public void AddItemDB(ref Dictionary<int, ItemDB> now_DB, ItemDB DB)
        {
            now_DB[DB.Id] = DB;
        }
    }
    
    class DBSerizator
    {
        const string file_name = "DB.roo";
        public static void SaveDataBase(ref DBlist DB)
        {
            // 직렬화 클래스
            var formatter = new BinaryFormatter();
            // 클래스를 직렬화하여 보관할 데이터
            byte[] data;
            using (MemoryStream stream = new MemoryStream())
            {
                formatter.Serialize(stream, DB);
                data = new byte[stream.Length];
                //스트림을 byte[] 데이터로 변환한다.
                data = stream.GetBuffer();
            }

            // 직렬화 데이터를 파일로 저장한다.
            using (FileStream stream = new FileStream(file_name, FileMode.Create, FileAccess.Write))
            {
                formatter.Serialize(stream, DB);
            }
        }

        public static void ReadDB(ref DBlist DB)
        {
            if (!IsFileAvailable())
                return;

            var formatter = new BinaryFormatter();
            using (FileStream stream = new FileStream(file_name, FileMode.Open, FileAccess.Read))
            {
                // 클래스를 역직렬화 하고 Node클래스의 Print함수 실행.
                DB = new DBlist((DBlist)formatter.Deserialize(stream));
            }
        }

        public static bool IsFileAvailable()
        {
            //FileInfo생성
            FileInfo fi = new FileInfo(file_name);
            //FileInfo.Exists로 파일 존재유무 확인
            if (fi.Exists)
                return true;
            else
                return false;
        }
    }
}
