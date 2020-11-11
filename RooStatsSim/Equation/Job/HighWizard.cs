using System.Collections.Generic;

using RooStatsSim.DB;
using RooStatsSim.Skills;
using RooStatsSim.User;

namespace RooStatsSim.Equation.Job
{
    class HighWizard : Equations
    {
        static List<double> dmg = new List<double>
        {
            0.1, 0.2, 0.3, 0.4, 0.5, 0.6, 0.7, 0.8, 0.9, 0.25
        };
        public List<SkillInfo> skillinfo = new List<SkillInfo>
    {
        new SkillInfo("NULL", 10, dmg),
    };

        public HighWizard() : base(ATTACK_TYPE.MELEE_TYPE)
        {
        }

        enum BUFF_SKILL
        {
            NULL,
        }
    }

}
