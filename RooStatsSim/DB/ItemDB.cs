
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Text.Json.Serialization;

using RooStatsSim.DB;
using RooStatsSim.User;
using RooStatsSim.DB.Table;

namespace RooStatsSim.DB
{
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

            Option = new Dictionary<ITEM_OPTION_TYPE, Dictionary<string, double>>(item_db.Option);
        }
        public ItemDB() { }

        public static ItemDB operator +(ItemDB a, ItemDB b)
        {
            foreach(KeyValuePair<ITEM_OPTION_TYPE, Dictionary<string, double>> item_option in b.Option)
            {
                if (a.Option.ContainsKey(item_option.Key) == true)
                {
                    foreach(KeyValuePair<string, double> detail_option in item_option.Value)
                    {
                        if (a.Option[item_option.Key].ContainsKey(detail_option.Key) == true)
                        {
                            a.Option[item_option.Key][detail_option.Key] += detail_option.Value;
                        }
                        else
                            a.Option[item_option.Key][detail_option.Key] = detail_option.Value;
                    }
                }
                else
                {
                    a.Option[item_option.Key] = item_option.Value;
                }
            }
            AddOption(ref a.if_option, b.if_option);
            return a;
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

        protected Dictionary<ITEM_OPTION_TYPE, Dictionary<string, double>> _option;
        public Dictionary<IFTYPE, AbilityPerStatus> if_option = new Dictionary<IFTYPE, AbilityPerStatus>();


        #region Property
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
        public Dictionary<ITEM_OPTION_TYPE, Dictionary<string,double>> Option
        {
            get
            {
                if (_option == null)
                    _option = new Dictionary<ITEM_OPTION_TYPE, Dictionary<string, double>>();
                return _option;
            }
            set { _option = value; }
        }
        public Dictionary<IFTYPE, AbilityPerStatus> IF_OPTION
        {
            get { return if_option; }
            set { if_option = value; }
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
        #endregion

        #region ShortCut OptionAccess
        [JsonIgnore] public Dictionary<string, double> Option_ITYPE
        {
            get {
                if (!Option.ContainsKey(ITEM_OPTION_TYPE.ITYPE))
                    Option.Add(ITEM_OPTION_TYPE.ITYPE, new Dictionary<string, double>());
                return Option[ITEM_OPTION_TYPE.ITYPE]; 
            }
            set
            {
                Option[ITEM_OPTION_TYPE.ITYPE] = value;
            }
        }
        [JsonIgnore] public Dictionary<string, double> Option_DTYPE
        {
            get {
                if (!Option.ContainsKey(ITEM_OPTION_TYPE.DTYPE))
                    Option.Add(ITEM_OPTION_TYPE.DTYPE, new Dictionary<string, double>());
                return Option[ITEM_OPTION_TYPE.DTYPE]; 
            }
            set
            {
                Option[ITEM_OPTION_TYPE.DTYPE] = value;
            }
        }
        [JsonIgnore] public Dictionary<string, double> Option_SE_ATK_RATE_TYPE
        {
            get {
                if (!Option.ContainsKey(ITEM_OPTION_TYPE.SE_ATK_RATE_TYPE))
                    Option.Add(ITEM_OPTION_TYPE.SE_ATK_RATE_TYPE, new Dictionary<string, double>());
                return Option[ITEM_OPTION_TYPE.SE_ATK_RATE_TYPE]; 
            }
            set
            {
                Option[ITEM_OPTION_TYPE.SE_ATK_RATE_TYPE] = value;
            }
        }
        [JsonIgnore] public Dictionary<string, double> Option_SE_REG_RATE_TYPE
        {
            get {
                if (!Option.ContainsKey(ITEM_OPTION_TYPE.SE_REG_RATE_TYPE))
                    Option.Add(ITEM_OPTION_TYPE.SE_REG_RATE_TYPE, new Dictionary<string, double>());
                return Option[ITEM_OPTION_TYPE.SE_REG_RATE_TYPE]; 
            }
            set
            {
                Option[ITEM_OPTION_TYPE.SE_REG_RATE_TYPE] = value;
            }
        }
        [JsonIgnore] public Dictionary<string, double> Option_TRIBE_DMG_TYPE
        {
            get {
                if (!Option.ContainsKey(ITEM_OPTION_TYPE.TRIBE_DMG_TYPE))
                    Option.Add(ITEM_OPTION_TYPE.TRIBE_DMG_TYPE, new Dictionary<string, double>());
                return Option[ITEM_OPTION_TYPE.TRIBE_DMG_TYPE]; 
            }
            set
            {
                Option[ITEM_OPTION_TYPE.TRIBE_DMG_TYPE] = value;
            }
        }
        [JsonIgnore] public Dictionary<string, double> Option_TRIBE_REG_TYPE
        {
            get {
                if (!Option.ContainsKey(ITEM_OPTION_TYPE.TRIBE_REG_TYPE))
                    Option.Add(ITEM_OPTION_TYPE.TRIBE_REG_TYPE, new Dictionary<string, double>());
                return Option[ITEM_OPTION_TYPE.TRIBE_REG_TYPE]; 
            }
            set
            {
                Option[ITEM_OPTION_TYPE.TRIBE_REG_TYPE] = value;
            }
        }
        [JsonIgnore] public Dictionary<string, double> Option_MONSTER_KINDS_DMG_TYPE
        {
            get {
                if (!Option.ContainsKey(ITEM_OPTION_TYPE.MONSTER_KINDS_DMG_TYPE))
                    Option.Add(ITEM_OPTION_TYPE.MONSTER_KINDS_DMG_TYPE, new Dictionary<string, double>());
                return Option[ITEM_OPTION_TYPE.MONSTER_KINDS_DMG_TYPE]; 
            }
            set
            {
                Option[ITEM_OPTION_TYPE.MONSTER_KINDS_DMG_TYPE] = value;
            }
        }
        [JsonIgnore] public Dictionary<string, double> Option_MONSTER_KINDS_REG_TYPE
        {
            get {
                if (!Option.ContainsKey(ITEM_OPTION_TYPE.MONSTER_KINDS_REG_TYPE))
                    Option.Add(ITEM_OPTION_TYPE.MONSTER_KINDS_REG_TYPE, new Dictionary<string, double>());
                return Option[ITEM_OPTION_TYPE.MONSTER_KINDS_REG_TYPE]; 
            }
            set
            {
                Option[ITEM_OPTION_TYPE.MONSTER_KINDS_REG_TYPE] = value;
            }
        }
        [JsonIgnore] public Dictionary<string, double> Option_MONSTER_SIZE_DMG_TYPE
        {
            get {
                if (!Option.ContainsKey(ITEM_OPTION_TYPE.MONSTER_SIZE_DMG_TYPE))
                    Option.Add(ITEM_OPTION_TYPE.MONSTER_SIZE_DMG_TYPE, new Dictionary<string, double>());
                return Option[ITEM_OPTION_TYPE.MONSTER_SIZE_DMG_TYPE]; 
            }
            set
            {
                Option[ITEM_OPTION_TYPE.MONSTER_SIZE_DMG_TYPE] = value;
            }
        }
        [JsonIgnore] public Dictionary<string, double> Option_MONSTER_SIZE_REG_TYPE
        {
            get {
                if (!Option.ContainsKey(ITEM_OPTION_TYPE.MONSTER_SIZE_REG_TYPE))
                    Option.Add(ITEM_OPTION_TYPE.MONSTER_SIZE_REG_TYPE, new Dictionary<string, double>());
                return Option[ITEM_OPTION_TYPE.MONSTER_SIZE_REG_TYPE]; 
            }
            set
            {
                Option[ITEM_OPTION_TYPE.MONSTER_SIZE_REG_TYPE] = value;
            }
        }
        [JsonIgnore] public Dictionary<string, double> Option_MONSTER_ELEMENT_DMG_TYPE
        {
            get {
                if (!Option.ContainsKey(ITEM_OPTION_TYPE.MONSTER_ELEMENT_DMG_TYPE))
                    Option.Add(ITEM_OPTION_TYPE.MONSTER_ELEMENT_DMG_TYPE, new Dictionary<string, double>());
                return Option[ITEM_OPTION_TYPE.MONSTER_ELEMENT_DMG_TYPE]; 
            }
            set
            {
                Option[ITEM_OPTION_TYPE.MONSTER_ELEMENT_DMG_TYPE] = value;
            }
        }
        [JsonIgnore] public Dictionary<string, double> Option_ELEMENT_DMG_TYPE
        {
            get {
                if (!Option.ContainsKey(ITEM_OPTION_TYPE.ELEMENT_DMG_TYPE))
                    Option.Add(ITEM_OPTION_TYPE.ELEMENT_DMG_TYPE, new Dictionary<string, double>());
                return Option[ITEM_OPTION_TYPE.ELEMENT_DMG_TYPE]; 
            }
            set
            {
                Option[ITEM_OPTION_TYPE.ELEMENT_DMG_TYPE] = value;
            }
        }
        [JsonIgnore] public Dictionary<string, double> Option_ELEMENT_REG_TYPE
        {
            get {
                if (!Option.ContainsKey(ITEM_OPTION_TYPE.ELEMENT_REG_TYPE))
                    Option.Add(ITEM_OPTION_TYPE.ELEMENT_REG_TYPE, new Dictionary<string, double>());
                return Option[ITEM_OPTION_TYPE.ELEMENT_REG_TYPE]; 
            }
            set
            {
                Option[ITEM_OPTION_TYPE.ELEMENT_REG_TYPE] = value;
            }
        }
        [JsonIgnore] public Dictionary<string, double> Option_ETC_TYPE
        {
            get {
                if (!Option.ContainsKey(ITEM_OPTION_TYPE.ETC_TYPE))
                    Option.Add(ITEM_OPTION_TYPE.ETC_TYPE, new Dictionary<string, double>());
                return Option[ITEM_OPTION_TYPE.ETC_TYPE]; 
            }
            set
            {
                Option[ITEM_OPTION_TYPE.ETC_TYPE] = value;
            }
        }
        [JsonIgnore] public Dictionary<string, double> Option_ETC_DMG_TYPE
        {
            get {
                if (!Option.ContainsKey(ITEM_OPTION_TYPE.ETC_DMG_TYPE))
                    Option.Add(ITEM_OPTION_TYPE.ETC_DMG_TYPE, new Dictionary<string, double>());
                return Option[ITEM_OPTION_TYPE.ETC_DMG_TYPE]; 
            }
            set
            {
                Option[ITEM_OPTION_TYPE.ETC_DMG_TYPE] = value;
            }
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
            item.Option[ITEM_OPTION_TYPE.ITYPE].Add(Enum.GetName(typeof(ITYPE), ITYPE.ATK), (int)(user.Status.GetStatus(STATUS_ENUM.STR) / PerValue) * AddValue);
            return item;
        }
        public ItemDB ATK_PER_AGI(UserData user)
        {
            ItemDB item = new ItemDB();
            item.Option[ITEM_OPTION_TYPE.ITYPE].Add(Enum.GetName(typeof(ITYPE), ITYPE.ATK), (int)(user.Status.GetStatus(STATUS_ENUM.AGI) / PerValue) * AddValue);
            return item;
        }
        public ItemDB HP_PER_VIT(UserData user)
        {
            ItemDB item = new ItemDB();
            item.Option[ITEM_OPTION_TYPE.ITYPE].Add(Enum.GetName(typeof(ITYPE), ITYPE.HP), (int)(user.Status.GetStatus(STATUS_ENUM.VIT) / PerValue) * AddValue);
            return item;
        }
        public ItemDB MATK_PER_INT(UserData user)
        {
            ItemDB item = new ItemDB();
            item.Option[ITEM_OPTION_TYPE.ITYPE].Add(Enum.GetName(typeof(ITYPE), ITYPE.MATK), (int)(user.Status.GetStatus(STATUS_ENUM.INT) / PerValue) * AddValue);
            return item;
        }
        public ItemDB ASPD_PER_AGI(UserData user)
        {
            ItemDB item = new ItemDB();
            item.Option[ITEM_OPTION_TYPE.DTYPE].Add(Enum.GetName(typeof(DTYPE), DTYPE.ASPD), (int)(user.Status.GetStatus(STATUS_ENUM.AGI) / PerValue) * AddValue);
            return item;
        }
        public ItemDB PHYSICAL_DAMAGE_PER_HIT(UserData user)
        {
            ItemDB item = new ItemDB();
            int hit = Convert.ToInt32(user.User_Item.Option[ITEM_OPTION_TYPE.ITYPE][Enum.GetName(typeof(ITYPE), ITYPE.HIT)]);
            double physical_damage = hit / PerValue * AddValue;
            item.Option[ITEM_OPTION_TYPE.DTYPE].Add(Enum.GetName(typeof(DTYPE), DTYPE.PHYSICAL_DAMAGE), physical_damage);
            return item;
        }
        public ItemDB ADDITIONAL_PHYSICAL_DAMAGE_PER_FIXED(UserData user)
        {
            ItemDB item = new ItemDB();
            int physical_damage_add = 1;        //실험필요
            item.Option[ITEM_OPTION_TYPE.ITYPE].Add(Enum.GetName(typeof(ITYPE), ITYPE.PHYSICAL_DAMAGE_ADDITIONAL), physical_damage_add);
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
                item.Option[ITEM_OPTION_TYPE.ITYPE].Add(Enum.GetName(typeof(ITYPE), ITYPE.ATK), AddValue);
            return item;
        }
        #endregion

        #region REFINE(SMELTING) CALC
        public ItemDB HP_PER_REFINE(UserData user, int refine)
        {
            ItemDB item = new ItemDB();
            item.Option[ITEM_OPTION_TYPE.ITYPE].Add(Enum.GetName(typeof(ITYPE), ITYPE.HP), (int)(user.Status.GetStatus(STATUS_ENUM.VIT) / PerValue) * AddValue);
            int hp = Convert.ToInt32(user.User_Item.Option[ITEM_OPTION_TYPE.ITYPE][Enum.GetName(typeof(ITYPE), ITYPE.HP)]) * AddValue / (refine / PerValue);
            item.Option[ITEM_OPTION_TYPE.ITYPE].Add(Enum.GetName(typeof(ITYPE), ITYPE.HP), hp);
            return item;
        }
        public ItemDB ELEMENT_DAMAGE_PER_REFINE(UserData user, int refine)
        {
            ItemDB item = new ItemDB();
            double element_damage = AddValue / (refine / PerValue);
            item.Option[ITEM_OPTION_TYPE.ELEMENT_DMG_TYPE].Add(Enum.GetName(typeof(ELEMENT_DMG_TYPE), (ELEMENT_DMG_TYPE)Selected), element_damage);
            return item;
        }
        #endregion
    }
}
