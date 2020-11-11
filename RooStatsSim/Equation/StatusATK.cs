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
            int BASE = user.Base_Level.Point;
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
        public static int GetStatusBonusATK(ATTACK_TYPE atk_type, GetValue getvalue)
        {
            int BASE = getvalue.User_Data.Base_Level.Point;
            int STR = getvalue.User_Data.Status.List[(int)STATUS_ENUM.STR].Point + getvalue.User_Data.Status.List[(int)STATUS_ENUM.STR].AddPoint;
            int DEX = getvalue.User_Data.Status.List[(int)STATUS_ENUM.DEX].Point + getvalue.User_Data.Status.List[(int)STATUS_ENUM.DEX].AddPoint;
            int statusBonusATK = 0;
            if (atk_type == ATTACK_TYPE.MELEE_TYPE)
            {
                statusBonusATK = (int)(getvalue.WeaponATK() * STR * STAT_WEIGHT);
            }
            else if (atk_type == ATTACK_TYPE.RANGE_TYPE)
            {
                statusBonusATK = (int)(getvalue.WeaponATK() * DEX * STAT_WEIGHT);
            }
            return statusBonusATK;
        }
    }
}
