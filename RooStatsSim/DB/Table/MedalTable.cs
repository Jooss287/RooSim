using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RooStatsSim.DB.Table
{
    class MedalTable
    {
        public static int Get_ATK_MATK(int level)
        {
            if (level == 0)
                return 0;
            else if (level <= 20)
                return 4;
            else
                return 6;
        }
        public static double Get_P_M_Damage(int level)
        {
            if (level == 0)
                return 0;
            else if (level <= 20)
                return 0.25;
            else
                return 0.4;
        }
        public static double Get_MaxHP(int level)
        {
            if (level == 0)
                return 0;
            else if (level == 1)
                return 27.5;
            else if (level <= 20)
                return 17.5;
            else
                return 25;
        }
        public static double Get_Dec_Damage(int level)
        {
            if (level == 0)
                return 0;
            else if (level <= 20)
                return 0.25;
            else
                return 0.4;
        }
    }
}
