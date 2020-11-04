using RooStatsSim;
using RooStatsSim.DB;
using RooStatsSim.UI.Equipment;
using RooStatsSim.User;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RooStatsSim.UI.Equipment
{
    class EquipList : ObservableCollection<EquipItem>
    {
        public string Name { get; set; }
        public EquipItem Card { get; set; }
        public EquipItem Enchant { get; set; }

        public EquipList()
        {
            Name = "TestName";
            Add(Card = new EquipItem("카드"));
            Card.SubList.Add(new EquipItem("스켈 워커"));
            Card.SubList.Add(new EquipItem("마이너 우로스"));
            Add(Enchant = new EquipItem("인챈트"));
            Enchant.SubList.Add(new EquipItem("투지 2"));
            Enchant.SubList.Add(new EquipItem("첨예 3"));
        }
        public EquipList(ItemDB item)
        {
            Name = item.Name;
            Add(Card = new EquipItem("카드"));
            Add(Enchant = new EquipItem("인챈트"));
        }
        
    }
}


class ItemListFilter : ObservableCollection<EquipId>
{
    public ItemListFilter(ref UserData user, ITEM_TYPE_ENUM itemtype, EQUIP_TYPE_ENUM equiptype)
    {
        foreach(KeyValuePair<int, ItemDB> itemPair in GetItemList(itemtype))
        {
            if (!(itemPair.Value)._wear_job_limit.Contains(user.Job))
                continue;
            if ((itemPair.Value).Equip_type != equiptype)
                continue;
            Add(new EquipId()
            {
                Id = itemPair.Key,
                Name = itemPair.Value.Name
            });
        }
    }

    Dictionary<int, ItemDB> GetItemList(ITEM_TYPE_ENUM itemtype)
    {
        switch(itemtype)
        {
            case ITEM_TYPE_ENUM.EQUIPMENT:
                return MainWindow._roo_db.Equip_db;
            case ITEM_TYPE_ENUM.CARD:
                return MainWindow._roo_db.Card_db;
            case ITEM_TYPE_ENUM.ENCHANT:
                return MainWindow._roo_db.Enchant_db;
            case ITEM_TYPE_ENUM.GEAR:
                return MainWindow._roo_db.Gear_db;
        }
        return null;
    }
}