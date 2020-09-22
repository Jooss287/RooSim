using System.Collections.ObjectModel;
using System.ComponentModel;
using DbManager.DB;
using System.Collections.Generic;

namespace DbManager.UI
{
    
    class ItemDB_Binding : ItemDB, INotifyPropertyChanged
    {
        public ItemDB_Binding() { }
        public ItemDB_Binding(ItemDB db)
            : base(db)
        { }

        public new int Id
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged("ItemId"); }
        }
        public new string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged("Name"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public override string ToString() => _name;

        protected void OnPropertyChanged(string info)
        {
            var handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(info));
        }

        public void ChangeValue(ItemDB_Binding param)
        {
            Id = param.Id;
            Name = param.Name;
        }
    }


    class ItemListBox : ObservableCollection<ItemDB_Binding>
    {
        public ItemListBox()
        { }
        public ItemListBox(ref Dictionary<int, ItemDB> DB)
        {
            foreach (KeyValuePair<int, ItemDB> items in DB)
            {
                ItemDB db = items.Value;
                Add(new ItemDB_Binding(db));
            }
        }
        
        public void AddList(ItemDB db)
        {
            if (Count == db.Id)
                Add(new ItemDB_Binding(db));
            else
                SetItem(db.Id, new ItemDB_Binding(db));
            
        }
    }
}
