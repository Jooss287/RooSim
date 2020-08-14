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
        NONE,
        MIN_DAMAGE,
        MAX_DAMAGE
    }
    class Equations
    {
        public Equations(int param_attack_type, Status param_status, ItemAbility param_abilitys, MonsterDB param_mobDB)
        {
            attack_type = param_attack_type;
            status = param_status;
            abilities = param_abilitys;
            mobDB = param_mobDB;
        }

        private readonly int attack_type;
        private readonly ItemAbility abilities;
        private readonly Status status;
        private readonly MonsterDB mobDB;

        const double STR_WEIGHT = 0.005;
        const double RANDOM_ATK_WEIGHT = 0.1;
        public double element_inc = 0;
        public double size_panelty = 1;

        double GetStrATK()              { return abilities.ATK_weapon * status._str * STR_WEIGHT; }
        double GetDexATK()              { return abilities.ATK_weapon * status._dex * STR_WEIGHT; }
        double GetRandomATK()           { return abilities.ATK_weapon * RANDOM_ATK_WEIGHT; }
        double GetDefRatio()
        {
            double def_ignore = 1 - 0.01 * abilities.def_ignore;
            double def_ratio = (4000 + (mobDB.defense * def_ignore)) / (4000 + (mobDB.defense * def_ignore * 10));
            return def_ratio;
        }

        public int CalcATKdamage(CALC_STANDARD calc_standard = CALC_STANDARD.NONE)
        {
            double status_atk;
            double tot_weapon_atk;
            double randomATK = 0;

            switch (calc_standard)
            {
                case CALC_STANDARD.NONE:
                    randomATK = 0;
                    break;
                case CALC_STANDARD.MIN_DAMAGE:
                    randomATK = -1 * GetRandomATK();
                    break;
                case CALC_STANDARD.MAX_DAMAGE:
                    randomATK = 1 * GetRandomATK();
                    break;
            }

            if (attack_type == 0)
            {
                status_atk = status._str + (status._dex + status._luk) * 0.2 + status._base * 0.25;
                tot_weapon_atk = abilities.ATK_weapon + abilities.ATK_smelting + GetStrATK() + randomATK;
            }
            else
            {
                status_atk = status._dex + (status._str + status._luk) * 0.2 + status._base * 0.25;
                tot_weapon_atk = abilities.ATK_weapon + abilities.ATK_smelting + GetDexATK() + randomATK;
            }
            status_atk *= 2;

            double tot_weapon_atk_ratio = (0.01 * size_panelty);
            double tot_weapon_atk_inc = tot_weapon_atk * tot_weapon_atk_ratio;

            double tot_equip_atk = tot_weapon_atk_inc + abilities.ATK_equipment;

            double tot_equip_atk_ratio = (1 + element_inc) * (1 + 0.01*abilities.element_increse) * (1 + 0.01*abilities.tribe_increse)
                * (1 + 0.01*abilities.size_increse) * (1 + 0.01*abilities.boss_increse) * (1 + 0.01*abilities.ATK_percent) * GetDefRatio();
            double tot_equip_atk_inc = tot_equip_atk * tot_equip_atk_ratio;
            

            double tot_atk = status_atk + abilities.ATK_mastery + tot_equip_atk_inc;
            double tot_atk_inc = tot_atk * (1 + 0.01*abilities.PDamage_percent) * (1 + 0.01*abilities.PDamage_attack_type) + abilities.PDamage_addition;
            double tot_atk_inc_def = tot_atk_inc ;

            return Convert.ToInt32(Math.Floor(tot_atk_inc_def));
        }

        public int CalcStatusWinATK(CALC_STANDARD calc_standard = CALC_STANDARD.NONE)
        {
            double status_atk;
            double tot_weapon_atk;
            double randomATK = 0;

            switch (calc_standard)
            {
                case CALC_STANDARD.NONE:
                    randomATK = 0;
                    break;
                case CALC_STANDARD.MIN_DAMAGE:
                    randomATK = -1 * GetRandomATK();
                    break;
                case CALC_STANDARD.MAX_DAMAGE:
                    randomATK = 1 * GetRandomATK();
                    break;
            }

            if (attack_type == 0)
            {
                status_atk = status._str + (status._dex + status._luk) * 0.2 + status._base * 0.25;
                tot_weapon_atk = abilities.ATK_weapon + GetStrATK() + randomATK;
            }
            else
            {
                status_atk = status._dex + (status._str + status._luk) * 0.2 + status._base * 0.25;
                tot_weapon_atk = abilities.ATK_weapon + GetDexATK() + randomATK;
            }

            double tot_weapon_atk_ratio = (0.01 * size_panelty);
            double tot_weapon_atk_inc = tot_weapon_atk * tot_weapon_atk_ratio;

            double tot_equip_atk = tot_weapon_atk_inc + abilities.ATK_equipment;

            double tot_equip_atk_ratio = (1 + 0.01 * abilities.ATK_percent);
            double tot_equip_atk_inc = tot_equip_atk * tot_equip_atk_ratio;
            // tot_equip_atk_inc는 반올림해주는것같음


            double tot_atk = status_atk + abilities.ATK_mastery + tot_equip_atk_inc;

            return Convert.ToInt32(Math.Floor(tot_atk));
        }
    }
}
