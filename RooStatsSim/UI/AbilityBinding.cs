using System.ComponentModel;
using RooStatsSim.User;
using RooStatsSim.UI;

namespace RooStatsSim.UI
{
    class AbilityBinding<T> : INotifyPropertyChanged
        where T : struct
    {
        string _name = "Unknown";
        string _enum_name;
        T _point;
        T _add_point;

        public AbilityBinding(string name, T point, T add_point = default(T), string enum_name = "Unknown")
        {
            _name = name;
            _enum_name = enum_name;
            _point = point;
            _add_point = add_point;
        }
        public AbilityBinding(string name, ABILITTY<T> ability, string enum_name = "Unknown")
        {
            _name = name;
            _enum_name = enum_name;
            _point = ability.Point;
            _add_point = ability.AddPoint;
        }

        public void UpdateAbility(ABILITTY<T> param_ability)
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
        public T Point
        {
            get { return _point; }
            set
            {
                _point = value;
                OnPropertyChanged("Point");
            }
        }
        public T AddPoint
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
