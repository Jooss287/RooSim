using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using RooStatsSim.DB;
using System.Collections.Generic;

using RooStatsSim.DB.Table;
using System.Windows.Controls;
using System.ComponentModel.Design;
using System.Reflection;

namespace RooStatsSim.UI.Manager
{
    #region UI Binding
    class ItemDB_Binding : ItemDB, INotifyPropertyChanged
    {
        public ItemDB_Binding() { }
        public ItemDB_Binding(ItemDB db)
            : base(db)
        { }

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
        public new int LevelLimit
        {
            get { return _level_limit; }
            set { _level_limit = value; OnPropertyChanged("LevelLimit"); }
        }
        public new int CardSlot
        {
            get { return _card_slot; }
            set { _card_slot = value; OnPropertyChanged("CardSlot"); }
        }
        public new int EnchantSlot
        {
            get { return _enchant_slot; }
            set { _enchant_slot = value; OnPropertyChanged("EnchantSlot"); }
        }
        public int Count
        {
            get { return Option.Count + Option_IF_TYPE.Count + Refine_Option.Count; }
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
            LevelLimit = param.LevelLimit;
            CardSlot = param.CardSlot;
            EnchantSlot = param.EnchantSlot;
            Item_type = param.Item_type;
            Equip_type = param.Equip_type;
            Wear_job_limit = param.Wear_job_limit;
            Option = param.Option;
            Option_IF_TYPE = param.Option_IF_TYPE;
            Refine_Option = param.Refine_Option;
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
    class Job_Limite_List : ObservableCollection<AbilityBinding<bool>>
    {
        public Job_Limite_List(ref List<JOB_SELECT_LIST> joblist)
        {
            foreach (JOB_SELECT_LIST job in Enum.GetValues(typeof(JOB_SELECT_LIST)))
            {
                bool value = false;
                if (joblist.Contains(job))
                    value = true;
                Add(new AbilityBinding<bool>(EnumBaseTable_Kor.JOB_SELECT_LIST_KOR_3WORD[job], value, false, Enum.GetName(typeof(JOB_SELECT_LIST), job)));
            }
        }

        public void SelectClass(JOB_SELECT_LIST select_job, bool value)
        {
            int inx = 0;
            int ClassRoot = 0;
            if ((int)select_job % 100 == 0)
                ClassRoot = 100;
            else if ((int)select_job % 10 == 0)
                ClassRoot = 10;

            foreach (JOB_SELECT_LIST job in Enum.GetValues(typeof(JOB_SELECT_LIST)))
            {
                if (((int)job >= (int)select_job) && ((int)job < (int)select_job + ClassRoot))
                {
                    this[inx].Point = value;
                }
                inx++;
            }
        }

        public List<JOB_SELECT_LIST> GetLimitedJobList()
        {
            List<JOB_SELECT_LIST> retValue = new List<JOB_SELECT_LIST>();

            foreach (AbilityBinding<bool> ability in this)
            {
                if (ability.Point)
                {
                    retValue.Add((JOB_SELECT_LIST)Enum.Parse(typeof(JOB_SELECT_LIST), ability.EnumName));
                }
            }
            return retValue;
        }
    }
    #endregion

    #region Normal Option Binding
    class ItemOption_Binding : INotifyPropertyChanged
    {
        public ItemOption_Binding() { }
        public ItemOption_Binding(KeyValuePair<string, double> db)
        {
            _type_name = db.Key;
            _type_value = db.Value;
        }

        string _type_name;
        double _type_value;
        public string Type_name
        { 
            get { return _type_name; } 
            set { _type_name = value; OnPropertyChanged("Type_name"); } 
        }
        
        public double Type_value
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
    class ItemOptionListBox : ObservableCollection<ItemOption_Binding>
    {
        public ItemOptionListBox()
        { }
        public ItemOptionListBox(params Dictionary<string, double>[] DB)
        {
            foreach (Dictionary<string, double> pairs in DB)
            {
                foreach (KeyValuePair<string, double> items in pairs)
                {
                    Add(new ItemOption_Binding(items));
                }
            }

        }
    }
    #endregion

    #region If Type Option Binding
    class ItemOption_IfType_Binding : INotifyPropertyChanged
    {
        public ItemOption_IfType_Binding(AbilityPerStatus db)
        {
            _value = new AbilityPerStatus(db);
        }

        AbilityPerStatus _value;

        public string PerTypeName
        {
            get { return _value.PerType; }
            set { _value.PerType = value; OnPropertyChanged("PerTypeName"); }
        }
        public string AddTypeName
        {
            get { return _value.AddType; }
            set { _value.AddType = value; OnPropertyChanged("AddTypeName"); }
        }
        public double PerTypeValue
        {
            get { return _value.PerValue; }
            set { _value.PerValue = value; OnPropertyChanged("PerTypeValue"); }
        }
        public double AddTypeValue
        {
            get { return _value.AddValue; }
            set { _value.AddValue = value; OnPropertyChanged("AddTypeValue"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string info)
        {
            var handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(info));
        }
    }
    class ItemOptionIfTypeListBox : ObservableCollection<ItemOption_IfType_Binding>
    {
        public ItemOptionIfTypeListBox()
        { }
        public ItemOptionIfTypeListBox(List<AbilityPerStatus> DB)
        {
            foreach (AbilityPerStatus items in DB)
            {
                Add(new ItemOption_IfType_Binding(items));
            }
        }
    }
    #endregion
    #region Refine Type Option Binding
    class ItemOption_Refine_Binding : INotifyPropertyChanged
    {
        public ItemOption_Refine_Binding() { }
        public ItemOption_Refine_Binding(int refine, KeyValuePair<string, double> db)
        {
            _refine = refine;
            _type_name = db.Key;
            _type_value = db.Value;
        }

        int _refine;
        string _type_name;
        double _type_value;
        public int Refine
        {
            get { return _refine; }
            set { _refine = value; OnPropertyChanged("Refine"); }
        }
        public string Type_name
        {
            get { return _type_name; }
            set { _type_name = value; OnPropertyChanged("Type_name"); }
        }

        public double Type_value
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
    class ItemOptionRefineListBox : ObservableCollection<ItemOption_Refine_Binding>
    {
        public ItemOptionRefineListBox()
        { }
        public ItemOptionRefineListBox(Dictionary<int, Dictionary<ITEM_OPTION_TYPE, Dictionary<string, double>>> DB)
        {
            foreach (KeyValuePair<int, Dictionary<ITEM_OPTION_TYPE, Dictionary<string, double>>> options in DB)
            {
                foreach (KeyValuePair<ITEM_OPTION_TYPE, Dictionary<string, double>> item_option in options.Value)
                {
                    foreach (KeyValuePair<string, double> items in item_option.Value)
                        Add(new ItemOption_Refine_Binding(options.Key, items));
                }
            }
        }
    }
    #endregion
}

