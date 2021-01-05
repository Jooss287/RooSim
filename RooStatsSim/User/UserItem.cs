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
    [Serializable]
    public class UserItem : ItemDB
    {
        public UserItem() { }
        public UserItem(Boolean makeProperty)
        {
            if (makeProperty)
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
            if (b == null)
                return a;
            AddOption(a.Option, b.Option);

            foreach (AbilityPerStatus ability in b.Option_IF_TYPE)
                a.Option_IF_TYPE.Add(new AbilityPerStatus(ability));
            foreach (KeyValuePair<int, Dictionary<ITEM_OPTION_TYPE, Dictionary<string, double>>> refine_num in b.Option_Refine)
            {
                if (a.Option_Refine.ContainsKey(refine_num.Key) == false)
                    a.Option_Refine.Add(refine_num.Key, new Dictionary<ITEM_OPTION_TYPE, Dictionary<string, double>>());
                AddOption(a.Option_Refine[refine_num.Key], b.Option_Refine[refine_num.Key]);
            }
            return a;
        }

        public ItemDB CalcIftypeValues(UserData user)
        {
            ItemDB item_iftype = new ItemDB();

            foreach (AbilityPerStatus ability in user.User_Item.Option_IF_TYPE)
            {
                item_iftype += GetOptionWithoutRefine(user, ability);
            }
            return item_iftype;
        }

        private ItemDB GetOptionWithoutRefine(UserData user_data, AbilityPerStatus abilities)
        {
            ItemDB db = new ItemDB();

            if (abilities.PerType == Enum.GetName(typeof(REFINE_TYPE), REFINE_TYPE.REFINE))
                return db;

            db.Option[EnumItemOptionTable.GET_ITEM_OPTION_TYPE(abilities.AddType)][abilities.AddType] = abilities.AddValue *
                (user_data.User_Item.Option[EnumItemOptionTable.GET_ITEM_OPTION_TYPE(abilities.PerType)][abilities.PerType] / abilities.PerValue);
            return db;
        }
    }
}
