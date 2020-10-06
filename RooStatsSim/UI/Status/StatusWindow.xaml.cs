using System;
using System.Windows;
using System.Windows.Controls;
using RooStatsSim.User;
using RooStatsSim.DB.Table;

namespace RooStatsSim.UI.Status
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
            statusDB = UserData.GetInstance;

            InitializeComponent();

            DataContext = this;
            BindingStatusList = new StatusList(ref statusDB);
            StatusListBox.ItemsSource = BindingStatusList;

            BindingLevel = new AbilityBinding(Enum.GetName(typeof(LEVEL_ENUM), LEVEL_ENUM.BASE), statusDB.Level[(int)LEVEL_ENUM.BASE]);
            BaseLvlUI.DataContext = BindingLevel;
            BindingLevelPoint = new AbilityBinding(Enum.GetName(typeof(LEVEL_ENUM), LEVEL_ENUM.BASE_POINT), statusDB.Level[(int)LEVEL_ENUM.BASE_POINT]);
            BaseLvlUIpoint.DataContext = BindingLevelPoint;
        }

        void StatusPointUp(AbilityBinding dataCxtx)
        {
            STATUS_ENUM statusName = (STATUS_ENUM)Enum.Parse(typeof(STATUS_ENUM), dataCxtx.Name);
            ABILITTY status = statusDB.Status[(int)statusName];
            ABILITTY LevelStatsPoint = statusDB.Level[(int)LEVEL_ENUM.BASE_POINT];
            LevelStatsPoint.Point -= StatsPointTable.StatusNeedPoint[status.Point];
            status.Point++;
            dataCxtx.UpdateAbility(status);
            BindingLevelPoint.UpdateAbility(LevelStatsPoint);
        }

        void StatusPointDown(AbilityBinding dataCxtx)
        {
            STATUS_ENUM statusName = (STATUS_ENUM)Enum.Parse(typeof(STATUS_ENUM), dataCxtx.Name);
            ABILITTY status = statusDB.Status[(int)statusName];
            ABILITTY LevelStatsPoint = statusDB.Level[(int)LEVEL_ENUM.BASE_POINT];
            status.Point--;
            LevelStatsPoint.Point += StatsPointTable.StatusNeedPoint[status.Point];
            dataCxtx.UpdateAbility(status);
            BindingLevelPoint.UpdateAbility(LevelStatsPoint);
        }

        void LevelUp(AbilityBinding dataCxtx)
        {
            LEVEL_ENUM LevelName = (LEVEL_ENUM)Enum.Parse(typeof(LEVEL_ENUM), dataCxtx.Name);
            ABILITTY Level = statusDB.Level[(int)LevelName];
            ABILITTY LevelStatsPoint = statusDB.Level[(int)LEVEL_ENUM.BASE_POINT];
            Level.Point++;
            LevelStatsPoint.Point += StatsPointTable.LevelUpStatusPoint[Level.Point];
            dataCxtx.UpdateAbility(Level);
            BindingLevelPoint.UpdateAbility(LevelStatsPoint);
        }

        void LevelDown(AbilityBinding dataCxtx)
        {
            LEVEL_ENUM LevelName = (LEVEL_ENUM)Enum.Parse(typeof(LEVEL_ENUM), dataCxtx.Name);
            ABILITTY Level = statusDB.Level[(int)LevelName];
            ABILITTY LevelStatsPoint = statusDB.Level[(int)LEVEL_ENUM.BASE_POINT];
            Level.Point--;
            LevelStatsPoint.Point -= StatsPointTable.LevelUpStatusPoint[Level.Point];
            dataCxtx.UpdateAbility(Level);
            BindingLevelPoint.UpdateAbility(LevelStatsPoint);
        }

        #region Mouse reaction func
        private void StatusUp_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var tb = sender as StackPanel;
            AbilityBinding dataCxtx = tb.DataContext as AbilityBinding;

            StatusPointUp(dataCxtx);
        }

        private void StatusDown_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var tb = sender as StackPanel;
            AbilityBinding dataCxtx = tb.DataContext as AbilityBinding;

            StatusPointDown(dataCxtx);
        }

        private void LevelUp_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var tb = sender as StackPanel;
            AbilityBinding dataCxtx = tb.DataContext as AbilityBinding;

            LevelUp(dataCxtx);
        }

        private void LevelDown_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var tb = sender as StackPanel;
            AbilityBinding dataCxtx = tb.DataContext as AbilityBinding;

            LevelDown(dataCxtx);
        }

        private void Level_MouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
        {
            var tb = sender as StackPanel;
            AbilityBinding dataCxtx = tb.DataContext as AbilityBinding;

            if (e.Delta < 0)
                LevelDown(dataCxtx);
            else
                LevelUp(dataCxtx);
                
        }

        private void Status_MouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
        {
            var tb = sender as StackPanel;
            AbilityBinding dataCxtx = tb.DataContext as AbilityBinding;

            if (e.Delta < 0)
                StatusPointDown(dataCxtx);
            else
                StatusPointUp(dataCxtx);
        }

        #endregion


    }
}
