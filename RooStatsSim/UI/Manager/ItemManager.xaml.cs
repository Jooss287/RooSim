using System;
using System.Windows;
using System.Windows.Controls;
using RooStatsSim.DB;
using System.Collections.Generic;
using System.CodeDom;

namespace RooStatsSim.UI.Manager
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

            cmb_equip_type.SelectedIndex = 3;
            now_DB = SelectedItemType();
            InitializeContents();
            BindingItemList = new ItemListBox(ref now_DB);
            DB_ListBox.ItemsSource = BindingItemList;
            //SetNowItemOption();
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
            foreach (ELEMENT_TYPE option in Enum.GetValues(typeof(ELEMENT_TYPE)))
            {
                string statusName = Enum.GetName(typeof(ELEMENT_TYPE), option);
                cmb_element_inc_option.Items.Add(statusName);
                cmb_element_dec_option.Items.Add(statusName);
            }
            foreach (MONSTER_SIZE option in Enum.GetValues(typeof(MONSTER_SIZE)))
            {
                string statusName = Enum.GetName(typeof(MONSTER_SIZE), option);
                cmb_size_inc_option.Items.Add(statusName);
                cmb_size_dec_option.Items.Add(statusName);
            }
            foreach (TRIBE_TYPE option in Enum.GetValues(typeof(TRIBE_TYPE)))
            {
                string statusName = Enum.GetName(typeof(TRIBE_TYPE), option);
                cmb_tribe_inc_option.Items.Add(statusName);
                cmb_tribe_dec_option.Items.Add(statusName);
            }
            foreach (MONSTER_TYPE option in Enum.GetValues(typeof(MONSTER_TYPE)))
            {
                string statusName = Enum.GetName(typeof(MONSTER_TYPE), option);
                cmb_mobtype_inc_option.Items.Add(statusName);
                cmb_mobtype_dec_option.Items.Add(statusName);
            }
        }

        void SetNowItemOption()
        {
            list_iOption.ItemsSource = new ItemOptionListBox<ITYPE, int>(ref now_item.i_option);
            list_dOption.ItemsSource = new ItemOptionListBox<DTYPE, double>(ref now_item.d_option);
            list_seOption.ItemsSource = new ItemOptionListBox<STATUS_EFFECT_TYPE, double>(ref now_item.se_option);
            list_ifOption.ItemsSource = new ItemOptionListBox(ref now_item.if_option);
        }


        void InitializeContents()
        {
            if (now_DB == null)
                now_item.Id = 0;
            else
                now_item.Id = now_DB.Count;

            now_item.Name = "";
            now_item.i_option.Clear();
            now_item.d_option.Clear();
            now_item.if_option.Clear();
            now_item.se_option.Clear();

            now_item.mobtype_inc_option.Clear();
            now_item.size_inc_option.Clear();
            now_item.tribe_inc_option.Clear();
            now_item.element_inc_option.Clear();
            now_item.mobtype_dec_option.Clear();
            now_item.size_dec_option.Clear();
            now_item.tribe_dec_option.Clear();
            now_item.element_dec_option.Clear();
            SetNowItemOption();
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
                    return _DB._sticker_db;
                case (int)ITEM_TYPE_ENUM.DRESS_STYLE:
                    return _DB._dress_style_db;
                case (int)ITEM_TYPE_ENUM.EQUIPMENT:
                    return _DB._equip_db;
                case (int)ITEM_TYPE_ENUM.CARD:
                    return _DB._card_db;
            }

            return null;
        }

        #region CLICK FUNCTION
        private void New_DB_Click(object sender, RoutedEventArgs e)
        {
            InitializeContents();
            Item_name.Focus();
            DB_ListBox.SelectedIndex = -1;
        }
        private void Add_DB_Click(object sender, RoutedEventArgs e)
        {
            if (string.Compare(Item_name.Text, "") == 0)
                return;

            now_DB[now_item.Id] = new ItemDB(now_item);
            BindingItemList.AddList(new ItemDB(now_item));

            InitializeContents();
            Item_name.Focus();
            DB_ListBox.SelectedIndex = -1;
            _isNew = true;
        }

        private void DB_Type_Click(object sender, RoutedEventArgs e)
        {
            RadioButton a = sender as RadioButton;
        }

        private void DB_ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ItemDB_Binding temp = (ItemDB_Binding)DB_ListBox.SelectedItem;
            if (temp != null)
            {
                now_item.ChangeValue(temp);
                SetNowItemOption();
            }
                
        }

        private void cmb_equip_type_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            now_DB = SelectedItemType();
            InitializeContents();
            BindingItemList = new ItemListBox(ref now_DB);
            DB_ListBox.ItemsSource = BindingItemList;
            SetNowItemOption();
        }

        private void Add_Option_Click(object sender, RoutedEventArgs e)
        {
            StackPanel parentStackpanel = ((sender as Button).Parent as StackPanel).Parent as StackPanel;
            StackPanel OptionStack = parentStackpanel.Children[0] as StackPanel;

            ComboBox AddType = OptionStack.Children[0] as ComboBox;
            TextBox AddValue = OptionStack.Children[1] as TextBox;

            if (AddValue.Text == "")
                return;
            if (Convert.ToInt32(AddValue.Text) == 0)
                return;

            string typeName = Convert.ToString(AddType.SelectedItem);
            switch (Convert.ToString(parentStackpanel.Tag))
            {
                case "ITYPE":
                    {
                        ITYPE type = (ITYPE)Enum.Parse(typeof(ITYPE), typeName);
                        now_item.i_option[type] = Convert.ToInt32(AddValue.Text);
                        break;
                    }
                case "DTYPE":
                    { 
                        DTYPE type = (DTYPE)Enum.Parse(typeof(DTYPE), typeName);
                        now_item.d_option[type] = Convert.ToDouble(AddValue.Text);
                        break;
                    }
                case "SETYPE":
                    {
                        STATUS_EFFECT_TYPE type = (STATUS_EFFECT_TYPE)Enum.Parse(typeof(STATUS_EFFECT_TYPE), typeName);
                        now_item.se_option[type] = Convert.ToDouble(AddValue.Text);
                        break;
                    }
                case "IFTYPE":
                    {
                        AddValue = OptionStack.Children[3] as TextBox;
                        TextBox PerValue = OptionStack.Children[1] as TextBox;
                        IFTYPE type = (IFTYPE)Enum.Parse(typeof(IFTYPE), typeName);
                        now_item.if_option[type] = new AbilityPerStatus(type, Convert.ToInt32(AddValue.Text), Convert.ToInt32(PerValue.Text));
                        break;
                    }
            }
            SetNowItemOption();
            AddType.SelectedIndex = 0;
            AddValue.Text = null;
        }

        private void Del_Option_Click(object sender, RoutedEventArgs e)
        {
            StackPanel parentStackpanel = ((sender as Button).Parent as StackPanel).Parent as StackPanel;
            ListBox OptionList = parentStackpanel.Children[2] as ListBox;

            if (OptionList.SelectedItem == null)
                return;

            switch (Convert.ToString(parentStackpanel.Tag))
            {
                case "ITYPE":
                    {
                        string typeName = (OptionList.SelectedItem as ItemOption_Binding<ITYPE, int>).Type_name;
                        ITYPE type = (ITYPE)Enum.Parse(typeof(ITYPE), typeName);
                        now_item.i_option.Remove(type);
                        break;
                    }
                case "DTYPE":
                    {
                        string typeName = (OptionList.SelectedItem as ItemOption_Binding<DTYPE, double>).Type_name;
                        DTYPE type = (DTYPE)Enum.Parse(typeof(DTYPE), typeName);
                        now_item.d_option.Remove(type);
                        break;
                    }
                case "SETYPE":
                    {
                        string typeName = (OptionList.SelectedItem as ItemOption_Binding<STATUS_EFFECT_TYPE, double>).Type_name;
                        STATUS_EFFECT_TYPE type = (STATUS_EFFECT_TYPE)Enum.Parse(typeof(STATUS_EFFECT_TYPE), typeName);
                        now_item.se_option.Remove(type);
                        break;
                    }
                case "IFTYPE":
                    {
                        string typeName = (OptionList.SelectedItem as ItemOption_Binding).Type_name;
                        IFTYPE type = (IFTYPE)Enum.Parse(typeof(IFTYPE), typeName);
                        now_item.if_option.Remove(type);
                        break;
                    }
            }
            SetNowItemOption();
        }
        private void cmb_option_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            StackPanel parentStackpanel = (sender as ComboBox).Parent as StackPanel;
            TextBox AddValue = parentStackpanel.Children[1] as TextBox;

            AddValue.Text = "";
            AddValue.Focus();
        }
        #endregion


    }
}
