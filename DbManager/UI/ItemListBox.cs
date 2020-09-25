using System;
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

        string binding_str;
        public new int Id
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged("Id"); }
        }
        public new string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged("Name"); }
        }
        public string Itype_name
        {
           get { return Enum.GetName(typeof(ITYPE), i_option.Keys); }
        }

        public Dictionary<ITYPE, int> ITYPE_OPTION { get; set; }
        public string Itype_value
        {
            get { return Convert.ToString(i_option.Values); }
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
            i_option = param.i_option;
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

    class ItemOption_Binding : INotifyPropertyChanged
    {
        public ItemOption_Binding() { }
        public ItemOption_Binding(KeyValuePair<ITYPE, int> db)
        {
            _type_name = Enum.GetName(typeof(ITYPE), db.Key);
            _type_value = db.Value;
        }

        string _type_name;
        int _type_value;
        public string Type_name
        { 
            get { return _type_name; } 
            set { _type_name = value; OnPropertyChanged("Type_name"); } 
        }
        
        public int Type_value
        {
            get { return _type_value; }
            set { _type_value = value; OnPropertyChanged("Type_value"); }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        public override string ToString() => _type_name;

        protected void OnPropertyChanged(string info)
        {
            var handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(info));
        }
    }

    class testBox : ObservableCollection<ItemOption_Binding>
    {
        public testBox()
        { }
        public testBox(ref Dictionary<ITYPE, int> DB)
        {
            foreach (KeyValuePair<ITYPE, int> items in DB)
            {
                Add(new ItemOption_Binding(items)) ;
            }
        }

        //public void AddList(KeyValuePair<ITYPE, int> item)
        //{
        //    Add
        //    if (Count == db.Id)
        //        Add(new ItemDB_Binding(db));
        //    else
        //        SetItem(db.Id, new ItemDB_Binding(db));

        //}
    }

}

