using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using RooStatsSim.User;
using RooStatsSim.UI.Menu;
using RooStatsSim.DB.Table;
using System.Windows.Navigation;

namespace RooStatsSim.UI.StatusWindow
{
    /// <summary>
    /// StatusWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class StatusWindow : UserControl
    {
        UserData user_data;

        LevelList bindingLevel;
        StatusList bindingStatusList;
        NormalPropertyList normalPropertyList;
        AdvancedPropertyList advancedPropertyList;
        SpecialPropertyList specialPropertyList;

        #region Initialize
        public StatusWindow()
        {
            user_data = MainWindow._user_data;
            user_data.itemDataChanged += new UserData.UserDataChangedEventHandler(CalcStatusProperty);

            InitializeComponent();

            DataContext = this;
            
            CalcStatusProperty();
        }
        void CalcStatusProperty()
        {
            bindingLevel = new LevelList(ref user_data);
            LvlUI.ItemsSource = bindingLevel;
            BaseLvlUIpoint.DataContext = bindingLevel;
            bindingStatusList = new StatusList(ref user_data);
            StatusListBox.ItemsSource = bindingStatusList;
            normalPropertyList = new NormalPropertyList(ref user_data);
            NormalProperty.ItemsSource = normalPropertyList;
            advancedPropertyList = new AdvancedPropertyList(ref user_data);
            AdvancedProperty.ItemsSource = advancedPropertyList;
            specialPropertyList = new SpecialPropertyList(ref user_data);
            SpecialProperty.ItemsSource = specialPropertyList;
        }
        #endregion
        #region Status Point
        private void StatusUp_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var tb = sender as StackPanel;
            AbilityBinding<int> dataCxtx = tb.DataContext as AbilityBinding<int>;
            StatusPointUp(dataCxtx, 1);
        }

        private void StatusDown_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var tb = sender as StackPanel;
            AbilityBinding<int> dataCxtx = tb.DataContext as AbilityBinding<int>;
            StatusPointDown(dataCxtx, 1);
        }
        private void Status_MouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
        {
            var tb = sender as StackPanel;
            AbilityBinding<int> dataCxtx = tb.DataContext as AbilityBinding<int>;

            if (e.Delta < 0)
                StatusPointDown(dataCxtx, 1);
            else
                StatusPointUp(dataCxtx, 1);
        }
        void StatusPointUp(AbilityBinding<int> dataCxtx, int changeValue)
        {
            if (dataCxtx == null)
                return;
            if ((Keyboard.IsKeyDown(Key.LeftShift)) || (Keyboard.IsKeyDown(Key.RightShift)))
                changeValue *= 10;
            STATUS_ENUM statusName = (STATUS_ENUM)Enum.Parse(typeof(STATUS_ENUM), dataCxtx.Name);
            for (int i = changeValue; i != 0; i--)
            {
                user_data.Base_Level.RemainPoint -= user_data.Status.List[(int)statusName].NecessaryPoint;
                user_data.Status.List[(int)statusName].Point++;
            }
            user_data.CalcUserData();
        }

        void StatusPointDown(AbilityBinding<int> dataCxtx, int changeValue)
        {
            if (dataCxtx == null)
                return;
            if ((Keyboard.IsKeyDown(Key.LeftShift)) || (Keyboard.IsKeyDown(Key.RightShift)))
                changeValue *= 10;
            STATUS_ENUM statusName = (STATUS_ENUM)Enum.Parse(typeof(STATUS_ENUM), dataCxtx.Name);
            for (int i = changeValue; i != 0; i--)
            {
                int nextPoint = user_data.Status.List[(int)statusName].Point - 1;
                user_data.Status.List[(int)statusName].Point = nextPoint;
                if (nextPoint != 0)
                    user_data.Base_Level.RemainPoint += user_data.Status.List[(int)statusName].NecessaryPoint;
            }
            user_data.CalcUserData();
        }
        #endregion
        #region Level Point
        private void LevelUp_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var tb = sender as Grid;
            AbilityBinding<int> dataCxtx = tb.DataContext as AbilityBinding<int>;
            LevelChange(dataCxtx, 1);
        }

        private void LevelDown_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var tb = sender as Grid;
            AbilityBinding<int> dataCxtx = tb.DataContext as AbilityBinding<int>;
            LevelChange(dataCxtx, -1);
        }

        private void Level_MouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
        {
            var tb = sender as Grid;
            AbilityBinding<int> dataCxtx = tb.DataContext as AbilityBinding<int>;
            int value = 1;
            if (e.Delta < 0)
                value = -1;

            LevelChange(dataCxtx, value);
        }

        void LevelChange(AbilityBinding<int> dataCxtx, int changeValue)
        {
            if (dataCxtx == null)
                return;
            if ((Keyboard.IsKeyDown(Key.LeftShift)) || (Keyboard.IsKeyDown(Key.RightShift)))
                changeValue *= 10;
            LEVEL_ENUM LevelName = (LEVEL_ENUM)Enum.Parse(typeof(LEVEL_ENUM), dataCxtx.EnumName);
            if (LevelName == LEVEL_ENUM.BASE)
                user_data.Base_Level.Point += changeValue;
            else
                user_data.Job_Level.Point += changeValue;

            user_data.CalcUserData();
        }
        #endregion
    }
}
