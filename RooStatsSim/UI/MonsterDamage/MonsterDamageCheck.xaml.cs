using System.Linq;
using System.Windows;
using System.Windows.Controls;
using RooStatsSim.UI.Menu;
using RooStatsSim.UI.Manager;
using RooStatsSim.User;
using RooStatsSim.Equation.Job;
using RooStatsSim.DB.Table;
using RooStatsSim.User;
using System;

namespace RooStatsSim.UI.MonsterDamage
{
    /// <summary>
    /// MonsterDamageCheck.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MonsterDamageCheck : UserControl
    {
        MonsterDB_Binding now_mob = new MonsterDB_Binding();
        MonsterListBox BindingMobList;
        CalcUserDamageBinding _calc_user_dmamge_binding;
        public MonsterDamageCheck()
        {
            InitializeComponent();

            DataContext = now_mob;
            InitializeContents();

            BindingMobList = new MonsterListBox(MainWindow._roo_db.Mob_db);
            DB_ListBox.ItemsSource = BindingMobList;

            MainWindow._user_data_manager.itemDataChanged += new UserDataManager.UserDataChangedEventHandler(CalcDamage);
            CalcDamage();
        }
        void InitializeContents()
        {
            now_mob.Name = "";
            now_mob.Level = 0;
            now_mob.Type = (int)MONSTER_KINDS_TYPE.NORMAL;
            now_mob.StatusInfo = new DB.Status();
            now_mob.Tribe = 0;
            now_mob.Element = 0;
            now_mob.Size = 0;
            now_mob.Atk = 0;
            now_mob.Matk = 0;
            now_mob.Hp = 0;
            now_mob.Def = 0;
            now_mob.Mdef = 0;
            now_mob.Hit = 0;
            now_mob.Flee = 0;
        }
        void CalcDamage()
        {
            if (now_mob.Name == "")
                return;

            UserData user_data = MainWindow._user_data_manager.Data;
            user_data.JobSelect.SetUserData(user_data);
            int skill_damage = 1;
            
            int calcATK_min = Convert.ToInt32(Math.Floor(user_data.JobSelect.GetMinATK() * skill_damage));
            int calcATK_max = Convert.ToInt32(Math.Floor(user_data.JobSelect.GetMaxATK() * skill_damage));

            string normal_atk = Convert.ToString(calcATK_min) + " ~ " + Convert.ToString(calcATK_max);
            _calc_user_dmamge_binding = new CalcUserDamageBinding("평타", normal_atk);
            foreach(UserSkill.UserSkillInfo info in user_data.User_Skill.GetActiveSkills())
            {
                if (info.Level == 0)
                    continue;
                //if ( info.Detail.HAS_DMG_EQUATION )
                normal_atk = Convert.ToString(calcATK_min*info.Detail.DAMAGE[info.Level]) + " ~ " + Convert.ToString(calcATK_max * info.Detail.DAMAGE[info.Level]);
                _calc_user_dmamge_binding.AddDamageBinding(info.Name_Kor, normal_atk);
            }
            CalcUserDamage.ItemsSource = _calc_user_dmamge_binding;
        }

        private void DB_ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MonsterDB_Binding temp = (MonsterDB_Binding)DB_ListBox.SelectedItem;
            if (temp != null)
            { 
                now_mob.ChangeValue(temp);
                MainWindow._user_data_manager.Data.SelectedEnemy = temp.MobId;
                CalcDamage();
            }
        }
    }
}
