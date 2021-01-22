using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RooStatsSim.DB.Enchant
{
    public class Enchant_DB
    {
        public static NormalEnchant normal_enchant = new NormalEnchant();
        public static AdvancedEnchant advanced_enchant = new AdvancedEnchant();
        public Dictionary<string, EnchantInfo> Dic { get; set; }

        public Enchant_DB()
        {
            Dic = new Dictionary<string, EnchantInfo>();
            MakeDB(normal_enchant.Dic, advanced_enchant.Dic);
        }

        void MakeDB(params Dictionary<string, EnchantInfo>[] param)
        {
            Dic.Clear();
            foreach (Dictionary<string, EnchantInfo> buffs in param)
            {
                foreach (KeyValuePair<string, EnchantInfo> buff in buffs)
                {
                    Dic.Add(buff.Key, buff.Value);
                }
            }
        }
    }
}
