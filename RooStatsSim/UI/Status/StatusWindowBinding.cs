using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using RooStatsSim.User;
using RooStatsSim.UI;
using RooStatsSim.DB;

namespace RooStatsSim.UI.Status
{
    class StatusList : ObservableCollection<AbilityBinding<int>>
    {
        public StatusList()
        { }
        public StatusList(ref UserData param_status)
        {
            foreach (STATUS_ENUM status in Enum.GetValues(typeof(STATUS_ENUM)))
            {
                string statusName = Enum.GetName(typeof(STATUS_ENUM), status);
                Add(new AbilityBinding<int>(statusName, param_status.Status[(int)status].Point, param_status.Status[(int)status].AddPoint));
            }
        }
    }

    class NormalPropertyList : ObservableCollection<AbilityBinding<int>>
    {
        public NormalPropertyList(ref UserData user_data)
        {
            Add(new AbilityBinding<int>("HP", user_data.User_Item.i_option[ITYPE.HP], 0, Enum.GetName(typeof(ITYPE), ITYPE.HP)));
            Add(new AbilityBinding<int>("SP", user_data.User_Item.i_option[ITYPE.SP], 0, Enum.GetName(typeof(ITYPE), ITYPE.SP)));
            Add(new AbilityBinding<int>("ATK", user_data.User_Item.i_option[ITYPE.ATK], 0, Enum.GetName(typeof(ITYPE), ITYPE.ATK)));
            Add(new AbilityBinding<int>("DEF", user_data.User_Item.i_option[ITYPE.DEF], 0, Enum.GetName(typeof(ITYPE), ITYPE.DEF)));
            Add(new AbilityBinding<int>("MATK", user_data.User_Item.i_option[ITYPE.MATK], 0, Enum.GetName(typeof(ITYPE), ITYPE.MATK)));
            Add(new AbilityBinding<int>("MDEF", user_data.User_Item.i_option[ITYPE.MDEF], 0, Enum.GetName(typeof(ITYPE), ITYPE.MDEF)));
            Add(new AbilityBinding<int>("제련 ATK", user_data.User_Item.i_option[ITYPE.SMELTING_ATK], 0, Enum.GetName(typeof(ITYPE), ITYPE.SMELTING_ATK)));
            Add(new AbilityBinding<int>("제련 DEF", user_data.User_Item.i_option[ITYPE.SMELTING_DEF], 0, Enum.GetName(typeof(ITYPE), ITYPE.SMELTING_DEF)));
            Add(new AbilityBinding<int>("제련 MATK", user_data.User_Item.i_option[ITYPE.SMELTING_MATK], 0, Enum.GetName(typeof(ITYPE), ITYPE.SMELTING_MATK)));
            Add(new AbilityBinding<int>("제련 MDEF", user_data.User_Item.i_option[ITYPE.SMELTING_MDEF], 0, Enum.GetName(typeof(ITYPE), ITYPE.SMELTING_MDEF)));
            Add(new AbilityBinding<int>("HP 자연 회복", user_data.User_Item.i_option[ITYPE.HP_RECOVERY], 0, Enum.GetName(typeof(ITYPE), ITYPE.HP_RECOVERY)));
            Add(new AbilityBinding<int>("SP 자연 회복", user_data.User_Item.i_option[ITYPE.SP_RECOVERY], 0, Enum.GetName(typeof(ITYPE), ITYPE.SP_RECOVERY)));
            Add(new AbilityBinding<int>("HIT", user_data.User_Item.i_option[ITYPE.HIT], 0, Enum.GetName(typeof(ITYPE), ITYPE.HIT)));
            Add(new AbilityBinding<int>("FLEE", user_data.User_Item.i_option[ITYPE.FLEE], 0, Enum.GetName(typeof(ITYPE), ITYPE.FLEE)));
            Add(new AbilityBinding<int>("CRI", user_data.User_Item.i_option[ITYPE.CRI], 0, Enum.GetName(typeof(ITYPE), ITYPE.CRI)));
            Add(new AbilityBinding<int>("CDEF", user_data.User_Item.i_option[ITYPE.CDEF], 0, Enum.GetName(typeof(ITYPE), ITYPE.CDEF)));
        }
    }

    class AdvancedPropertyList : ObservableCollection<AbilityBinding<double>>
    {
        public AdvancedPropertyList(ref UserData user_data)
        {
            Add(new AbilityBinding<double>("ASPD", user_data.User_Item.i_option[ITYPE.ASPD], 0, Enum.GetName(typeof(ITYPE), ITYPE.ASPD)));
            //Add(new AbilityBinding<double>("SP", Enum.GetName(typeof(ITYPE), ITYPE.SP), user_data.User_Item.i_option[ITYPE.SP], 0));
            //Add(new AbilityBinding<double>("ATK", Enum.GetName(typeof(ITYPE), ITYPE.ATK), user_data.User_Item.i_option[ITYPE.ATK], 0));
            //Add(new AbilityBinding("DEF", Enum.GetName(typeof(ITYPE), ITYPE.DEF), user_data.User_Item.i_option[ITYPE.DEF], 0));
            //Add(new AbilityBinding("MATK", Enum.GetName(typeof(ITYPE), ITYPE.MATK), user_data.User_Item.i_option[ITYPE.MATK], 0));
            //Add(new AbilityBinding("MDEF", Enum.GetName(typeof(ITYPE), ITYPE.MDEF), user_data.User_Item.i_option[ITYPE.MDEF], 0));
            //Add(new AbilityBinding("제련 ATK", Enum.GetName(typeof(ITYPE), ITYPE.SMELTING_ATK), user_data.User_Item.i_option[ITYPE.SMELTING_ATK], 0));
            //Add(new AbilityBinding("제련 DEF", Enum.GetName(typeof(ITYPE), ITYPE.SMELTING_DEF), user_data.User_Item.i_option[ITYPE.SMELTING_DEF], 0));
            //Add(new AbilityBinding("제련 MATK", Enum.GetName(typeof(ITYPE), ITYPE.SMELTING_MATK), user_data.User_Item.i_option[ITYPE.SMELTING_MATK], 0));
            //Add(new AbilityBinding("제련 MDEF", Enum.GetName(typeof(ITYPE), ITYPE.SMELTING_MDEF), user_data.User_Item.i_option[ITYPE.SMELTING_MDEF], 0));
            //Add(new AbilityBinding("HP 자연 회복", Enum.GetName(typeof(ITYPE), ITYPE.HP_RECOVERY), user_data.User_Item.i_option[ITYPE.HP_RECOVERY], 0));
            //Add(new AbilityBinding("SP 자연 회복", Enum.GetName(typeof(ITYPE), ITYPE.SP_RECOVERY), user_data.User_Item.i_option[ITYPE.SP_RECOVERY], 0));
            //Add(new AbilityBinding("HIT", Enum.GetName(typeof(ITYPE), ITYPE.HIT), user_data.User_Item.i_option[ITYPE.HIT], 0));
            //Add(new AbilityBinding("FLEE", Enum.GetName(typeof(ITYPE), ITYPE.FLEE), user_data.User_Item.i_option[ITYPE.FLEE], 0));
        }
    }
}
