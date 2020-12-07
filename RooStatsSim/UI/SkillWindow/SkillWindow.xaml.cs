using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using RooStatsSim.DB.Skill.JobSkill;
using RooStatsSim.User;

namespace RooStatsSim.UI.SkillWindow
{
    /// <summary>
    /// SkillWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class SkillWindow : UserControl
    {
        #region skill Info
        public static SwordmanSkill _swordman_skill = new SwordmanSkill();
        public static LoadKnightSkill _loadknight_skill = new LoadKnightSkill();
        #endregion

        UserData _user_data;
        

        public SkillWindow()
        {
            _user_data = MainWindow._user_data;
            _user_data.JobDataChanged += new UserData.JobChangedEventHandler(RefrashSkill);
            InitializeComponent();

            RefrashSkill();
        }
        public void RefrashSkill()
        {
            SkillSelector.ItemsSource = _user_data.User_Skill.List;
        }

        private void skill_lv_Wheel(object sender, MouseWheelEventArgs e)
        {

        }

        private void ContentControl_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void ContentControl_MouseLeave(object sender, MouseEventArgs e)
        {

        }
    }
}
