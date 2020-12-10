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
        public class EquipItem
        {
            int _refine;
            public int LastCardSetSlot { get; set; }
            public int LastEnchantSlot { get; set; }
            public int Refine 
            {
                get { return _refine; }
                set { _refine = value; SetRefineOption(); }
            }
            ItemDB _equip = new ItemDB();
            ItemDB _equip_refine_option;
            List<ItemDB> _cards;
            List<ItemDB> _enchant;

            public ItemDB Equip
            {
                get { return _equip; }
                set { _equip = value; }
            }
            
            public List<ItemDB> Card
            {
                get {
                    if (_cards == null)
                        _cards = new List<ItemDB>();
                    return _cards;
                }
                set { _cards = value; }
            }
            public List<ItemDB> Enchant
            {
                get {
                    if (_enchant == null)
                        _enchant = new List<ItemDB>();
                    return _enchant;
                }
                set { _enchant = value; }
            }
            [JsonIgnore]
            public ItemDB RefineOption
            {
                get { return _equip_refine_option; }
                set { _equip_refine_option = value; }
            }

            public void AddCard(ItemDB input_card)
            {
                if (Equip.CardSlot == 0)
                    return;
                if (Card.Count < Equip.CardSlot)
                    Card.Add(input_card);
                else
                {
                    if (LastCardSetSlot - 1 <= Equip.CardSlot)
                        LastCardSetSlot = 0;
                    Card[LastCardSetSlot] = input_card;
                }
            }
            private void SetRefineOption()
            {
                ItemDB db = null;
                CalcRefineOption(ref db, Equip);
                foreach(ItemDB card in Card)
                {
                    CalcRefineOption(ref db, card);
                }
                _equip_refine_option = db;
            }
            void CalcRefineOption(ref ItemDB db, ItemDB item_db)
            {
                foreach (KeyValuePair<int, Dictionary<ITEM_OPTION_TYPE, Dictionary<string, double>>> keyValue in item_db.Refine_Option)
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
            }
        }
        
        public ObservableCollection<EquipItem> List { get; }
        public EQUIP()
        {
            List = new ObservableCollection<EquipItem>();
            List.CollectionChanged += OnListChanged;

            foreach (string equip_type in Enum.GetNames(typeof(EQUIP_TYPE_ENUM)))
            {
                List.Add(new EquipItem());
            }
        }
        private void OnListChanged(object sender, NotifyCollectionChangedEventArgs args)
        {
            //if (Convert.ToInt32(args.NewItems[0]) < 0)
            //{
            //    List[args.NewStartingIndex] = Convert.ToInt32(args.OldItems[0]);
            //}
        }

        public UserItem GetOption()
        {
            UserItem option = new UserItem();
            List<string> set_name = new List<string>();
            foreach ( EquipItem equipment in List)
            {
                if (equipment.Equip == null)
                    continue;
                foreach (ItemDB card in equipment.Card)
                    option += card;
                foreach (ItemDB enchant in equipment.Enchant)
                    option += enchant;
                option += equipment.Equip;

                if (equipment.Equip.SetName != null)
                    set_name.Add(equipment.Equip.SetName);
            }

            // 세트 아이템 효과 적용
            set_name = set_name.Distinct().ToList();
            foreach (string set in set_name)
            {
                bool set_access = true;
                ItemDB set_item = MainWindow._roo_db.Set_Equip_db.FirstOrDefault(x => x.Value.SetName == set).Value;
                foreach(EQUIP_TYPE_ENUM type in set_item.SetPosition)
                {
                    if ( List[(int)type].Equip.SetName != set)
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
