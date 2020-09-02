using System.Collections.ObjectModel;

namespace RooStatsSim.UI
{
    class StatusInfo
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
        }
        public int AddPoint
        {
            get { return _add_point; }
        }
    }

    class StatusList : ObservableCollection<StatusInfo>
    {
        public StatusList()
        {
            Add(new StatusInfo("STR", 10, 1));
            Add(new StatusInfo("AGI", 10, 1));
            Add(new StatusInfo("VIT", 10, 1));
            Add(new StatusInfo("DEX", 10, 1));
            Add(new StatusInfo("INT", 10, 1));
            Add(new StatusInfo("LUK", 10, 1));
        }
    }


    class BasicOptionInfo
    {
        string _name;
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
            get { return _point; }
        }
        public int AddPoint
        {
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
