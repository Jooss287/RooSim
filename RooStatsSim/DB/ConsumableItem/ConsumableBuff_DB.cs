using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RooStatsSim.DB.ConsumableItem
{

    public class ConsumableBuff_DB
    {
        public static CookingConsumable cooking = new CookingConsumable();
        public static PortionConsumable portion = new PortionConsumable();
        public Dictionary<string, ConsumableBuffInfo> Dic { get; set; }

        public ConsumableBuff_DB()
        {
            Dic = new Dictionary<string, ConsumableBuffInfo>();
            MakeDB(cooking.Buff, portion.Buff);
        }

        void MakeDB(params Dictionary<string, ConsumableBuffInfo>[] param)
        {
            Dic.Clear();
            foreach (Dictionary<string, ConsumableBuffInfo> buffs in param)
            {
                foreach (KeyValuePair<string, ConsumableBuffInfo> buff in buffs)
                {
                    Dic.Add(buff.Key, buff.Value);
                }
            }
        }
    }
}
