using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace RooStatsSim.DB.Abilitys
{
    public class BasicAbility
    {
        public StatusPoint Status { get; set; }

        public int Hp { get; set; }
        public int Sp { get; set; }
        public int Atk { get; set; }
        public int AtkStatus { get; set; }
        public int AtkRefine { get; set; }
        public int AtkMastery { get; set; }
        public int Matk { get; set; }
        public int MatkStatus { get; set; }
        public int MatkRefine { get; set; }
        public int DefStats { get; set; }
        public int DefEquip { get; set; }
        public int DefRefine { get; set; }
        public int MdefStats { get; set; }
        public int MdefEquip { get; set; }
        public int MdefRefine { get; set; }
        public int HpRecovery { get; set; }
        public int SpRecovery { get; set; }
        public int Hit { get; set; }
        public int Flee { get; set; }

        public BasicAbility()
        {
            Status = new StatusPoint();
        }
        public static BasicAbility operator +(BasicAbility lhs, BasicAbility rhs)
        {
            lhs.Status += rhs.Status;
            lhs.Hp += rhs.Hp;
            lhs.Sp += rhs.Sp;
            lhs.Atk += rhs.Atk;
            lhs.AtkStatus += rhs.AtkStatus;
            lhs.AtkRefine += rhs.AtkRefine;
            lhs.AtkMastery += rhs.AtkMastery;
            lhs.Matk += rhs.Matk;
            lhs.MatkStatus += rhs.MatkStatus;
            lhs.MatkRefine += rhs.MatkRefine;
            lhs.DefStats += rhs.DefStats;
            lhs.DefEquip += rhs.DefEquip;
            lhs.MdefStats += rhs.MdefStats;
            lhs.MdefEquip += rhs.MdefEquip;
            lhs.MdefRefine += rhs.MdefRefine;
            lhs.HpRecovery += rhs.HpRecovery;
            lhs.SpRecovery += rhs.SpRecovery;
            lhs.Hit += rhs.Hit;
            lhs.Flee += rhs.Flee;
            return lhs;
        }
    }
}
