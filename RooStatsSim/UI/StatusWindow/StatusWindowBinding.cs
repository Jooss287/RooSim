using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using RooStatsSim.User;
using RooStatsSim.DB;
using RooStatsSim.DB.Table;

namespace RooStatsSim.UI.StatusWindow
{
    class EnumList
    {
        public static List<ITYPE> NormalProperty = new List<ITYPE>()
        {
            ITYPE.STR,
            ITYPE.AGI,
            ITYPE.VIT,
            ITYPE.INT,
            ITYPE.DEX,
            ITYPE.LUK,
            ITYPE.HP,
            ITYPE.SP,
            ITYPE.ATK,
            ITYPE.DEF,
            ITYPE.MATK,
            ITYPE.MDEF,
            ITYPE.SMELTING_ATK,
            ITYPE.SMELTING_DEF,
            ITYPE.SMELTING_MATK,
            ITYPE.SMELTING_MDEF,
            ITYPE.WEAPON_ATK,
            ITYPE.WEAPON_MATK,
            ITYPE.STATUS_ATK,
            ITYPE.STATUS_MATK,
            ITYPE.HP_RECOVERY,
            ITYPE.SP_RECOVERY,
            ITYPE.HIT,
            ITYPE.FLEE,
            ITYPE.CRI,
            ITYPE.CDEF,
        };
    }
    class LevelList : ObservableCollection<AbilityBinding<int>>
    {
        public LevelList()
        { }
        public LevelList(ref UserData param_status)
        {
            Add(new AbilityBinding<int>("Level", param_status.Base_Level.Point,
                                                        param_status.Base_Level.RemainPoint,
                                                        Enum.GetName(typeof(LEVEL_ENUM), LEVEL_ENUM.BASE)));
            Add(new AbilityBinding<int>("Job", param_status.Job_Level.Point,
                                                        param_status.Job_Level.RemainPoint,
                                                        Enum.GetName(typeof(LEVEL_ENUM), LEVEL_ENUM.JOB)));
        }
    }

    class StatusList : ObservableCollection<AbilityBinding<int>>
    {
        public StatusList()
        { }
        public StatusList(ref UserData param_status)
        {
            foreach (STATUS_ENUM status in Enum.GetValues(typeof(STATUS_ENUM)))
            {
                string statusName = Enum.GetName(typeof(STATUS_ENUM), status);
                Add(new AbilityBinding<int>(statusName, param_status.Status.List[(int)status].Point, param_status.User_Item.I_OPTION[(ITYPE)status], statusName));
            }
        }
    }

    class NormalPropertyList : ObservableCollection<AbilityBinding<int>>
    {
        public NormalPropertyList(ref UserData user_data)
        {
            Add(new AbilityBinding<int>("HP", user_data.User_Item.I_OPTION[ITYPE.HP], 0, Enum.GetName(typeof(ITYPE), ITYPE.HP)));
            Add(new AbilityBinding<int>("SP", user_data.User_Item.I_OPTION[ITYPE.SP], 0, Enum.GetName(typeof(ITYPE), ITYPE.SP)));
            Add(new AbilityBinding<int>("ATK", user_data.User_Item.I_OPTION[ITYPE.ATK], 0, Enum.GetName(typeof(ITYPE), ITYPE.ATK)));
            Add(new AbilityBinding<int>("DEF", user_data.User_Item.I_OPTION[ITYPE.DEF], 0, Enum.GetName(typeof(ITYPE), ITYPE.DEF)));
            Add(new AbilityBinding<int>("MATK", user_data.User_Item.I_OPTION[ITYPE.MATK], 0, Enum.GetName(typeof(ITYPE), ITYPE.MATK)));
            Add(new AbilityBinding<int>("MDEF", user_data.User_Item.I_OPTION[ITYPE.MDEF], 0, Enum.GetName(typeof(ITYPE), ITYPE.MDEF)));
            Add(new AbilityBinding<int>("제련 ATK", user_data.User_Item.I_OPTION[ITYPE.SMELTING_ATK], 0, Enum.GetName(typeof(ITYPE), ITYPE.SMELTING_ATK)));
            Add(new AbilityBinding<int>("제련 DEF", user_data.User_Item.I_OPTION[ITYPE.SMELTING_DEF], 0, Enum.GetName(typeof(ITYPE), ITYPE.SMELTING_DEF)));
            Add(new AbilityBinding<int>("제련 MATK", user_data.User_Item.I_OPTION[ITYPE.SMELTING_MATK], 0, Enum.GetName(typeof(ITYPE), ITYPE.SMELTING_MATK)));
            Add(new AbilityBinding<int>("제련 MDEF", user_data.User_Item.I_OPTION[ITYPE.SMELTING_MDEF], 0, Enum.GetName(typeof(ITYPE), ITYPE.SMELTING_MDEF)));
            Add(new AbilityBinding<int>("무기 ATK", user_data.User_Item.I_OPTION[ITYPE.WEAPON_ATK], 0, Enum.GetName(typeof(ITYPE), ITYPE.WEAPON_ATK)));
            Add(new AbilityBinding<int>("무기 MATK", user_data.User_Item.I_OPTION[ITYPE.WEAPON_MATK], 0, Enum.GetName(typeof(ITYPE), ITYPE.WEAPON_MATK)));
            Add(new AbilityBinding<int>("스텟 ATK", user_data.User_Item.I_OPTION[ITYPE.STATUS_ATK], 0, Enum.GetName(typeof(ITYPE), ITYPE.STATUS_ATK)));
            Add(new AbilityBinding<int>("스텟 MATK", user_data.User_Item.I_OPTION[ITYPE.STATUS_MATK], 0, Enum.GetName(typeof(ITYPE), ITYPE.STATUS_MATK)));
            Add(new AbilityBinding<int>("HP 자연 회복", user_data.User_Item.I_OPTION[ITYPE.HP_RECOVERY], 0, Enum.GetName(typeof(ITYPE), ITYPE.HP_RECOVERY)));
            Add(new AbilityBinding<int>("SP 자연 회복", user_data.User_Item.I_OPTION[ITYPE.SP_RECOVERY], 0, Enum.GetName(typeof(ITYPE), ITYPE.SP_RECOVERY)));
            Add(new AbilityBinding<int>("HIT", user_data.User_Item.I_OPTION[ITYPE.HIT], 0, Enum.GetName(typeof(ITYPE), ITYPE.HIT)));
            Add(new AbilityBinding<int>("FLEE", user_data.User_Item.I_OPTION[ITYPE.FLEE], 0, Enum.GetName(typeof(ITYPE), ITYPE.FLEE)));
            Add(new AbilityBinding<int>("CRI", user_data.User_Item.I_OPTION[ITYPE.CRI], 0, Enum.GetName(typeof(ITYPE), ITYPE.CRI)));
            Add(new AbilityBinding<int>("CDEF", user_data.User_Item.I_OPTION[ITYPE.CDEF], 0, Enum.GetName(typeof(ITYPE), ITYPE.CDEF)));
        }
    }

    class AdvancedPropertyList : ObservableCollection<AbilityBinding<double>>
    {
        public AdvancedPropertyList(ref UserData user_data)
        {
            Add(new AbilityBinding<double>("ASPD", user_data.User_Item.D_OPTION[DTYPE.ASPD], 0, Enum.GetName(typeof(DTYPE), DTYPE.ASPD)));
            Add(new AbilityBinding<double>("이동속도", user_data.User_Item.D_OPTION[DTYPE.MOVING_SPEED], 0, Enum.GetName(typeof(DTYPE), DTYPE.MOVING_SPEED)));
            foreach(KeyValuePair<ITYPE, int> item in user_data.User_Item.I_OPTION)
            {
                if (EnumList.NormalProperty.Contains(item.Key))
                    continue;
                Add(new AbilityBinding<double>(EnumItemOptionTable_Kor.ITYPE_KOR[item.Key], user_data.User_Item.I_OPTION[item.Key], 0, Enum.GetName(typeof(ITYPE), item.Key)));
            }
            foreach(KeyValuePair<DTYPE, double> item in user_data.User_Item.D_OPTION)
            {
                if ((item.Key == DTYPE.ASPD) || (item.Key == DTYPE.MOVING_SPEED))
                    continue;
                Add(new AbilityBinding<double>(EnumItemOptionTable_Kor.DTYPE_KOR[item.Key], user_data.User_Item.D_OPTION[item.Key], 0, Enum.GetName(typeof(DTYPE), item.Key)));
            }
        }
    }

    class SpecialPropertyList : ObservableCollection<AbilityBinding<double>>
    {
        public SpecialPropertyList(ref UserData user_data)
        {
            foreach (KeyValuePair<STATUS_EFFECT_TYPE, double> item in user_data.User_Item.SE_ATTACKRATE_OPTION)
                Add(new AbilityBinding<double>(EnumBaseTable_Kor.STATUS_EFFECT_TYPE_KOR[item.Key] + "상태 확률(%)"
                    , user_data.User_Item.SE_ATTACKRATE_OPTION[item.Key], 0, Enum.GetName(typeof(STATUS_EFFECT_TYPE), item.Key)));
            foreach (KeyValuePair<STATUS_EFFECT_TYPE, double> item in user_data.User_Item.SE_REGISTANCE_OPTION)
                Add(new AbilityBinding<double>(EnumBaseTable_Kor.STATUS_EFFECT_TYPE_KOR[item.Key] + "상태 저항(%)"
                    , user_data.User_Item.SE_REGISTANCE_OPTION[item.Key], 0, Enum.GetName(typeof(STATUS_EFFECT_TYPE), item.Key)));
            foreach (KeyValuePair<ELEMENT_TYPE, double> item in user_data.User_Item.ELEMENT_INC_OPTION)
                Add(new AbilityBinding<double>("몬스터 ("+EnumBaseTable_Kor.ELEMENT_TYPE_KOR[item.Key] + ")에게 데미지 증가(%)"
                    , user_data.User_Item.ELEMENT_INC_OPTION[item.Key], 0, Enum.GetName(typeof(ELEMENT_TYPE), item.Key)));
            foreach (KeyValuePair<ELEMENT_TYPE, double> item in user_data.User_Item.ELEMENT_DAMAGE_OPTION)
                Add(new AbilityBinding<double>(EnumBaseTable_Kor.ELEMENT_TYPE_KOR[item.Key] + "데미지 증가(%)"
                    , user_data.User_Item.ELEMENT_INC_OPTION[item.Key], 0, Enum.GetName(typeof(ELEMENT_TYPE), item.Key)));
            foreach (KeyValuePair<ELEMENT_TYPE, double> item in user_data.User_Item.ELEMENT_DEC_OPTION)
                Add(new AbilityBinding<double>(EnumBaseTable_Kor.ELEMENT_TYPE_KOR[item.Key] + "데미지 감소(%)"
                    , user_data.User_Item.ELEMENT_INC_OPTION[item.Key], 0, Enum.GetName(typeof(ELEMENT_TYPE), item.Key)));
            foreach (KeyValuePair<ELEMENT_TYPE, double> item in user_data.User_Item.ELEMENT_DEC_OPTION)
                Add(new AbilityBinding<double>(EnumBaseTable_Kor.ELEMENT_TYPE_KOR[item.Key] + "데미지 감소(%)"
                    , user_data.User_Item.ELEMENT_INC_OPTION[item.Key], 0, Enum.GetName(typeof(ELEMENT_TYPE), item.Key)));
            foreach (KeyValuePair<MONSTER_SIZE, double> item in user_data.User_Item.SIZE_INC_OPTION)
                Add(new AbilityBinding<double>(EnumBaseTable_Kor.MONSTER_SIZE_KOR[item.Key] + "데미지 증가(%)"
                    , user_data.User_Item.SIZE_INC_OPTION[item.Key], 0, Enum.GetName(typeof(MONSTER_SIZE), item.Key)));
            foreach (KeyValuePair<MONSTER_SIZE, double> item in user_data.User_Item.SIZE_DEC_OPTION)
                Add(new AbilityBinding<double>(EnumBaseTable_Kor.MONSTER_SIZE_KOR[item.Key] + "데미지 감소(%)"
                    , user_data.User_Item.SIZE_DEC_OPTION[item.Key], 0, Enum.GetName(typeof(MONSTER_SIZE), item.Key)));
            foreach (KeyValuePair<TRIBE_TYPE, double> item in user_data.User_Item.TRIBE_INC_OPTION)
                Add(new AbilityBinding<double>(EnumBaseTable_Kor.TRIBE_TYPE_KOR[item.Key] + "데미지 증가(%)"
                    , user_data.User_Item.TRIBE_INC_OPTION[item.Key], 0, Enum.GetName(typeof(TRIBE_TYPE), item.Key)));
            foreach (KeyValuePair<TRIBE_TYPE, double> item in user_data.User_Item.TRIBE_DEC_OPTION)
                Add(new AbilityBinding<double>(EnumBaseTable_Kor.TRIBE_TYPE_KOR[item.Key] + "데미지 감소(%)"
                    , user_data.User_Item.TRIBE_DEC_OPTION[item.Key], 0, Enum.GetName(typeof(TRIBE_TYPE), item.Key)));
            foreach (KeyValuePair<MONSTER_KINDS_TYPE, double> item in user_data.User_Item.MOBTYPE_INC_OPTION)
                Add(new AbilityBinding<double>(EnumBaseTable_Kor.MONSTER_KINDS_TYPE_KOR[item.Key] + "데미지 증가(%)"
                    , user_data.User_Item.MOBTYPE_INC_OPTION[item.Key], 0, Enum.GetName(typeof(MONSTER_KINDS_TYPE), item.Key)));
            foreach (KeyValuePair<MONSTER_KINDS_TYPE, double> item in user_data.User_Item.MOBTYPE_DEC_OPTION)
                Add(new AbilityBinding<double>(EnumBaseTable_Kor.MONSTER_KINDS_TYPE_KOR[item.Key] + "데미지 감소(%)"
                    , user_data.User_Item.MOBTYPE_DEC_OPTION[item.Key], 0, Enum.GetName(typeof(MONSTER_KINDS_TYPE), item.Key)));
        }
    }
}
