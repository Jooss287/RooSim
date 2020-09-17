using RooStatsSim.DB;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace RooStatsSim.UI
{
    enum STATUS_INFO
    {
        BASE,
        JOB,
        STR,
        AGI,
        VIT,
        INT,
        DEX,
        LUK
    }

    class NewStatus
    {
        public StatusInfo _STR = new StatusInfo("STR", 0, 0);
        public StatusInfo _AGI = new StatusInfo("AGI", 0, 0);
        public StatusInfo _VIT = new StatusInfo("VIT", 0, 0);
        public StatusInfo _INT = new StatusInfo("INT", 0, 0);
        public StatusInfo _DEX = new StatusInfo("DEX", 0, 0);
        public StatusInfo _LUK = new StatusInfo("LUK", 0, 0);
        public StatusInfo _BASE = new StatusInfo("BASE", 0, 0);

    }

    class StatusInfo : INotifyPropertyChanged
    {
        string _name;
        int _point;
        int _add_point;

        public StatusInfo(string name, int point, int add_point)
        {
            _name = name;
            _point = point;
            _add_point = add_point;
        }

        public string Name
        {
            get { return _name; }
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

    class StatusList : ObservableCollection<StatusInfo>
    {
        public StatusList()
        { }
        public StatusList(ref NewStatus param_status)
        {
            Add(param_status._STR);
            Add(param_status._AGI);
            Add(param_status._VIT);
            Add(param_status._INT);
            Add(param_status._DEX);
            Add(param_status._LUK);
        }
    }

    class BasicOptionInfo
    {
        readonly string _name;
        int _point;
        int _add_point;

        public BasicOptionInfo(string name, int point, int add_point)
        {
            _name = name;
            _point = point;
            _add_point = add_point;
        }

        public string Name
        {
            get { return _name; }
        }
        public int Point
        {
            set { _point = value; }
            get { return _point; }
        }
        public int AddPoint
        {
            set { _add_point = value; }
            get { return _add_point; }
        }
    }

    class BasicOptionInfoList : ObservableCollection<BasicOptionInfo>
    {
        public BasicOptionInfoList()
        {
            Add(new BasicOptionInfo("ATK", 10, 1));
            Add(new BasicOptionInfo("MATK", 10, 1));
            Add(new BasicOptionInfo("제련ATK", 10, 1));
            Add(new BasicOptionInfo("제련MATK", 10, 1));
            Add(new BasicOptionInfo("ASPD", 10, 1));
            Add(new BasicOptionInfo("HIT", 10, 1));
            Add(new BasicOptionInfo("DEF", 10, 1));
            Add(new BasicOptionInfo("MDEF", 10, 1));
            Add(new BasicOptionInfo("제련DEF", 10, 1));
            Add(new BasicOptionInfo("제련MDEF", 10, 1));
        }
    }
}
