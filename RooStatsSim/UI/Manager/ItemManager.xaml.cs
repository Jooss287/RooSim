using System;
using System.Windows;
using System.Windows.Controls;
using RooStatsSim.DB;
using System.Collections.Generic;

using RooStatsSim.DB.Table;
using System.Linq;

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

            InitUIsetting();
            cmb_equip_type.SelectedIndex = 3;
            now_DB = SelectedItemType();
            InitializeContents();
            BindingItemList = new ItemListBox(ref now_DB);
            DB_ListBox.ItemsSource = BindingItemList;

            SetComboBox();
        }

        void InitUIsetting()
        {
            foreach (ITEM_TYPE_ENUM option in Enum.GetValues(typeof(ITEM_TYPE_ENUM)))
            {
                string statusName = Enum.GetName(typeof(ITEM_TYPE_ENUM), option);
                cmb_equip_type.Items.Add(statusName);
            }
            cmb_equip_type.SelectedIndex = (int)ITEM_TYPE_ENUM.EQUIPMENT;

            {
                list_Job_limit.ItemsSource = new Job_Limite_List();
            }
            
        }
        void SetComboBox()
        {
            foreach (ITYPE option in Enum.GetValues(typeof(ITYPE)))
            {
                string statusName = EnumProperty_Kor.ITYPE_KOR[option];
                cmb_Ioption.Items.Add(statusName);
            }
            foreach (DTYPE option in Enum.GetValues(typeof(DTYPE)))
            {
                string statusName = EnumProperty_Kor.DTYPE_KOR[option];
                cmb_Doption.Items.Add(statusName);
            }
            foreach (STATUS_EFFECT_TYPE option in Enum.GetValues(typeof(STATUS_EFFECT_TYPE)))
            {
                string statusName = EnumProperty_Kor.STATUS_EFFECT_TYPE_KOR[option];
                cmb_SEoption.Items.Add(statusName);
            }
            foreach (IFTYPE option in Enum.GetValues(typeof(IFTYPE)))
            {
                string statusName = Enum.GetName(typeof(IFTYPE), option);
                cmb_IFoption.Items.Add(statusName);
            }
            foreach (ELEMENT_TYPE option in Enum.GetValues(typeof(ELEMENT_TYPE)))
            {
                string statusName = EnumProperty_Kor.ELEMENT_TYPE_KOR[option];
                cmb_element_inc_option.Items.Add(statusName);
                cmb_element_dec_option.Items.Add(statusName);
            }
            foreach (MONSTER_SIZE option in Enum.GetValues(typeof(MONSTER_SIZE)))
            {
                string statusName = EnumProperty_Kor.MONSTER_SIZE_KOR[option];
                cmb_size_inc_option.Items.Add(statusName);
                cmb_size_dec_option.Items.Add(statusName);
            }
            foreach (TRIBE_TYPE option in Enum.GetValues(typeof(TRIBE_TYPE)))
            {
                string statusName = EnumProperty_Kor.TRIBE_TYPE_KOR[option];
                cmb_tribe_inc_option.Items.Add(statusName);
                cmb_tribe_dec_option.Items.Add(statusName);
            }
            foreach (MONSTER_TYPE option in Enum.GetValues(typeof(MONSTER_TYPE)))
            {
                string statusName = EnumProperty_Kor.MONSTER_TYPE_KOR[option];
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
            list_element_inc_option.ItemsSource = new ItemOptionListBox<ELEMENT_TYPE, double>(ref now_item.element_inc_option);
            list_element_dec_option.ItemsSource = new ItemOptionListBox<ELEMENT_TYPE, double>(ref now_item.element_dec_option);
            list_tribe_inc_option.ItemsSource = new ItemOptionListBox<TRIBE_TYPE, double>(ref now_item.tribe_inc_option);
            list_tribe_dec_option.ItemsSource = new ItemOptionListBox<TRIBE_TYPE, double>(ref now_item.tribe_dec_option);
            list_size_inc_option.ItemsSource = new ItemOptionListBox<MONSTER_SIZE, double>(ref now_item.size_inc_option);
            list_size_dec_option.ItemsSource = new ItemOptionListBox<MONSTER_SIZE, double>(ref now_item.size_dec_option);
            list_mobtype_inc_option.ItemsSource = new ItemOptionListBox<MONSTER_TYPE, double>(ref now_item.mobtype_inc_option);
            list_mobtype_dec_option.ItemsSource = new ItemOptionListBox<MONSTER_TYPE, double>(ref now_item.mobtype_dec_option);
        }


        void InitializeContents()
        {
            if (now_DB == null)
                now_item.Id = 0;
            else
                now_item.Id = now_DB.Count;

            now_item.Item_type = (ITEM_TYPE_ENUM)cmb_equip_type.SelectedIndex;
            now_item.Name = "";
            now_item.i_option.Clear();
            now_item.d_option.Clear();
            now_item.IF_OPTION.Clear();
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
            ITEM_TYPE_ENUM selected = (ITEM_TYPE_ENUM)cmb_equip_type.SelectedIndex;

            switch (selected)
            {
                case ITEM_TYPE_ENUM.MONSTER_RESEARCH:
                    return _DB._monster_research_db;
                case ITEM_TYPE_ENUM.STICKER:
                    return _DB._sticker_db;
                case ITEM_TYPE_ENUM.DRESS_STYLE:
                    return _DB._dress_style_db;
                case ITEM_TYPE_ENUM.EQUIPMENT:
                    return _DB._equip_db;
                case ITEM_TYPE_ENUM.CARD:
                    return _DB._card_db;
                case ITEM_TYPE_ENUM.ENCHANT:
                    return _DB._enchant_db;
                case ITEM_TYPE_ENUM.GEAR:
                    return _DB._gear_db;
            }

            return null;
        }
        private void SetSelectedItemTypeUI()
        {
            ITEM_TYPE_ENUM selected = (ITEM_TYPE_ENUM)cmb_equip_type.SelectedIndex;
            if ((selected == ITEM_TYPE_ENUM.EQUIPMENT) ||
                (selected == ITEM_TYPE_ENUM.GEAR))
                list_Job_limit.IsEnabled = true;
            else
                list_Job_limit.IsEnabled = false;
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

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            Job_Limite_List temp_list = (Job_Limite_List)list_Job_limit.ItemsSource;
            AbilityBinding<bool> temp = (AbilityBinding<bool>)(sender as CheckBox).DataContext;
            if (temp != null)
            {
                temp_list.SelectClass((JOB_SELECT_LIST)Enum.Parse(typeof(JOB_SELECT_LIST), temp.EnumName), temp.Point);
            }
            list_Job_limit.ItemsSource = temp_list;
        }

        private void cmb_equip_type_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            now_DB = SelectedItemType();
            if (now_DB == null)
                return;
            else
                SetSelectedItemTypeUI();

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
                        ITYPE type = EnumProperty_Kor.ITYPE_KOR.FirstOrDefault(x => x.Value == typeName).Key;
                        now_item.i_option[type] = Convert.ToInt32(AddValue.Text);
                        break;
                    }
                case "DTYPE":
                    {
                        DTYPE type = EnumProperty_Kor.DTYPE_KOR.FirstOrDefault(x => x.Value == typeName).Key;
                        now_item.d_option[type] = Convert.ToDouble(AddValue.Text);
                        break;
                    }
                case "SETYPE":
                    {
                        STATUS_EFFECT_TYPE type = EnumProperty_Kor.STATUS_EFFECT_TYPE_KOR.FirstOrDefault(x => x.Value == typeName).Key;
                        now_item.se_option[type] = Convert.ToDouble(AddValue.Text);
                        break;
                    }
                case "IFTYPE":
                    {
                        AddValue = OptionStack.Children[3] as TextBox;
                        TextBox PerValue = OptionStack.Children[1] as TextBox;
                        IFTYPE type = (IFTYPE)Enum.Parse(typeof(IFTYPE), typeName);
                        now_item.IF_OPTION[type] = new AbilityPerStatus(type, Convert.ToInt32(AddValue.Text), Convert.ToInt32(PerValue.Text));
                        break;
                    }
                case "ELEMENT_INC_TYPE":
                    {
                        ELEMENT_TYPE type = EnumProperty_Kor.ELEMENT_TYPE_KOR.FirstOrDefault(x => x.Value == typeName).Key;
                        now_item.ELEMENT_INC_OPTION[type] = Convert.ToDouble(AddValue.Text);
                        break;
                    }
                case "ELEMENT_DEC_TYPE":
                    {
                        ELEMENT_TYPE type = EnumProperty_Kor.ELEMENT_TYPE_KOR.FirstOrDefault(x => x.Value == typeName).Key;
                        now_item.ELEMENT_DEC_OPTION[type] = Convert.ToDouble(AddValue.Text);
                        break;
                    }
                case "SIZE_INC_TYPE":
                    {
                        MONSTER_SIZE type = EnumProperty_Kor.MONSTER_SIZE_KOR.FirstOrDefault(x => x.Value == typeName).Key;
                        now_item.SIZE_INC_OPTION[type] = Convert.ToDouble(AddValue.Text);
                        break;
                    }
                case "SIZE_DEC_TYPE":
                    {
                        MONSTER_SIZE type = EnumProperty_Kor.MONSTER_SIZE_KOR.FirstOrDefault(x => x.Value == typeName).Key;
                        now_item.SIZE_DEC_OPTION[type] = Convert.ToDouble(AddValue.Text);
                        break;
                    }
                case "TRIBE_INC_TYPE":
                    {
                        TRIBE_TYPE type = EnumProperty_Kor.TRIBE_TYPE_KOR.FirstOrDefault(x => x.Value == typeName).Key;
                        now_item.TRIBE_INC_OPTION[type] = Convert.ToDouble(AddValue.Text);
                        break;
                    }
                case "TRIBE_DEC_TYPE":
                    {
                        TRIBE_TYPE type = EnumProperty_Kor.TRIBE_TYPE_KOR.FirstOrDefault(x => x.Value == typeName).Key;
                        now_item.TRIBE_DEC_OPTION[type] = Convert.ToDouble(AddValue.Text);
                        break;
                    }
                case "MOBTYPE_INC_TYPE":
                    {
                        MONSTER_TYPE type = EnumProperty_Kor.MONSTER_TYPE_KOR.FirstOrDefault(x => x.Value == typeName).Key;
                        now_item.MOBTYPE_INC_OPTION[type] = Convert.ToDouble(AddValue.Text);
                        break;
                    }
                case "MOBTYPE_DEC_TYPE":
                    {
                        MONSTER_TYPE type = EnumProperty_Kor.MONSTER_TYPE_KOR.FirstOrDefault(x => x.Value == typeName).Key;
                        now_item.MOBTYPE_DEC_OPTION[type] = Convert.ToDouble(AddValue.Text);
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
                        now_item.IF_OPTION.Remove(type);
                        break;
                    }
                case "ELEMENT_INC_TYPE":
                    {
                        string typeName = (OptionList.SelectedItem as ItemOption_Binding<ELEMENT_TYPE, double>).Type_name;
                        ELEMENT_TYPE type = (ELEMENT_TYPE)Enum.Parse(typeof(ELEMENT_TYPE), typeName);
                        now_item.ELEMENT_INC_OPTION.Remove(type);
                        break;
                    }
                case "ELEMENT_DEC_TYPE":
                    {
                        string typeName = (OptionList.SelectedItem as ItemOption_Binding<ELEMENT_TYPE, double>).Type_name;
                        ELEMENT_TYPE type = (ELEMENT_TYPE)Enum.Parse(typeof(ELEMENT_TYPE), typeName);
                        now_item.ELEMENT_DEC_OPTION.Remove(type);
                        break;
                    }
                case "SIZE_INC_TYPE":
                    {
                        string typeName = (OptionList.SelectedItem as ItemOption_Binding<MONSTER_SIZE, double>).Type_name;
                        MONSTER_SIZE type = (MONSTER_SIZE)Enum.Parse(typeof(MONSTER_SIZE), typeName);
                        now_item.SIZE_INC_OPTION.Remove(type);
                        break;
                    }
                case "SIZE_DEC_TYPE":
                    {
                        string typeName = (OptionList.SelectedItem as ItemOption_Binding<MONSTER_SIZE, double>).Type_name;
                        MONSTER_SIZE type = (MONSTER_SIZE)Enum.Parse(typeof(MONSTER_SIZE), typeName);
                        now_item.SIZE_DEC_OPTION.Remove(type);
                        break;
                    }
                case "TRIBE_INC_TYPE":
                    {
                        string typeName = (OptionList.SelectedItem as ItemOption_Binding<TRIBE_TYPE, double>).Type_name;
                        TRIBE_TYPE type = (TRIBE_TYPE)Enum.Parse(typeof(TRIBE_TYPE), typeName);
                        now_item.TRIBE_INC_OPTION.Remove(type);
                        break;
                    }
                case "TRIBE_DEC_TYPE":
                    {
                        string typeName = (OptionList.SelectedItem as ItemOption_Binding<TRIBE_TYPE, double>).Type_name;
                        TRIBE_TYPE type = (TRIBE_TYPE)Enum.Parse(typeof(TRIBE_TYPE), typeName);
                        now_item.TRIBE_DEC_OPTION.Remove(type);
                        break;
                    }
                case "MOBTYPE_INC_TYPE":
                    {
                        string typeName = (OptionList.SelectedItem as ItemOption_Binding<MONSTER_TYPE, double>).Type_name;
                        MONSTER_TYPE type = (MONSTER_TYPE)Enum.Parse(typeof(MONSTER_TYPE), typeName);
                        now_item.MOBTYPE_INC_OPTION.Remove(type);
                        break;
                    }
                case "MOBTYPE_DEC_TYPE":
                    {
                        string typeName = (OptionList.SelectedItem as ItemOption_Binding<MONSTER_TYPE, double>).Type_name;
                        MONSTER_TYPE type = (MONSTER_TYPE)Enum.Parse(typeof(MONSTER_TYPE), typeName);
                        now_item.MOBTYPE_DEC_OPTION.Remove(type);
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
