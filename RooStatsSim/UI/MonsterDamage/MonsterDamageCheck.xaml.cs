using System.Linq;
using System.Windows;
using System.Windows.Controls;
using RooStatsSim.UI.Menu;
using RooStatsSim.UI.Manager;
using RooStatsSim.User;
using RooStatsSim.Equation.Job;
using System;

namespace RooStatsSim.UI.MonsterDamage
{
    /// <summary>
    /// MonsterDamageCheck.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MonsterDamageCheck : Window
    {
        UserData user_data;
        MonsterDB_Binding now_mob = new MonsterDB_Binding();
        MonsterListBox BindingMobList;
        string normal_atk_binding = "";
        public MonsterDamageCheck()
        {
            InitializeComponent();

            DataContext = now_mob;
            InitializeContents();

            BindingMobList = new MonsterListBox(MenuBox._roo_db.Mob_db);
            DB_ListBox.ItemsSource = BindingMobList;

            user_data = UserData.GetInstance;
            user_data.itemDataChanged += new UserData.UserDataChangedEventHandler(CalcDamage);
        }
        void InitializeContents()
        {
            now_mob.Name = "";
            now_mob.Level = 0;
            now_mob.IsBoss = false;
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

            JobSelect jobsel = new JobSelect(user_data.Job);
            int skill_damage = 1;
            
            int calcATK_min = Convert.ToInt32(Math.Floor(jobsel.GetMinATK() * skill_damage));
            int calcATK_max = Convert.ToInt32(Math.Floor(jobsel.GetMaxATK() * skill_damage));

            normalATK.Text = Convert.ToString(calcATK_min) + " ~ " + Convert.ToString(calcATK_max);
            //txt_sATK.Text = Convert.ToString(job_selection.GetWinATK());
        }

        private void DB_ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MonsterDB_Binding temp = (MonsterDB_Binding)DB_ListBox.SelectedItem;
            if (temp != null)
            { 
                now_mob.ChangeValue(temp);
                user_data.SelectedEnemy = temp.MobId;
                CalcDamage();
            }
        }
    }
}
