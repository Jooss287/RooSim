using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using RooStatsSim.User;
using RooStatsSim.UI;

namespace RooStatsSim.UI.Status
{
    class StatusList : ObservableCollection<AbilityBinding>
    {
        public StatusList()
        { }
        public StatusList(ref UserData param_status)
        {
            foreach (STATUS_ENUM status in Enum.GetValues(typeof(STATUS_ENUM)))
            {
                string statusName = Enum.GetName(typeof(STATUS_ENUM), status);
                Add(new AbilityBinding(statusName, param_status.Status[(int)status].Point, param_status.Status[(int)status].AddPoint));
            }
        }
    }

    class BasicOptionInfoList : ObservableCollection<AbilityBinding>
    {
        public BasicOptionInfoList()
        {
            Add(new AbilityBinding("ATK", 10, 1));
            Add(new AbilityBinding("MATK", 10, 1));
            Add(new AbilityBinding("제련ATK", 10, 1));
            Add(new AbilityBinding("제련MATK", 10, 1));
            Add(new AbilityBinding("ASPD", 10, 1));
            Add(new AbilityBinding("HIT", 10, 1));
            Add(new AbilityBinding("DEF", 10, 1));
            Add(new AbilityBinding("MDEF", 10, 1));
            Add(new AbilityBinding("제련DEF", 10, 1));
            Add(new AbilityBinding("제련MDEF", 10, 1));
        }
    }
}
