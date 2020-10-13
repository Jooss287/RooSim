using System;
using System.Collections.ObjectModel;
using RooStatsSim.User;
using RooStatsSim.DB.Table;

namespace RooStatsSim.UI.StackBuff
{
    class MedalList : ObservableCollection<AbilityBinding<int>>
    {
        public MedalList()
        { }
        public MedalList(ref UserData param_status)
        {
            MEDAL medal = param_status.Medal;
            Add(new AbilityBinding<int>(EnumProperty_Kor.MEDAL_ENUM_KOR[MEDAL_ENUM.VALOR], medal.List[(int)MEDAL_ENUM.VALOR], 0, Enum.GetName(typeof(MEDAL_ENUM), MEDAL_ENUM.VALOR)));
            Add(new AbilityBinding<int>(EnumProperty_Kor.MEDAL_ENUM_KOR[MEDAL_ENUM.GUARDIAN], medal.List[(int)MEDAL_ENUM.GUARDIAN], 0, Enum.GetName(typeof(MEDAL_ENUM), MEDAL_ENUM.GUARDIAN)));
            Add(new AbilityBinding<int>(EnumProperty_Kor.MEDAL_ENUM_KOR[MEDAL_ENUM.WISDOM], medal.List[(int)MEDAL_ENUM.WISDOM], 0, Enum.GetName(typeof(MEDAL_ENUM), MEDAL_ENUM.WISDOM)));
            Add(new AbilityBinding<int>(EnumProperty_Kor.MEDAL_ENUM_KOR[MEDAL_ENUM.CHARM], medal.List[(int)MEDAL_ENUM.CHARM], 0, Enum.GetName(typeof(MEDAL_ENUM), MEDAL_ENUM.CHARM)));
            Add(new AbilityBinding<int>(EnumProperty_Kor.MEDAL_ENUM_KOR[MEDAL_ENUM.GALE], medal.List[(int)MEDAL_ENUM.GALE], 0, Enum.GetName(typeof(MEDAL_ENUM), MEDAL_ENUM.GALE)));
        }
    }

    class RidingList : ObservableCollection<AbilityBinding<double>>
    {
        public RidingList()
        { }
        public RidingList(ref RIDING param_riding)
        {
            Add(new AbilityBinding<double>(EnumProperty_Kor.RIDING_ENUM_KOR[RIDING_ENUM.ATK_MATK], param_riding.List[(int)RIDING_ENUM.ATK_MATK], 0, Enum.GetName(typeof(RIDING_ENUM), RIDING_ENUM.ATK_MATK)));
            Add(new AbilityBinding<double>(EnumProperty_Kor.RIDING_ENUM_KOR[RIDING_ENUM.MAX_HP], param_riding.List[(int)RIDING_ENUM.MAX_HP], 0, Enum.GetName(typeof(RIDING_ENUM), RIDING_ENUM.MAX_HP)));
            Add(new AbilityBinding<double>(EnumProperty_Kor.RIDING_ENUM_KOR[RIDING_ENUM.ATK_MATK_PERCENT], param_riding.List[(int)RIDING_ENUM.ATK_MATK_PERCENT], 0, Enum.GetName(typeof(RIDING_ENUM), RIDING_ENUM.ATK_MATK_PERCENT)));
        }
    }
}
