using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RooStatsSim.DB
{
    class Equations
    {
        public Equations(ItemAbility param_abilitys)
        {
            abilities = param_abilitys;
        }

        private readonly ItemAbility abilities;
        const double STR_WEIGHT = 0.05;
        const double RANDOM_ATK_WEIGHT = 0.05;
        const int BASE_ATK = 5;
        const int BASE_MATK = 5;

        double GetStrATK(int _atk_weapon, int _str)
        {
            return _atk_weapon * _str / STR_WEIGHT;
        }
        double GetRandomATK(int _atk_weapon)
        {
            return _atk_weapon * RANDOM_ATK_WEIGHT;
        }
    }
}
