using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using DbManager.DB;




namespace DbManager.UI
{
    /// <summary>
    /// MonsterManager.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MonsterManager : Page
    {
        DBlist _DB;
        MonsterDB_Binding now_mob = new MonsterDB_Binding();

        MonsterListBox BindingMobList;
        public MonsterManager(ref DBlist DB)
        {
            _DB = DB;
            InitializeComponent();

            if (_DB._mob_db == null)
                now_mob.MobId = 0;
            else
                now_mob.MobId = _DB._mob_db.Count();
            
            DataContext = now_mob;
            InitalizeContents();

            BindingMobList = new MonsterListBox(ref _DB);
            DB_ListBox.ItemsSource = BindingMobList;
        }
        void InitalizeContents()
        {
            int count;
            if (_DB._mob_db == null)
                now_mob.MobId = 0;
            else
                now_mob.MobId = _DB._mob_db.Count();
            now_mob.IsBoss = false;
            now_mob.Name = "";
            //Tribe 없음
            
            checkBoss.IsChecked = false;
            MobNumber.Text = Convert.ToString(count);
            MobName.Text = "";
            MobTribe.Text = "";
            MobElement.Text = "";
            MobSize.SelectedIndex = -1;
            MobAtk.Text = "";
            MobMatk.Text = "";
            MobHp.Text = "";
            MobDef.Text = "";
            MobMdef.Text = "";
            MobHit.Text = "";
            MobFlee.Text = "";
        }
        private void New_DB_Click(object sender, RoutedEventArgs e)
        {
            InitalizeContents();
        }
        
        private void Add_DB_Click(object sender, RoutedEventArgs e)
        {
            MonsterDB temp = new MonsterDB(Convert.ToInt32(MobNumber.Text), Convert.ToString(MobName.Text), Convert.ToBoolean(checkBoss.IsChecked), Convert.ToInt32(MobSize.SelectedIndex),
                Convert.ToInt32(MobAtk.Text), Convert.ToInt32(MobMatk.Text), Convert.ToInt32(MobHp.Text),
                Convert.ToInt32(MobDef.Text), Convert.ToInt32(MobMdef.Text), Convert.ToInt32(MobHit.Text), Convert.ToInt32(MobFlee.Text));
            _DB.Add(temp);
            BindingMobList.AddList(temp);
        }
        private void DB_ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MonsterDB_Binding temp = (MonsterDB_Binding)DB_ListBox.SelectedItem;
            now_mob.Name = temp.Name;
        }

        #region UI Setting
        public bool IsNumeric(string source)
        {
            Regex regex = new Regex("[^0-9.-]+");
            return !regex.IsMatch(source);
        }
        private void NurmericCheckFunc(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsNumeric(e.Text);
        }

        private void TxtboxSelectAll(object sender, RoutedEventArgs e)
        {
            Dispatcher.CurrentDispatcher.BeginInvoke(
                DispatcherPriority.ContextIdle,
                new Action(
                    delegate
                    {
                        (sender as TextBox).SelectAll();
                    }
                )
            );
        }
        #endregion

        
    }
}
