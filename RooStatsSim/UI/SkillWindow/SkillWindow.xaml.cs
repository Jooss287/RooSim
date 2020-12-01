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
        public SkillWindow()
        {
            InitializeComponent();
        }
    }
}
