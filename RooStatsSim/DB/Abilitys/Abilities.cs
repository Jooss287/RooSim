using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RooStatsSim.DB.Abilitys
{
    public abstract class Abilities
    {
        public BasicAbility BasicAbilities { get; set; }
        public AdvancedAbility AdvancedAbilities { get; set; }
        public SpecialAbility SpecialAbilities { get; set; }
        public StatusEffectAbility StatusEffectAbilities { get; set; }

        public Abilities()
        {
            BasicAbilities = new BasicAbility();
            AdvancedAbilities = new AdvancedAbility();
            SpecialAbilities = new SpecialAbility();
            StatusEffectAbilities = new StatusEffectAbility();
        }
    }
}
