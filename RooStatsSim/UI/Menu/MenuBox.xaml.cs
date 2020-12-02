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

using RooStatsSim;
using RooStatsSim.DB;
using RooStatsSim.DB.Table;
using RooStatsSim.Equation.Job;
using RooStatsSim.UI.StatusWindow;
using RooStatsSim.UI.Manager;
using RooStatsSim.UI.ACK;
using RooStatsSim.User;
using RooStatsSim.UI.StackBuff;
using RooStatsSim.UI.Equipment;
using RooStatsSim.UI.SkillWindow;
using WPF.MDI;

namespace RooStatsSim.UI.Menu
{
    /// <summary>
    /// MenuBox.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MenuBox : UserControl
    {
        UserData _user_data;
        MainWindow _parents;
        public MenuBox(MainWindow parents)
        {
            _user_data = MainWindow._user_data;
            _parents = parents;
            InitializeComponent();
        }


        private void job_sel_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult res = MessageBox.Show("세팅된 모든 정보가 변경될 수 있습니다. 변경하시겠습니까?", "ClassChange", MessageBoxButton.YesNo);
            if (res == MessageBoxResult.No)
                return;

            RadioButton source = e.Source as RadioButton;
            _user_data.Job = (JOB_SELECT_LIST)Enum.Parse(typeof(JOB_SELECT_LIST), Convert.ToString(source.Tag));
            //_user_data.User_Skill.InitSkills(SkillWindow.SkillWindow._)
            //모든 값 초기화 시켜야 함
        }
        private void TurnOnOff(WINDOW_ENUM window_name)
        {
            MdiChild window = _parents.RoosimContainer.Children[(int)window_name];
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
            TurnOnOff(WINDOW_ENUM.STATUS);
        }
        private void StackBuff_window_Click(object sender, RoutedEventArgs e)
        {
            TurnOnOff(WINDOW_ENUM.STACK_BUFF);
        }
        private void Equip_window_Click(object sender, RoutedEventArgs e)
        {
            TurnOnOff(WINDOW_ENUM.EQUIP);
        }
        private void DamageCheck_window_Click(object sender, RoutedEventArgs e)
        {
            TurnOnOff(WINDOW_ENUM.DAMAGE_CHECK);
        }
        private void Skill_window_Click(object sender, RoutedEventArgs e)
        {

        }
        

        #region Window Modal
        private void DBManager_window_Click(object sender, RoutedEventArgs e)
        {
            if (_parents._db_manager == null)
                _parents._db_manager = new DBManager();

            _parents._db_manager.Owner = _parents;
            if (_parents._db_manager.ShowDialog() == true) { }
            _parents._db_manager.Close();
            _parents._db_manager = null;

            User_Serializer.ReadDB(ref MainWindow._user_data);
        }

        private void Info_window_Click(object sender, RoutedEventArgs e)
        {
            if ( _parents._info == null)
                _parents._info = new ProgramInfo();

            _parents._info.Owner = _parents;
            if (_parents._info.ShowDialog() == true) { }
            _parents._info = null;
        }
        #endregion


    }
}
