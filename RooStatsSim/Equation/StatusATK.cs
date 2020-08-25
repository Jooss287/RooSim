using RooStatsSim.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RooStatsSim.Equation
{
    class StatusATK
    {
        const double STR_WEIGHT = 0.005;
        private readonly double statusATK;
        private readonly double statusBonusATK;

        public StatusATK(int attack_type, ref ItemAbility ability, ref Status status)
        {
            if (attack_type == 0)
            {
                statusATK = status._str + (status._dex + status._luk) * 0.2 + status._base * 0.25;
                statusBonusATK = ability.ATK_weapon * status._str * STR_WEIGHT;
            }
            else
            {
                statusATK = status._dex + (status._str + status._luk) * 0.2 + status._base * 0.25;
                statusBonusATK = ability.ATK_weapon * status._dex * STR_WEIGHT;
            }
        }

        public double GetStatusATK() { return statusATK; }
        public double GetStatusBonusATK() { return statusBonusATK; }
    }
}
