using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
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
            public int LastCardSetSlot { get; set; }
            public int LastEnchantSlot { get; set; }
            public int Smelting { get; set; }
            ItemDB _equip = new ItemDB();
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

            public void AddCard(ItemDB input_card)
            {
                if (Card.Count < Equip.CardSlot)
                    Card.Add(input_card);
                else
                {
                    if (LastCardSetSlot - 1 == Equip.CardSlot)
                        LastCardSetSlot = 0;
                    Card[LastCardSetSlot] = input_card;
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

            foreach ( EquipItem equipment in List)
            {
                if (equipment.Equip == null)
                    continue;
                foreach (ItemDB card in equipment.Card)
                    option += card;
                foreach (ItemDB enchant in equipment.Enchant)
                    option += enchant;
                option += equipment.Equip;
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
