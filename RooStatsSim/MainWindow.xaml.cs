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

namespace RooStatsSim
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        MenuBox _menu = new MenuBox();
        public MainWindow()
        {
            InitializeComponent();

            Content = _menu;
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

        
    }
}
