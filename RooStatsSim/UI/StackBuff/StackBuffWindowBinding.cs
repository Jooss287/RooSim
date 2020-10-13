using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using RooStatsSim.User;

namespace RooStatsSim.UI.StackBuff
{
    class MedalList : ObservableCollection<AbilityBinding<int>>
    {
        public MedalList()
        { }
        public MedalList(ref UserData param_status)
        {
            MEDAL medal = param_status.Medal;
            Add(new AbilityBinding<int>("용맹훈장", medal.List[(int)MEDAL_ENUM.VALOR], 0));
            Add(new AbilityBinding<int>("수호훈장", medal.List[(int)MEDAL_ENUM.GUARDIAN], 0));
            Add(new AbilityBinding<int>("지혜훈장", medal.List[(int)MEDAL_ENUM.WISDOM], 0));
            Add(new AbilityBinding<int>("매력훈장", medal.List[(int)MEDAL_ENUM.CHARM], 0));
            Add(new AbilityBinding<int>("질풍훈장", medal.List[(int)MEDAL_ENUM.GALE], 0));
        }
    }

    class RidingList : ObservableCollection<AbilityBinding<int>>
    {
        public RidingList()
        { }
        public RidingList(ref RIDING param_riding)
        {
            Add(new AbilityBinding<int>("ATK / MATK", param_riding[(int)RIDING_ENUM.ATK_MATK], 0, Enum.GetName(typeof(RIDING_ENUM), RIDING_ENUM.ATK_MATK)));
            Add(new AbilityBinding<int>("MAX HP", param_riding[(int)RIDING_ENUM.MAX_HP], 0, Enum.GetName(typeof(RIDING_ENUM), RIDING_ENUM.MAX_HP)));
            Add(new AbilityBinding<int>("ATK% / MATK%", param_riding[(int)RIDING_ENUM.ATK_MATK_PERCENT], 0, Enum.GetName(typeof(RIDING_ENUM), RIDING_ENUM.ATK_MATK_PERCENT)));
        }
    }
}
