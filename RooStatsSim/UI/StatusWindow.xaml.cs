using RooStatsSim.DB;
using System;
using System.Windows;
using System.Windows.Controls;

namespace RooStatsSim.UI
{
    /// <summary>
    /// StatusWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class StatusWindow : Window
    {
        StatusList BindingStatus;
        NewStatus statusDB;
        Status statusAddDB;

        public StatusWindow()
        {
            //DB가 레퍼로 들어왔다 치고.
            statusDB = new NewStatus();
            //statusAddDB = new Status();

            InitializeComponent();
            
            DataContext = this;
            BaseLvlUI.DataContext = statusDB._BASE.Point;
            BindingStatus = new StatusList(ref statusDB);
            StatusListBox.ItemsSource = BindingStatus;
        }

        private void StatusUp_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var tb = sender as StackPanel;
            StatusInfo dataCxtx = tb.DataContext as StatusInfo;
            dataCxtx.Point++;
        }

        private void StatusDown_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var tb = sender as StackPanel;
            StatusInfo dataCxtx = tb.DataContext as StatusInfo;
            dataCxtx.Point--;
        }

        private void LevelUp_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

        }

        private void LevelDown_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

        }
    }
}
