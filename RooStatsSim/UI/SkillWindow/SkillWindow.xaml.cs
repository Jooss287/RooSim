using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Collections.Generic;
using RooStatsSim.DB.Skill;
using RooStatsSim.DB.Skill.JobSkill;
using RooStatsSim.User;

namespace RooStatsSim.UI.SkillWindow
{
    /// <summary>
    /// SkillWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class SkillWindow : UserControl
    {
        public static Skill_DB _skill_db = new Skill_DB();

        UserData _user_data;
        Popup skillPopup = new Popup();

        public SkillWindow()
        {
            MainWindow._user_data_manager.JobDataChanged += new UserDataManager.JobChangedEventHandler(GetUserData);
            InitializeComponent();
        }
        void GetUserData()
        {
            _user_data = MainWindow._user_data_manager.Data;
            SkillSelector.ItemsSource = _user_data.User_Skill.List;
        }

        void ChangeSkillLevel(UserSkill.UserSkillInfo skill, int i)
        {
            skill.Level += i;
            if (skill.Detail.OPTION.Count != 0)
                MainWindow._user_data_manager.CalcUserData();
            else
                MainWindow._user_data_manager._user_data_edited = true;
        }
        private void skill_lv_Wheel(object sender, MouseWheelEventArgs e)
        {
            UserSkill.UserSkillInfo skill = ((sender as ContentControl).Content as StackPanel).DataContext as UserSkill.UserSkillInfo;
            ChangeSkillLevel(skill, e.Delta > 0 ? 1 : -1);
        }
        private void ContentControl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            UserSkill.UserSkillInfo skill = ((sender as ContentControl).Content as StackPanel).DataContext as UserSkill.UserSkillInfo;
            ChangeSkillLevel(skill, 1);
        }

        private void ContentControl_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            UserSkill.UserSkillInfo skill = ((sender as ContentControl).Content as StackPanel).DataContext as UserSkill.UserSkillInfo;
            ChangeSkillLevel(skill, 1);
        }

        private void ContentControl_MouseEnter(object sender, MouseEventArgs e)
        {
            UserSkill.UserSkillInfo skill = ((sender as ContentControl).Content as StackPanel).DataContext as UserSkill.UserSkillInfo;
            SetSkillTextBlock(skill);

            skillPopup.PlacementTarget = ((sender as ContentControl).Content as StackPanel).Children[0];
            skillPopup.IsOpen = true;
        }

        private void ContentControl_MouseLeave(object sender, MouseEventArgs e)
        {
            skillPopup.IsOpen = false;
        }

        void SetSkillTextBlock(UserSkill.UserSkillInfo skill)
        {
            TextBlock PopupText = new TextBlock
            {
                Text = skill.Name_Kor,
                Background = Brushes.Silver
            };
            skillPopup.Child = PopupText;
        }
    }
}
