using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbManager.DB
{
    public enum ITYPE
    {
        ATK = 1000,
        MATK = 2000,
        DEF = 3000,
        MDEF = 4000,
        ELEMENT = 8000,
    }
    public enum DTYPE
    {
        ATK_P,

    }
    public enum IFTYPE
    {
        STR_TO_ATK = 1000,
        AGI_TO_ATK = 2000,
        VIT_TO_HP = 3000,
        INT_TO_MATK = 3000,
    }
    class ItemInfo
    {
        public delegate int CalcFunc(int value);
        public Dictionary<ITYPE, int> i_option;
        public Dictionary<DTYPE, int> d_option;
        public Dictionary<IFTYPE, AbilityPerStatus> if_option;

        public class AbilityPerStatus
        {
            int AddValue;
            int PerValue;
            CalcFunc Calc;

            public AbilityPerStatus(IFTYPE iftype, int add_value, int per_value)
            {
                switch (iftype)
                {
                    case IFTYPE.STR_TO_ATK:
                        Calc = ATK_PER_STR;
                        break;
                }

            }
            
            int ATK_PER_STR(int value)
            {
                return ((int)(value / PerValue) * AddValue);
            }
        }

        
    }
}
