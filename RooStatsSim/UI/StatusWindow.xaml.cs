using RooStatsSim.DB;
using System;
using System.Windows;
using System.Windows.Controls;
using RooStatsSim.User;
using RooStatsSim.DB;

namespace RooStatsSim.UI
{
    /// <summary>
    /// StatusWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class StatusWindow : Window
    {
        AbilityBinding BindingLevel;
        AbilityBinding BindingLevelPoint;
        StatusList BindingStatusList;
        UserData statusDB;

        public StatusWindow()
        {
            //DB가 레퍼로 들어왔다 치고.
            statusDB = new UserData();

            InitializeComponent();

            DataContext = this;
            BindingStatusList = new StatusList(ref statusDB);
            StatusListBox.ItemsSource = BindingStatusList;

            BindingLevel = new AbilityBinding(Enum.GetName(typeof(LEVEL_ENUM), LEVEL_ENUM.BASE), statusDB.Level[(int)LEVEL_ENUM.BASE]);
            BaseLvlUI.DataContext = BindingLevel;
            BindingLevelPoint = new AbilityBinding(Enum.GetName(typeof(LEVEL_ENUM), LEVEL_ENUM.BASE_POINT), statusDB.Level[(int)LEVEL_ENUM.BASE_POINT]);
            BaseLvlUIpoint.DataContext = BindingLevelPoint;
        }

        private void StatusUp_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var tb = sender as StackPanel;
            AbilityBinding dataCxtx = tb.DataContext as AbilityBinding;

            STATUS_ENUM statusName = (STATUS_ENUM)Enum.Parse(typeof(STATUS_ENUM), dataCxtx.Name);
            ABILITTY status = statusDB.Status[(int)statusName];
            status.Point++;
            dataCxtx.UpdateAbility(status);
        }

        private void StatusDown_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var tb = sender as StackPanel;
            AbilityBinding dataCxtx = tb.DataContext as AbilityBinding;

            STATUS_ENUM statusName = (STATUS_ENUM)Enum.Parse(typeof(STATUS_ENUM), dataCxtx.Name);
            ABILITTY status = statusDB.Status[(int)statusName];
            status.Point--;
            dataCxtx.UpdateAbility(status);
        }

        private void LevelUp_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var tb = sender as StackPanel;
            AbilityBinding dataCxtx = tb.DataContext as AbilityBinding;

            LEVEL_ENUM LevelName = (LEVEL_ENUM)Enum.Parse(typeof(LEVEL_ENUM), dataCxtx.Name);
            ABILITTY Level = statusDB.Level[(int)LevelName];
            ABILITTY LevelStatsPoint = statusDB.Level[(int)LEVEL_ENUM.BASE_POINT];
            Level.Point++;
            LevelStatsPoint.Point += StatsPointTable.LevelUpStatusPoint[Level.Point];
            dataCxtx.UpdateAbility(Level);
            BindingLevelPoint.UpdateAbility(LevelStatsPoint);
        }

        private void LevelDown_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var tb = sender as StackPanel;
            AbilityBinding dataCxtx = tb.DataContext as AbilityBinding;

            LEVEL_ENUM LevelName = (LEVEL_ENUM)Enum.Parse(typeof(LEVEL_ENUM), dataCxtx.Name);
            ABILITTY Level = statusDB.Level[(int)LevelName];
            ABILITTY LevelStatsPoint = statusDB.Level[(int)LEVEL_ENUM.BASE_POINT];
            Level.Point--;
            LevelStatsPoint.Point -= StatsPointTable.LevelUpStatusPoint[Level.Point];
            dataCxtx.UpdateAbility(Level);
            BindingLevelPoint.UpdateAbility(LevelStatsPoint);
        }
    }
}
