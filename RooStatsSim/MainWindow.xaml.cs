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
using RooStatsSim.UI.Status;
using RooStatsSim.UI.Manager;
using RooStatsSim.UI.ACK;
using RooStatsSim.User;
using RooStatsSim.UI.StackBuff;
using RooStatsSim.UI.Equipment;
using RooStatsSim.UI.Menu;
using System.Windows.Shapes;

namespace RooStatsSim
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
<<<<<<< HEAD

        public static DBlist _roo_db;
        DBManager _db_manager;
        StatusWindow _status = new StatusWindow();
        ProgramInfo _info = new ProgramInfo();
        StackBuff _stacK_buff = new StackBuff();
        Equip _equip;

=======
        double objXPos, objYPos;
        object MovingObject;
        MenuBox _menu;
        public StatusWindow _status;
        public ProgramInfo _info;
        public StackBuffWindow _stacK_buff;
        public Equip _equip;
        public DBManager _db_manager;
>>>>>>> Feat/DesignRebuilding
        public MainWindow()
        {
            InitializeComponent();
            _menu = new MenuBox(this);
            menu_contents.Navigate(_menu);
            menu_titlebar.PreviewMouseLeftButtonDown += this.ObjMouseLeftButtonDown;
            menu_titlebar.PreviewMouseLeftButtonUp += this.ObjPreviewMouseLeftButtonUp;
            menu_titlebar.PreviewMouseMove += this.ObjMouseMove;

            _status = new StatusWindow();
            status_contents.Navigate(_status);
            _info = new ProgramInfo();
            _stacK_buff = new StackBuffWindow();
            _equip = new Equip();

<<<<<<< HEAD
            //DB생성, Window open 등

            //_status.Show();
            //_stacK_buff.Show();
            //_equip.Show();

             _equip = new Equip();
            _equip.Show();
=======
            System.Windows.Media.Brush brush = DesigningCanvas.Background;
>>>>>>> Feat/DesignRebuilding
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


        private void ATK_ReverseClick(object sender, RoutedEventArgs e)
        {
            //InputUIData();

            //txt_atk_equip.Text = Convert.ToString(job_selection.GetReverseATK(Convert.ToInt32(txt_sATK.Text)));
        }

        private void CalcSim_Click(object sender, RoutedEventArgs e)
        {
            //InputUIData();

            //double skill_damage = (Convert.ToInt32(txt_skill_percent.Text) + Convert.ToInt32(txt_skill_add_percent.Text)) * 0.01;
            //int calcATK_min = Convert.ToInt32(Math.Floor(job_selection.GetMinATK() * skill_damage));
            //int calcATK_max = Convert.ToInt32(Math.Floor(job_selection.GetMaxATK() * skill_damage));

            //retCalc.Text = Convert.ToString(calcATK_min) + " ~ " + Convert.ToString(calcATK_max);
            //txt_sATK.Text = Convert.ToString(job_selection.GetWinATK());
        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            //BuffList[Convert.ToInt32(((e.Source as CheckBox).Tag))] = (bool)((e.Source as CheckBox).IsChecked);

            //MessageBox.Show(Convert.ToString((e.Source as CheckBox).IsChecked));
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
            Grid moveTarget = (sender as Rectangle).Parent as Grid;
            objXPos = e.GetPosition(moveTarget).X;
            objYPos = e.GetPosition(moveTarget).Y;
            MovingObject = (object)moveTarget;
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
        }

    }
}
