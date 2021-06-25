using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RooStatsSim.DB.DataType;

namespace RooStatsSim.DB.Abilitys
{
    enum BasicAbilityList
    {
        Hp,
        Sp,
        Atk,
        Matk,
        Def,
        Mdef,
    }

    public class SpecialAbility
    {
        //Percent Multiply Options
        public double HpPercent { get; set;}
        public double SpPercent { get; set; }
        public double AtkPercent { get; set; }
        public double MatkPercent { get; set; }
        public double DefPercent { get; set; }
        public double MdefPercent { get; set; }

        public Dictionary<ElementType, double> ElementDamage { get; set; }
        public Dictionary<ElementType, double> ElementResistance { get; set; }
        public Dictionary<TribeType, double> TribeDamage { get; set; }
        public Dictionary<TribeType, double> TribeResistance { get; set; }
        public Dictionary<SizeType, double> SizeDamage { get; set; }
        public Dictionary<SizeType, double> SizeResistance { get; set; }
        public Dictionary<MonsterKindType, double> KindDamage { get; set; }
        public Dictionary<MonsterKindType, double> KindResitance { get; set; }

        public SpecialAbility()
        {
            ElementDamage = new Dictionary<ElementType, double>();
            ElementResistance = new Dictionary<ElementType, double>();
            TribeDamage = new Dictionary<TribeType, double>();
            TribeResistance = new Dictionary<TribeType, double>();
            SizeDamage = new Dictionary<SizeType, double>();
            SizeResistance = new Dictionary<SizeType, double>();
            KindDamage = new Dictionary<MonsterKindType, double>();
            KindResitance = new Dictionary<MonsterKindType, double>();
    }

        public static SpecialAbility operator +(SpecialAbility lhs, SpecialAbility rhs)
        {
            return lhs;
        }
    }
}
