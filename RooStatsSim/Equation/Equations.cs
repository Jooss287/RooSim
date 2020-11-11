using RooStatsSim.Equation;
using RooStatsSim.User;
using System;

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
        public Equations(ATTACK_TYPE atk_type=ATTACK_TYPE.MELEE_TYPE)
        {
            attack_type = atk_type;
            User = new GetValue();
        }

        protected readonly ATTACK_TYPE attack_type;
        //protected Status status = null;
        protected GetValue User;
        protected bool[] buff_list;
        const double RANDOM_ATK_WEIGHT = 0.1;

        #region DB Set Functions

        public void SetBuffList(ref bool[] param_buff_list)
        {
            buff_list = param_buff_list;
        }
        #endregion

        #region Common Call Functions
        protected virtual double GetRandomATK() { return User.WeaponATK() * RANDOM_ATK_WEIGHT; }

        protected virtual double GetWeaponATK(CALC_STANDARD calc_standard = CALC_STANDARD.NONE) {
            return User.WeaponATK() + StatusATK.GetStatusBonusATK(attack_type, User) + GetRandomATK() * (int)calc_standard;
        }
        protected virtual double GetBaseTotalATK(CALC_STANDARD calc_standard = CALC_STANDARD.NONE) {
            return User.WeaponATK() + User.SmeltingATK() + StatusATK.GetStatusBonusATK(attack_type, User) + GetRandomATK() * (int)calc_standard;
        }
        protected virtual double GetTotalEquipATKRatio() {
            return User.ElementInteraction() * User.ElementIncreseDamage() * User.TribeIncreseDamage() * User.SizeIncreseDamage() * User.MonsterTypeIncreseDamage()
                * User.PercentATK() * User.DefenseRatio();
        }
        protected virtual double GetTotalATKRatio() {
            return User.PercentPhysicalDamage(attack_type);
        }
        protected virtual double GetMasteryATK() {
            return User.MasteryATK();
        }
        #endregion

        #region Attack Equation
        protected virtual double TotalWeaponATK(CALC_STANDARD calc_standard = CALC_STANDARD.NONE) {
            return GetBaseTotalATK(calc_standard) * User.WeaponSizePanelty();
        }
        protected virtual double TotalEquipATK(double total_weapon_atk)
        {
            return total_weapon_atk + User.EquipATK();
        }
        protected virtual double TotalEquipATKinc(double total_equip_atk)
        {
            return total_equip_atk * GetTotalEquipATKRatio();
        }
        protected virtual double TotalATK(double total_equip_atk_inc)
        {
            return StatusATK.GetStatusATK(attack_type, User.User_Data) * 2 + GetMasteryATK() + total_equip_atk_inc;
        }
        protected virtual double TotalATKinc(double total_atk)
        {
            return total_atk * GetTotalATKRatio() + User.AdditionalPhysicalDamage();
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
            return Math.Round(total_equip_atk * User.PercentATK());
        }
        protected virtual double WinTotalEquipATK(double total_weapon_atk)
        {
            return total_weapon_atk + User.EquipATK();
        }
        protected virtual double WinTotalATK(double total_equip_atk_inc)
        {
            return StatusATK.GetStatusATK(attack_type, User.User_Data) + GetMasteryATK() + total_equip_atk_inc;
        }
        public int CalcStatusWinATK()
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
            double status_atk = StatusATK.GetStatusATK(attack_type, User.User_Data);
            double equipATK = (sATK - User.MasteryATK() - status_atk) / User.PercentATK()- User.WeaponATK() - StatusATK.GetStatusBonusATK(attack_type, User);

            return Convert.ToInt32(Math.Floor(equipATK));
        }
    }
}
