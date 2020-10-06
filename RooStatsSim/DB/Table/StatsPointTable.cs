using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RooStatsSim.DB.Table
{
    class StatsPointTable
    {
        // LevelupStatusPoint[Nextlevel]
        public static int[] LevelUpStatusPoint = new int[100]
        {
            0, 
            0, 3, 3, 3, 3,
            4, 4, 4, 4, 4,
            5, 5, 5, 5, 5, 
            6, 6, 6, 6, 6, 
            7, 7, 7, 7, 7, 
            8, 8, 8, 8, 8,
            9, 9, 9, 9, 9, 
            10,10,10,10,10,
            11,11,11,11,11,
            12,12,12,12,12,
            13,13,13,13,13,
            14,14,14,14,14,
            15,15,15,15,15,
            16,16,16,16,16,
            17,17,17,17,17,
            18,18,18,18,18,
            19,19,19,19,19,
            20,20,20,20,20,
            21,21,21,21,21,
            22,22,22,22,
        };

        //StatusNeedPoint[point]
        public static int[] StatusNeedPoint = new int[99]
        {
            0,
            2, 2, 2, 2, 2, 2, 2, 2, 
            3, 3, 3, 3, 3, 3, 3, 3, 3, 3,
            4, 4, 4, 4, 4, 4, 4, 4, 4, 4,
            5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 
            6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 
            7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 
            8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 
            9, 9, 9, 9, 9, 9, 9, 9, 9, 9,
            10,10,10,10,10,10,10,10,10,10,
            11,11,11,11,11,11,11,11,11,11,
        };
    }
}
