
using System.Collections.Generic;

using RooStatsSim.DB;
using RooStatsSim.User;
using RooStatsSim.DB.Job;
using RooStatsSim.DB.Job.JobInfo;
using RooStatsSim.UI.SkillWindow;

namespace RooStatsSim.Equation.Job
{
    class LordKnight : Equations
    {
        public Dictionary<string, SkillInfo> Skill { get; set; }
        public SwordmanJobBonus JobBonus_1st = new SwordmanJobBonus();
        public LoadKnightJobBonus JobBonus = new LoadKnightJobBonus();

        public LordKnight() : base(ATTACK_TYPE.MELEE_TYPE)
        {
        }
        #region override Skill
        protected override double GetBaseTotalATK(CALC_STANDARD calc_standard = CALC_STANDARD.NONE)
        {
            //int Enabled_Concentrate = Convert.ToInt32(buff_list[(int)BUFF_SKILL.CONCENTRATION]);
            //double buff_concentrate = Enabled_Concentrate * (User.WeaponATK() + StatusATK.GetStatusBonusATK(attack_type, User) + User.SmeltingATK()) * buff_concentrate_ratio;
            //return base.GetBaseTotalATK(calc_standard) + Convert.ToInt32(buff_concentrate);
            return 0;
        }
        protected override double TotalEquipATK(double total_weapon_atk)
        {
            //int Enabled_Concentrate = Convert.ToInt32(buff_list[(int)BUFF_SKILL.CONCENTRATION]);
            //double buff_concentrate = Enabled_Concentrate * User.EquipATK() * buff_concentrate_ratio;
            //return base.TotalEquipATK(total_weapon_atk) + buff_concentrate;
            return 0;
        }
        protected override double WinTotalATK(double total_equip_atk_inc)
        {
            //int Enabled_Concentrate = Convert.ToInt32(buff_list[(int)BUFF_SKILL.CONCENTRATION]);
            //double buff_concentrate = Enabled_Concentrate * (User.WeaponATK() + StatusATK.GetStatusBonusATK(attack_type, User) + User.EquipATK()) * buff_concentrate_ratio;
            //return  base.WinTotalATK(total_equip_atk_inc) + buff_concentrate;
            return 0;
        }
        #endregion
    }
}
