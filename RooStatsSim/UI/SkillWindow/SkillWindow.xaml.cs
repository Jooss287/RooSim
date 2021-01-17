using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using RooStatsSim.DB.Job.JobInfo;
using RooStatsSim.User;
using RooStatsSim.DB.Skill;


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
        SkillBinding _skill_binding;

        public SkillWindow()
        {
            MainWindow._user_data_manager.JobDataChanged += new UserDataManager.JobChangedEventHandler(GetUserData);
            InitializeComponent();
        }
        void GetUserData()
        {
            _user_data = MainWindow._user_data_manager.Data;
            CalcSkillProperty();
        }
        void CalcSkillProperty()
        {
            _skill_binding = new SkillBinding(_user_data, _skill_db.GetJobInitSkills(_user_data.Job));
            SkillSelector.ItemsSource = _skill_binding;
        }

        void ChangeSkillLevel(SkillBindingInfo skill, int i)
        {
            skill.Level += i;
            _user_data.User_Skill.SetSkillLevel(skill.Name, skill.Level);
            if (skill.Detail.OPTION.Count != 0)
                MainWindow._user_data_manager.CalcUserData();
            else
                MainWindow._user_data_manager._user_data_edited = true;
        }
        private void skill_lv_Wheel(object sender, MouseWheelEventArgs e)
        {
            SkillBindingInfo skill = ((sender as ContentControl).Content as StackPanel).DataContext as SkillBindingInfo;
            ChangeSkillLevel(skill, e.Delta > 0 ? 1 : -1);
        }
        private void ContentControl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            SkillBindingInfo skill = ((sender as ContentControl).Content as StackPanel).DataContext as SkillBindingInfo;
            ChangeSkillLevel(skill, 1);
        }

        private void ContentControl_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            SkillBindingInfo skill = ((sender as ContentControl).Content as StackPanel).DataContext as SkillBindingInfo;
            ChangeSkillLevel(skill, 1);
        }

        private void ContentControl_MouseEnter(object sender, MouseEventArgs e)
        {
            SkillBindingInfo skill = ((sender as ContentControl).Content as StackPanel).DataContext as SkillBindingInfo;
            SetSkillTextBlock(skill);

            skillPopup.PlacementTarget = ((sender as ContentControl).Content as StackPanel).Children[0];
            skillPopup.IsOpen = true;
        }

        private void ContentControl_MouseLeave(object sender, MouseEventArgs e)
        {
            skillPopup.IsOpen = false;
        }

        void SetSkillTextBlock(SkillBindingInfo skill)
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
