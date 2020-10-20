using RooStatsSim.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RooStatsSim.UI.Equipment
{
    public class EquipItem
    {
        public EquipItem(string name)
        {
            Name = name;
            SubList = new List<EquipItem>();
        }
        public EquipItem(ItemDB item)
        {
            Id = item.Id;
            Name = item.Name;

            SubList = new List<EquipItem>();
        }
        public string Name { get; set; }
        public int Id { get; set; }
        public List<EquipItem> SubList { get; set; }

    }
}
