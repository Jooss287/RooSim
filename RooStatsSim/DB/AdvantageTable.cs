using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RooStatsSim.DB
{
    public enum MONSTER_SIZE
    {
        SMALL,
        MIDDLE,
        LARGE,
        SIZE_CNT
    }
    public enum WEAPON_TYPE
    {
        HAND,
        DAGGER,
        SWARD,
        TWOHAND_SWARD,
        BLUNT,
        SPEAR,
        TWOHAND_SPEAR,
        AXE,
        TWOHAND_AXE,
        WAND,
        TWOHAND_WAND,
        BOW,
        JAMADHAR,
        WEAPON_CNT
    }

    public enum ELEMENT_TYPE
    {
        ELEMENT_CNT
    }
    
    class AdvantageTable
    {
        double[,] SizeRatio = new double[(int)WEAPON_TYPE.WEAPON_CNT, (int)MONSTER_SIZE.SIZE_CNT]
        {
            {1.0, 1.0, 1.0},
            {1.0, 0.75, 0.5 },
            {0.75, 1.0, 0.75 },
            {0.75, 0.75, 1.0 },
            {0.75, 1.0, 1.0 },
            {0.75, 0.75, 1.0 },
            {0.75, 0.75, 1.0 },
            {0.5, 0.75, 1.0 },
            {0.5, 0.75, 1.0 },
            {1.0, 1.0, 1.0 },
            {1.0, 1.0, 1.0 },
            {1.0, 1.0, 0.75 },
            {0.75, 1.0, 0.75 },
        };

        // double[,] ElementRatio
    }
    
}
