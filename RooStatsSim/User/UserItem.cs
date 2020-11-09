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
            AddOption<STATUS_EFFECT_TYPE>(ref a.se_option, b.se_option);

            return a;
        }
    }
}
