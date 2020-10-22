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
        public EquipList()
        {
            Name = "TestName";
            EquipItem Card;
            EquipItem Enchent;
            Add(Card = new EquipItem("카드"));
            Card.SubList.Add(new EquipItem("스켈 워커"));
            Card.SubList.Add(new EquipItem("마이너 우로스"));
            Add(Enchent = new EquipItem("인챈트"));
            Enchent.SubList.Add(new EquipItem("투지 2"));
            Enchent.SubList.Add(new EquipItem("첨예 3"));
        }
    }
}


class ItemListFilter : ObservableCollection<EquipId>
{
    public ItemListFilter(ref UserData user_data)
    {
        foreach(KeyValuePair<int, ItemDB> itemPair in MainWindow._roo_db.Dress_style_db)
        {
            Add(new EquipId()
            {
                Id = itemPair.Key,
                Name = itemPair.Value.Name
            });
        }
        //        Add(new AbilityBinding<int>("HP", user_data.User_Item.i_option[ITYPE.HP], 0, Enum.GetName(typeof(ITYPE), ITYPE.HP)));
        //        Add(new AbilityBinding<int>("SP", user_data.User_Item.i_option[ITYPE.SP], 0, Enum.GetName(typeof(ITYPE), ITYPE.SP)));
        //        Add(new AbilityBinding<int>("ATK", user_data.User_Item.i_option[ITYPE.ATK], 0, Enum.GetName(typeof(ITYPE), ITYPE.ATK)));
        //        Add(new AbilityBinding<int>("DEF", user_data.User_Item.i_option[ITYPE.DEF], 0, Enum.GetName(typeof(ITYPE), ITYPE.DEF)));
        //        Add(new AbilityBinding<int>("MATK", user_data.User_Item.i_option[ITYPE.MATK], 0, Enum.GetName(typeof(ITYPE), ITYPE.MATK)));
        //        Add(new AbilityBinding<int>("MDEF", user_data.User_Item.i_option[ITYPE.MDEF], 0, Enum.GetName(typeof(ITYPE), ITYPE.MDEF)));
        //        Add(new AbilityBinding<int>("제련 ATK", user_data.User_Item.i_option[ITYPE.SMELTING_ATK], 0, Enum.GetName(typeof(ITYPE), ITYPE.SMELTING_ATK)));
        //        Add(new AbilityBinding<int>("제련 DEF", user_data.User_Item.i_option[ITYPE.SMELTING_DEF], 0, Enum.GetName(typeof(ITYPE), ITYPE.SMELTING_DEF)));
        //        Add(new AbilityBinding<int>("제련 MATK", user_data.User_Item.i_option[ITYPE.SMELTING_MATK], 0, Enum.GetName(typeof(ITYPE), ITYPE.SMELTING_MATK)));
        //        Add(new AbilityBinding<int>("제련 MDEF", user_data.User_Item.i_option[ITYPE.SMELTING_MDEF], 0, Enum.GetName(typeof(ITYPE), ITYPE.SMELTING_MDEF)));
        //        Add(new AbilityBinding<int>("무기 ATK", user_data.User_Item.i_option[ITYPE.WEAPON_ATK], 0, Enum.GetName(typeof(ITYPE), ITYPE.WEAPON_ATK)));
        //        Add(new AbilityBinding<int>("무기 MATK", user_data.User_Item.i_option[ITYPE.WEAPON_MATK], 0, Enum.GetName(typeof(ITYPE), ITYPE.WEAPON_MATK)));
        //        Add(new AbilityBinding<int>("스텟 ATK", user_data.User_Item.i_option[ITYPE.STATUS_ATK], 0, Enum.GetName(typeof(ITYPE), ITYPE.STATUS_ATK)));
        //        Add(new AbilityBinding<int>("스텟 MATK", user_data.User_Item.i_option[ITYPE.STATUS_MATK], 0, Enum.GetName(typeof(ITYPE), ITYPE.STATUS_MATK)));
        //        Add(new AbilityBinding<int>("HP 자연 회복", user_data.User_Item.i_option[ITYPE.HP_RECOVERY], 0, Enum.GetName(typeof(ITYPE), ITYPE.HP_RECOVERY)));
        //        Add(new AbilityBinding<int>("SP 자연 회복", user_data.User_Item.i_option[ITYPE.SP_RECOVERY], 0, Enum.GetName(typeof(ITYPE), ITYPE.SP_RECOVERY)));
        //        Add(new AbilityBinding<int>("HIT", user_data.User_Item.i_option[ITYPE.HIT], 0, Enum.GetName(typeof(ITYPE), ITYPE.HIT)));
        //        Add(new AbilityBinding<int>("FLEE", user_data.User_Item.i_option[ITYPE.FLEE], 0, Enum.GetName(typeof(ITYPE), ITYPE.FLEE)));
        //        Add(new AbilityBinding<int>("CRI", user_data.User_Item.i_option[ITYPE.CRI], 0, Enum.GetName(typeof(ITYPE), ITYPE.CRI)));
        //        Add(new AbilityBinding<int>("CDEF", user_data.User_Item.i_option[ITYPE.CDEF], 0, Enum.GetName(typeof(ITYPE), ITYPE.CDEF)));
    }
}