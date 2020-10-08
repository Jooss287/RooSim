using System.ComponentModel;
using RooStatsSim.User;
using RooStatsSim.UI;

namespace RooStatsSim.UI
{
    class AbilityBinding : INotifyPropertyChanged
    {
        string _name;
        string _enum_name;
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
            _enum_name = name;
            _point = point;
            _add_point = add_point;
        }
        public AbilityBinding(string name, string enum_name, int point, int add_point)
        {
            _name = name;
            _enum_name = enum_name;
            _point = point;
            _add_point = add_point;
        }
        public AbilityBinding(string name, ABILITTY ability)
        {
            _name = name;
            _point = ability.Point;
            _add_point = ability.AddPoint;
        }

        public void UpdateAbility(ABILITTY param_ability)
        {
            Point = param_ability.Point;
            AddPoint = param_ability.AddPoint;
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }
        public string EnumName
        {
            get { return _enum_name; }
            set { _enum_name = value; }
        }
        public int Point
        {
            get { return _point; }
            set
            {
                _point = value;
                OnPropertyChanged("Point");
            }
        }
        public int AddPoint
        {
            get { return _add_point; }
            set
            {
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
}
