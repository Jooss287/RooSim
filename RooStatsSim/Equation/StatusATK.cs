using RooStatsSim.DB;
using RooStatsSim.Equation.Job;
using RooStatsSim.User;

namespace RooStatsSim.Equation
{
    class StatusATK
    {
        const double STR_WEIGHT = 0.005;
        private readonly double statusATK;
        private readonly double statusBonusATK;

        public StatusATK(ATTACK_TYPE attack_type, ref ItemAbility ability, UserData user)
        {
            int BASE = user.Level[(int)LEVEL_ENUM.BASE].Point;
            int STR = user.Status[(int)STATUS_ENUM.STR].Point + user.Status[(int)STATUS_ENUM.STR].AddPoint;
            int DEX = user.Status[(int)STATUS_ENUM.DEX].Point + user.Status[(int)STATUS_ENUM.DEX].AddPoint;
            int LUK = user.Status[(int)STATUS_ENUM.LUK].Point + user.Status[(int)STATUS_ENUM.LUK].AddPoint;

            if (attack_type == ATTACK_TYPE.MELEE_TYPE)
            {
                statusATK =  STR + (DEX + LUK) * 0.2 + BASE * 0.25;
                statusBonusATK = ability.ATK_weapon * STR* STR_WEIGHT;
            }
            else if (attack_type == ATTACK_TYPE.RANGE_TYPE)
            {
                statusATK = DEX + (STR + LUK) * 0.2 + BASE * 0.25;
                statusBonusATK = ability.ATK_weapon * DEX * STR_WEIGHT;
            }
        }

        public double GetStatusATK() { return statusATK; }
        public double GetStatusBonusATK() { return statusBonusATK; }
    }
}
