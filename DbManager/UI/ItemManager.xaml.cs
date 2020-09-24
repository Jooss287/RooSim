using System;
using System.Windows;
using System.Windows.Controls;
using DbManager.DB;
using DbManager.UI;
using System.Collections.Generic;

namespace DbManager
{
    /// <summary>
    /// ItemManager.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ItemManager : Page
    {
        DBlist _DB;
        Dictionary<int, ItemDB> now_DB;
        ItemDB_Binding now_item = new ItemDB_Binding();
        ItemListBox BindingItemList;
        

        public ItemManager(ref DBlist DB)
        {
            _DB = DB;
            InitializeComponent();

            DataContext = now_item;

            now_DB = SelectedItemType();
            InitializeContents(ref now_DB);

            BindingItemList = new ItemListBox(ref now_DB);
            DB_ListBox.ItemsSource = BindingItemList;

            SetComboBox();
        }

        void SetComboBox()
        {
            foreach (ITYPE option in Enum.GetValues(typeof(ITYPE)))
            {
                string statusName = Enum.GetName(typeof(ITYPE), option);
                cmb_Ioption.Items.Add(statusName);
            }
            foreach (DTYPE option in Enum.GetValues(typeof(DTYPE)))
            {
                string statusName = Enum.GetName(typeof(DTYPE), option);
                cmb_Doption.Items.Add(statusName);
            }
            foreach (STATUS_EFFECT_TYPE option in Enum.GetValues(typeof(STATUS_EFFECT_TYPE)))
            {
                string statusName = Enum.GetName(typeof(STATUS_EFFECT_TYPE), option);
                cmb_SEoption.Items.Add(statusName);
            }
            foreach (IFTYPE option in Enum.GetValues(typeof(IFTYPE)))
            {
                string statusName = Enum.GetName(typeof(IFTYPE), option);
                cmb_IFoption.Items.Add(statusName);
            }
        }

        void InitializeContents(ref Dictionary<int, ItemDB> db)
        {
            //if (db == null)
                
            //    now_mob.MobId = 0;
            //else
            //    now_mob.MobId = _DB._mob_db.Count();

            //now_mob.Name = "";
            //now_mob.Level = 0;
            //now_mob.IsBoss = false;
            //now_mob.Tribe = 0;
            //now_mob.Element = 0;
            //now_mob.Size = 0;
            //now_mob.Atk = 0;
            //now_mob.Matk = 0;
            //now_mob.Hp = 0;
            //now_mob.Def = 0;
            //now_mob.Mdef = 0;
            //now_mob.Hit = 0;
            //now_mob.Flee = 0;
        }

        #region To pass mainwindow
        private bool _isNew = false;
        public bool IsNew
        {
            get { return _isNew; }
            set { _isNew = value; }
        }
        #endregion

        private Dictionary<int, ItemDB> SelectedItemType()
        {
            int selected = cmb_equip_type.SelectedIndex + 1;

            switch (selected)
            {
                case (int)ITEM_TYPE_ENUM.MONSTER_RESEARCH:
                    return _DB._monster_research_db;
                case (int)ITEM_TYPE_ENUM.STICKER:
                    return _DB._stiker_db;
                case (int)ITEM_TYPE_ENUM.DRESS_STYLE:
                    return _DB._dress_style_db;
                case (int)ITEM_TYPE_ENUM.EQUIPMENT:
                    return _DB._equip_db;
                case (int)ITEM_TYPE_ENUM.CARD:
                    return _DB._card_db;
            }

            return null;
        }
        private void New_DB_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Add_DB_Click(object sender, RoutedEventArgs e)
        {
            _isNew = true;
        }

        private void DB_Type_Click(object sender, RoutedEventArgs e)
        {
            RadioButton a = sender as RadioButton;
        }

        private void DB_ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cmb_equip_type_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedItemType();
        }
    }
}
