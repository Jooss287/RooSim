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
            if (param_status == null) return;
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
            if (param_status == null) return;
            foreach (STATUS_ENUM status in Enum.GetValues(typeof(STATUS_ENUM)))
            {
                string statusName = Enum.GetName(typeof(STATUS_ENUM), status);
                Add(new AbilityBinding<int>(statusName, param_status.Status.List[(int)status].Point, 
                    Convert.ToInt32(param_status.User_Item.Option_ITYPE[Enum.GetName(typeof(ITYPE),(ITYPE)status)]), statusName));
            }
        }
    }

    class NormalPropertyList : ObservableCollection<AbilityBinding<double>>
    {
        public NormalPropertyList(ref UserData user_data)
        {
            if (user_data == null) return;
            AddType(user_data, ITYPE.HP);
            AddType(user_data, ITYPE.SP);
            AddType(user_data, ITYPE.ATK);
            AddType(user_data, ITYPE.DEF);
            AddType(user_data, ITYPE.MATK);
            AddType(user_data, ITYPE.MDEF);
            AddType(user_data, ITYPE.SMELTING_ATK);
            AddType(user_data, ITYPE.SMELTING_DEF);
            AddType(user_data, ITYPE.SMELTING_MATK);
            AddType(user_data, ITYPE.SMELTING_MDEF);
            AddType(user_data, ITYPE.WEAPON_ATK);
            AddType(user_data, ITYPE.WEAPON_MATK);
            AddType(user_data, ITYPE.STATUS_ATK);
            AddType(user_data, ITYPE.STATUS_MATK);
            AddType(user_data, ITYPE.HP_RECOVERY);
            AddType(user_data, ITYPE.SP_RECOVERY);
            AddType(user_data, ITYPE.HIT);
            AddType(user_data, ITYPE.FLEE);
            AddType(user_data, ITYPE.CRI);
            AddType(user_data, ITYPE.CDEF);
        }
        void AddType(UserData user_data, ITYPE type)
        {
            Add(new AbilityBinding<double>(EnumItemOptionTable_Kor.ITYPE_KOR[type], user_data.User_Item.Option_ITYPE[Enum.GetName(typeof(ITYPE), type)], 0, Enum.GetName(typeof(ITYPE), type)));
        }
    }

    class AdvancedPropertyList : ObservableCollection<AbilityBinding<double>>
    {
        public AdvancedPropertyList(ref UserData user_data)
        {
            if (user_data == null) return;
            Add(new AbilityBinding<double>(EnumItemOptionTable_Kor.DTYPE_KOR[DTYPE.ASPD], user_data.User_Item.Option_DTYPE[Enum.GetName(typeof(DTYPE), DTYPE.ASPD)], 0, Enum.GetName(typeof(DTYPE), DTYPE.ASPD)));
            Add(new AbilityBinding<double>(EnumItemOptionTable_Kor.DTYPE_KOR[DTYPE.MOVING_SPEED], user_data.User_Item.Option_DTYPE[Enum.GetName(typeof(DTYPE), DTYPE.MOVING_SPEED)], 0, Enum.GetName(typeof(DTYPE), DTYPE.MOVING_SPEED)));
            foreach(KeyValuePair<string, double> item in user_data.User_Item.Option_ITYPE)
            {
                ITYPE itype = (ITYPE)Enum.Parse(typeof(ITYPE), item.Key);
                if (EnumList.NormalProperty.Contains(itype))
                    continue;
                Add(new AbilityBinding<double>(EnumItemOptionTable_Kor.ITYPE_KOR[itype], (int)user_data.User_Item.Option_ITYPE[item.Key], 0, Enum.GetName(typeof(ITYPE), itype)));
            }
            foreach(KeyValuePair<string, double> item in user_data.User_Item.Option_DTYPE)
            {
                DTYPE dtype = (DTYPE)Enum.Parse(typeof(DTYPE), item.Key);
                if ((dtype == DTYPE.ASPD) || (dtype == DTYPE.MOVING_SPEED))
                    continue;
                Add(new AbilityBinding<double>(EnumItemOptionTable_Kor.DTYPE_KOR[dtype], user_data.User_Item.Option_DTYPE[item.Key], 0, Enum.GetName(typeof(DTYPE), dtype)));
            }
        }
    }

    class SpecialPropertyList : ObservableCollection<AbilityBinding<double>>
    {
        public SpecialPropertyList(ref UserData user_data)
        {
            if (user_data == null) return;
            foreach (KeyValuePair<string, double> item in user_data.User_Item.Option_SE_ATK_RATE_TYPE)
            {
                SE_ATK_RATE_TYPE type = (SE_ATK_RATE_TYPE)Enum.Parse(typeof(SE_ATK_RATE_TYPE), item.Key);
                Add(new AbilityBinding<double>(EnumItemOptionTable_Kor.SE_ATK_RATE_TYPE_KOR[type] + "(%)"
                    , user_data.User_Item.Option_SE_ATK_RATE_TYPE[item.Key], 0, Enum.GetName(typeof(SE_ATK_RATE_TYPE), type)));
            }
            foreach (KeyValuePair<string, double> item in user_data.User_Item.Option_SE_REG_RATE_TYPE)
            {
                SE_REG_RATE_TYPE type = (SE_REG_RATE_TYPE)Enum.Parse(typeof(SE_REG_RATE_TYPE), item.Key);
                Add(new AbilityBinding<double>(EnumItemOptionTable_Kor.SE_REG_RATE_TYPE_KOR[type] + "(%)"
                    , user_data.User_Item.Option_SE_REG_RATE_TYPE[item.Key], 0, Enum.GetName(typeof(SE_REG_RATE_TYPE), type)));
            }
            foreach (KeyValuePair<string, double> item in user_data.User_Item.Option_MONSTER_ELEMENT_DMG_TYPE)
            {
                MONSTER_ELEMENT_DMG_TYPE type = (MONSTER_ELEMENT_DMG_TYPE)Enum.Parse(typeof(MONSTER_ELEMENT_DMG_TYPE), item.Key);
                Add(new AbilityBinding<double>(EnumItemOptionTable_Kor.MONSTER_ELEMENT_DMG_TYPE_KOR[type] + "(%)"
                    , user_data.User_Item.Option_MONSTER_ELEMENT_DMG_TYPE[item.Key], 0, Enum.GetName(typeof(MONSTER_ELEMENT_DMG_TYPE), type)));
            }
            foreach (KeyValuePair<string, double> item in user_data.User_Item.Option_ELEMENT_DMG_TYPE)
            {
                ELEMENT_DMG_TYPE type = (ELEMENT_DMG_TYPE)Enum.Parse(typeof(ELEMENT_DMG_TYPE), item.Key);
                Add(new AbilityBinding<double>(EnumItemOptionTable_Kor.ELEMENT_DMG_TYPE_KOR[type] + "(%)"
                    , user_data.User_Item.Option_ELEMENT_DMG_TYPE[item.Key], 0, Enum.GetName(typeof(ELEMENT_DMG_TYPE), type)));
            }
            foreach (KeyValuePair<string, double> item in user_data.User_Item.Option_ELEMENT_REG_TYPE)
            {
                ELEMENT_REG_TYPE type = (ELEMENT_REG_TYPE)Enum.Parse(typeof(ELEMENT_REG_TYPE), item.Key);
                Add(new AbilityBinding<double>(EnumItemOptionTable_Kor.ELEMENT_REG_TYPE_KOR[type] + "(%)"
                    , user_data.User_Item.Option_ELEMENT_REG_TYPE[item.Key], 0, Enum.GetName(typeof(ELEMENT_REG_TYPE), type)));
            }
            foreach (KeyValuePair<string, double> item in user_data.User_Item.Option_MONSTER_SIZE_DMG_TYPE)
            {
                MONSTER_SIZE_DMG_TYPE type = (MONSTER_SIZE_DMG_TYPE)Enum.Parse(typeof(MONSTER_SIZE_DMG_TYPE), item.Key);
                Add(new AbilityBinding<double>(EnumItemOptionTable_Kor.MONSTER_SIZE_DMG_TYPE_KOR[type] + "(%)"
                    , user_data.User_Item.Option_MONSTER_SIZE_DMG_TYPE[item.Key], 0, Enum.GetName(typeof(MONSTER_SIZE_DMG_TYPE), type)));
            }
            foreach (KeyValuePair<string, double> item in user_data.User_Item.Option_MONSTER_SIZE_REG_TYPE)
            {
                MONSTER_SIZE_REG_TYPE type = (MONSTER_SIZE_REG_TYPE)Enum.Parse(typeof(MONSTER_SIZE_REG_TYPE), item.Key);
                Add(new AbilityBinding<double>(EnumItemOptionTable_Kor.MONSTER_SIZE_REG_TYPE_KOR[type] + "(%)"
                    , user_data.User_Item.Option_MONSTER_SIZE_REG_TYPE[item.Key], 0, Enum.GetName(typeof(MONSTER_SIZE_REG_TYPE), type)));
            }
            foreach (KeyValuePair<string, double> item in user_data.User_Item.Option_TRIBE_DMG_TYPE)
            {
                TRIBE_DMG_TYPE type = (TRIBE_DMG_TYPE)Enum.Parse(typeof(TRIBE_DMG_TYPE), item.Key);
                Add(new AbilityBinding<double>(EnumItemOptionTable_Kor.TRIBE_DMG_TYPE_KOR[type] + "(%)"
                    , user_data.User_Item.Option_TRIBE_DMG_TYPE[item.Key], 0, Enum.GetName(typeof(TRIBE_DMG_TYPE), type)));
            }
            foreach (KeyValuePair<string, double> item in user_data.User_Item.Option_TRIBE_REG_TYPE)
            {
                TRIBE_REG_TYPE type = (TRIBE_REG_TYPE)Enum.Parse(typeof(TRIBE_REG_TYPE), item.Key);
                Add(new AbilityBinding<double>(EnumItemOptionTable_Kor.TRIBE_REG_TYPE_KOR[type] + "(%)"
                    , user_data.User_Item.Option_TRIBE_REG_TYPE[item.Key], 0, Enum.GetName(typeof(TRIBE_REG_TYPE), type)));
            }
            foreach (KeyValuePair<string, double> item in user_data.User_Item.Option_MONSTER_KINDS_DMG_TYPE)
            {
                MONSTER_KINDS_DMG_TYPE type = (MONSTER_KINDS_DMG_TYPE)Enum.Parse(typeof(MONSTER_KINDS_DMG_TYPE), item.Key);
                Add(new AbilityBinding<double>(EnumItemOptionTable_Kor.MONSTER_KINDS_DMG_TYPE_KOR[type] + "(%)"
                    , user_data.User_Item.Option_MONSTER_KINDS_DMG_TYPE[item.Key], 0, Enum.GetName(typeof(MONSTER_KINDS_DMG_TYPE), type)));
            }
            foreach (KeyValuePair<string, double> item in user_data.User_Item.Option_MONSTER_KINDS_REG_TYPE)
            {
                MONSTER_KINDS_REG_TYPE type = (MONSTER_KINDS_REG_TYPE)Enum.Parse(typeof(MONSTER_KINDS_REG_TYPE), item.Key);
                Add(new AbilityBinding<double>(EnumItemOptionTable_Kor.MONSTER_KINDS_REG_TYPE_KOR[type] + "(%)"
                    , user_data.User_Item.Option_MONSTER_KINDS_REG_TYPE[item.Key], 0, Enum.GetName(typeof(MONSTER_KINDS_REG_TYPE), type)));
            }
        }
    }
}
