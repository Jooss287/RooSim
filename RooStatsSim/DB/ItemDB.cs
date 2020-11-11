using RooStatsSim.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RooStatsSim.DB
{
    public enum ITEM_TYPE_ENUM
    {
        MONSTER_RESEARCH,
        STICKER,
        DRESS_STYLE,
        EQUIPMENT,
        CARD,
        ENCHANT,
        GEAR,
    }

    public enum EQUIP_TYPE_ENUM
    {
        HEAD_TOP,
        HEAD_MID,
        HEAD_BOT,
        WEAPON,
        ARMOR,
        SUB_WEAPON,
        CLOAK,
        SHOES,
        ACCESSORIES1,
        ACCESSORIES2,
        COSTUME,
        BACK_DECORATION,
    }
    public enum JOB_SELECT_LIST
    {
        NOVICE = 0,
        SWORDMAN = 100,
        KNIGHT = 110,
        CRUSADER = 120,
        MARCHANT = 200,
        BLACKSMITH = 210,
        ALCHEMIST = 220,
        THIEF = 300,
        ASSASSIN = 310,
        LOGUE = 320,
        ARCHER = 400,
        HUNTER = 410,
        BARD = 420,
        DANCER = 430,
        MAGICIAN = 500,
        WIZARD = 510,
        SAGE = 520,
        ACOLYTE = 600,
        PRIST = 610,
        MONK = 620,
    }

    public enum ITYPE
    {
        STR = 0000,     //스테이터스 관련 스텟
        AGI,
        VIT,
        INT,
        DEX,
        LUK,
        ATK = 1000,     //공격력 관련 스텟
        MATK,
        SMELTING_ATK,
        SMELTING_MATK,
        WEAPON_ATK,
        WEAPON_MATK,
        STATUS_ATK,
        STATUS_MATK,
        MASTERY_ATK,
        MASTERY_MATK,
        PHYSICAL_DAMAGE_ADDITIONAL,
        MAGICAL_DAMAGE_ADDITIONAL,
        DEF = 2000,     //방어력 관련 스텟
        MDEF,
        SMELTING_DEF,
        SMELTING_MDEF,
        HP = 3000,      //HP,SP 관련 스텟
        SP,
        HP_RECOVERY,
        SP_RECOVERY,
        FLEE = 4000,    //회피명중 관련 스텟
        HIT,
        CRI = 5000,     //크리율 관련 스텟
        CDEF,
    }

    public enum DTYPE
    {
        ATK_P = 1000,
        MATK_P,
        PHYSICAL_DAMAGE,
        MAGICAL_DAMAGE,
        IGNORE_PHYSICAL_DEFENSE,
        IGNORE_MAGICAL_DEFENSE,
        MELEE_PHYSICAL_DAMAGE,
        RANGE_PHYSICAL_DAMAGE,
        DEF_P = 2000,
        MDEF_P,
        PHYSICAL_DEC_DAMAGE,
        MAGICAL_DEC_DAMAGE,
        MAX_HP_P = 3000,
        MAX_SP_P,
        ASPD = 6000,    //기타 관련 스텟
        MOVING_SPEED,
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
            Id = item_db.Id;
            Name = item_db.Name;
            LevelLimit = item_db.LevelLimit;
            Item_type = item_db.Item_type;
            Equip_type = item_db.Equip_type;
            Smelt = item_db.Smelt;
            CardSlot = item_db.CardSlot;
            EnchantSlot = item_db.EnchantSlot;
            Wear_job_limit = new List<JOB_SELECT_LIST>(item_db.Wear_job_limit);
            i_option = new Dictionary<ITYPE, int>(item_db.i_option);
            d_option = new Dictionary<DTYPE, double>(item_db.d_option);
            se_option = new Dictionary<STATUS_EFFECT_TYPE, double>(item_db.se_option);
            if_option = new Dictionary<IFTYPE, AbilityPerStatus>(item_db.if_option);

            element_inc_option = new Dictionary<ELEMENT_TYPE, double>(item_db.element_inc_option);
            element_dec_option = new Dictionary<ELEMENT_TYPE, double>(item_db.element_dec_option);
            size_inc_option = new Dictionary<MONSTER_SIZE, double>(item_db.size_inc_option);
            size_dec_option = new Dictionary<MONSTER_SIZE, double>(item_db.size_dec_option);
            tribe_inc_option = new Dictionary<TRIBE_TYPE, double>(item_db.tribe_inc_option);
            tribe_dec_option = new Dictionary<TRIBE_TYPE, double>(item_db.tribe_dec_option);
            mobtype_inc_option = new Dictionary<MONSTER_TYPE, double>(item_db.mobtype_inc_option);
            mobtype_dec_option = new Dictionary<MONSTER_TYPE, double>(item_db.mobtype_dec_option);
        }
        public ItemDB() { }

        public static ItemDB operator +(ItemDB a, ItemDB b)
        {
            AddOption<ITYPE>(ref a.i_option, b.i_option);
            AddOption<DTYPE>(ref a.d_option, b.d_option);
            AddOption<STATUS_EFFECT_TYPE>(ref a.se_option, b.se_option);
            AddOption(ref a.if_option, b.if_option);
            AddOption<ELEMENT_TYPE>(ref a.element_inc_option, b.element_inc_option);
            AddOption<ELEMENT_TYPE>(ref a.element_dec_option, b.element_dec_option);
            AddOption<MONSTER_SIZE>(ref a.size_inc_option, b.size_inc_option);
            AddOption<MONSTER_SIZE>(ref a.size_dec_option, b.size_dec_option);
            AddOption<TRIBE_TYPE>(ref a.tribe_inc_option, b.tribe_inc_option);
            AddOption<TRIBE_TYPE>(ref a.tribe_dec_option, b.tribe_dec_option);
            AddOption<MONSTER_TYPE>(ref a.mobtype_inc_option, b.mobtype_inc_option);
            AddOption<MONSTER_TYPE>(ref a.mobtype_dec_option, b.mobtype_dec_option);
            return a;
        }
        
        protected static void AddOption<T1>(ref Dictionary<T1, int> a, Dictionary<T1, int> b)
        {
            foreach (KeyValuePair<T1, int> opt in b)
            {
                if (a.ContainsKey(opt.Key) == true)
                {
                    a[opt.Key] = a[opt.Key] + opt.Value;
                }
                else
                {
                    a[opt.Key] = opt.Value;
                }
            }
        }
        protected static void AddOption<T1>(ref Dictionary<T1, double> a, Dictionary<T1, double> b)
        {
            foreach (KeyValuePair<T1, double> opt in b)
            {
                if (a.ContainsKey(opt.Key) == true)
                {
                    a[opt.Key] = a[opt.Key] + opt.Value;
                }
                else
                {
                    a[opt.Key] = opt.Value;
                }
            }
        }
        protected static void AddOption(ref Dictionary<IFTYPE, AbilityPerStatus> a, Dictionary<IFTYPE, AbilityPerStatus> b)
        {
            foreach (KeyValuePair<IFTYPE, AbilityPerStatus> opt in b)
            {
                if (a.ContainsKey(opt.Key) == true)
                {
                    a[opt.Key].AddValue += opt.Value.AddValue;
                    a[opt.Key].PerValue += opt.Value.PerValue;
                    a[opt.Key].IfType = opt.Value.IfType;
                }
                else
                {
                    a[opt.Key] = opt.Value;
                }
            }
        }



        ITEM_TYPE_ENUM _item_type;
        EQUIP_TYPE_ENUM _equip_type;
        WEAPON_TYPE _weapon_type = WEAPON_TYPE.HAND;
        protected int _id;
        protected string _name;
        protected int _level_limit;
        protected int _smelt;
        protected int _card_slot;
        protected int _enchant_slot;
        protected ELEMENT_TYPE _attacker_element;
        protected ELEMENT_TYPE _defenser_element;
        public List<JOB_SELECT_LIST> _wear_job_limit = new List<JOB_SELECT_LIST>();
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

        #region property
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
        public int LevelLimit
        {
            get { return _level_limit; }
            set { _level_limit = value; }
        }
        public int Smelt
        {
            get { return _smelt; }
            set { _smelt = value; }
        }
        public int CardSlot
        {
            get { return _card_slot; }
            set { _card_slot = value; }
        }
        public int EnchantSlot
        {
            get { return _enchant_slot; }
            set { _enchant_slot = value; }
        }
        public ELEMENT_TYPE AttackerElement
        {
            get { return _attacker_element; }
            set { _attacker_element = value; }
        }
        public ELEMENT_TYPE DefenserElement
        {
            get { return _defenser_element; }
            set { _defenser_element = value; }
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
        public WEAPON_TYPE Weapon_type
        {
            get { return _weapon_type; }
            set { _weapon_type = value; }
        }
        public List<JOB_SELECT_LIST> Wear_job_limit
        {
            get { return _wear_job_limit; }
            set { _wear_job_limit = value; }
        }
        public Dictionary<ITYPE, int> I_OPTION
        {
            get { return i_option; }
            set { i_option = value; }
        }
        public Dictionary<DTYPE, double> D_OPTION
        {
            get { return d_option; }
            set { d_option = value; }
        }
        public Dictionary<STATUS_EFFECT_TYPE, double> SE_OPTION
        {
            get { return se_option; }
            set { se_option = value; }
        }
        public Dictionary<IFTYPE, AbilityPerStatus> IF_OPTION
        {
            get { return if_option; }
            set { if_option = value; }
        }
        public Dictionary<ELEMENT_TYPE, double> ELEMENT_INC_OPTION
        {
            get { return element_inc_option; }
            set { element_inc_option = value; }
        }
        public Dictionary<MONSTER_SIZE, double> SIZE_INC_OPTION
        {
            get { return size_inc_option; }
            set { size_inc_option = value; }
        }
        public Dictionary<TRIBE_TYPE, double> TRIBE_INC_OPTION
        {
            get { return tribe_inc_option; }
            set { tribe_inc_option = value; }
        }
        public Dictionary<MONSTER_TYPE, double> MOBTYPE_INC_OPTION
        {
            get { return mobtype_inc_option; }
            set { mobtype_inc_option = value; }
        }
        public Dictionary<ELEMENT_TYPE, double> ELEMENT_DEC_OPTION
        {
            get { return element_dec_option; }
            set { element_dec_option = value; }
        }
        public Dictionary<MONSTER_SIZE, double> SIZE_DEC_OPTION
        {
            get { return size_dec_option; }
            set { size_dec_option = value; }
        }
        public Dictionary<TRIBE_TYPE, double> TRIBE_DEC_OPTION
        {
            get { return tribe_dec_option; }
            set { tribe_dec_option = value; }
        }
        public Dictionary<MONSTER_TYPE, double> MOBTYPE_DEC_OPTION
        {
            get { return mobtype_dec_option; }
            set { mobtype_dec_option = value; }
        }
        #endregion
    }

    public class AbilityPerStatus
    {
        public delegate int CalcFunc(int value);
        public int AddValue;
        public int PerValue;
        public IFTYPE IfType;
        CalcFunc Calc;

        public AbilityPerStatus(IFTYPE iftype, int add_value, int per_value)
        {
            AddValue = add_value;
            PerValue = per_value;
            IfType = iftype;
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
