using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RooStatsSim.UI.Equipment
{
    class EquipList : ObservableCollection<EquipItem>
    {
        
        
        
        public EquipList()
        {
            EquipItem Equipment;
            EquipItem Card;
            EquipItem Enchent;
            Add(Equipment = new EquipItem("장비_이름"));
            Equipment.SubList.Add(Card = new EquipItem("보운드"));
            Equipment.SubList.Add(Enchent = new EquipItem("투지"));
        }
    }
    //public EquipItem this[string name] => this.FirstOrDefault(l => l.Name == name);
}
