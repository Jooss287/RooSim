using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RooStatsSim.DB.Abilitys;

namespace RooStatsSim.DB
{
    public class ConsumableItemInfo: Abilities
    {
        private int _level = 0;

        public int Level
        {
            get => _level;
            set
            {
                if (value < 0)
                    return;
                _level = value;
            }
        }
    }
}
