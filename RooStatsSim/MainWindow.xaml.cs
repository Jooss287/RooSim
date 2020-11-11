using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

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
using RooStatsSim.UI.Menu;
using System.Windows.Shapes;
using RooStatsSim.UI.MonsterDamage;

namespace RooStatsSim
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        double objXPos, objYPos;
        object MovingObject;
        Grid ClickedGrid;
        MenuBox _menu;
        public StatusWindow _status;
        public ProgramInfo _info;
        public StackBuffWindow _stacK_buff;
        public Equip _equip;
        public DBManager _db_manager;
        public MonsterDamageCheck _damage_check;

        public MainWindow()
        {
            InitializeComponent();
            _menu = new MenuBox(this);
            menu_contents.Navigate(_menu);
            SetMouseEventControl(menu_titlebar);

            _status = new StatusWindow();
            status_contents.Navigate(_status);
            SetMouseEventControl(status_titlebar);
            _stacK_buff = new StackBuffWindow();
            stack_buff_contents.Navigate(_stacK_buff);
            SetMouseEventControl(stack_buff_titlebar);
            _equip = new Equip();
            equip_contents.Navigate(_equip);
            SetMouseEventControl(equip_titlebar);
            _damage_check = new MonsterDamageCheck();
            damage_check_contents.Navigate(_damage_check);
            SetMouseEventControl(damage_check_titlebar);

            System.Windows.Media.Brush brush = DesigningCanvas.Background;
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

        void SetMouseEventControl(Border titlebar)
        {
            titlebar.PreviewMouseLeftButtonDown += this.ObjMouseLeftButtonDown;
            titlebar.PreviewMouseLeftButtonUp += this.ObjPreviewMouseLeftButtonUp;
            titlebar.PreviewMouseMove += this.ObjMouseMove;
        }
        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void status_closeButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ObjMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (MovingObject == null)
            {
                ClickedGrid = (sender as Border).Parent as Grid;
                objXPos = e.GetPosition(ClickedGrid).X;
                objYPos = e.GetPosition(ClickedGrid).Y;
                MovingObject = ClickedGrid;
                ClickedGrid.CaptureMouse();
            }
            
        }
        private void ObjMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                (MovingObject as FrameworkElement).SetValue(Canvas.LeftProperty,
                    e.GetPosition((MovingObject as FrameworkElement).Parent as FrameworkElement).X - objXPos);

                (MovingObject as FrameworkElement).SetValue(Canvas.TopProperty,
                    e.GetPosition((MovingObject as FrameworkElement).Parent as FrameworkElement).Y - objYPos);
            }
        }

        private void ObjPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            MovingObject = null;
            ClickedGrid.ReleaseMouseCapture();
        }

    }
}
