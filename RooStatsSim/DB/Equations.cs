using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RooStatsSim.DB
{
    class Equations
    {
        public Equations(int param_attack_type, Status param_status, ItemAbility param_abilitys)
        {
            attack_type = param_attack_type;
            status = param_status;
            abilities = param_abilitys;
        }

        private readonly int attack_type;
        private readonly ItemAbility abilities;
        private readonly Status status;

        const double STR_WEIGHT = 0.05;
        const double RANDOM_ATK_WEIGHT = 0.05;
        const int BASE_ATK = 5;
        const int BASE_MATK = 5;

        double GetStrATK()
        {
            return abilities.ATK_weapon * status._str * STR_WEIGHT;
        }
        double GetRandomATK()
        {
            return abilities.ATK_weapon * RANDOM_ATK_WEIGHT;
        }

        public int CalcATKdamage()
        {
            double status_atk;
            if (attack_type == 0)
                status_atk = BASE_ATK + status._str + (status._dex + status._luk) * 0.2 + status._base * 0.25;
            else
                status_atk = BASE_ATK + status._dex + (status._str + status._luk) * 0.2 + status._base * 0.25;
            status_atk *= 2;

            double tot_weapon_atk = abilities.ATK_weapon + abilities.ATK_smelting + GetStrATK();
            double tot_weapon_atk_min = tot_weapon_atk - GetRandomATK();
            double tot_weapon_atk_max = tot_weapon_atk + GetRandomATK();
            double tot_weapon_atk_inc = tot_weapon_atk /** SIZE_PANELTY*/;

            double tot_equip_atk = tot_weapon_atk_inc + abilities.ATK_equipment;
            double tot_equip_atk_inc = tot_equip_atk * abilities.element_increse * abilities.tribe_increse * abilities.size_increse * abilities.boss_increse;


            return 1;
        }
    }
}
