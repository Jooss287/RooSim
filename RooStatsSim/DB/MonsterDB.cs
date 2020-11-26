using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RooStatsSim.DB.Table;
using RooStatsSim.UI.Manager;

namespace RooStatsSim.DB
{
    [Serializable]
    public class MonsterDB
    {
        public MonsterDB(MonsterDB monsterDB)
        {
            MobId = monsterDB.MobId;
            Name = monsterDB.Name;
            Level = monsterDB.Level;
            Type = monsterDB.Type;
            StatusInfo = new Status(monsterDB.StatusInfo);
            Tribe = monsterDB.Tribe;
            Element = monsterDB.Element;
            Size = monsterDB.Size;
            Atk = monsterDB.Atk;
            Matk = monsterDB.Matk;
            Hp = monsterDB.Hp;
            Def = monsterDB.Def;
            Mdef = monsterDB.Mdef;
            Hit = monsterDB.Hit;
            Flee = monsterDB.Flee;
        }
        public MonsterDB() { }
        public MonsterDB(int mob_id, string name, int level, MONSTER_KINDS_TYPE type, Status status, int tribe, int element, int size,
            int atk, int matk, int hp, int def, int mdef, int hit, int flee)
        {
            MobId = mob_id;
            Name = name;
            Level = level;
            Type = type;
            StatusInfo = new Status(status);
            Tribe = tribe;
            Element = element;
            Size = size;
            Atk = atk;
            Matk = matk;
            Hp = hp;
            Def = def;
            Mdef = mdef;
            Hit = hit;
            Flee = flee;
        }
        protected int _mob_id;
        protected string _name;
        protected bool _isBoss;
        protected MONSTER_KINDS_TYPE _type;
        protected int _level;
        protected Status _status = new Status();
        protected int _tribe;
        protected int _element;
        protected int _size;
        protected int _atk;
        protected int _matk;
        protected int _hp;
        protected int _def;
        protected int _mdef;
        protected int _hit;
        protected int _flee;

        public int MobId
        {
            get { return _mob_id; }
            set { _mob_id = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public int Level
        {
            get { return _level; }
            set { _level = value; }
        }
        public MONSTER_KINDS_TYPE Type
        {
            get { return _type; }
            set { _type = value; }
        }
        public Status StatusInfo
        {
            get { return _status; }
            set { _status = value; }
        }
        public int Tribe
        {
            get { return _tribe; }
            set { _tribe = value; }
        }
        public int Element
        {
            get { return _element; }
            set { _element = value; }
        }
        public int Size
        {
            get { return _size; }
            set { _size = value; }
        }
        public int Atk
        {
            get { return _atk; }
            set { _atk = value; }
        }
        public int Matk
        {
            get { return _matk; }
            set { _matk = value; }
        }
        public int Hp
        {
            get { return _hp; }
            set { _hp = value; }
        }
        public int Def
        {
            get { return _def; }
            set { _def = value; }
        }
        public int Mdef
        {
            get { return _mdef; }
            set { _mdef = value; }
        }
        public int Hit
        {
            get { return _hit; }
            set { _hit = value; }
        }
        public int Flee
        {
            get { return _flee; }
            set { _flee = value; }
        }
    }
}
