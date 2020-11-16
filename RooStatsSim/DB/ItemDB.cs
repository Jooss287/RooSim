
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

using RooStatsSim.DB;
using RooStatsSim.User;

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
        MELEE_PHYSICAL_DEC_DAMAGE,
        RANGE_PHYSICAL_DEC_DAMAGE,
        MAX_HP_P = 3000,
        MAX_SP_P,
        SP_WASTE,
        ASPD = 6000,    //기타 관련 스텟
        MOVING_SPEED,
        HEALING,
        HEALING_RECERIVED,
        VERIABLE_CASTING,
        FIXED_CASTING,
        COMMON_SKILL_DELAY,
    }
    public enum IFTYPE
    {
        ATK_PER_STR,
        ATK_PER_AGI,
        HP_PER_VIT,
        MATK_PER_INT,
        ASPD_PER_AGI,
        PHYSICAL_DAMAGE_PER_HIT,
        ADDITIONAL_PHYSICAL_DAMAGE_PER_FIXED,
        
        //REFINE 관련
        HP_PER_REFINE = 1000,
        
        //TRIBE 관련
        CRI_TO_TRIBE = 2000,

        //SIMPLE IF
        ATK_MORETHAN_STR,
    }
    public enum STATUS_EFFECT_TYPE
    {
        STERN,
        FEAR,
        SILENCE,
        FROZEN,
        CURSE,
        PETRIFICATION,
        DARK,
        POISON,
        SLEEP
    }
    public enum ETC_TYPE
    {
        NO_SIZE_PANELTY,
        NO_BREAK,
    }
    public enum ETC_INC_DAMAGE_TYPE
    {
        OAK_INC_DAMAGE,
        KOBOLD_INC_DAMAGE,
        GOBLIN_INC_DAMAGE,
        ALL_MONSTERS_DAMAGE,
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
            if_option = new Dictionary<IFTYPE, AbilityPerStatus>(item_db.if_option);


            se_attackrate_option = new Dictionary<STATUS_EFFECT_TYPE, double>(item_db.se_attackrate_option);
            se_resistance_option = new Dictionary<STATUS_EFFECT_TYPE, double>(item_db.se_resistance_option);
            element_inc_option = new Dictionary<ELEMENT_TYPE, double>(item_db.element_inc_option);
            element_dec_option = new Dictionary<ELEMENT_TYPE, double>(item_db.element_dec_option);
            element_damage_option = new Dictionary<ELEMENT_TYPE, double>(item_db.element_damage_option);
            size_inc_option = new Dictionary<MONSTER_SIZE, double>(item_db.size_inc_option);
            size_dec_option = new Dictionary<MONSTER_SIZE, double>(item_db.size_dec_option);
            tribe_inc_option = new Dictionary<TRIBE_TYPE, double>(item_db.tribe_inc_option);
            tribe_dec_option = new Dictionary<TRIBE_TYPE, double>(item_db.tribe_dec_option);
            mobtype_inc_option = new Dictionary<MONSTER_TYPE, double>(item_db.mobtype_inc_option);
            mobtype_dec_option = new Dictionary<MONSTER_TYPE, double>(item_db.mobtype_dec_option);
            etc_option = new Dictionary<ETC_TYPE, double>(item_db.etc_option);
            etc_inc_damage_option = new Dictionary<ETC_INC_DAMAGE_TYPE, double>(item_db.etc_inc_damage_option);
        }
        public ItemDB() { }

        public static ItemDB operator +(ItemDB a, ItemDB b)
        {
            AddOption<ITYPE>(ref a.i_option, b.i_option);
            AddOption<DTYPE>(ref a.d_option, b.d_option);
            AddOption(ref a.if_option, b.if_option);
            AddOption<STATUS_EFFECT_TYPE>(ref a.se_attackrate_option, b.se_attackrate_option);
            AddOption<STATUS_EFFECT_TYPE>(ref a.se_resistance_option, b.se_resistance_option);
            AddOption<ELEMENT_TYPE>(ref a.element_inc_option, b.element_inc_option);
            AddOption<ELEMENT_TYPE>(ref a.element_dec_option, b.element_dec_option);
            AddOption<ELEMENT_TYPE>(ref a.element_damage_option, b.element_damage_option);
            AddOption<MONSTER_SIZE>(ref a.size_inc_option, b.size_inc_option);
            AddOption<MONSTER_SIZE>(ref a.size_dec_option, b.size_dec_option);
            AddOption<TRIBE_TYPE>(ref a.tribe_inc_option, b.tribe_inc_option);
            AddOption<TRIBE_TYPE>(ref a.tribe_dec_option, b.tribe_dec_option);
            AddOption<MONSTER_TYPE>(ref a.mobtype_inc_option, b.mobtype_inc_option);
            AddOption<MONSTER_TYPE>(ref a.mobtype_dec_option, b.mobtype_dec_option);
            AddOption<ETC_TYPE>(ref a.etc_option, b.etc_option);
            AddOption<ETC_INC_DAMAGE_TYPE>(ref a.etc_inc_damage_option, b.etc_inc_damage_option);
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
                    a[opt.Key].PerValue = opt.Value.PerValue;
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
        WEAPON_TYPE_ENUM _weapon_type = WEAPON_TYPE_ENUM.HAND;
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
        public Dictionary<IFTYPE, AbilityPerStatus> if_option = new Dictionary<IFTYPE, AbilityPerStatus>();

        public Dictionary<STATUS_EFFECT_TYPE, double> se_attackrate_option = new Dictionary<STATUS_EFFECT_TYPE, double>();
        public Dictionary<STATUS_EFFECT_TYPE, double> se_resistance_option = new Dictionary<STATUS_EFFECT_TYPE, double>();

        public Dictionary<ELEMENT_TYPE, double> element_inc_option = new Dictionary<ELEMENT_TYPE, double>();
        public Dictionary<ELEMENT_TYPE, double> element_dec_option = new Dictionary<ELEMENT_TYPE, double>();
        public Dictionary<ELEMENT_TYPE, double> element_damage_option = new Dictionary<ELEMENT_TYPE, double>();

        public Dictionary<MONSTER_SIZE, double> size_inc_option = new Dictionary<MONSTER_SIZE, double>();
        public Dictionary<MONSTER_SIZE, double> size_dec_option = new Dictionary<MONSTER_SIZE, double>();
        public Dictionary<TRIBE_TYPE, double> tribe_inc_option = new Dictionary<TRIBE_TYPE, double>();
        public Dictionary<TRIBE_TYPE, double> tribe_dec_option = new Dictionary<TRIBE_TYPE, double>();
        public Dictionary<MONSTER_TYPE, double> mobtype_inc_option = new Dictionary<MONSTER_TYPE, double>();
        public Dictionary<MONSTER_TYPE, double> mobtype_dec_option = new Dictionary<MONSTER_TYPE, double>();

        public Dictionary<ETC_TYPE, double> etc_option = new Dictionary<ETC_TYPE, double>();
        public Dictionary<ETC_INC_DAMAGE_TYPE, double> etc_inc_damage_option = new Dictionary<ETC_INC_DAMAGE_TYPE, double>();

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
        public WEAPON_TYPE_ENUM Weapon_type
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
        public Dictionary<IFTYPE, AbilityPerStatus> IF_OPTION
        {
            get { return if_option; }
            set { if_option = value; }
        }

        public Dictionary<STATUS_EFFECT_TYPE, double> SE_ATTACKRATE_OPTION
        {
            get { return se_attackrate_option; }
            set { se_attackrate_option = value; }
        }
        public Dictionary<STATUS_EFFECT_TYPE, double> SE_REGISTANCE_OPTION
        {
            get { return se_resistance_option; }
            set { se_resistance_option = value; }
        }
        public Dictionary<ELEMENT_TYPE, double> ELEMENT_INC_OPTION
        {
            get { return element_inc_option; }
            set { element_inc_option = value; }
        }
        public Dictionary<ELEMENT_TYPE, double> ELEMENT_DAMAGE_OPTION
        {
            get { return element_damage_option; }
            set { element_damage_option = value; }
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
        public Dictionary<ETC_TYPE, double> ETC_OPTION
        {
            get { return etc_option; }
            set { etc_option = value; }
        }
        public Dictionary<ETC_INC_DAMAGE_TYPE, double> ETC_INC_DAMAGE_OPTION
        {
            get { return etc_inc_damage_option; }
            set { etc_inc_damage_option = value; }
        }
        #endregion
    }

    public class AbilityPerStatus
    {
        public delegate ItemDB CalcFunc(UserData user);
        public delegate ItemDB CalcRefine(UserData user, int refine);
        public int AddValue;
        public int PerValue;
        public int Selected;
        public IFTYPE IfType;
        public CalcFunc Calc;
        public CalcRefine Calc_refine;

        public AbilityPerStatus(IFTYPE iftype, int add_value, int per_value, int selected = 0)
        {
            AddValue = add_value;
            PerValue = per_value;
            Selected = selected;
            IfType = iftype;

            switch (iftype)
            {
                case IFTYPE.ATK_PER_STR:
                    Calc = ATK_PER_STR;
                    break;
                case IFTYPE.HP_PER_REFINE:
                    Calc = null;
                    Calc_refine = HP_PER_REFINE;
                    break;
            }
        }

        #region iftype option equation
        public ItemDB ATK_PER_STR(UserData user)
        {
            ItemDB item = new ItemDB();
            item.i_option.Add(ITYPE.STR, (int)(user.Status.GetStatus(STATUS_ENUM.STR) / PerValue) * AddValue);
            return item;
        }
        public ItemDB ATK_PER_AGI(UserData user)
        {
            ItemDB item = new ItemDB();
            item.i_option.Add(ITYPE.STR, (int)(user.Status.GetStatus(STATUS_ENUM.AGI) / PerValue) * AddValue);
            return item;
        }
        public ItemDB HP_PER_VIT(UserData user)
        {
            ItemDB item = new ItemDB();
            item.i_option.Add(ITYPE.STR, (int)(user.Status.GetStatus(STATUS_ENUM.VIT) / PerValue) * AddValue);
            return item;
        }
        public ItemDB MATK_PER_INT(UserData user)
        {
            ItemDB item = new ItemDB();
            item.i_option.Add(ITYPE.STR, (int)(user.Status.GetStatus(STATUS_ENUM.INT) / PerValue) * AddValue);
            return item;
        }
        public ItemDB ASPD_PER_AGI(UserData user)
        {
            ItemDB item = new ItemDB();
            item.i_option.Add(ITYPE.STR, (int)(user.Status.GetStatus(STATUS_ENUM.AGI) / PerValue) * AddValue);
            return item;
        }
        public ItemDB PHYSICAL_DAMAGE_PER_HIT(UserData user)
        {
            ItemDB item = new ItemDB();
            double physical_damage = user.User_Item.i_option[ITYPE.HIT] / PerValue * AddValue;
            item.d_option.Add(DTYPE.PHYSICAL_DAMAGE, physical_damage);
            return item;
        }
        public ItemDB ADDITIONAL_PHYSICAL_DAMAGE_PER_FIXED(UserData user)
        {
            ItemDB item = new ItemDB();
            int physical_damage_add = 1;        //실험필요
            item.i_option.Add(ITYPE.PHYSICAL_DAMAGE_ADDITIONAL, physical_damage_add);
            return item;
        }
        public ItemDB CRI_TO_TRIBE(UserData user)
        {
            ItemDB item = new ItemDB();
            int CRI = 1;        //추가필요
            return item;
        }
        public ItemDB ATK_MORETHAN_STR(UserData user)
        {
            ItemDB item = new ItemDB();
            if (user.Status.GetStatus(STATUS_ENUM.STR) >= PerValue)
                item.i_option.Add(ITYPE.ATK, AddValue);
            return item;
        }
        #endregion

        #region REFINE(SMELTING) CALC
        public ItemDB HP_PER_REFINE(UserData user, int refine)
        {
            ItemDB item = new ItemDB();
            int hp = user.User_Item.I_OPTION[ITYPE.HP] * AddValue / (refine / PerValue);
            item.I_OPTION.Add(ITYPE.HP, hp);
            return item;
        }
        public ItemDB ELEMENT_DAMAGE_PER_REFINE(UserData user, int refine)
        {
            ItemDB item = new ItemDB();
            double element_damage = AddValue / (refine / PerValue);
            item.element_damage_option.Add((ELEMENT_TYPE)Selected, element_damage);
            return item;
        }
        #endregion
    }
}
