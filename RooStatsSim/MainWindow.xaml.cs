using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

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
        MdiChild _menu;
        MdiChild _status;
        MdiChild _stack_buff;
        MdiChild _equip;
        MdiChild _damage_check;

        public ProgramInfo _info;
        public DBManager _db_manager;

        public MainWindow()
        {
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
                Width = 298,
                Height = 295,
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
    }
}
