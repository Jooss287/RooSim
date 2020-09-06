using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbManager.DB
{
    [Serializable]
    public class MonsterDB
    {
        public MonsterDB() { }
        public MonsterDB(int mob_id, string name, bool isBoss, int size,
            int atk, int matk, int hp, int def, int mdef, int hit, int flee)
        {
            _mob_id = mob_id;
            _name = name;
            _isBoss = isBoss;
            _size = size;
            _atk = atk;
            _matk = matk;
            _hp = hp;
            _def = def;
            _mdef = mdef;
            _hit = hit;
            _flee = flee;
        }
        protected int _mob_id;
        protected string _name;
        protected bool _isBoss;
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
        public bool IsBoss
        {
            get { return _isBoss;  }
            set { _isBoss = value; }
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
            set { _def= value; }
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
