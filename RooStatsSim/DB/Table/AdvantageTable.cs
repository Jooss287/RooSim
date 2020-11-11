using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RooStatsSim.DB.Table
{
    class AdvantageTable
    {
        public static double[,] SizeRatio = new double[(int)WEAPON_TYPE.JAMADHAR+1, (int)MONSTER_SIZE.LARGE+1]
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
        public static double[,] ElementRatio = new double[(int)ELEMENT_TYPE.UNDEAD+1, (int)ELEMENT_TYPE.UNDEAD+1]
        {
            {0,    0,     0,     0,     0,     0,     0, 0,     -0.3, 0 },                     //NORMAL
            {0,    -0.75, -0.2,  0,     0.75,  0,     0, 0,     0,    0 },              //WIND
            {0,    0.75,  -0.75, -0.2,  0,     0,     0, 0,     0,    0 },              //EARTH
            {0,    0,     0.75,  -0.75, -0.2,  0,     0, 0,     0,    0.5 },            //FIRE
            {0,    -0.2,  0,     0.75,  -0.75, 0,     0, 0,     0,    0 },              //WATER
            {0,    0.25,  0.25,  0.25,  0.25,  -0.75, 0, -0.5,  0,    -0.75 }, //POISION
            {0,    0,     0,     0,     0,     0,     0, 0,     0.5,  0.75 },                   //HOLY
            {0,    0,     0,     0,     0,     0,     0, 0,     0,    0 },                        //DARK
            {-0.3, 0,     0,     0,     0,     0,     0, -0.25, 0.5,  0.25 },            //ASTRAL
            {0,    0,     0,     0,     0,     0,     0, 0,     0,    0 },                        //UNDEAD
        };

        public static double GetSizePanelty(WEAPON_TYPE attacker, MONSTER_SIZE defender)
        {
            return SizeRatio[Convert.ToInt32(attacker),Convert.ToInt32(defender)];
        }

        public static double GetElementRatio(ELEMENT_TYPE attacker, ELEMENT_TYPE defender)
        {
            return ElementRatio[Convert.ToInt32(attacker), Convert.ToInt32(defender)];
        }
    }
    
}
