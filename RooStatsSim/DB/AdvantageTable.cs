using System;
using System.Collections.Generic;
using System.Data;
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
        NORMAL,
        WIND,
        EARTH,
        FIRE,
        WATER,
        POISON,
        HOLY,
        DARK,
        ASTRAL,
        UNDEAD,
        ELEMENT_CNT
    }
    class AdvantageTable
    {
        readonly double[,] SizeRatio = new double[(int)WEAPON_TYPE.WEAPON_CNT, (int)MONSTER_SIZE.SIZE_CNT]
        {
            {1.0, 1.0, 1.0},        //HAND
            {1.0, 0.75, 0.5 },      //DAGGER
            {0.75, 1.0, 0.75 },     //SWARD
            {0.75, 0.75, 1.0 },     //TWOHAND_SWARD
            {0.75, 1.0, 1.0 },      //BLUNT
            {0.75, 0.75, 1.0 },     //SPEAR
            {0.75, 0.75, 1.0 },     //TOWHAD_SPEAR
            {0.5, 0.75, 1.0 },      //AXE
            {0.5, 0.75, 1.0 },      //TOWHAND_AXE
            {1.0, 1.0, 1.0 },       //WAND
            {1.0, 1.0, 1.0 },       //TWOHAND_WAND
            {1.0, 1.0, 0.75 },      //BOW
            {0.75, 1.0, 0.75 },     //JAMADHAR
        };

        //  [ATTACKER_ELEMENT, DEFENSER_ELEMENT]
        readonly double[,] ElementRatio = new double[(int)ELEMENT_TYPE.ELEMENT_CNT, (int)ELEMENT_TYPE.ELEMENT_CNT]
        {
            {0, 0, 0, 0, 0, 0, 0, 0, -0.3, 0 },                     //NORMAL
            {0, -0.75, -0.2, 0, 0.75, 0, 0, 0, 0, 0 },              //WIND
            {0, 0.75, -0.75, -0.2, 0, 0, 0, 0, 0, 0 },              //EARTH
            {0, 0, 0.75, -0.75, -0.2, 0, 0, 0, 0, 0.5 },            //FIRE
            {0, -0.2, 0, 0.75, -0.75, 0, 0, 0, 0, 0 },              //WATER
            {0, 0.25, 0.25, 0.25, 0.25, -0.75, 0, -0.5, 0, -0.75 }, //POISION
            {0, 0, 0, 0, 0, 0, 0, 0, 0.5, 0.75 },                   //HOLY
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },                        //DARK
            {-0.3, 0, 0, 0, 0, 0, 0, -0.25, 0.5, 0.25 },            //ASTRAL
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },                        //UNDEAD
        };

        public double GetSizePanelty(WEAPON_TYPE attacker, WEAPON_TYPE defender)
        {
            return SizeRatio[Convert.ToInt32(attacker),Convert.ToInt32(defender)];
        }

        public double GetElementRatio(ELEMENT_TYPE attacker, ELEMENT_TYPE defender)
        {
            return ElementRatio[Convert.ToInt32(attacker), Convert.ToInt32(defender)];
        }
    }
    
}
