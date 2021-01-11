using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RooStatsSim.DB.ConsumableItem
{
    public class ConsumableBuffInfo
    {
        List<ItemDB> _option;
        public string NAME { get; set; }
        public string NAME_KOR { get; set; }
        public int MAX_LV { get; set; }
        public List<ItemDB> OPTION
        {
            get
            {
                if (_option == null) _option = new List<ItemDB>();
                return _option;
            }
            set { _option = value; }
        }

        public ConsumableBuffInfo(string name, string name_kor, int max_lv = 0)
        {
            NAME = name;
            NAME_KOR = name_kor;
            MAX_LV = max_lv;
        }
    }
}
