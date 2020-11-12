using RooStatsSim.DB;
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
            AddOption(ref a.if_option, b.if_option);

            AddOption<STATUS_EFFECT_TYPE>(ref a.se_attackrate_option, b.se_attackrate_option);
            AddOption<ELEMENT_TYPE>(ref a.element_inc_option, b.element_inc_option);
            AddOption<ELEMENT_TYPE>(ref a.element_dec_option, b.element_dec_option);
            AddOption<ELEMENT_TYPE>(ref a.element_damage_option, b.element_damage_option);
            AddOption<MONSTER_SIZE>(ref a.size_inc_option, b.size_inc_option);
            AddOption<MONSTER_SIZE>(ref a.size_dec_option, b.size_dec_option);
            AddOption<TRIBE_TYPE>(ref a.tribe_inc_option, b.tribe_inc_option);
            AddOption<TRIBE_TYPE>(ref a.tribe_dec_option, b.tribe_dec_option);
            AddOption<MONSTER_TYPE>(ref a.mobtype_inc_option, b.mobtype_inc_option);
            AddOption<MONSTER_TYPE>(ref a.mobtype_dec_option, b.mobtype_dec_option);
            return a;
        }
    }
}
