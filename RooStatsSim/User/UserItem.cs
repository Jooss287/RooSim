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
            //i_option[ITYPE.STR] = 0;
            //i_option[ITYPE.AGI] = 0;
            //i_option[ITYPE.VIT] = 0;
            //i_option[ITYPE.INT] = 0;
            //i_option[ITYPE.DEX] = 0;
            //i_option[ITYPE.LUK] = 0;

            //i_option[ITYPE.HP] = 0;
            //i_option[ITYPE.SP] = 0;
            //i_option[ITYPE.ATK] = 0;
            //i_option[ITYPE.DEF] = 0;
            //i_option[ITYPE.MATK] = 0;
            //i_option[ITYPE.MDEF] = 0;
            //i_option[ITYPE.SMELTING_ATK] = 0;
            //i_option[ITYPE.SMELTING_DEF] = 0;
            //i_option[ITYPE.SMELTING_MATK] = 0;
            //i_option[ITYPE.SMELTING_MDEF] = 0;
            //i_option[ITYPE.STATUS_ATK] = 0;
            //i_option[ITYPE.STATUS_MATK] = 0;
            //i_option[ITYPE.WEAPON_ATK] = 0;
            //i_option[ITYPE.WEAPON_MATK] = 0;
            //i_option[ITYPE.HP_RECOVERY] = 0;
            //i_option[ITYPE.SP_RECOVERY] = 0;
            //i_option[ITYPE.HIT] = 0;
            //i_option[ITYPE.FLEE] = 0;
            //i_option[ITYPE.CRI] = 0;
            //i_option[ITYPE.CDEF] = 0;

            d_option[DTYPE.ASPD] = 0;
            d_option[DTYPE.MOVING_SPEED] = 0;
        }
        public static UserItem operator +(UserItem a, ItemDB b)
        {
            AddOption<ITYPE>(ref a.i_option, b.i_option);
            AddOption<DTYPE>(ref a.d_option, b.d_option);
            AddOption<STATUS_EFFECT_TYPE>(ref a.se_option, b.se_option);

            return a;
        }
    }
}
