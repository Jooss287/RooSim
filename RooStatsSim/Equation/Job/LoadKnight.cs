using RooStatsSim.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RooStatsSim.Equation.Job
{
    class LoadKnight : Equations
    {
        public LoadKnight(int param_attack_type, Status param_status, ItemAbility param_abilitys, MonsterDB param_mobDB)
        : base(param_attack_type, param_status, param_abilitys, param_mobDB)
        {
        }

        private bool buff_concentrate_lvl = true;
        private double buff_concentrate_ratio = 0.25;
        
        protected override double GetBaseTotalATK(CALC_STANDARD calc_standard = CALC_STANDARD.NONE)
        {
            double base_total_atk = abilities.ATK_weapon + abilities.ATK_smelting + statusATK.GetStatusBonusATK() + base.GetRandomATK() * (int)calc_standard;
            double buff_concentrate = Convert.ToInt32(buff_concentrate_lvl) * (abilities.ATK_weapon + statusATK.GetStatusBonusATK() + abilities.ATK_smelting) * buff_concentrate_ratio;
            return base_total_atk + Convert.ToInt32(buff_concentrate);
        }
        protected override double TotalEquipATK(double total_weapon_atk)
        {
            double base_total_atk = total_weapon_atk + abilities.ATK_equipment;
            double buff_concentrate = Convert.ToInt32(buff_concentrate_lvl) * (abilities.ATK_equipment) * buff_concentrate_ratio;
            return base_total_atk + buff_concentrate;
        }
        protected override double WinTotalATK(double total_equip_atk_inc)
        {
            double base_total_atk = statusATK.GetStatusATK() + GetMasteryATK() + total_equip_atk_inc;
            double buff_concentrate = Convert.ToInt32(buff_concentrate_lvl) * (abilities.ATK_weapon + statusATK.GetStatusBonusATK() + abilities.ATK_equipment) * buff_concentrate_ratio;
            return  base_total_atk + buff_concentrate;
        }

    }
}
