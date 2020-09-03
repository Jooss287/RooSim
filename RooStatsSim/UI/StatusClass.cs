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
        public StatusList(ref Status param_status, ref Status param_status_add)
        {
            Add(new StatusInfo("STR", param_status.Str, param_status_add.Str));
            Add(new StatusInfo("AGI", param_status.Agi, param_status_add.Agi));
            Add(new StatusInfo("VIT", param_status.Vit, param_status_add.Vit));
            Add(new StatusInfo("INT", param_status.Int, param_status_add.Int));
            Add(new StatusInfo("DEX", param_status.Dex, param_status_add.Dex));
            Add(new StatusInfo("LUK", param_status.Luk, param_status_add.Luk));
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
