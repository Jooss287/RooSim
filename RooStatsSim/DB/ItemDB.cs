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
        public ItemDB() { Option_Refine.Add(0, Option); }
        public ItemDB(ItemDB item_db)
        {
            Id = item_db.Id;
            Name = item_db.Name;
            ImageName = item_db.ImageName;
            SetName = item_db.SetName;
            LevelLimit = item_db.LevelLimit;
            Item_type = item_db.Item_type;
            Equip_type = item_db.Equip_type;
            Smelt = item_db.Smelt;
            CardSlot = item_db.CardSlot;
            EnchantSlot = item_db.EnchantSlot;
            Weight = item_db.Weight;

            
            Wear_job_limit = new List<JOB_SELECT_LIST>(item_db.Wear_job_limit);
            SetPosition = new List<EQUIP_TYPE_ENUM>(item_db.SetPosition);

            Option_IF_TYPE = new List<AbilityPerStatus>(item_db.Option_IF_TYPE);
            Option_ITYPE = new Dictionary<string, double>(item_db.Option_ITYPE);
            Option_DTYPE = new Dictionary<string, double>(item_db.Option_DTYPE);
            Option_SE_ATK_RATE_TYPE = new Dictionary<string, double>(item_db.Option_SE_ATK_RATE_TYPE);
            Option_SE_REG_RATE_TYPE = new Dictionary<string, double>(item_db.Option_SE_REG_RATE_TYPE);
            Option_ELEMENT_DMG_TYPE = new Dictionary<string, double>(item_db.Option_ELEMENT_DMG_TYPE);
            Option_ELEMENT_REG_TYPE = new Dictionary<string, double>(item_db.Option_ELEMENT_REG_TYPE);
            Option_MONSTER_ELEMENT_DMG_TYPE = new Dictionary<string, double>(item_db.Option_MONSTER_ELEMENT_DMG_TYPE);
            Option_MONSTER_KINDS_DMG_TYPE = new Dictionary<string, double>(item_db.Option_MONSTER_KINDS_DMG_TYPE);
            Option_MONSTER_KINDS_REG_TYPE = new Dictionary<string, double>(item_db.Option_MONSTER_KINDS_REG_TYPE);
            Option_MONSTER_SIZE_DMG_TYPE = new Dictionary<string, double>(item_db.Option_MONSTER_SIZE_DMG_TYPE);
            Option_MONSTER_SIZE_REG_TYPE = new Dictionary<string, double>(item_db.Option_MONSTER_SIZE_REG_TYPE);
            Option_TRIBE_DMG_TYPE = new Dictionary<string, double>(item_db.Option_TRIBE_DMG_TYPE);
            Option_TRIBE_REG_TYPE = new Dictionary<string, double>(item_db.Option_TRIBE_REG_TYPE);
            Option_ETC_DMG_TYPE = new Dictionary<string, double>(item_db.Option_ETC_DMG_TYPE);
            Option_ETC_TYPE = new Dictionary<string, double>(item_db.Option_ETC_TYPE);
            Option_SKILL_DMG_TYPE = new Dictionary<string, double>(item_db.Option_SKILL_DMG_TYPE);

            Option_Refine[0] = Option;
            foreach(KeyValuePair<int, Dictionary<ITEM_OPTION_TYPE, Dictionary<string, double>>> option in item_db.Option_Refine)
            {
                Option_Refine[option.Key] = new Dictionary<ITEM_OPTION_TYPE, Dictionary<string, double>>();
                foreach(KeyValuePair<ITEM_OPTION_TYPE, Dictionary<string, double>> item_option in option.Value)
                {
                    Option_Refine[option.Key].Add(item_option.Key, new Dictionary<string, double>(item_option.Value));
                }
            }
        }

        ITEM_TYPE_ENUM _item_type;
        EQUIP_TYPE_ENUM _equip_type;
        WEAPON_TYPE_ENUM _weapon_type = WEAPON_TYPE_ENUM.HAND;
        protected int _id;
        protected string _name;
        protected string _image_name = "";
        protected string _set_name = null;
        protected int _level_limit;
        protected int _smelt;
        protected int _card_slot;
        protected int _enchant_slot;
        protected int _weight;

        protected EQUIP_REFINE_TYPE_ENUM _refine_type;
        protected ELEMENT_TYPE _attacker_element;
        protected ELEMENT_TYPE _defenser_element;
        public List<JOB_SELECT_LIST> _wear_job_limit = new List<JOB_SELECT_LIST>();
        protected List<EQUIP_TYPE_ENUM> _set_pos = new List<EQUIP_TYPE_ENUM>();

        protected Dictionary<ITEM_OPTION_TYPE, Dictionary<string, double>> _option;
        protected List<AbilityPerStatus> _option_if_type;
        protected Dictionary<int, Dictionary<ITEM_OPTION_TYPE, Dictionary<string, double>>> _option_refine;

        #region operator overriding
        public static ItemDB operator +(ItemDB a, ItemDB b)
        {
            AddOption(a.Option, b.Option);

            foreach (AbilityPerStatus ability in b.Option_IF_TYPE)
                a.Option_IF_TYPE.Add(new AbilityPerStatus(ability));
            //foreach (KeyValuePair<int, Dictionary<ITEM_OPTION_TYPE, Dictionary<string, double>>> refine_num in b.Refine_Option)
            //{
            //    if (a.Refine_Option.ContainsKey(refine_num.Key) == false)
            //        a.Refine_Option.Add(refine_num.Key, new Dictionary<ITEM_OPTION_TYPE, Dictionary<string, double>>());
            //    AddOption(a.Refine_Option[refine_num.Key], b.Refine_Option[refine_num.Key]);
            //}
            return a;
        }
        public static void AddOption(Dictionary<ITEM_OPTION_TYPE, Dictionary<string, double>> A, Dictionary<ITEM_OPTION_TYPE, Dictionary<string, double>> B)
        {
            foreach (KeyValuePair<ITEM_OPTION_TYPE, Dictionary<string, double>> item_option in B)
            {
                if (A.ContainsKey(item_option.Key) == true)  //A, B 모두 존재
                {
                    foreach (KeyValuePair<string, double> detail_option in item_option.Value)
                    {
                        if (A[item_option.Key].ContainsKey(detail_option.Key) == true)
                        {
                            A[item_option.Key][detail_option.Key] += detail_option.Value;
                        }
                        else
                        {
                            A[item_option.Key].Add(detail_option.Key, detail_option.Value);
                        }

                    }
                }
                else                                                //B에만 존재
                {
                    A.Add(item_option.Key, new Dictionary<string, double>());
                    foreach (KeyValuePair<string, double> detail_option in item_option.Value)
                    {
                        A[item_option.Key].Add(detail_option.Key, detail_option.Value);
                    }
                }
            }
        }
        #endregion
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
        public string ImageName
        {
            get { return _image_name; }
            set { _image_name = value; }
        }
        public string SetName
        {
            get { return _set_name; }
            set { _set_name = value; }
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
        public int Weight
        {
            get { return _weight; }
            set { _weight = value; }
        }
        public EQUIP_REFINE_TYPE_ENUM RefineType
        {
            get { return _refine_type; }
            set { _refine_type = value; }
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
        public List<EQUIP_TYPE_ENUM> SetPosition
        {
            get { return _set_pos; }
            set { _set_pos = value; }
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
        public List<AbilityPerStatus> Option_IF_TYPE
        {
            get 
            {
                if (_option_if_type == null)
                    _option_if_type = new List<AbilityPerStatus>();
                return _option_if_type; 
            }
            set { _option_if_type = value; }
        }
        public Dictionary<int, Dictionary<ITEM_OPTION_TYPE, Dictionary<string, double>>> Option_Refine
        {
            get {
                if (_option_refine == null)
                    _option_refine = new Dictionary<int, Dictionary<ITEM_OPTION_TYPE, Dictionary<string, double>>>();
                return _option_refine; 
            }
            set { _option_refine = value; }
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
        [JsonIgnore] public Dictionary<string, double> Option_SKILL_DMG_TYPE
        {
            get
            {
                if (!Option.ContainsKey(ITEM_OPTION_TYPE.SKILL_DMG_TYPE))
                    Option.Add(ITEM_OPTION_TYPE.SKILL_DMG_TYPE, new Dictionary<string, double>());
                return Option[ITEM_OPTION_TYPE.SKILL_DMG_TYPE];
            }
            set
            {
                Option[ITEM_OPTION_TYPE.SKILL_DMG_TYPE] = value;
            }
        }
        #endregion
    }
    
    [Serializable]
    public class AbilityPerStatus
    {
        public string PerType { get; set; }
        public string AddType { get; set; }
        public double PerValue { get; set; }
        public double AddValue { get; set; }
        public double MaxValue { get; set; }

        public AbilityPerStatus() { }
        public AbilityPerStatus(string per_type, double per_value, string add_type, double add_value, double max_value = 0)
        {
            PerType = per_type;
            PerValue = per_value;
            AddType = add_type;
            AddValue = add_value;
            MaxValue = max_value;
        }
        public AbilityPerStatus(AbilityPerStatus ability)
        {
            PerType = ability.PerType;
            PerValue = ability.PerValue;
            AddType = ability.AddType;
            AddValue = ability.AddValue;
            MaxValue = ability.MaxValue;
        }

        public ItemDB GetRefineOption(int Refine)
        {
            ItemDB db = new ItemDB();
            if (PerType != Enum.GetName(typeof(REFINE_TYPE), REFINE_TYPE.REFINE))
                return db;

            double add_value = AddValue * Refine / PerValue;
            if ((add_value >= MaxValue) && (MaxValue != 0)) add_value = MaxValue;
            db.Option[EnumItemOptionTable.GET_ITEM_OPTION_TYPE(AddType)][AddType] = add_value;

            return db;
        }
    }
}
