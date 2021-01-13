using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Controls.Primitives;
using System.Collections.Generic;
using RooStatsSim.DB.ConsumableItem;
using RooStatsSim.User;


namespace RooStatsSim.UI.ConsumableBuff
{
    /// <summary>
    /// ComsumableBuffWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ConsumableBuffWindow : UserControl
    {
        public static ConsumableBuff_DB _consumable_buff_db = new ConsumableBuff_DB();

        UserData _user_data;
        Popup skillPopup = new Popup();
        ConsumableBinding _consumable_binding;

        public ConsumableBuffWindow()
        {
            MainWindow._user_data_manager.JobDataChanged += new UserDataManager.JobChangedEventHandler(GetUserData);
            InitializeComponent();
        }

        void GetUserData()
        {
            _user_data = MainWindow._user_data_manager.Data;
            CalcConsumableBuffProperty();
        }
        void CalcConsumableBuffProperty()
        {
            _consumable_binding = new ConsumableBinding(_user_data, _consumable_buff_db.Dic);
            BuffSelector.ItemsSource = _consumable_binding;
        }

        void ChangeBuffLevel(ConsumableBindingInfo buff, int i)
        {
            buff.Level += i;
            MainWindow._user_data_manager.CalcUserData();
        }
        private void buff_lv_Wheel(object sender, MouseWheelEventArgs e)
        {
            ConsumableBindingInfo buff = ((sender as ContentControl).Content as StackPanel).DataContext as ConsumableBindingInfo;
            ChangeBuffLevel(buff, e.Delta > 0 ? 1 : -1);
        }

        private void ContentControl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ConsumableBindingInfo buff = ((sender as ContentControl).Content as StackPanel).DataContext as ConsumableBindingInfo;
            ChangeBuffLevel(buff, 1);
        }

        private void ContentControl_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            ConsumableBindingInfo buff = ((sender as ContentControl).Content as StackPanel).DataContext as ConsumableBindingInfo;
            ChangeBuffLevel(buff, 1);
        }

        private void ContentControl_MouseEnter(object sender, MouseEventArgs e)
        {
            ConsumableBindingInfo buff = ((sender as ContentControl).Content as StackPanel).DataContext as ConsumableBindingInfo;
            SetBuffTextBlock(buff);

            skillPopup.PlacementTarget = ((sender as ContentControl).Content as StackPanel).Children[0];
            skillPopup.IsOpen = true;
        }

        private void ContentControl_MouseLeave(object sender, MouseEventArgs e)
        {
            skillPopup.IsOpen = false;
        }

        void SetBuffTextBlock(ConsumableBindingInfo buff)
        {
            TextBlock PopupText = new TextBlock
            {
                Text = _consumable_buff_db.Dic[buff.Name].NAME_KOR,
                Background = Brushes.Silver
            };
            skillPopup.Child = PopupText;
        }
    }
}
