using System.Collections.ObjectModel;
using System.ComponentModel;
using DbManager.DB;
using System.Collections.Generic;

namespace DbManager.UI
{
    class MonsterDB_Binding : MonsterDB, INotifyPropertyChanged
    {
        public MonsterDB_Binding() { }
        public MonsterDB_Binding(int mob_id, string name, bool isBoss, int size,
            int atk, int matk, int hp, int def, int mdef, int hit, int flee)
            : base(mob_id, name, isBoss, size, atk, matk, hp, def, mdef, hit, flee)
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
        public new bool IsBoss
        {
            get { return _isBoss; }
            set { _isBoss = value; OnPropertyChanged("IsBoss"); }
        }
        public new int Size
        {
            get { return _size; }
            set { _size = value; OnPropertyChanged("Size"); }
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

        public event PropertyChangedEventHandler PropertyChanged;

        public override string ToString() => _name;

        protected void OnPropertyChanged(string info)
        {
            var handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(info));
        }
    }


    class MonsterListBox : ObservableCollection<MonsterDB_Binding>
    {
        public MonsterListBox()
        { }
        public MonsterListBox(ref DBlist DB)
        {
            foreach (KeyValuePair<int, MonsterDB> items in DB._mob_db )
            {
                MonsterDB db = items.Value;
                Add(new MonsterDB_Binding(db.MobId, db.Name, db.IsBoss, db.Size,
                    db.Atk, db.Matk, db.Hp, db.Def, db.Mdef, db.Hit, db.Flee));
            }
        }
        
        public void AddList(MonsterDB db)
        {
            Add(new MonsterDB_Binding(db.MobId, db.Name, db.IsBoss, db.Size,
                    db.Atk, db.Matk, db.Hp, db.Def, db.Mdef, db.Hit, db.Flee));
        }
    }
}
