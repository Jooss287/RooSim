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
    public partial class MenuBox : Page
    {
        public static DBlist _roo_db;
        UserData _user_data;
        MainWindow _parents;
        public MenuBox(MainWindow parents)
        {
            _parents = parents;
            InitializeComponent();

            job_UI_setting((int)(JOB_LIST.LOAD_KNIGHT));

            _roo_db = new DBlist();
            DBSerizator.ReadDB(ref _roo_db);
            _user_data = UserData.GetInstance;
        }


        private void job_sel_Click(object sender, RoutedEventArgs e)
        {
            RadioButton source = e.Source as RadioButton;
            //job_select = Convert.ToInt32(source.Tag);

            //job_selection.JobSelectNum = (JOB_LIST)job_select;
            //job_UI_setting(job_select);
        }

        private void job_UI_setting(int param_job_select)
        {
            //List<SkillInfo> skillNames = job_selection.GetSkillCnt(job_select);
            //BuffList = new bool[skillNames.Count];

            //if (SkillListBox != null)
            //    SkillListBox.ItemsSource = new SkillAdd(skillNames);
        }

        private void Status_window_Click(object sender, RoutedEventArgs e)
        {
            if (_parents._status.IsVisible)
                _parents._status.Visibility = Visibility.Hidden;
            else
                _parents._status.Visibility = Visibility.Visible;
        }

        private void DBManager_window_Click(object sender, RoutedEventArgs e)
        {
            if (_parents._db_manager == null)
                _parents._db_manager = new DBManager();
            else
                _parents._db_manager.Show();
        }

        private void Info_window_Click(object sender, RoutedEventArgs e)
        {
            if (_parents._info.IsVisible)
                _parents._info.Hide();
            else
                _parents._info.Show();
        }

        private void StackBuff_window_Click(object sender, RoutedEventArgs e)
        {
            if (_parents._stacK_buff.IsVisible)
                _parents._stacK_buff.Hide();
            else
                _parents._stacK_buff.Show();
        }

        private void Skill_window_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Equip_window_Click(object sender, RoutedEventArgs e)
        {
            if (_parents._equip.IsVisible)
                _parents._equip.Visibility = Visibility.Hidden;
            else
                _parents._equip.Visibility = Visibility.Visible;
        }
    }
}
