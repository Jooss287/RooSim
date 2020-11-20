using RooStatsSim.DB;
using RooStatsSim.DB.Table;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RooStatsSim.User
{
    public class UserItem : ItemDB
    {
        public UserItem()
        {
            MakeNormalProperty();
        }
        
        public void MakeNormalProperty()
        {
            foreach(ITYPE type in Enum.GetValues(typeof(ITYPE)))
            {
                i_option[type] = 0;
            }

            d_option[DTYPE.ASPD] = 0;
            d_option[DTYPE.MOVING_SPEED] = 0;
        }
        public static UserItem operator +(UserItem a, ItemDB b)
        {
            AddOption<ITYPE>(ref a.i_option, b.i_option);
            AddOption<DTYPE>(ref a.d_option, b.d_option);
            AddOption<STATUS_EFFECT_TYPE>(ref a.se_attackrate_option, b.se_attackrate_option);
            AddOption<STATUS_EFFECT_TYPE>(ref a.se_resistance_option, b.se_resistance_option);
            AddOption<ELEMENT_TYPE>(ref a.element_inc_option, b.element_inc_option);
            AddOption<ELEMENT_TYPE>(ref a.element_dec_option, b.element_dec_option);
            AddOption<ELEMENT_TYPE>(ref a.element_damage_option, b.element_damage_option);
            AddOption<MONSTER_SIZE>(ref a.size_inc_option, b.size_inc_option);
            AddOption<MONSTER_SIZE>(ref a.size_dec_option, b.size_dec_option);
            AddOption<TRIBE_TYPE>(ref a.tribe_inc_option, b.tribe_inc_option);
            AddOption<TRIBE_TYPE>(ref a.tribe_dec_option, b.tribe_dec_option);
            AddOption<MONSTER_KINDS_TYPE>(ref a.mobtype_inc_option, b.mobtype_inc_option);
            AddOption<MONSTER_KINDS_TYPE>(ref a.mobtype_dec_option, b.mobtype_dec_option);
            return a;
        }

        public ItemDB CalcIftypeValues(UserData user)
        {
            ItemDB item_iftype = new ItemDB();

            foreach (EQUIP.EquipItem equip_item in user.Equip.List)
            {
                foreach (KeyValuePair<IFTYPE, AbilityPerStatus> option in equip_item.Equip.IF_OPTION)
                {
                    if (option.Value.Calc != null)
                        item_iftype += option.Value.Calc(user);
                    else
                        item_iftype += option.Value.Calc_refine(user, equip_item.Smelting);
                }
            }
            return item_iftype;
        }
    }
}
