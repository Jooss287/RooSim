using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using RooStatsSim.User;

namespace RooStatsSim.UI.StackBuff
{
    class MedalList : ObservableCollection<AbilityBinding>
    {
        public MedalList()
        { }
        public MedalList(ref UserData param_status)
        {
            MEDAL temp = param_status.Medal;
            Add(new AbilityBinding("용맹훈장", temp[(int)MEDAL_ENUM.VALOR], 0));
            Add(new AbilityBinding("수호훈장", temp[(int)MEDAL_ENUM.GUARDIAN], 0));
            Add(new AbilityBinding("지혜훈장", temp[(int)MEDAL_ENUM.WISDOM], 0));
            Add(new AbilityBinding("매력훈장", temp[(int)MEDAL_ENUM.CHARM], 0));
            Add(new AbilityBinding("질풍훈장", temp[(int)MEDAL_ENUM.GALE], 0));
        }
    }
}
