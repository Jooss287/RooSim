using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RooStatsSim.UI
{
    /// <summary>
    /// StatusWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class StatusWindow : Window
    {
        public StatusWindow()
        {
            InitializeComponent();
        }
    }

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

    class StatusInit: ObservableCollection<StatusInfo>
    {
        public StatusInit()
        {
            Add(new StatusInfo("STR", 10, 1));
            Add(new StatusInfo("AGI", 10, 1));
            Add(new StatusInfo("VIT", 10, 1));
            Add(new StatusInfo("DEX", 10, 1));
            Add(new StatusInfo("INT", 10, 1));
            Add(new StatusInfo("LUK", 10, 1));
        }
    }
}
