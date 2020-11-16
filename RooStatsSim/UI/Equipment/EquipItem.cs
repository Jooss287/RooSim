using RooStatsSim.DB;
using System.ComponentModel;
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
            Refine = 0;

            SubList = new List<EquipTreeViewBinding>();
        }
        public List<EquipTreeViewBinding> SubList { get; set; }

    }

    public class EquipId : INotifyPropertyChanged
    {
        string _name;
        int _id;
        int _refine;

        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged("Name"); }
        }
        public int Id
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged("Id"); }
        }
        public int Refine
        {
            get { return _refine; }
            set { _refine = value; OnPropertyChanged("Refine"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public override string ToString() => _name;

        protected void OnPropertyChanged(string info)
        {
            var handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(info));
        }
    }
}
