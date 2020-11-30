using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

using RooStatsSim.DB;
using RooStatsSim.User;
using RooStatsSim.UI.StatusWindow;
using RooStatsSim.UI.Manager;
using RooStatsSim.UI.ACK;
using RooStatsSim.UI.StackBuff;
using RooStatsSim.UI.Equipment;
using RooStatsSim.UI.Menu;
using RooStatsSim.UI.MonsterDamage;
using MDIXWindow;
using WPF.MDI;

namespace RooStatsSim
{
    public enum WINDOW_ENUM
    {
        MENU,
        STATUS,
        STACK_BUFF,
        EQUIP,
        DAMAGE_CHECK,
    };
    public partial class MainWindow : Window
    {
        public static DBlist _roo_db;
        public static UserData _user_data;
        public static bool _user_data_edited = false;

        MdiChild _menu;
        MdiChild _status;
        MdiChild _stack_buff;
        MdiChild _equip;
        MdiChild _damage_check;

        public ProgramInfo _info;
        public DBManager _db_manager;

        public MainWindow()
        {
            Version();

            _roo_db = new DBlist();
            DBSerializer.ReadDB(ref _roo_db);
            _user_data = new UserData();
            User_Serializer.ReadDB(ref _user_data);

            MaterialDesignWindow.RegisterCommands(this);
            InitializeComponent();

            _menu = new MdiChild()
            {
                Title = "MenuBox",
                Content = new MenuBox(this),
                Width = 698,
                Height = 139,
                Position = new Point(0, 0),
                CloseBox = false,
            };
            _status = new MdiChild()
            {
                Title = "스테이터스",
                Content = new StatusWindow(),
                Width = 1203,
                Height = 352,
                Position = new Point(0, 138),
                CloseBox = false,
            };
            _stack_buff = new MdiChild()
            {
                Title = "StackBuff",
                Content = new StackBuffWindow(),
                Width = 415,    //284 257 14 38
                Height = 415,
                Position = new Point(1204, 0),
                CloseBox = false,
            };
            _equip= new MdiChild()
            {
                Title = "장비창",
                Content = new Equip(),
                Width = 886,
                Height = 378,
                Position = new Point(0, 490),
                CloseBox = false,
            };
            _damage_check = new MdiChild()
            {
                Title = "데미지 계산기",
                Content = new MonsterDamageCheck(),
                Width = 728,
                Height = 258,
                Position = new Point(885, 490),
                CloseBox = false,
            };



            RoosimContainer.Children.Add(_menu);
            RoosimContainer.Children.Add(_status);
            RoosimContainer.Children.Add(_stack_buff);
            RoosimContainer.Children.Add(_equip);
            RoosimContainer.Children.Add(_damage_check);
        }

        #region UI Setting
        public bool IsNumeric(string source)
        {
            Regex regex = new Regex("[^0-9.-]+");
            return !regex.IsMatch(source);
        }
        private void NurmericCheckFunc(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsNumeric(e.Text);
        }

        private void TxtboxSelectAll(object sender, RoutedEventArgs e)
        {
            Dispatcher.CurrentDispatcher.BeginInvoke(
                DispatcherPriority.ContextIdle,
                new Action(
                    delegate
                    {
                        (sender as TextBox).SelectAll();
                    }
                )
            );
        }

        #endregion

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_user_data_edited)
            {
                MessageBoxResult res = MessageBox.Show("변경사항이 있습니다. 변경하시겠습니까?", "Save", MessageBoxButton.YesNo);
                if (res == MessageBoxResult.Yes)
                    User_Serializer.SaveDataBase(ref _user_data);
            }
        }

        private void Version()
        {
            if (ProgramInfo.IsLastestVer())
                return;

            MessageBoxResult MsgRes = MessageBox.Show("최신 버전이 아닙니다.최신 버전을 다운받으시겠습니까?", "VersionCheck", MessageBoxButton.YesNo);
            if (MsgRes == MessageBoxResult.Yes)
            {
                System.Diagnostics.Process.Start(ProgramInfo.GetLeastURL());
                this.Close();
            }
        }
    }
}
