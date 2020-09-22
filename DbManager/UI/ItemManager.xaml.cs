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
        ItemDB_Binding now_item = new ItemDB_Binding();
        ItemListBox BindingItemList;
        

        public ItemManager(ref DBlist DB)
        {
            _DB = DB;
            InitializeComponent();

            
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
