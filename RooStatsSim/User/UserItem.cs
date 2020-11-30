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
        
        private void MakeNormalProperty()
        {
            foreach(string type_name in Enum.GetNames(typeof(ITYPE)))
            {
                Option_ITYPE.Add(type_name, 0);
            }
            Option_DTYPE.Add(Enum.GetName(typeof(DTYPE), DTYPE.ASPD), 0);
            Option_DTYPE.Add(Enum.GetName(typeof(DTYPE), DTYPE.MOVING_SPEED), 0);
        }
        public static UserItem operator +(UserItem a, ItemDB b)
        {
            foreach (KeyValuePair<ITEM_OPTION_TYPE, Dictionary<string, double>> item_option in b.Option)
            {
                if (a.Option.ContainsKey(item_option.Key) == true)
                {
                    foreach (KeyValuePair<string, double> detail_option in item_option.Value)
                    {
                        if (a.Option[item_option.Key].ContainsKey(detail_option.Key) == true)
                        {
                            a.Option[item_option.Key][detail_option.Key] += detail_option.Value;
                        }
                        else
                            a.Option[item_option.Key][detail_option.Key] = detail_option.Value;
                    }
                }
                else
                {
                    a.Option[item_option.Key] = item_option.Value;
                }
            }
            return a;
        }

        public ItemDB CalcIftypeValues(UserData user)
        {
            ItemDB item_iftype = new ItemDB();

            //foreach (EQUIP.EquipItem equip_item in user.Equip.List)
            //{
            //    foreach (KeyValuePair<IFTYPE, AbilityPerStatus> option in equip_item.Equip.IF_OPTION)
            //    {
            //        if (option.Value.Calc != null)
            //            item_iftype += option.Value.Calc(user);
            //        else
            //            item_iftype += option.Value.Calc_refine(user, equip_item.Smelting);
            //    }
            //}
            return item_iftype;
        }
    }
}
