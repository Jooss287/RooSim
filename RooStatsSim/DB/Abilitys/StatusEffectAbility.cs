using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RooStatsSim.DB.Abilitys
{
    enum StatusEffectList
    {
        Stern,
        Fear,
        Slience,
        Frozen,
        Curse,
        Petrification,
        Dark,
        Posion,
        Sleep,
        Bleeding,
    }
    public class StatusEffectAbility
    {
        public Dictionary<string, double> StatusEffectAttack { get; set; }
        public Dictionary<string, double> StatusEffectResistance { get; set; }
    }
}
