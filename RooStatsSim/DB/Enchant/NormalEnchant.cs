using System;
using System.Collections.Generic;
using RooStatsSim.DB.Table;

namespace RooStatsSim.DB.Enchant
{
    public enum NORMAL_ENCHANT_ITEM
    {
        STR,
        AGI,
        VIT,
        INT,
        DEX,
        LUK,
        ATK,
        ATK_P,
        ASPD,
        MATK,
        MATK_P,
        MAX_HP,
        MAX_SP,
        DEF,
        MDEF,
        CDEF,
        FLEE,
        CRI,
        HIT
    }

    public class NormalEnchant
    {
        public static Dictionary<string, string> NORMAL_ENCHANT_ITEM_KOR = new Dictionary<string, string>()
        {
            {Enum.GetName(typeof(NORMAL_ENCHANT_ITEM),NORMAL_ENCHANT_ITEM.STR), "STR" },
            {Enum.GetName(typeof(NORMAL_ENCHANT_ITEM),NORMAL_ENCHANT_ITEM.AGI), "AGI" },
            {Enum.GetName(typeof(NORMAL_ENCHANT_ITEM),NORMAL_ENCHANT_ITEM.VIT), "VIT" },
            {Enum.GetName(typeof(NORMAL_ENCHANT_ITEM),NORMAL_ENCHANT_ITEM.INT), "INT" },
            {Enum.GetName(typeof(NORMAL_ENCHANT_ITEM),NORMAL_ENCHANT_ITEM.DEX), "DEX" },
            {Enum.GetName(typeof(NORMAL_ENCHANT_ITEM),NORMAL_ENCHANT_ITEM.LUK), "LUK" },
            {Enum.GetName(typeof(NORMAL_ENCHANT_ITEM),NORMAL_ENCHANT_ITEM.ATK), "ATK" },
            {Enum.GetName(typeof(NORMAL_ENCHANT_ITEM),NORMAL_ENCHANT_ITEM.ATK_P), "ATK%" },
            {Enum.GetName(typeof(NORMAL_ENCHANT_ITEM),NORMAL_ENCHANT_ITEM.ASPD), "ASPD" },
            {Enum.GetName(typeof(NORMAL_ENCHANT_ITEM),NORMAL_ENCHANT_ITEM.MATK), "MATK" },
            {Enum.GetName(typeof(NORMAL_ENCHANT_ITEM),NORMAL_ENCHANT_ITEM.MATK_P), "MATK%" },
            {Enum.GetName(typeof(NORMAL_ENCHANT_ITEM),NORMAL_ENCHANT_ITEM.MAX_HP), "MAX_HP" },
            {Enum.GetName(typeof(NORMAL_ENCHANT_ITEM),NORMAL_ENCHANT_ITEM.MAX_SP), "MAX_SP" },
            {Enum.GetName(typeof(NORMAL_ENCHANT_ITEM),NORMAL_ENCHANT_ITEM.DEF), "DEF" },
            {Enum.GetName(typeof(NORMAL_ENCHANT_ITEM),NORMAL_ENCHANT_ITEM.MDEF), "MDEF" },
            {Enum.GetName(typeof(NORMAL_ENCHANT_ITEM),NORMAL_ENCHANT_ITEM.CDEF), "CDEF" },
            {Enum.GetName(typeof(NORMAL_ENCHANT_ITEM),NORMAL_ENCHANT_ITEM.FLEE), "FLEE" },
            {Enum.GetName(typeof(NORMAL_ENCHANT_ITEM),NORMAL_ENCHANT_ITEM.CRI), "CRI" },
            {Enum.GetName(typeof(NORMAL_ENCHANT_ITEM),NORMAL_ENCHANT_ITEM.HIT), "HIT" },
        };

        public Dictionary<string, EnchantInfo> Dic { get; set; }

        public NormalEnchant()
        {
            int max_lvl = 1;
            Dic = new Dictionary<string, EnchantInfo>();
            foreach (string name in Enum.GetNames(typeof(NORMAL_ENCHANT_ITEM)))
            {
                Dic.Add(name, new EnchantInfo(name, NORMAL_ENCHANT_ITEM_KOR[name], max_lvl));
                for (int i = 0; i < max_lvl; i++)
                    Dic[name].OPTION.Add(new ItemDB());
            }

            //STR
            Dic[Enum.GetName(typeof(NORMAL_ENCHANT_ITEM), NORMAL_ENCHANT_ITEM.STR)].OPTION[0].Option_ITYPE[Enum.GetName(typeof(ITYPE), ITYPE.STR)] = 1;
            //AGI
            Dic[Enum.GetName(typeof(NORMAL_ENCHANT_ITEM), NORMAL_ENCHANT_ITEM.AGI)].OPTION[0].Option_ITYPE[Enum.GetName(typeof(ITYPE), ITYPE.AGI)] = 1;
            //VIT
            Dic[Enum.GetName(typeof(NORMAL_ENCHANT_ITEM), NORMAL_ENCHANT_ITEM.VIT)].OPTION[0].Option_ITYPE[Enum.GetName(typeof(ITYPE), ITYPE.VIT)] = 1;
            //INT
            Dic[Enum.GetName(typeof(NORMAL_ENCHANT_ITEM), NORMAL_ENCHANT_ITEM.INT)].OPTION[0].Option_ITYPE[Enum.GetName(typeof(ITYPE), ITYPE.INT)] = 1;
            //DEX
            Dic[Enum.GetName(typeof(NORMAL_ENCHANT_ITEM), NORMAL_ENCHANT_ITEM.DEX)].OPTION[0].Option_ITYPE[Enum.GetName(typeof(ITYPE), ITYPE.DEX)] = 1;
            //LUK
            Dic[Enum.GetName(typeof(NORMAL_ENCHANT_ITEM), NORMAL_ENCHANT_ITEM.LUK)].OPTION[0].Option_ITYPE[Enum.GetName(typeof(ITYPE), ITYPE.LUK)] = 1;

            //ATK
            Dic[Enum.GetName(typeof(NORMAL_ENCHANT_ITEM), NORMAL_ENCHANT_ITEM.ATK)].OPTION[0].Option_ITYPE[Enum.GetName(typeof(ITYPE), ITYPE.ATK)] = 1;
            //ATK_P
            Dic[Enum.GetName(typeof(NORMAL_ENCHANT_ITEM), NORMAL_ENCHANT_ITEM.ATK_P)].OPTION[0].Option_DTYPE[Enum.GetName(typeof(DTYPE), DTYPE.ATK_P)] = 1;
            //ASPD
            Dic[Enum.GetName(typeof(NORMAL_ENCHANT_ITEM), NORMAL_ENCHANT_ITEM.ASPD)].OPTION[0].Option_DTYPE[Enum.GetName(typeof(DTYPE), DTYPE.ASPD)] = 1;
            //MATK
            Dic[Enum.GetName(typeof(NORMAL_ENCHANT_ITEM), NORMAL_ENCHANT_ITEM.MATK)].OPTION[0].Option_ITYPE[Enum.GetName(typeof(ITYPE), ITYPE.MATK)] = 1;
            //MATK_P
            Dic[Enum.GetName(typeof(NORMAL_ENCHANT_ITEM), NORMAL_ENCHANT_ITEM.MATK_P)].OPTION[0].Option_DTYPE[Enum.GetName(typeof(DTYPE), DTYPE.MATK_P)] = 1;

            //MAX_HP
            Dic[Enum.GetName(typeof(NORMAL_ENCHANT_ITEM), NORMAL_ENCHANT_ITEM.MAX_HP)].OPTION[0].Option_ITYPE[Enum.GetName(typeof(ITYPE), ITYPE.HP)] = 1;
            //MAX_SP
            Dic[Enum.GetName(typeof(NORMAL_ENCHANT_ITEM), NORMAL_ENCHANT_ITEM.MAX_SP)].OPTION[0].Option_ITYPE[Enum.GetName(typeof(ITYPE), ITYPE.SP)] = 1;
            //DEF
            Dic[Enum.GetName(typeof(NORMAL_ENCHANT_ITEM), NORMAL_ENCHANT_ITEM.DEF)].OPTION[0].Option_ITYPE[Enum.GetName(typeof(ITYPE), ITYPE.DEF)] = 1;
            //MDEF
            Dic[Enum.GetName(typeof(NORMAL_ENCHANT_ITEM), NORMAL_ENCHANT_ITEM.MDEF)].OPTION[0].Option_ITYPE[Enum.GetName(typeof(ITYPE), ITYPE.MDEF)] = 1;
            //CDEF
            Dic[Enum.GetName(typeof(NORMAL_ENCHANT_ITEM), NORMAL_ENCHANT_ITEM.CDEF)].OPTION[0].Option_ITYPE[Enum.GetName(typeof(ITYPE), ITYPE.CDEF)] = 1;
            //FLEE
            Dic[Enum.GetName(typeof(NORMAL_ENCHANT_ITEM), NORMAL_ENCHANT_ITEM.FLEE)].OPTION[0].Option_ITYPE[Enum.GetName(typeof(ITYPE), ITYPE.FLEE)] = 1;
            //CRI
            Dic[Enum.GetName(typeof(NORMAL_ENCHANT_ITEM), NORMAL_ENCHANT_ITEM.CRI)].OPTION[0].Option_ITYPE[Enum.GetName(typeof(ITYPE), ITYPE.CRI)] = 1;
            //HIT
            Dic[Enum.GetName(typeof(NORMAL_ENCHANT_ITEM), NORMAL_ENCHANT_ITEM.HIT)].OPTION[0].Option_ITYPE[Enum.GetName(typeof(ITYPE), ITYPE.HIT)] = 1;
        }
    }
}

