using System.Linq;
using System.Windows;
using System.Windows.Controls;
using RooStatsSim.UI.Menu;
using RooStatsSim.UI.Manager;

namespace RooStatsSim.UI.MonsterDamage
{
    /// <summary>
    /// MonsterDamageCheck.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MonsterDamageCheck : Window
    {
        MonsterDB_Binding now_mob = new MonsterDB_Binding();
        MonsterListBox BindingMobList;
        public MonsterDamageCheck()
        {
            InitializeComponent();

            DataContext = now_mob;
            InitializeContents();

            BindingMobList = new MonsterListBox(MenuBox._roo_db.Mob_db);
            DB_ListBox.ItemsSource = BindingMobList;

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

        private void DB_ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MonsterDB_Binding temp = (MonsterDB_Binding)DB_ListBox.SelectedItem;
            if (temp != null)
                now_mob.ChangeValue(temp);
        }
    }
}
