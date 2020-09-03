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
                statusATK = status.Str+ (status.Dex+ status.Luk) * 0.2 + status.Base* 0.25;
                statusBonusATK = ability.ATK_weapon * status.Str* STR_WEIGHT;
            }
            else if (attack_type == ATTACK_TYPE.RANGE_TYPE)
            {
                statusATK = status.Dex+ (status.Str+ status.Luk) * 0.2 + status.Base* 0.25;
                statusBonusATK = ability.ATK_weapon * status.Dex* STR_WEIGHT;
            }
        }

        public double GetStatusATK() { return statusATK; }
        public double GetStatusBonusATK() { return statusBonusATK; }
    }
}
