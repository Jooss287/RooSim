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
    public class EQUIP
    {
        public class EquipItem
        {
            int LastCardSetSlot = 0;
            int LastEnchantSlot = 0;
            ItemDB _equip;
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

        public ItemDB GetOption()
        {
            ItemDB option = new ItemDB();

            foreach ( EquipItem equipment in List)
            {
                if (equipment.Equip == null)
                    continue;
                option += equipment.Equip;
                foreach (ItemDB card in equipment.Card)
                    option += card;
                foreach (ItemDB enchant in equipment.Enchant)
                    option += enchant;
            }
            
            return option;
        }
    }

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
