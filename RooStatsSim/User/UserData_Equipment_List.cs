using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using RooStatsSim.DB;
using RooStatsSim.DB.Table;

namespace RooStatsSim.User
{
    public class EQUIP
    {
        public class EquipItem
        {
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
                get { return _cards; }
                set { _cards = value; }
            }
            public List<ItemDB> Enchant
            {
                get { return _enchant; }
                set { _enchant = value; }
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
