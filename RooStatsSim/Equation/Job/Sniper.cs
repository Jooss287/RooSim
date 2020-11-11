
using System.Collections.Generic;

using RooStatsSim.DB;
using RooStatsSim.Skills;
using RooStatsSim.User;

namespace RooStatsSim.Equation.Job
{
    class Sniper : Equations
{
        static List<double> dmg = new List<double>
        {
            0.1, 0.2, 0.3, 0.4, 0.5, 0.6, 0.7, 0.8, 0.9, 0.25
        };
        public List<SkillInfo> skillinfo = new List<SkillInfo>
    {
        new SkillInfo("트루 사이트", 10, dmg),
        new SkillInfo("화살 수련", 0, dmg)
    };

        public Sniper() : base(ATTACK_TYPE.RANGE_TYPE)
        {
        }

        enum BUFF_SKILL
        {
            TRUE_SIGHT,
            ARROW_TRAINING,
        }
    }

}
