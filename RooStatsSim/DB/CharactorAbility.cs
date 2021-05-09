using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RooStatsSim.DB.Abilitys;

namespace RooStatsSim.DB
{
    public class CharactorAbility : Abilities
    {
        private int _baseLevel = 1;
        private int _jobLevel = 1;

        public int BaseLevel
        {
            get { return _baseLevel; }
            set
            {
                if (value < 1)
                    return;
                _baseLevel = value;
            }
        }
        public int JobLevel
        {
            get { return _jobLevel; }
            set
            {
                if (value < 1)
                    return;
                _jobLevel = value;
            }
        }
    }
}
