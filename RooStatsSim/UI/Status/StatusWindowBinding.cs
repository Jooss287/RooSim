using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using RooStatsSim.User;

namespace RooStatsSim.UI.Status
{
    class AbilityBinding: INotifyPropertyChanged
    {
        string _name;
        int _point;
        int _add_point;

        public AbilityBinding()
        {
            _name = "Test";
            _point = 1;
            _add_point = 0;
        }
        public AbilityBinding(string name, int point, int add_point)
        {
            _name = name;
            _point = point;
            _add_point = add_point;
        }
        public AbilityBinding(string name, ABILITTY ability)
        {
            _name = name;
            _point = ability.Point;
            _add_point = ability.AddPoint;
        }

        public void UpdateAbility(ABILITTY param_ability) {
            Point = param_ability.Point;
            AddPoint = param_ability.AddPoint;
        }

        public string Name {
            get { return _name; }
            set { 
                _name = value;
                OnPropertyChanged("Name");
            }
        }
        public int Point {
            get { return _point; } 
            set {
                _point = value;
                OnPropertyChanged("Point");
            }
        }
        public int AddPoint {
            get { return _add_point; } 
            set { 
                _add_point = value;
                OnPropertyChanged("AddPoint");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public override string ToString() => _name;

        protected void OnPropertyChanged(string info)
        {
            var handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(info));
        }
    }

    class StatusList : ObservableCollection<AbilityBinding>
    {
        public StatusList()
        { }
        public StatusList(ref UserData param_status)
        {
            foreach (STATUS_ENUM status in Enum.GetValues(typeof(STATUS_ENUM)))
            {
                string statusName = Enum.GetName(typeof(STATUS_ENUM), status);
                Add(new AbilityBinding(statusName, param_status.Status[(int)status].Point, param_status.Status[(int)status].AddPoint));
            }
        }
    }

    class BasicOptionInfoList : ObservableCollection<AbilityBinding>
    {
        public BasicOptionInfoList()
        {
            Add(new AbilityBinding("ATK", 10, 1));
            Add(new AbilityBinding("MATK", 10, 1));
            Add(new AbilityBinding("제련ATK", 10, 1));
            Add(new AbilityBinding("제련MATK", 10, 1));
            Add(new AbilityBinding("ASPD", 10, 1));
            Add(new AbilityBinding("HIT", 10, 1));
            Add(new AbilityBinding("DEF", 10, 1));
            Add(new AbilityBinding("MDEF", 10, 1));
            Add(new AbilityBinding("제련DEF", 10, 1));
            Add(new AbilityBinding("제련MDEF", 10, 1));
        }
    }
}
