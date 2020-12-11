using System;
using System.Windows;
using System.Windows.Controls;

using RooStatsSim.DB.Table;
using RooStatsSim.UI.Manager;
using RooStatsSim.UI.ACK;
using RooStatsSim.User;
using WPF.MDI;

namespace RooStatsSim.UI.Menu
{
    /// <summary>
    /// MenuBox.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MenuBox : UserControl
    {
        UserData _user_data;
        MainWindow _parents = null;
        public MenuBox(MainWindow parents)
        {
            _user_data = MainWindow._user_data;
            InitializeComponent();
            _parents = parents;

            DataContext = new CheckboxBinding();
        }

        #region UI callbacks
        private void job_sel_Click(object sender, RoutedEventArgs e)
        {
            if (_parents != null)
            {
                MessageBoxResult res = MessageBox.Show("세팅된 모든 정보가 변경될 수 있습니다. 변경하시겠습니까?", "ClassChange", MessageBoxButton.YesNo);
                if (res == MessageBoxResult.No)
                { 
                    return;
                }

                MainWindow._user_data_edited = true;
            }

            RadioButton source = e.Source as RadioButton;
            _user_data.Initializor();
            _user_data.JobChanged((JOB_SELECT_LIST)Enum.Parse(typeof(JOB_SELECT_LIST), Convert.ToString(source.Tag)));
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
            TurnOnOff(WINDOW_ENUM.SKILL);
        }
        private void UserSave_Checked(object sender, RoutedEventArgs e)
        {
            MainWindow.CheckUserDataChanged();
            _user_data.Initializor();
            User_Serializer.ReadDB(ref _user_data, Convert.ToInt32((sender as RadioButton).Tag));
            _user_data.CalcUserData();
        }
        #endregion
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
