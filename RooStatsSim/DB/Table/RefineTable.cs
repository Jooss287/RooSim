using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RooStatsSim.DB.Table
{
    public enum REFINE_OPTION_TYPE
    {
        PHYSICAL,
        MAGICAL,
        COMMON,
        ARMOR,
    }
    public class RefineTable
    {
        public static int[] Refine_ATK_MATK = new int[] { 0, 7, 14, 21, 28, 38, 48, 58, 73, 88, 103, 111, 139, 160, 181, 202 };
        public static int[] Refine_Physical_Add_DMG = new int[] { 0, 3, 6, 9, 12, 17, 22, 27, 34, 41, 48, 55, 65, 75, 85, 95 };
        public static int[] Refine_Magical_Add_DMG = new int[] { 0, 9, 18, 27, 36, 51, 66, 81, 102, 123, 144, 165, 195, 225, 255, 285 };
        public static double[] Reffine_Physical_Magical_DMG = new double[] { 0, 0, 0, 0, 0, 1, 1, 1, 2, 2, 2, 3, 3, 3, 4, 4 };

        public static int[] Refine_Def = new int[] { 0, 3, 6, 9, 12, 16, 20, 24, 29, 34, 39, 44, 50, 56, 62, 68 };
        public static double[] Refine_Physical_DEC = new double[] { 0, 1, 2, 3, 3.9, 5.1, 6.3, 7.5, 8.9, 10.2, 11.6, 12.8, 14.3, 15.8, 17.4, 19.0 };
        public static double[] Refine_Def_Percent = new double[] { 0, 0, 0, 0, 1, 1, 1, 2, 2, 2, 3, 3, 3, 4, 4 };

        public static ItemDB GetRefineOption(REFINE_OPTION_TYPE type, int refine_num)
        {
            ItemDB item = new ItemDB();
            if ((type == REFINE_OPTION_TYPE.PHYSICAL) || (type == REFINE_OPTION_TYPE.COMMON))
            {
                item.Option_ITYPE[Enum.GetName(typeof(ITYPE), ITYPE.SMELTING_ATK)] = Refine_ATK_MATK[refine_num];
                item.Option_ITYPE[Enum.GetName(typeof(ITYPE), ITYPE.PHYSICAL_DAMAGE_ADDITIONAL)] = Refine_Physical_Add_DMG[refine_num];
                item.Option_DTYPE[Enum.GetName(typeof(DTYPE), DTYPE.PHYSICAL_DAMAGE)] = Reffine_Physical_Magical_DMG[refine_num];
            }
            if ((type == REFINE_OPTION_TYPE.MAGICAL) || (type == REFINE_OPTION_TYPE.COMMON))
            {
                item.Option_ITYPE[Enum.GetName(typeof(ITYPE), ITYPE.SMELTING_MATK)] = Refine_ATK_MATK[refine_num];
                item.Option_ITYPE[Enum.GetName(typeof(ITYPE), ITYPE.MAGICAL_DAMAGE_ADDITIONAL)] = Refine_Physical_Add_DMG[refine_num];
                item.Option_DTYPE[Enum.GetName(typeof(DTYPE), DTYPE.MAGICAL_DAMAGE)] = Reffine_Physical_Magical_DMG[refine_num];
            }
            if (type == REFINE_OPTION_TYPE.ARMOR)
            { 
                item.Option_DTYPE[Enum.GetName(typeof(DTYPE), DTYPE.REFINE_DEF)] = Refine_Def[refine_num];
                item.Option_DTYPE[Enum.GetName(typeof(DTYPE), DTYPE.PHYSICAL_DEC_DAMAGE)] = Refine_Physical_DEC[refine_num];
                item.Option_DTYPE[Enum.GetName(typeof(DTYPE), DTYPE.DEF_P)] = Refine_Def_Percent[refine_num];
            }
            return item;
        }
    }
}
