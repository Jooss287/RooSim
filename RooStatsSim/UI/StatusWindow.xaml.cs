using RooStatsSim.DB;
using System.Windows;

namespace RooStatsSim.UI
{
    /// <summary>
    /// StatusWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class StatusWindow : Window
    {
        StatusList BindingStatus;
        Status statusDB;
        Status statusAddDB;

        public StatusWindow()
        {
            //DB가 레퍼로 들어왔다 치고.
            statusDB = new Status();
            statusAddDB = new Status();

            InitializeComponent();

            BindingStatus = new StatusList(ref statusDB, ref statusAddDB);
            StatusListBox.ItemsSource = BindingStatus;
        }

        private void StatusUp_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            
        }

        private void StatusDown_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

        }

        private void LevelUp_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

        }

        private void LevelDown_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

        }
    }
}
