using RooStatsSim.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RooStatsSim.UI.Equipment
{
    public class EquipList
    {
        public EquipList(ItemDB item)
        {
            Id = item.Id;
            Name = item.Name;

            SubList = new List<EquipList>();
        }
        public string Name { get; set; }
        public int Id { get; set; }
        public List<EquipList> SubList { get; set; }

    }
}
