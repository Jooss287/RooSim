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

        private readonly int attack_type;
        private readonly ItemAbility abilities;
        private readonly Status status;
        private readonly MonsterDB mobDB;
        private readonly StatusATK statusATK;
        public double element_inc;
        public int size_panelty;
        const double RANDOM_ATK_WEIGHT = 0.1;

        double GetRandomATK() { return abilities.ATK_weapon * RANDOM_ATK_WEIGHT; }

        public int CalcATKdamage(CALC_STANDARD calc_standard = CALC_STANDARD.NONE)
        {
            double status_atk = statusATK.GetStatusATK() * 2;
            double tot_weapon_atk = abilities.ATK_weapon + abilities.ATK_smelting + statusATK.GetStatusBonusATK() + GetRandomATK() * (int)calc_standard;

            double tot_weapon_atk_ratio = (0.01 * size_panelty);
            double tot_weapon_atk_inc = tot_weapon_atk * tot_weapon_atk_ratio;

            double tot_equip_atk = tot_weapon_atk_inc + abilities.ATK_equipment;

            double tot_equip_atk_ratio = (1 + element_inc) * (1 + 0.01*abilities.element_increse) * (1 + 0.01*abilities.tribe_increse)
                * (1 + 0.01*abilities.size_increse) * (1 + 0.01*abilities.boss_increse) * (1 + 0.01*abilities.ATK_percent) * Defense.GetDefRatio(mobDB.defense, abilities.def_ignore);
            double tot_equip_atk_inc = tot_equip_atk * tot_equip_atk_ratio;
            

            double tot_atk = status_atk + abilities.ATK_mastery + tot_equip_atk_inc;
            double tot_atk_inc = tot_atk * (1 + 0.01*abilities.PDamage_percent) * (1 + 0.01*abilities.PDamage_attack_type) + abilities.PDamage_addition;
            double tot_atk_inc_def = tot_atk_inc ;

            return Convert.ToInt32(Math.Floor(tot_atk_inc_def));
        }

        public int CalcStatusWinATK(CALC_STANDARD calc_standard = CALC_STANDARD.NONE)
        {
            double status_atk = statusATK.GetStatusATK();
            double tot_weapon_atk = abilities.ATK_weapon + statusATK.GetStatusBonusATK() + GetRandomATK()*(int)calc_standard;

            double tot_weapon_atk_ratio = (0.01 * size_panelty);
            double tot_weapon_atk_inc = tot_weapon_atk * tot_weapon_atk_ratio;

            double tot_equip_atk = tot_weapon_atk_inc + abilities.ATK_equipment;

            double tot_equip_atk_ratio = (1 + 0.01 * abilities.ATK_percent);
            double tot_equip_atk_inc = tot_equip_atk * tot_equip_atk_ratio;
            // tot_equip_atk_inc는 반올림해주는것같음


            double tot_atk = status_atk + abilities.ATK_mastery + tot_equip_atk_inc;

            return Convert.ToInt32(Math.Floor(tot_atk));
        }

        public int CalcReverseATK(int sATK)
        {
            double status_atk = statusATK.GetStatusATK();
            double equipATK = (sATK - abilities.ATK_mastery - status_atk) / (1 + 0.01*abilities.ATK_percent) - abilities.ATK_weapon - statusATK.GetStatusBonusATK();

            return Convert.ToInt32(Math.Floor(equipATK));
        }
    }
}
