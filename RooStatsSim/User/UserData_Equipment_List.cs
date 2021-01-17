using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Text.Json.Serialization;
using System.Windows.Media;
using MaterialDesignThemes.Wpf;
using RooStatsSim.DB;
using RooStatsSim.DB.Table;
using RooStatsSim.UI.Equipment;



namespace RooStatsSim.User
{
    [Serializable]
    public class EQUIP
    {
        [Serializable]
        public class EquipItem
        {
            public EQUIP_TYPE_ENUM EquipType { get; set; }
            public int LastCardSetSlot { get; set; }
            public int LastEnchantSlot { get; set; }

            int _equip;
            List<int> _cards;
            List<int> _enchant;

            [JsonIgnore] public ItemDB EquipInfo { get; set; }
            //[JsonIgnore] Dictionary<ItemDB> CardInfo { get; set; }

            int _refine;
            public int Refine
            {
                get { return _refine; }
                set { _refine = value; }
            }
            public int Equip
            {
                get { return _equip; }
                set { _equip = value; EquipInfo = MainWindow._roo_db.Equip_db[(int)EnumBaseTable_Kor.EQUIP_TYPE_TO_DB_ENUM[EquipType]][Equip]; }
            }
            
            public List<int> Card
            {
                get {
                    if (_cards == null)
                        _cards = new List<int>();
                    return _cards;
                }
                set { _cards = value; }
            }
            public List<int> Enchant
            {
                get {
                    if (_enchant == null)
                        _enchant = new List<int>();
                    return _enchant;
                }
                set { _enchant = value; }
            }

            public void AddCard(int input_card)
            {
                ItemDB item = MainWindow._roo_db.Equip_db[(int)EnumBaseTable_Kor.EQUIP_TYPE_TO_DB_ENUM[EquipType]][Equip];
                if (item.CardSlot == 0)
                    return;
                if (Card.Count < item.CardSlot)
                    Card.Add(input_card);
                else
                {
                    if (LastCardSetSlot - 1 <= item.CardSlot)
                        LastCardSetSlot = 0;
                    Card[LastCardSetSlot] = input_card;
                }
            }
            public ItemDB GetRefineOption()
            {
                ItemDB db = null;
                CalcRefineOption(ref db, EquipInfo);
                foreach(int card_id in Card)
                {
                    ItemDB item = MainWindow._roo_db.Card_db[card_id];
                    CalcRefineOption(ref db, item);
                }
                return db;
            }
            void CalcRefineOption(ref ItemDB db, ItemDB item_db)
            {
                foreach (KeyValuePair<int, Dictionary<ITEM_OPTION_TYPE, Dictionary<string, double>>> keyValue in item_db.Option_Refine)
                {
                    if (Refine >= keyValue.Key)
                    {
                        if (db == null)
                            db = new ItemDB();
                        ItemDB.AddOption(db.Option, keyValue.Value);
                    }
                }
                foreach (AbilityPerStatus ability in item_db.Option_IF_TYPE)
                {
                    if (db == null)
                        db = new ItemDB();
                    db += ability.GetRefineOption(Refine);
                }
                if ( Refine > 0 )
                {
                    if (db == null)
                        db = new ItemDB();
                    db += RefineTable.GetRefineOption(REFINE_OPTION_TYPE.COMMON, Refine);
                }
            }
        }
        
        public Dictionary<EQUIP_TYPE_ENUM, EquipItem> Dic { get; set; }
        public EQUIP()
        {
            Dic = new Dictionary<EQUIP_TYPE_ENUM, EquipItem>();
            
            //foreach (EQUIP_TYPE_ENUM equip_type in Enum.GetValues(typeof(EQUIP_TYPE_ENUM)))
            //{
            //    Dic[equip_type] = new EquipItem();
            //}
        }

        public UserItem GetOption()
        {
            UserItem option = new UserItem();
            List<string> set_name = new List<string>();
            foreach (KeyValuePair<EQUIP_TYPE_ENUM, EquipItem> equipment in Dic)
            {
                if (equipment.Value == null)
                    continue;
                foreach (int card_id in equipment.Value.Card)
                    option += MainWindow._roo_db.Card_db[card_id];
                foreach (int enchant_id in equipment.Value.Enchant)
                    option += MainWindow._roo_db.Card_db[enchant_id];
                option += equipment.Value.EquipInfo;
                option += equipment.Value.GetRefineOption();

                if (equipment.Value.EquipInfo != null)
                    set_name.Add(equipment.Value.EquipInfo.SetName);
            }

            // 세트 아이템 효과 적용
            set_name = set_name.Distinct().ToList();
            foreach (string set in set_name)
            {
                bool set_access = true;
                ItemDB set_item = MainWindow._roo_db.Set_Equip_db.FirstOrDefault(x => x.Value.SetName == set).Value;
                if (set_item == null)
                    continue;
                foreach(EQUIP_TYPE_ENUM type in set_item.SetPosition)
                {
                    if ( Dic[type].EquipInfo.SetName != set)
                    {
                        set_access = false;
                        break;
                    }
                }
                if (set_access)
                    option += set_item;
            }

            return option;
        }
    }

    [Serializable]
    public class GEAR
    {
        public ObservableCollection<ItemDB> List { get; }
        public GEAR()
        {
            List = new ObservableCollection<ItemDB>();
            List.CollectionChanged += OnListChanged;

            foreach (string equip_type in Enum.GetNames(typeof(EQUIP_TYPE_ENUM)))
            {
                List.Add(new ItemDB());
            }
        }
        private void OnListChanged(object sender, NotifyCollectionChangedEventArgs args)
        {
            //if (Convert.ToInt32(args.NewItems[0]) < 0)
            //{
            //    List[args.NewStartingIndex] = Convert.ToInt32(args.OldItems[0]);
            //}
        }
    }
}
