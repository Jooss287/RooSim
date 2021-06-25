using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RooStatsSim.DB.Abilitys
{
    public class AdvancedAbility
    {
        public double Aspd { get; set; }
        public double Spd { get; set; }
        public double CastingVarable { get; set; }
        public double CastingFixed { get; set; }
        public double CastingVarablePercent { get; set; }
        public double CastingFixedPercent { get; set; }
        public double HealingAmount { get; set; }
        public double HealingAmountReceived { get; set; }
        public double Critical { get; set; }
        public double CriticalDef { get; set; }
        public double CriticalDmg { get; set; }
        public double CriticalDmgDef { get; set; }
        public double PhysDmg { get; set; }
        public double PhysDmgMelee { get; set; }
        public double PhysDmgRange { get; set; }
        public int PhysDmgAddition { get; set; }
        public double PhysDmgReg { get; set; }
        public double PhysDmgMeleeReg { get; set; }
        public double PhysDmgRangeReg { get; set; }
        public double MageDmg { get; set; }
        public double MageDmgReg { get; set; }
        public int MageDmgAddition { get; set; }
        public double DefIgnore { get; set; }
        public double MDefIgnore { get; set; }
        public double CoolDownTime { get; set; }
        

        public static AdvancedAbility operator +(AdvancedAbility lhs, AdvancedAbility rhs)
        {
            lhs.Aspd += rhs.Aspd;
            lhs.Spd += rhs.Spd;
            lhs.CastingVarable += rhs.CastingVarable;
            lhs.CastingFixed += rhs.CastingFixed;
            lhs.CastingVarablePercent += rhs.CastingVarablePercent;
            lhs.CastingFixedPercent += rhs.CastingVarablePercent;
            lhs.HealingAmount += rhs.HealingAmount;
            lhs.HealingAmountReceived += rhs.HealingAmountReceived;
            lhs.Critical += rhs.Critical;
            lhs.CriticalDef += rhs.CriticalDef;
            lhs.CriticalDmg += rhs.CriticalDmg;
            lhs.CriticalDmgDef += rhs.CriticalDmgDef;
            lhs.PhysDmg += rhs.PhysDmg;
            lhs.PhysDmgMelee += rhs.PhysDmgMelee;
            lhs.PhysDmgRange += rhs.PhysDmgRange;
            lhs.PhysDmgReg += rhs.PhysDmgReg;
            lhs.PhysDmgMeleeReg += rhs.PhysDmgMeleeReg;
            lhs.PhysDmgRangeReg += rhs.PhysDmgRangeReg;
            lhs.MageDmg += rhs.MageDmg;
            lhs.MageDmgReg += rhs.MageDmgReg;
            lhs.DefIgnore += rhs.DefIgnore;
            lhs.MDefIgnore += rhs.MDefIgnore;
            lhs.CoolDownTime += rhs.CoolDownTime;
            return lhs;
        }
    }
}
