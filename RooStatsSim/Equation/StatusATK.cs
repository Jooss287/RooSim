using RooStatsSim.DB;
using RooStatsSim.Equation.Job;
using RooStatsSim.User;

namespace RooStatsSim.Equation
{
    class StatusATK
    {
        const double STAT_WEIGHT = 0.005;
        
        public static int GetStatusATK(ATTACK_TYPE atk_type, UserData user)
        {
            int BASE = user.Level.List[(int)LEVEL_ENUM.BASE].Point;
            int STR = user.Status.List[(int)STATUS_ENUM.STR].Point + user.Status.List[(int)STATUS_ENUM.STR].AddPoint;
            int DEX = user.Status.List[(int)STATUS_ENUM.DEX].Point + user.Status.List[(int)STATUS_ENUM.DEX].AddPoint;
            int LUK = user.Status.List[(int)STATUS_ENUM.LUK].Point + user.Status.List[(int)STATUS_ENUM.LUK].AddPoint;
            int statusATK = 0;
            if (atk_type == ATTACK_TYPE.MELEE_TYPE)
            {
                statusATK = (int)(STR + (DEX + LUK) * 0.2 + BASE * 0.25);
            }
            else if (atk_type == ATTACK_TYPE.RANGE_TYPE)
            {
                statusATK = (int)(DEX + (STR + LUK) * 0.2 + BASE * 0.25);
            }
            return statusATK;
        }
        public static int GetStatusBonusATK(ATTACK_TYPE atk_type, UserData user)
        {
            int BASE = user.Level.List[(int)LEVEL_ENUM.BASE].Point;
            int STR = user.Status.List[(int)STATUS_ENUM.STR].Point + user.Status.List[(int)STATUS_ENUM.STR].AddPoint;
            int DEX = user.Status.List[(int)STATUS_ENUM.DEX].Point + user.Status.List[(int)STATUS_ENUM.DEX].AddPoint;
            int LUK = user.Status.List[(int)STATUS_ENUM.LUK].Point + user.Status.List[(int)STATUS_ENUM.LUK].AddPoint;
            int statusBonusATK = 0;
            if (atk_type == ATTACK_TYPE.MELEE_TYPE)
            {
                statusBonusATK = (int)(user.User_Item.i_option[ITYPE.WEAPON_ATK] * STR * STAT_WEIGHT);
            }
            else if (atk_type == ATTACK_TYPE.RANGE_TYPE)
            {
                statusBonusATK = (int)(user.User_Item.i_option[ITYPE.WEAPON_ATK] * DEX * STAT_WEIGHT);
            }
            return statusBonusATK;
        }
    }
}
