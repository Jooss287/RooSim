using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

using RooStatsSim.DB;
using RooStatsSim.DB.Table;
using RooStatsSim.Equation.Job;
using RooStatsSim.Skills;
using RooStatsSim.UI.StatusWindow;
using RooStatsSim.UI.Manager;
using RooStatsSim.UI.ACK;
using RooStatsSim.User;
using RooStatsSim.UI.StackBuff;
using RooStatsSim.UI.Equipment;

namespace RooStatsSim.UI.Menu
{
    /// <summary>
    /// MenuBox.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MenuBox : UserControl
    {
        public static DBlist _roo_db;
        UserData _user_data;
        MainWindow _parents;
        public MenuBox(MainWindow parents)
        {
            _roo_db = new DBlist();
            DBSerizator.ReadDB(ref _roo_db);
            _user_data = UserData.GetInstance;

            _parents = parents;
            InitializeComponent();
        }


        private void job_sel_Click(object sender, RoutedEventArgs e)
        {
            RadioButton source = e.Source as RadioButton;
            _user_data.Job = (JOB_SELECT_LIST)Enum.Parse(typeof(JOB_SELECT_LIST), Convert.ToString(source.Tag));

            //모든 값 초기화 시켜야 함
        }
        private void TurnOnOff(Grid window)
        {
            if (window.IsVisible)
            {
                window.Visibility = Visibility.Hidden;
                window.IsEnabled = false;
            }
            else
            {
                window.Visibility = Visibility.Visible;
                window.IsEnabled = true;
            }
                
        }
        private void Status_window_Click(object sender, RoutedEventArgs e)
        {
            //TurnOnOff((_parents.status_contents.Parent as Grid));
        }
        private void StackBuff_window_Click(object sender, RoutedEventArgs e)
        {
            //TurnOnOff((_parents.stack_buff_contents.Parent as Grid));
        }
        private void Equip_window_Click(object sender, RoutedEventArgs e)
        {
            //TurnOnOff((_parents.equip_contents.Parent as Grid));
        }
        private void DamageCheck_window_Click(object sender, RoutedEventArgs e)
        {
            //TurnOnOff((_parents.damage_check_contents.Parent as Grid));
        }
        private void Skill_window_Click(object sender, RoutedEventArgs e)
        {

        }
        

        #region Window Modal
        private void DBManager_window_Click(object sender, RoutedEventArgs e)
        {
            if (_parents._db_manager == null)
                _parents._db_manager = new DBManager();
            else
                _parents._db_manager.Focus();
        }

        private void Info_window_Click(object sender, RoutedEventArgs e)
        {
            if (_parents._info == null)
                _parents._info = new ProgramInfo();
            else
                _parents._info.Focus();
        }
        #endregion

        
    }
}
