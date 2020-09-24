using System;
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

        #region Initilaize
        public MonsterManager(ref DBlist DB)
        {
            _DB = DB;
            InitializeComponent();

            if (_DB._mob_db == null)
                now_mob.MobId = 0;
            else
                now_mob.MobId = _DB._mob_db.Count();
            
            DataContext = now_mob;
            InitializeContents();

            BindingMobList = new MonsterListBox(ref _DB);
            DB_ListBox.ItemsSource = BindingMobList;

            MobName.Focus();
        }
        void InitializeContents()
        {
            if (_DB._mob_db == null)
                now_mob.MobId = 0;
            else
                now_mob.MobId = _DB._mob_db.Count();
            
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
        #endregion

        #region To pass mainwindow
        private bool _isNew = false;
        public bool IsNew
        {
            get { return _isNew; }
            set { _isNew = value; }
        }
        #endregion

        #region UI Binding, Contents settings
        private void New_DB_Click(object sender, RoutedEventArgs e)
        {
            InitializeContents();
            MobName.Focus();
        }
        
        private void Add_DB_Click(object sender, RoutedEventArgs e)
        {
            if (string.Compare(MobName.Text, "") == 0)
                return;

            _DB.AddMonsterDB(new MonsterDB(now_mob));
            BindingMobList.AddList(new MonsterDB(now_mob));

            InitializeContents();
            MobName.Focus();
            _isNew = true;
        }
        private void DB_ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MonsterDB_Binding temp = (MonsterDB_Binding)DB_ListBox.SelectedItem;
            if ( temp != null)
                now_mob.ChangeValue(temp);
        }

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
