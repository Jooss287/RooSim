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
        #region buff Info
        CookingConsumable _cooking_consumable = new CookingConsumable();
        PortionConsumable _portion_consumable = new PortionConsumable();
        #endregion

        UserData _user_data;
        Popup skillPopup = new Popup();

        public ConsumableBuffWindow()
        {
            MainWindow._user_data_manager.JobDataChanged += new UserDataManager.JobChangedEventHandler(GetUserData);
            InitializeComponent();
        }

        void GetUserData()
        {
            _user_data = MainWindow._user_data_manager.Data;
            _user_data.User_ConBuff.InitBuffs(_cooking_consumable.Buff, _portion_consumable.Buff);
            BuffSelector.ItemsSource = _user_data.User_ConBuff.List;
        }
        void ChangeBuffLevel(UserConsumableBuff.UserConsumableBuffnfo buff, int i)
        {
            buff.Level += i;
            if (buff.Detail.OPTION.Count != 0)
                MainWindow._user_data_manager.CalcUserData();
        }
        private void buff_lv_Wheel(object sender, MouseWheelEventArgs e)
        {
            UserConsumableBuff.UserConsumableBuffnfo buff = ((sender as ContentControl).Content as StackPanel).DataContext as UserConsumableBuff.UserConsumableBuffnfo;
            ChangeBuffLevel(buff, e.Delta > 0 ? 1 : -1);
        }

        private void ContentControl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            UserConsumableBuff.UserConsumableBuffnfo buff = ((sender as ContentControl).Content as StackPanel).DataContext as UserConsumableBuff.UserConsumableBuffnfo;
            ChangeBuffLevel(buff, 1);
        }

        private void ContentControl_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            UserConsumableBuff.UserConsumableBuffnfo buff = ((sender as ContentControl).Content as StackPanel).DataContext as UserConsumableBuff.UserConsumableBuffnfo;
            ChangeBuffLevel(buff, 1);
        }

        private void ContentControl_MouseEnter(object sender, MouseEventArgs e)
        {
            UserConsumableBuff.UserConsumableBuffnfo buff = ((sender as ContentControl).Content as StackPanel).DataContext as UserConsumableBuff.UserConsumableBuffnfo;
            SetBuffTextBlock(buff);

            skillPopup.PlacementTarget = ((sender as ContentControl).Content as StackPanel).Children[0];
            skillPopup.IsOpen = true;
        }

        private void ContentControl_MouseLeave(object sender, MouseEventArgs e)
        {
            skillPopup.IsOpen = false;
        }

        void SetBuffTextBlock(UserConsumableBuff.UserConsumableBuffnfo buff)
        {
            TextBlock PopupText = new TextBlock
            {
                Text = buff.Name_Kor,
                Background = Brushes.Silver
            };
            skillPopup.Child = PopupText;
        }
    }
}
