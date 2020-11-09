using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Collections.Generic;
using RooStatsSim.DB;
using RooStatsSim.DB.Table;

namespace RooStatsSim.UI.Manager
{
    class MonsterDB_Binding : MonsterDB, INotifyPropertyChanged
    {
        public MonsterDB_Binding() { }
        public MonsterDB_Binding(int mob_id, string name, int level, bool isBoss, DB.Status status, int tribe, int element, int size,
            int atk, int matk, int hp, int def, int mdef, int hit, int flee)
            : base(mob_id, name, level, isBoss, status, tribe, element, size, atk, matk, hp, def, mdef, hit, flee)
        { }

        public new int MobId
        {
            get { return _mob_id; }
            set { _mob_id = value; OnPropertyChanged("MobId"); }
        }
        public new string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged("Name"); }
        }
        public new int Level
        {
            get { return _level; }
            set { _level = value; OnPropertyChanged("Level"); }
        }
        public new bool IsBoss
        {
            get { return _isBoss; }
            set { _isBoss = value; OnPropertyChanged("IsBoss"); }
        }
        public new DB.Status StatusInfo
        {
            get {return _status; }
            set { _status = value; }
        }
        public new int Tribe
        {
            get { return _tribe; }
            set { _tribe = value; OnPropertyChanged("Tribe"); OnPropertyChanged("Tribe_Kor"); }
        }
        public string Tribe_Kor
        {
            get { return EnumProperty_Kor.TRIBE_TYPE_KOR[(TRIBE_TYPE)_tribe]; }
        }
        public new int Element
        {
            get { return _element; }
            set { _element = value; OnPropertyChanged("Element"); OnPropertyChanged("Element_Kor"); }
        }
        public string Element_Kor
        {
            get { return EnumProperty_Kor.ELEMENT_TYPE_KOR[(ELEMENT_TYPE)_element]; }
        }
        public new int Size
        {
            get { return _size; }
            set { _size = value; OnPropertyChanged("Size"); OnPropertyChanged("Size_Kor"); }
        }
        public string Size_Kor
        {
            get { return EnumProperty_Kor.MONSTER_SIZE_KOR[(MONSTER_SIZE)_size]; }
        }
        public new int Atk
        {
            get { return _atk; }
            set { _atk = value; OnPropertyChanged("Atk"); }
        }
        public new int Matk
        {
            get { return _matk; }
            set { _matk = value; OnPropertyChanged("Matk"); }
        }
        public new int Hp
        {
            get { return _hp; }
            set { _hp = value; OnPropertyChanged("Hp"); }
        }
        public new int Def
        {
            get { return _def; }
            set { _def = value; OnPropertyChanged("Def"); }
        }
        public new int Mdef
        {
            get { return _mdef; }
            set { _mdef = value; OnPropertyChanged("Mdef"); }
        }
        public new int Hit
        {
            get { return _hit; }
            set { _hit = value; OnPropertyChanged("Hit"); }
        }
        public new int Flee
        {
            get { return _flee; }
            set { _flee = value; OnPropertyChanged("Flee"); }
        }
        public int Str
        {
            get { return _status.Str; }
            set { _status.Str = value; OnPropertyChanged("Str"); }
        }
        public int Agi
        {
            get { return _status.Agi; }
            set { _status.Agi = value; OnPropertyChanged("Agi"); }
        }
        public int Vit
        {
            get { return _status.Vit; }
            set { _status.Vit = value; OnPropertyChanged("Vit"); }
        }
        public int Dex
        {
            get { return _status.Dex; }
            set { _status.Dex = value; OnPropertyChanged("Dex"); }
        }
        public int Int
        {
            get { return _status.Int; }
            set { _status.Int = value; OnPropertyChanged("Int"); }
        }
        public int Luk
        {
            get { return _status.Luk; }
            set { _status.Luk = value; OnPropertyChanged("Luk"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public override string ToString() => _name;

        protected void OnPropertyChanged(string info)
        {
            var handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(info));
        }

        public void ChangeValue(MonsterDB_Binding param)
        {
            MobId = param.MobId;
            Name = param.Name;
            Level = param.Level;
            IsBoss = param.IsBoss;
            StatusInfo = param.StatusInfo;
            Tribe = param.Tribe;
            Element = param.Element;
            Size = param.Size;
            Atk = param.Atk;
            Matk = param.Matk;
            Hp = param.Hp;
            Def = param.Def;
            Mdef = param.Mdef;
            Hit = param.Hit;
            Flee = param.Flee;
        }
    }


    class MonsterListBox : ObservableCollection<MonsterDB_Binding>
    {
        public MonsterListBox()
        { }
        public MonsterListBox(Dictionary<int, MonsterDB> DB)
        {
            foreach (KeyValuePair<int, MonsterDB> items in DB)
            {
                MonsterDB db = items.Value;
                Add(new MonsterDB_Binding(db.MobId, db.Name, db.Level, db.IsBoss, db.StatusInfo, db.Tribe, db.Element, db.Size,
                    db.Atk, db.Matk, db.Hp, db.Def, db.Mdef, db.Hit, db.Flee));
            }
        }
        
        public void AddList(MonsterDB db)
        {
            if (Count == db.MobId)
                Add(new MonsterDB_Binding(db.MobId, db.Name, db.Level, db.IsBoss, db.StatusInfo, db.Tribe, db.Element, db.Size,
                    db.Atk, db.Matk, db.Hp, db.Def, db.Mdef, db.Hit, db.Flee));
            else
                SetItem(db.MobId, new MonsterDB_Binding(db.MobId, db.Name, db.Level, db.IsBoss, db.StatusInfo, db.Tribe, db.Element, db.Size,
                    db.Atk, db.Matk, db.Hp, db.Def, db.Mdef, db.Hit, db.Flee));
            
        }
    }
}
