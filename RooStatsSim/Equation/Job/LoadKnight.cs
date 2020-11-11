
using System;
using System.Collections.Generic;

using RooStatsSim.DB;
using RooStatsSim.User;
using RooStatsSim.Skills;

namespace RooStatsSim.Equation.Job
{
    class LordKnight : Equations
    {
        static List<double> dmg = new List<double>
            {
                0.1, 0.2, 0.3, 0.4, 0.5, 0.6, 0.7, 0.8, 0.9, 0.25
            };
        public List<SkillInfo> skillinfo = new List<SkillInfo>
        {
            new SkillInfo("컨센트레이션", 10, dmg),
            new SkillInfo("오러블레이드", 0, dmg),
            new SkillInfo("매그넘브레이크", 0, dmg)
        };

        public LordKnight() : base(ATTACK_TYPE.MELEE_TYPE)
        {
        }

        enum BUFF_SKILL
        {
            CONCENTRATION,
            AUROR_BLADE,
            MAGUNUM_BRAKE,
        }

        private bool buff_concentrate_lvl = false;
        private double buff_concentrate_ratio = 0.25;

        #region Skill
        
        #endregion


        #region override Skill
        protected override double GetBaseTotalATK(CALC_STANDARD calc_standard = CALC_STANDARD.NONE)
        {
            int Enabled_Concentrate = Convert.ToInt32(buff_list[(int)BUFF_SKILL.CONCENTRATION]);
            double buff_concentrate = Enabled_Concentrate * (User.WeaponATK() + StatusATK.GetStatusBonusATK(attack_type, User) + User.SmeltingATK()) * buff_concentrate_ratio;
            return base.GetBaseTotalATK(calc_standard) + Convert.ToInt32(buff_concentrate);
        }
        protected override double TotalEquipATK(double total_weapon_atk)
        {
            int Enabled_Concentrate = Convert.ToInt32(buff_list[(int)BUFF_SKILL.CONCENTRATION]);
            double buff_concentrate = Enabled_Concentrate * User.EquipATK() * buff_concentrate_ratio;
            return base.TotalEquipATK(total_weapon_atk) + buff_concentrate;
        }
        protected override double WinTotalATK(double total_equip_atk_inc)
        {
            int Enabled_Concentrate = Convert.ToInt32(buff_list[(int)BUFF_SKILL.CONCENTRATION]);
            double buff_concentrate = Enabled_Concentrate * (User.WeaponATK() + StatusATK.GetStatusBonusATK(attack_type, User) + User.EquipATK()) * buff_concentrate_ratio;
            return  base.WinTotalATK(total_equip_atk_inc) + buff_concentrate;
        }
        #endregion
    }
}
