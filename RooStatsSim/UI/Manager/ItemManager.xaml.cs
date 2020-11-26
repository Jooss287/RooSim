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
                cmb_item_type.Items.Add(statusName);
            }
            cmb_item_type.SelectedIndex = (int)ITEM_TYPE_ENUM.EQUIPMENT;

            foreach (EQUIP_TYPE_ENUM equip in Enum.GetValues(typeof(EQUIP_TYPE_ENUM)))
            {
                string statusName = EnumBaseTable_Kor.EQUIP_TYPE_ENUM_KOR[equip];
                cmb_equip_type.Items.Add(statusName);
            }
            cmb_equip_type.SelectedIndex = (int)EQUIP_TYPE_ENUM.HEAD_TOP;
        }
        void SetComboBox()
        {
            foreach (IFTYPE option in Enum.GetValues(typeof(IFTYPE)))
            {
                string statusName = Enum.GetName(typeof(IFTYPE), option);
                cmb_IFoption.Items.Add(statusName);
            }
            foreach (ITYPE option in Enum.GetValues(typeof(ITYPE)))
            {
                string statusName = EnumItemOptionTable_Kor.ITYPE_KOR[option];
                cmb_Ioption.Items.Add(statusName);
                cmb_refine_if_option.Items.Add(statusName);
            }
            foreach (DTYPE option in Enum.GetValues(typeof(DTYPE)))
            {
                string statusName = EnumItemOptionTable_Kor.DTYPE_KOR[option];
                cmb_Doption.Items.Add(statusName);
                cmb_refine_if_option.Items.Add(statusName);
            }
            foreach (STATUS_EFFECT_TYPE option in Enum.GetValues(typeof(STATUS_EFFECT_TYPE)))
            {
                string statusName = EnumBaseTable_Kor.STATUS_EFFECT_TYPE_KOR[option];
                cmb_se_attackrate_option.Items.Add(EnumItemOptionTable_Kor.SE_ATK_RATE_TYPE_KOR[(SE_ATK_RATE_TYPE)option]);
                cmb_se_registance_option.Items.Add(EnumItemOptionTable_Kor.SE_REG_RATE_TYPE_KOR[(SE_REG_RATE_TYPE)option]);
                cmb_refine_if_option.Items.Add(EnumItemOptionTable_Kor.SE_ATK_RATE_TYPE_KOR[(SE_ATK_RATE_TYPE)option]);
                cmb_refine_if_option.Items.Add(EnumItemOptionTable_Kor.SE_REG_RATE_TYPE_KOR[(SE_REG_RATE_TYPE)option]);
            }
            foreach (ELEMENT_TYPE option in Enum.GetValues(typeof(ELEMENT_TYPE)))
            {
                string statusName = EnumBaseTable_Kor.ELEMENT_TYPE_KOR[option];
                cmb_element_inc_option.Items.Add(EnumItemOptionTable_Kor.ELEMENT_DMG_TYPE_KOR[(ELEMENT_DMG_TYPE)option]);
                cmb_element_dec_option.Items.Add(EnumItemOptionTable_Kor.ELEMENT_REG_TYPE_KOR[(ELEMENT_REG_TYPE)option]);
                cmb_element_damage_option.Items.Add(EnumItemOptionTable_Kor.MONSTER_ELEMENT_DMG_TYPE_KOR[(MONSTER_ELEMENT_DMG_TYPE)option]);
                cmb_refine_if_option.Items.Add(EnumItemOptionTable_Kor.ELEMENT_DMG_TYPE_KOR[(ELEMENT_DMG_TYPE)option]);
                cmb_refine_if_option.Items.Add(EnumItemOptionTable_Kor.ELEMENT_REG_TYPE_KOR[(ELEMENT_REG_TYPE)option]);
                cmb_refine_if_option.Items.Add(EnumItemOptionTable_Kor.MONSTER_ELEMENT_DMG_TYPE_KOR[(MONSTER_ELEMENT_DMG_TYPE)option]);
            }
            foreach (MONSTER_SIZE option in Enum.GetValues(typeof(MONSTER_SIZE)))
            {
                string statusName = EnumBaseTable_Kor.MONSTER_SIZE_KOR[option];
                cmb_size_inc_option.Items.Add(EnumItemOptionTable_Kor.MONSTER_SIZE_DMG_TYPE_KOR[(MONSTER_SIZE_DMG_TYPE)option]);
                cmb_size_dec_option.Items.Add(EnumItemOptionTable_Kor.MONSTER_SIZE_REG_TYPE_KOR[(MONSTER_SIZE_REG_TYPE)option]);
                cmb_refine_if_option.Items.Add(EnumItemOptionTable_Kor.MONSTER_SIZE_DMG_TYPE_KOR[(MONSTER_SIZE_DMG_TYPE)option]);
                cmb_refine_if_option.Items.Add(EnumItemOptionTable_Kor.MONSTER_SIZE_REG_TYPE_KOR[(MONSTER_SIZE_REG_TYPE)option]);
            }
            foreach (TRIBE_TYPE option in Enum.GetValues(typeof(TRIBE_TYPE)))
            {
                string statusName = EnumBaseTable_Kor.TRIBE_TYPE_KOR[option];
                cmb_tribe_inc_option.Items.Add(EnumItemOptionTable_Kor.TRIBE_DMG_TYPE_KOR[(TRIBE_DMG_TYPE)option]);
                cmb_tribe_dec_option.Items.Add(EnumItemOptionTable_Kor.TRIBE_REG_TYPE_KOR[(TRIBE_REG_TYPE)option]);
                cmb_refine_if_option.Items.Add(EnumItemOptionTable_Kor.TRIBE_DMG_TYPE_KOR[(TRIBE_DMG_TYPE)option]);
                cmb_refine_if_option.Items.Add(EnumItemOptionTable_Kor.TRIBE_REG_TYPE_KOR[(TRIBE_REG_TYPE)option]);
            }
            foreach (MONSTER_KINDS_TYPE option in Enum.GetValues(typeof(MONSTER_KINDS_TYPE)))
            {
                string statusName = EnumBaseTable_Kor.MONSTER_KINDS_TYPE_KOR[option];
                cmb_mobtype_inc_option.Items.Add(EnumItemOptionTable_Kor.MONSTER_KINDS_DMG_TYPE_KOR[(MONSTER_KINDS_DMG_TYPE)option]);
                cmb_mobtype_dec_option.Items.Add(EnumItemOptionTable_Kor.MONSTER_KINDS_REG_TYPE_KOR[(MONSTER_KINDS_REG_TYPE)option]);
                cmb_refine_if_option.Items.Add(EnumItemOptionTable_Kor.MONSTER_KINDS_DMG_TYPE_KOR[(MONSTER_KINDS_DMG_TYPE)option]);
                cmb_refine_if_option.Items.Add(EnumItemOptionTable_Kor.MONSTER_KINDS_REG_TYPE_KOR[(MONSTER_KINDS_REG_TYPE)option]);
            }
            foreach (ETC_TYPE option in Enum.GetValues(typeof(ETC_TYPE)))
            {
                string statusName = EnumItemOptionTable_Kor.ETC_TYPE_KOR[option];
                cmb_etc_option.Items.Add(statusName);
                cmb_refine_if_option.Items.Add(statusName);
            }
            foreach (ETC_DMG_TYPE option in Enum.GetValues(typeof(ETC_DMG_TYPE)))
            {
                string statusName = EnumItemOptionTable_Kor.ETC_DMG_TYPE_KOR[option];
                cmb_etc_inc_option.Items.Add(statusName);
                cmb_refine_if_option.Items.Add(statusName);
            }
            for (int i = 0; i <= 20; ++i)
                cmb_refine_value.Items.Add(i);
        }

        void SetNowItemOption()
        {
            cmb_equip_type.SelectedIndex = (int)now_item.Equip_type;
            list_Job_limit.ItemsSource = new Job_Limite_List(ref now_item._wear_job_limit);
            list_iOption.ItemsSource = new ItemOptionListBox(now_item.Option_ITYPE);
            list_dOption.ItemsSource = new ItemOptionListBox(now_item.Option_DTYPE);
            list_ifOption.ItemsSource = new ItemOptionListBox<IFTYPE>(now_item.if_option);
            list_attackrate_option.ItemsSource = new ItemOptionListBox(now_item.Option_SE_ATK_RATE_TYPE);
            list_se_registance_option.ItemsSource = new ItemOptionListBox(now_item.Option_SE_REG_RATE_TYPE);
            list_element_damage_option.ItemsSource = new ItemOptionListBox(now_item.Option_MONSTER_ELEMENT_DMG_TYPE);
            list_element_inc_option.ItemsSource = new ItemOptionListBox(now_item.Option_ELEMENT_DMG_TYPE);
            list_element_dec_option.ItemsSource = new ItemOptionListBox(now_item.Option_ELEMENT_REG_TYPE);
            list_tribe_inc_option.ItemsSource = new ItemOptionListBox(now_item.Option_TRIBE_DMG_TYPE);
            list_tribe_dec_option.ItemsSource = new ItemOptionListBox(now_item.Option_TRIBE_REG_TYPE);
            list_size_inc_option.ItemsSource = new ItemOptionListBox(now_item.Option_MONSTER_SIZE_DMG_TYPE);
            list_size_dec_option.ItemsSource = new ItemOptionListBox(now_item.Option_MONSTER_SIZE_REG_TYPE);
            list_mobtype_inc_option.ItemsSource = new ItemOptionListBox(now_item.Option_MONSTER_KINDS_DMG_TYPE);
            list_mobtype_dec_option.ItemsSource = new ItemOptionListBox(now_item.Option_MONSTER_KINDS_REG_TYPE);
            list_etc_option.ItemsSource = new ItemOptionListBox(now_item.Option_ETC_TYPE);
            list_etc_inc_option.ItemsSource = new ItemOptionListBox(now_item.Option_ETC_DMG_TYPE);
            list_refine_if_option.ItemsSource = new TotalItemOptionListBox(now_item.Refine_Option);
        }


        void InitializeContents()
        {
            if (now_DB == null)
                now_item.Id = 0;
            else
                now_item.Id = now_DB.Count;

            now_item.Name = "";
            now_item.LevelLimit = 0;
            now_item.CardSlot = 0;
            now_item.EnchantSlot = 0;
            now_item.Item_type = (ITEM_TYPE_ENUM)cmb_item_type.SelectedIndex;
            now_item.Equip_type = (EQUIP_TYPE_ENUM)cmb_equip_type.SelectedIndex;
            now_item._wear_job_limit.Clear();
            
            foreach(KeyValuePair<ITEM_OPTION_TYPE, Dictionary<string,double>> item_option in now_item.Option)
            {
                item_option.Value.Clear();
            }
            
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
            ITEM_TYPE_ENUM selected = (ITEM_TYPE_ENUM)cmb_item_type.SelectedIndex;

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
            ITEM_TYPE_ENUM selected = (ITEM_TYPE_ENUM)cmb_item_type.SelectedIndex;

            cmb_equip_type.IsEnabled = false;
            list_Job_limit.IsEnabled = false;
            Item_EnchantSlot.IsEnabled = false;
            Item_CardSlot.IsEnabled = false;
            Item_Level.IsEnabled = false;

            if (selected == ITEM_TYPE_ENUM.EQUIPMENT)
            {
                cmb_equip_type.IsEnabled = true;
                list_Job_limit.IsEnabled = true;
                Item_EnchantSlot.IsEnabled = true;
                Item_CardSlot.IsEnabled = true;
                Item_Level.IsEnabled = true;
            }
            else if (selected == ITEM_TYPE_ENUM.GEAR)
                list_Job_limit.IsEnabled = true;
            else if (selected == ITEM_TYPE_ENUM.CARD)
                cmb_equip_type.IsEnabled = true;
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
            now_item.Wear_job_limit = temp_list.GetLimitedJobList();
            SetNowItemOption();
        }

        private void cmb_item_type_SelectionChanged(object sender, SelectionChangedEventArgs e)
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

            string type_name = AddType.SelectedItem.ToString();
            double add_value = Convert.ToDouble(AddValue.Text);
            if ( Convert.ToString(parentStackpanel.Tag) == "IFTYPE")
            {
                AddValue = OptionStack.Children[3] as TextBox;
                TextBox PerValue = OptionStack.Children[1] as TextBox;
                IFTYPE type = (IFTYPE)Enum.Parse(typeof(IFTYPE), type_name);
                now_item.IF_OPTION[type] = new AbilityPerStatus(type, Convert.ToInt32(AddValue.Text), Convert.ToInt32(PerValue.Text));
            }    
            else
            {
                ITEM_OPTION_TYPE type = EnumItemOptionTable_Kor.GET_ITEM_OPTION_TYPE(ref type_name);
                Dictionary<string,double> item_option = GetItemOptionDictionary(type);
                item_option[type_name] = add_value;
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


            if ( Convert.ToString(parentStackpanel.Tag) == "ITYPE")
            {
                string type_name = (OptionList.SelectedItem as ItemOption_Binding).Type_name;
                IFTYPE type = (IFTYPE)Enum.Parse(typeof(IFTYPE), type_name);
                now_item.IF_OPTION.Remove(type);
            }
            else
            {
                string type_name = (OptionList.SelectedItem as ItemOption_Binding).Type_name;
                ITEM_OPTION_TYPE type = EnumItemOptionTable_Kor.GET_ITEM_OPTION_TYPE(ref type_name);
                Dictionary<string, double> item_option = GetItemOptionDictionary(type);
                item_option.Remove(type_name);
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
        private void cmb_equip_type_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            now_item.Equip_type = (EQUIP_TYPE_ENUM)cmb_equip_type.SelectedIndex;
        }
        private void cmb_refine_if_option_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            StackPanel parentStackpanel = (sender as ComboBox).Parent as StackPanel;
            TextBox AddValue = parentStackpanel.Children[3] as TextBox;

            AddValue.Text = "";
            AddValue.Focus();
        }
        private void Refine_Add_Option_Click(object sender, RoutedEventArgs e)
        {
            StackPanel parentStackpanel = ((sender as Button).Parent as StackPanel).Parent as StackPanel;
            StackPanel OptionStack = parentStackpanel.Children[0] as StackPanel;

            ComboBox Refine = OptionStack.Children[0] as ComboBox;
            ComboBox AddType = OptionStack.Children[2] as ComboBox;
            TextBox AddValue = OptionStack.Children[3] as TextBox;

            if (AddValue.Text == "")
                return;
            if (Convert.ToInt32(AddValue.Text) == 0)
                return;

            int refine = Refine.SelectedIndex;
            string type_name = AddType.SelectedItem.ToString();
            double add_value = Convert.ToDouble(AddValue.Text);
            ITEM_OPTION_TYPE type = EnumItemOptionTable_Kor.GET_ITEM_OPTION_TYPE(ref type_name);
            Dictionary<string, double> item_option = GetRefineItemOptionDictionary(refine, type);
            item_option[type_name] = add_value;

            SetNowItemOption();
            AddType.SelectedIndex = 0;
            AddValue.Text = null;
        }

        private void Refine_Del_Option_Click(object sender, RoutedEventArgs e)
        {
            StackPanel parentStackpanel = ((sender as Button).Parent as StackPanel).Parent as StackPanel;
            ListBox OptionList = parentStackpanel.Children[2] as ListBox;

            if (OptionList.SelectedItem == null)
                return;


            SetNowItemOption();
        }

        Dictionary<string, double> GetItemOptionDictionary(ITEM_OPTION_TYPE item_option_type)
        {
            switch (item_option_type)
            {
                case ITEM_OPTION_TYPE.ITYPE:
                    {
                        return now_item.Option_ITYPE;
                    }
                case ITEM_OPTION_TYPE.DTYPE:
                    {
                        return now_item.Option_DTYPE;
                    }
                case ITEM_OPTION_TYPE.SE_ATK_RATE_TYPE:
                    {
                        return now_item.Option_SE_ATK_RATE_TYPE;
                    }
                case ITEM_OPTION_TYPE.SE_REG_RATE_TYPE:
                    {
                        return now_item.Option_SE_REG_RATE_TYPE;
                    }
                case ITEM_OPTION_TYPE.ELEMENT_DMG_TYPE:
                    {
                        return now_item.Option_ELEMENT_DMG_TYPE;
                    }
                case ITEM_OPTION_TYPE.ELEMENT_REG_TYPE:
                    {
                        return now_item.Option_ELEMENT_REG_TYPE;
                    }
                case ITEM_OPTION_TYPE.MONSTER_ELEMENT_DMG_TYPE:
                    {
                        return now_item.Option_MONSTER_ELEMENT_DMG_TYPE;
                    }
                case ITEM_OPTION_TYPE.MONSTER_SIZE_DMG_TYPE:
                    {
                        return now_item.Option_MONSTER_SIZE_DMG_TYPE;
                    }
                case ITEM_OPTION_TYPE.MONSTER_SIZE_REG_TYPE:
                    {
                        return now_item.Option_MONSTER_SIZE_REG_TYPE;
                    }
                case ITEM_OPTION_TYPE.TRIBE_DMG_TYPE:
                    {
                        return now_item.Option_TRIBE_DMG_TYPE;
                    }
                case ITEM_OPTION_TYPE.TRIBE_REG_TYPE:
                    {
                        return now_item.Option_TRIBE_REG_TYPE;
                    }
                case ITEM_OPTION_TYPE.MONSTER_KINDS_DMG_TYPE:
                    {
                        return now_item.Option_MONSTER_KINDS_DMG_TYPE;
                    }
                case ITEM_OPTION_TYPE.MONSTER_KINDS_REG_TYPE:
                    {
                        return now_item.Option_MONSTER_KINDS_REG_TYPE;
                    }
                case ITEM_OPTION_TYPE.ETC_DMG_TYPE:
                    {
                        return now_item.Option_ETC_DMG_TYPE;
                    }
                case ITEM_OPTION_TYPE.ETC_TYPE:
                    {
                        return now_item.Option_ETC_TYPE;
                    }
                default:
                    MessageBox.Show("선언되지 않은 case가 존재합니다");
                    break;
            }
            return null;
        }
        Dictionary<string, double> GetRefineItemOptionDictionary(int refine, ITEM_OPTION_TYPE item_option_type)
        {
            switch (item_option_type)
            {
                case ITEM_OPTION_TYPE.ITYPE:
                    {
                        return now_item.Option_ITYPE;
                    }
                case ITEM_OPTION_TYPE.DTYPE:
                    {
                        return now_item.Option_DTYPE;
                    }
                case ITEM_OPTION_TYPE.SE_ATK_RATE_TYPE:
                    {
                        return now_item.Option_SE_ATK_RATE_TYPE;
                    }
                case ITEM_OPTION_TYPE.SE_REG_RATE_TYPE:
                    {
                        return now_item.Option_SE_REG_RATE_TYPE;
                    }
                case ITEM_OPTION_TYPE.ELEMENT_DMG_TYPE:
                    {
                        return now_item.Option_ELEMENT_DMG_TYPE;
                    }
                case ITEM_OPTION_TYPE.ELEMENT_REG_TYPE:
                    {
                        return now_item.Option_ELEMENT_REG_TYPE;
                    }
                case ITEM_OPTION_TYPE.MONSTER_ELEMENT_DMG_TYPE:
                    {
                        return now_item.Option_MONSTER_ELEMENT_DMG_TYPE;
                    }
                case ITEM_OPTION_TYPE.MONSTER_SIZE_DMG_TYPE:
                    {
                        return now_item.Option_MONSTER_SIZE_DMG_TYPE;
                    }
                case ITEM_OPTION_TYPE.MONSTER_SIZE_REG_TYPE:
                    {
                        return now_item.Option_MONSTER_SIZE_REG_TYPE;
                    }
                case ITEM_OPTION_TYPE.TRIBE_DMG_TYPE:
                    {
                        return now_item.Option_TRIBE_DMG_TYPE;
                    }
                case ITEM_OPTION_TYPE.TRIBE_REG_TYPE:
                    {
                        return now_item.Option_TRIBE_REG_TYPE;
                    }
                case ITEM_OPTION_TYPE.MONSTER_KINDS_DMG_TYPE:
                    {
                        return now_item.Option_MONSTER_KINDS_DMG_TYPE;
                    }
                case ITEM_OPTION_TYPE.MONSTER_KINDS_REG_TYPE:
                    {
                        return now_item.Option_MONSTER_KINDS_REG_TYPE;
                    }
                case ITEM_OPTION_TYPE.ETC_DMG_TYPE:
                    {
                        return now_item.Option_ETC_DMG_TYPE;
                    }
                case ITEM_OPTION_TYPE.ETC_TYPE:
                    {
                        return now_item.Option_ETC_TYPE;
                    }
                default:
                    MessageBox.Show("선언되지 않은 case가 존재합니다");
                    break;
            }
            return null;
        }
        #endregion

    }
}
