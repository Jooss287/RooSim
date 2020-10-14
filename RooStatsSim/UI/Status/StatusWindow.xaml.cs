using System;
using System.Windows;
using System.Windows.Controls;
using RooStatsSim.User;
using RooStatsSim.DB.Table;
using System.Windows.Navigation;

namespace RooStatsSim.UI.Status
{
    /// <summary>
    /// StatusWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class StatusWindow : Window
    {
        UserData user_data;

        AbilityBinding<int> bindingLevel;
        AbilityBinding<int> bindingLevelPoint;
        StatusList bindingStatusList;

        NormalPropertyList normalPropertyList;
        AdvancedPropertyList advancedPropertyList;
        public StatusWindow()
        {
            //DB가 레퍼로 들어왔다 치고.
            user_data = UserData.GetInstance;
            user_data.itemDataChanged += new UserData.UserDataChangedEventHandler(CalcStatusProperty);

            InitializeComponent();

            DataContext = this;
            bindingStatusList = new StatusList(ref user_data);
            StatusListBox.ItemsSource = bindingStatusList;

            CalcStatusProperty();

            bindingLevel = new AbilityBinding<int>(Enum.GetName(typeof(LEVEL_ENUM), LEVEL_ENUM.BASE), user_data.Level[(int)LEVEL_ENUM.BASE]);
            BaseLvlUI.DataContext = bindingLevel;
            bindingLevelPoint = new AbilityBinding<int>(Enum.GetName(typeof(LEVEL_ENUM), LEVEL_ENUM.BASE_POINT), user_data.Level[(int)LEVEL_ENUM.BASE_POINT]);
            BaseLvlUIpoint.DataContext = bindingLevelPoint;
        }

        void CalcStatusProperty()
        {
            normalPropertyList = new NormalPropertyList(ref user_data);
            NormalProperty.ItemsSource = normalPropertyList;
            advancedPropertyList = new AdvancedPropertyList(ref user_data);
            AdvancedProperty.ItemsSource = advancedPropertyList;
        }

        void StatusPointUp(AbilityBinding<int> dataCxtx)
        {
            STATUS_ENUM statusName = (STATUS_ENUM)Enum.Parse(typeof(STATUS_ENUM), dataCxtx.Name);
            ABILITTY<int> status = user_data.Status[(int)statusName];
            ABILITTY<int> LevelStatsPoint = user_data.Level[(int)LEVEL_ENUM.BASE_POINT];
            LevelStatsPoint.Point -= StatsPointTable.StatusNeedPoint[status.Point];
            status.Point++;
            dataCxtx.UpdateAbility(status);
            bindingLevelPoint.UpdateAbility(LevelStatsPoint);
        }

        void StatusPointDown(AbilityBinding<int> dataCxtx)
        {
            STATUS_ENUM statusName = (STATUS_ENUM)Enum.Parse(typeof(STATUS_ENUM), dataCxtx.Name);
            ABILITTY<int> status = user_data.Status[(int)statusName];
            ABILITTY<int> LevelStatsPoint = user_data.Level[(int)LEVEL_ENUM.BASE_POINT];
            status.Point--;
            LevelStatsPoint.Point += StatsPointTable.StatusNeedPoint[status.Point];
            dataCxtx.UpdateAbility(status);
            bindingLevelPoint.UpdateAbility(LevelStatsPoint);
        }

        void LevelUp(AbilityBinding<int> dataCxtx)
        {
            LEVEL_ENUM LevelName = (LEVEL_ENUM)Enum.Parse(typeof(LEVEL_ENUM), dataCxtx.Name);
            ABILITTY<int> Level = user_data.Level[(int)LevelName];
            ABILITTY<int> LevelStatsPoint = user_data.Level[(int)LEVEL_ENUM.BASE_POINT];
            Level.Point++;
            LevelStatsPoint.Point += StatsPointTable.LevelUpStatusPoint[Level.Point];
            dataCxtx.UpdateAbility(Level);
            bindingLevelPoint.UpdateAbility(LevelStatsPoint);
        }

        void LevelDown(AbilityBinding<int> dataCxtx)
        {
            LEVEL_ENUM LevelName = (LEVEL_ENUM)Enum.Parse(typeof(LEVEL_ENUM), dataCxtx.Name);
            ABILITTY<int> Level = user_data.Level[(int)LevelName];
            ABILITTY<int> LevelStatsPoint = user_data.Level[(int)LEVEL_ENUM.BASE_POINT];
            Level.Point--;
            LevelStatsPoint.Point -= StatsPointTable.LevelUpStatusPoint[Level.Point];
            dataCxtx.UpdateAbility(Level);
            bindingLevelPoint.UpdateAbility(LevelStatsPoint);
        }

        #region Mouse reaction func
        private void StatusUp_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var tb = sender as StackPanel;
            AbilityBinding<int> dataCxtx = tb.DataContext as AbilityBinding<int>;

            StatusPointUp(dataCxtx);
        }

        private void StatusDown_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var tb = sender as StackPanel;
            AbilityBinding<int> dataCxtx = tb.DataContext as AbilityBinding<int>;

            StatusPointDown(dataCxtx);
        }

        private void LevelUp_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var tb = sender as StackPanel;
            AbilityBinding<int> dataCxtx = tb.DataContext as AbilityBinding<int>;

            LevelUp(dataCxtx);
        }

        private void LevelDown_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var tb = sender as StackPanel;
            AbilityBinding<int> dataCxtx = tb.DataContext as AbilityBinding<int>;

            LevelDown(dataCxtx);
        }

        private void Level_MouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
        {
            var tb = sender as StackPanel;
            AbilityBinding<int> dataCxtx = tb.DataContext as AbilityBinding<int>;

            if (e.Delta < 0)
                LevelDown(dataCxtx);
            else
                LevelUp(dataCxtx);
                
        }

        private void Status_MouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
        {
            var tb = sender as StackPanel;
            AbilityBinding<int> dataCxtx = tb.DataContext as AbilityBinding<int>;

            if (e.Delta < 0)
                StatusPointDown(dataCxtx);
            else
                StatusPointUp(dataCxtx);
        }

        #endregion


    }
}
