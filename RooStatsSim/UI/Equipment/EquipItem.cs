using RooStatsSim.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RooStatsSim.UI.Equipment
{
    public class EquipTreeViewBinding : EquipId
    {
        public EquipTreeViewBinding(string name)
        {
            Name = name;
            SubList = new List<EquipTreeViewBinding>();
        }
        public EquipTreeViewBinding(ItemDB item)
        {
            Id = item.Id;
            Name = item.Name;

            SubList = new List<EquipTreeViewBinding>();
        }
        public List<EquipTreeViewBinding> SubList { get; set; }

    }

    public class EquipId
    {
        public string Name { get; set; }
        public int Id { get; set; }
    }
}
