using RooStatsSim.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RooStatsSim.DB.Table
{
    class StatsPointTable
    {
        public static int LevelUpStatusPoint(int nextLevel)
        {
            if (nextLevel <= 1)
                return 0;
            return ((nextLevel / 5) + 3);
        }
        public static int LevelChangeStatusPoint(int prevLevel, int nextLevel)
        {
            int stat_point = 0;
            for (int i = prevLevel + 1; i <= nextLevel; i++)
                stat_point += LevelUpStatusPoint(i);

            return stat_point;
        }
        public static int StatNecessaryPoint(int nowStatPoint)
        {
            if (nowStatPoint < 1)
                return 0;
            return (int)(nowStatPoint / 10) + (nowStatPoint % 10 >= 9 ? 1 : 0) + 2;
        }
    }
}
