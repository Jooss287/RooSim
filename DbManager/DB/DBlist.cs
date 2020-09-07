using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace DbManager.DB
{
    [Serializable]
    public class DBlist
    {
        public Dictionary<int, MonsterDB> _mob_db;
        //List<ItemDB> ItemDB;
        public DBlist()
        {
            _mob_db = new Dictionary<int, MonsterDB>();
        }
        public void Add(MonsterDB monsterDB)
        {
            _mob_db[monsterDB.MobId] = monsterDB;
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
            //using (MemoryStream stream = new MemoryStream())
            //{
            //    // byte를 읽어드린다.
            //    stream.Write(data, 0, data.Length);
            //    // Stream seek을 맨 처음으로 돌린다.
            //    stream.Seek(0, SeekOrigin.Begin);
            //}

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
                DB = (DBlist)(formatter.Deserialize(stream));
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
