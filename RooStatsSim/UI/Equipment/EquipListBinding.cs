using RooStatsSim;
using RooStatsSim.DB;
using RooStatsSim.DB.Table;
using RooStatsSim.UI.Equipment;
using RooStatsSim.UI.Menu;
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
    class EquipList : ObservableCollection<EquipTreeViewBinding>
    {
        public string Name { get; set; }

        public EquipList()
        {
            EquipTreeViewBinding CardTree;
            Add(CardTree = new EquipTreeViewBinding("카드"));
            EquipTreeViewBinding EnchantTree;
            Add(EnchantTree = new EquipTreeViewBinding("인챈트"));
        }
        public EquipList(EQUIP.EquipItem equip_item)
        {
            Name = equip_item.Equip.Name;
            EquipTreeViewBinding CardTree = new EquipTreeViewBinding("카드");
            Add(CardTree);
            foreach (ItemDB card in equip_item.Card)
            {
                CardTree.SubList.Add(new EquipTreeViewBinding(card));
            }
            EquipTreeViewBinding EnchantTree = new EquipTreeViewBinding("인챈트");
            Add(EnchantTree);
            foreach (ItemDB Enchant in equip_item.Enchant)
            {
                EnchantTree.SubList.Add(new EquipTreeViewBinding(Enchant));
            }
        }
    }
}


class ItemListFilter : ObservableCollection<EquipId>
{
    public ItemListFilter(ref UserData user, ITEM_TYPE_ENUM itemtype, EQUIP_TYPE_ENUM equiptype)
    {
        foreach(KeyValuePair<int, ItemDB> itemPair in GetItemList(itemtype, equiptype))
        {
            if ( ( (itemPair.Value)._wear_job_limit.Count != 0 ) &&
                (!(itemPair.Value)._wear_job_limit.Contains(user.Job)) )
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

    Dictionary<int, ItemDB> GetItemList(ITEM_TYPE_ENUM itemtype, EQUIP_TYPE_ENUM equiptype = EQUIP_TYPE_ENUM.HEAD_TOP)
    {
        switch(itemtype)
        {
            case ITEM_TYPE_ENUM.EQUIPMENT:
                return MainWindow._roo_db.Equip_db[(int)EnumBaseTable_Kor.EQUIP_TYPE_TO_DB_ENUM[equiptype]];
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