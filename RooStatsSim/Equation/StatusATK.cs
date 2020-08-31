using RooStatsSim.DB;
using RooStatsSim.Equation.Job;

namespace RooStatsSim.Equation
{
    class StatusATK
    {
        const double STR_WEIGHT = 0.005;
        private readonly double statusATK;
        private readonly double statusBonusATK;

        public StatusATK(ATTACK_TYPE attack_type, ref ItemAbility ability, ref Status status)
        {
            if (attack_type == ATTACK_TYPE.MELEE_TYPE)
            {
                statusATK = status._str + (status._dex + status._luk) * 0.2 + status._base * 0.25;
                statusBonusATK = ability.ATK_weapon * status._str * STR_WEIGHT;
            }
            else if (attack_type == ATTACK_TYPE.RANGE_TYPE)
            {
                statusATK = status._dex + (status._str + status._luk) * 0.2 + status._base * 0.25;
                statusBonusATK = ability.ATK_weapon * status._dex * STR_WEIGHT;
            }
        }

        public double GetStatusATK() { return statusATK; }
        public double GetStatusBonusATK() { return statusBonusATK; }
    }
}
