using RooStatsSim.Equation;
using RooStatsSim.Equation.Job;
using System;
using System.Collections.Generic;

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
        public Equations(ATTACK_TYPE atk_type)
        {
            attack_type = atk_type;
        }

        protected readonly ATTACK_TYPE attack_type;
        protected Status status = null;
        protected ItemAbility abilities = null;
        protected MonsterDB mobDB = null;
        protected StatusATK statusATK = null;
        public double element_inc;
        public double size_panelty;
        protected bool[] buff_list;
        const double RANDOM_ATK_WEIGHT = 0.1;

        #region DB Set Functions
        public void SetDB(ref Status param_status, ref ItemAbility param_abilities, ref MonsterDB param_mobDB,
            ref double param_element, ref double param_size)
        {
            status = param_status;
            abilities = param_abilities;
            mobDB = param_mobDB;
            element_inc = param_element;
            size_panelty = param_size;
            statusATK = new StatusATK(attack_type, ref abilities, ref status);
        }

        public void SetBuffList(ref bool[] param_buff_list)
        {
            buff_list = param_buff_list;
        }
        #endregion

        #region Common Call Functions
        protected bool IsAlived()
        {
            if ((status == null) || (abilities == null) || (mobDB == null) || (statusATK == null))
                return false;
            return true;
        }
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
            if (!IsAlived())
                return 0;

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
        public int CalcStatusWinATK()
        {
            if (IsAlived())
                return 0;

            double total_weapon_atk = GetWeaponATK();
            double total_equip_atk = WinTotalEquipATK(total_weapon_atk);
            double total_equip_atk_inc = WinTotalEquipATKinc(total_equip_atk);
            double tot_atk = WinTotalATK(total_equip_atk_inc);

            return Convert.ToInt32(tot_atk);
        }
        #endregion

        public int CalcReverseATK(int sATK)
        {
            if (IsAlived())
                return 0;

            double status_atk = statusATK.GetStatusATK();
            double equipATK = (sATK - abilities.ATK_mastery - status_atk) / abilities.ATK_percent - abilities.ATK_weapon - statusATK.GetStatusBonusATK();

            return Convert.ToInt32(Math.Floor(equipATK));
        }
    }
}
