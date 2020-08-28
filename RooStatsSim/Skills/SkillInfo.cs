using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RooStatsSim.Skills
{
    class SkillInfo
    {
        string _name;
        int _level;
        List<double> _damage;

        public SkillInfo(string name, int level, List<double> damage)
        {
            _name = name;
            _level = level;
            _damage = damage;
        }
    }
}
