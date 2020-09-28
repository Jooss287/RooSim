using RooStatsSim.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbManager.DB
{
    public enum ITEM_TYPE_ENUM
    {
        NONE,
        MONSTER_RESEARCH,
        STICKER,
        DRESS_STYLE,
        EQUIPMENT,
        CARD,
        ENCHANT,
    }

    public enum EQUIP_TYPE_ENUM
    {
        NONE,
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

    public enum ITYPE
    {
        ATK = 1000,
        MATK = 2000,
        DEF = 3000,
        MDEF = 4000,
        ELEMENT = 8000,
    }
    public enum DTYPE
    {
        ATK_P,
        MATK_P,


    }
    public enum IFTYPE
    {
        ATK_PER_STR = 1000,
        ATK_PER_AGI = 2000,
        HP_PER_VIT = 3000,
        MATK_PER_INT = 4000,
    }
    public enum STATUS_EFFECT_TYPE
    {
        STERN,
        FEAR,
        SILENCE,
        FROZEN,
        CURSE,
        PETRIFICATION,
    }

    [Serializable]
    public class ItemDB
    {
        public ItemDB(ItemDB item_db)
        {
            _id = item_db.Id;
            _name = item_db.Name;
            _item_type = item_db._item_type;
            _equip_type = item_db._equip_type;
            i_option = item_db.i_option;
            d_option = item_db.d_option;
            se_option = item_db.se_option;
            if_option = item_db.if_option;
        }
        public ItemDB() { }
        
        
        
        ITEM_TYPE_ENUM _item_type = ITEM_TYPE_ENUM.NONE;
        EQUIP_TYPE_ENUM _equip_type = EQUIP_TYPE_ENUM.NONE;
        protected int _id;
        protected string _name;
        public Dictionary<ITYPE, int> i_option = new Dictionary<ITYPE, int>();
        public Dictionary<DTYPE, double> d_option = new Dictionary<DTYPE, double>();
        public Dictionary<STATUS_EFFECT_TYPE, double> se_option = new Dictionary<STATUS_EFFECT_TYPE, double>();
        public Dictionary<IFTYPE, AbilityPerStatus> if_option = new Dictionary<IFTYPE, AbilityPerStatus>();

        public Dictionary<ELEMENT_TYPE, double> element_inc_option = new Dictionary<ELEMENT_TYPE, double>();
        public Dictionary<MONSTER_SIZE, double> size_inc_option = new Dictionary<MONSTER_SIZE, double>();
        public Dictionary<TRIBE_TYPE, double> tribe_inc_option = new Dictionary<TRIBE_TYPE, double>();
        public Dictionary<MONSTER_TYPE, double> mobtype_inc_option = new Dictionary<MONSTER_TYPE, double>();

        public Dictionary<ELEMENT_TYPE, double> element_dec_option = new Dictionary<ELEMENT_TYPE, double>();
        public Dictionary<MONSTER_SIZE, double> size_dec_option = new Dictionary<MONSTER_SIZE, double>();
        public Dictionary<TRIBE_TYPE, double> tribe_dec_option = new Dictionary<TRIBE_TYPE, double>();
        public Dictionary<MONSTER_TYPE, double> mobtype_dec_option = new Dictionary<MONSTER_TYPE, double>();

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public ITEM_TYPE_ENUM Item_type
        {
            get { return _item_type; }
            set { _item_type = value; }
        }
        public EQUIP_TYPE_ENUM Equip_type
        {
            get { return _equip_type; }
            set { _equip_type = value; }
        }
    }

    public class AbilityPerStatus
    {
        public delegate int CalcFunc(int value);
        public int AddValue;
        public int PerValue;
        CalcFunc Calc;

        public AbilityPerStatus(IFTYPE iftype, int add_value, int per_value)
        {
            AddValue = add_value;
            PerValue = per_value;
            switch (iftype)
            {
                case IFTYPE.ATK_PER_STR:
                    Calc = ATK_PER_STR;
                    break;
            }
        }

        public int ATK_PER_STR(int value)
        {
            return ((int)(value / PerValue) * AddValue);
        }
    }
}
