using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbManager.DB
{
    public enum ITEM_TYPE_ENUM
    {
        MONSTER_RESEARCH,
        STIKER,
        DRESS_STYLE,
        EQUIPMENT,
        CARD,
        ENCHANT,
    }

    public enum EQUIP_TYPE_ENUM
    {
        HEAD_TOP,
        HEAD_MID,
        HEAD_BOT,
        WEAPON,
        SUB_WEAPON,
        CLOAK,
        BOOTS,
        ACCESSORIES1,
        ACCESSORIES2,
        COSTUME,
        BACK_DECORATION,
    }

    [Serializable]
    public class ItemDB
    {
        public ItemDB(MonsterDB monsterDB)
        {
            _mob_id = monsterDB.MobId;
            _name = monsterDB.Name;
            _level = monsterDB.Level;
            _isBoss = monsterDB.IsBoss;
            _tribe = monsterDB.Tribe;
            _element = monsterDB.Element;
            _size = monsterDB.Size;
            _atk = monsterDB.Atk;
            _matk = monsterDB.Matk;
            _hp = monsterDB.Hp;
            _def = monsterDB.Def;
            _mdef = monsterDB.Mdef;
            _hit = monsterDB.Hit;
            _flee = monsterDB.Flee;
        }
        public ItemDB() { }
        public ItemDB(int mob_id, string name, int level, bool isBoss, int tribe, int element, int size,
            int atk, int matk, int hp, int def, int mdef, int hit, int flee)
        {
            _mob_id = mob_id;
            _name = name;
            _level = level;
            _isBoss = isBoss;
            _tribe = tribe;
            _element = element;
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
        protected int _level;
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
        public bool IsBoss
        {
            get { return _isBoss;  }
            set { _isBoss = value; }
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
