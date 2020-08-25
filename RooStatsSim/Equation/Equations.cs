using RooStatsSim.Equation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RooStatsSim.DB
{
    enum CALC_STANDARD
    {
        NONE = 0,
        MIN_DAMAGE = -1,
        MAX_DAMAGE = 1
    }
    class Equations
    {
        public Equations(int param_attack_type, Status param_status, ItemAbility param_abilitys, MonsterDB param_mobDB)
        {
            attack_type = param_attack_type;
            status = param_status;
            abilities = param_abilitys;
            mobDB = param_mobDB;

            statusATK = new StatusATK(attack_type, ref abilities, ref status);
        }

        protected readonly int attack_type;
        protected readonly ItemAbility abilities;
        protected readonly Status status;
        protected readonly MonsterDB mobDB;
        protected readonly StatusATK statusATK;
        public double element_inc;
        public double size_panelty;
        const double RANDOM_ATK_WEIGHT = 0.1;

        #region Common Call Functions
        protected virtual double GetRandomATK() { return abilities.ATK_weapon * RANDOM_ATK_WEIGHT; }
        protected virtual double GetWeaponATK(CALC_STANDARD calc_standard = CALC_STANDARD.NONE) {
            return abilities.ATK_weapon + statusATK.GetStatusBonusATK() + GetRandomATK() * (int)calc_standard;
        }
        protected virtual double GetBaseTotalATK(CALC_STANDARD calc_standard = CALC_STANDARD.NONE) {
            return abilities.ATK_weapon + abilities.ATK_smelting + statusATK.GetStatusBonusATK() + GetRandomATK() * (int)calc_standard;
        }
        protected virtual double GetTotalEquipATKRatio() {
            return element_inc * abilities.element_increse * abilities.tribe_increse * abilities.size_increse * abilities.boss_increse * abilities.ATK_percent
                * Defense.GetDefRatio(mobDB.defense, abilities.def_ignore);
        }
        protected virtual double GetTotalATKRatio() {
            return abilities.PDamage_percent * abilities.PDamage_attack_type;
        }
        protected virtual double GetMasteryATK() {
            return abilities.ATK_mastery;
        }
        #endregion

        #region Attack Equation
        protected virtual double TotalWeaponATK(CALC_STANDARD calc_standard = CALC_STANDARD.NONE) {
            return GetBaseTotalATK(calc_standard) * size_panelty;
        }

        protected virtual double TotalEquipATK(double total_weapon_atk)
        {
            return total_weapon_atk + abilities.ATK_equipment;
        }
        protected virtual double TotalEquipATKinc(double total_equip_atk)
        {
            return total_equip_atk * GetTotalEquipATKRatio();
        }
        protected virtual double TotalATK(double total_equip_atk_inc)
        {
            return statusATK.GetStatusATK() * 2 + GetMasteryATK() + total_equip_atk_inc;
        }
        protected virtual double TotalATKinc(double total_atk)
        {
            return total_atk * GetTotalATKRatio() + abilities.PDamage_addition;
        }

        public int CalcATKdamage(CALC_STANDARD calc_standard = CALC_STANDARD.NONE)
        {
            double total_weapon_atk = TotalWeaponATK(calc_standard);
            double total_equip_atk = TotalEquipATK(total_weapon_atk);
            double total_equip_atk_inc = TotalEquipATKinc(total_equip_atk);
            
            double total_atk = TotalATK(total_equip_atk_inc);
            double tot_atk_inc = TotalATKinc(total_atk);

            return Convert.ToInt32(Math.Floor(tot_atk_inc));
        }
        #endregion

        #region StatusWindow ATK Equation
        protected virtual double WinTotalEquipATKinc(double total_equip_atk)
        {
            return Math.Round(total_equip_atk * abilities.ATK_percent);
        }
        protected virtual double WinTotalEquipATK(double total_weapon_atk)
        {
            return total_weapon_atk + abilities.ATK_equipment;
        }
        protected virtual double WinTotalATK(double total_equip_atk_inc)
        {
            return statusATK.GetStatusATK() + GetMasteryATK() + total_equip_atk_inc;
        }
        public int CalcStatusWinATK(CALC_STANDARD calc_standard = CALC_STANDARD.NONE)
        {
            double total_weapon_atk = GetWeaponATK();
            double total_equip_atk = WinTotalEquipATK(total_weapon_atk);
            double total_equip_atk_inc = WinTotalEquipATKinc(total_equip_atk);
            double tot_atk = WinTotalATK(total_equip_atk_inc);

            return Convert.ToInt32(tot_atk);
        }
        #endregion

        public int CalcReverseATK(int sATK)
        {
            double status_atk = statusATK.GetStatusATK();
            double equipATK = (sATK - abilities.ATK_mastery - status_atk) / abilities.ATK_percent - abilities.ATK_weapon - statusATK.GetStatusBonusATK();

            return Convert.ToInt32(Math.Floor(equipATK));
        }
    }
}
