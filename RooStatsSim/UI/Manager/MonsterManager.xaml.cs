using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using RooStatsSim.DB;
using RooStatsSim.DB.Table;

namespace RooStatsSim.UI.Manager
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
            InitUIsetting();

            BindingMobList = new MonsterListBox(_DB.Mob_db);
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
            now_mob.Type = (int)MONSTER_KINDS_TYPE.NORMAL;
            now_mob.StatusInfo = new Status();
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
        void InitUIsetting()
        {
            foreach (TRIBE_TYPE option in Enum.GetValues(typeof(TRIBE_TYPE)))
            {
                string statusName = Enum.GetName(typeof(TRIBE_TYPE), option);
                MobTribe.Items.Add(statusName);
            }
            foreach (ELEMENT_TYPE option in Enum.GetValues(typeof(ELEMENT_TYPE)))
            {
                string statusName = Enum.GetName(typeof(ELEMENT_TYPE), option);
                MobElement.Items.Add(statusName);
            }
            foreach (MONSTER_SIZE option in Enum.GetValues(typeof(MONSTER_SIZE)))
            {
                string statusName = Enum.GetName(typeof(MONSTER_SIZE), option);
                MobSize.Items.Add(statusName);
            }
            foreach (MONSTER_KINDS_TYPE option in Enum.GetValues(typeof(MONSTER_KINDS_TYPE)))
            {
                string statusName = Enum.GetName(typeof(MONSTER_KINDS_TYPE), option);
                cmb_monster_type.Items.Add(statusName);
            }
            cmb_monster_type.SelectedIndex = (int)MONSTER_KINDS_TYPE.NORMAL;
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

            MobName.Focus();
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
