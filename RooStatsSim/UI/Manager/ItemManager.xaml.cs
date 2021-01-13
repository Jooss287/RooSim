using System;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Threading;
using System.IO;
using System.Linq;

using RooStatsSim.DB;
using RooStatsSim.DB.Table;
using RooStatsSim.DB.Skill;
using RooStatsSim.DB.Skill.JobSkill;
using RooStatsSim.UI.SkillWindow;


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
        const string _image_path = "Img";
        List<string> _image_list = new List<string>();
        List<string> _set_option_list = new List<string>();

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
        #region Initialize UI Binding
        void InitUIsetting()
        {
            foreach(EQUIP_DB_ENUM equip_db in Enum.GetValues(typeof(EQUIP_DB_ENUM)))
            {
                string statusName = EnumBaseTable_Kor.EQUIP_DB_ENUM_KOR[equip_db];
                cmb_db_type.Items.Add(statusName);
            }
            cmb_db_type.SelectedIndex = (int)EQUIP_DB_ENUM.HEAD;
            foreach (EQUIP_TYPE_ENUM equip in Enum.GetValues(typeof(EQUIP_TYPE_ENUM)))
            {
                string statusName = EnumBaseTable_Kor.EQUIP_TYPE_ENUM_KOR[equip];
                cmb_equip_type.Items.Add(statusName);
                cmb_set_equips.Items.Add(statusName);
            }
            cmb_equip_type.SelectedIndex = (int)EQUIP_TYPE_ENUM.HEAD_TOP;

            foreach (ITEM_TYPE_ENUM option in Enum.GetValues(typeof(ITEM_TYPE_ENUM)))
            {
                string statusName = Enum.GetName(typeof(ITEM_TYPE_ENUM), option);
                cmb_item_type.Items.Add(statusName);
            }
            cmb_item_type.SelectedIndex = (int)ITEM_TYPE_ENUM.EQUIPMENT;

            if (Directory.Exists(_image_path))
            {
                DirectoryInfo di = new DirectoryInfo(_image_path);
                foreach(var item in di.GetFiles())
                {
                    _image_list.Add(item.Name);
                    cmb_Item_image.Items.Add(item.Name);
                }
            }
            foreach(KeyValuePair<int, ItemDB> set_option in _DB.Set_Equip_db)
            {
                _set_option_list.Add(set_option.Value.SetName);
                cmb_set_name_list.Items.Add(set_option.Value.SetName);
            }
            for (int i = 0; i < 20; i++)
                cmb_refine_num.Items.Add(i);
            cmb_refine_num.SelectedIndex = 0;
        }
        void SetComboBox()
        {
            foreach (ITYPE option in Enum.GetValues(typeof(ITYPE)))
            {
                string statusName = EnumItemOptionTable_Kor.ITYPE_KOR[option];
                cmb_Ioption.Items.Add(statusName);
                cmb_if_per_option.Items.Add(statusName);
                cmb_if_add_option.Items.Add(statusName);
            }
            foreach (DTYPE option in Enum.GetValues(typeof(DTYPE)))
            {
                string statusName = EnumItemOptionTable_Kor.DTYPE_KOR[option];
                cmb_Doption.Items.Add(statusName);
                cmb_if_per_option.Items.Add(statusName);
                cmb_if_add_option.Items.Add(statusName);
            }
            foreach (STATUS_EFFECT_TYPE option in Enum.GetValues(typeof(STATUS_EFFECT_TYPE)))
            {
                cmb_status_effect_option.Items.Add(EnumItemOptionTable_Kor.SE_ATK_RATE_TYPE_KOR[(SE_ATK_RATE_TYPE)option]);
                cmb_status_effect_option.Items.Add(EnumItemOptionTable_Kor.SE_REG_RATE_TYPE_KOR[(SE_REG_RATE_TYPE)option]);
                cmb_if_per_option.Items.Add(EnumItemOptionTable_Kor.SE_ATK_RATE_TYPE_KOR[(SE_ATK_RATE_TYPE)option]);
                cmb_if_add_option.Items.Add(EnumItemOptionTable_Kor.SE_ATK_RATE_TYPE_KOR[(SE_ATK_RATE_TYPE)option]);
                cmb_if_per_option.Items.Add(EnumItemOptionTable_Kor.SE_REG_RATE_TYPE_KOR[(SE_REG_RATE_TYPE)option]);
                cmb_if_add_option.Items.Add(EnumItemOptionTable_Kor.SE_REG_RATE_TYPE_KOR[(SE_REG_RATE_TYPE)option]);
            }
            foreach (ELEMENT_TYPE option in Enum.GetValues(typeof(ELEMENT_TYPE)))
            {
                cmb_element_option.Items.Add(EnumItemOptionTable_Kor.ELEMENT_DMG_TYPE_KOR[(ELEMENT_DMG_TYPE)option]);
                cmb_element_option.Items.Add(EnumItemOptionTable_Kor.ELEMENT_REG_TYPE_KOR[(ELEMENT_REG_TYPE)option]);
                cmb_element_option.Items.Add(EnumItemOptionTable_Kor.MONSTER_ELEMENT_DMG_TYPE_KOR[(MONSTER_ELEMENT_DMG_TYPE)option]);
                cmb_if_per_option.Items.Add(EnumItemOptionTable_Kor.ELEMENT_DMG_TYPE_KOR[(ELEMENT_DMG_TYPE)option]);
                cmb_if_add_option.Items.Add(EnumItemOptionTable_Kor.ELEMENT_DMG_TYPE_KOR[(ELEMENT_DMG_TYPE)option]);
                cmb_if_per_option.Items.Add(EnumItemOptionTable_Kor.ELEMENT_REG_TYPE_KOR[(ELEMENT_REG_TYPE)option]);
                cmb_if_add_option.Items.Add(EnumItemOptionTable_Kor.ELEMENT_REG_TYPE_KOR[(ELEMENT_REG_TYPE)option]);
                cmb_if_per_option.Items.Add(EnumItemOptionTable_Kor.MONSTER_ELEMENT_DMG_TYPE_KOR[(MONSTER_ELEMENT_DMG_TYPE)option]);
                cmb_if_add_option.Items.Add(EnumItemOptionTable_Kor.MONSTER_ELEMENT_DMG_TYPE_KOR[(MONSTER_ELEMENT_DMG_TYPE)option]);
            }
            foreach (MONSTER_SIZE option in Enum.GetValues(typeof(MONSTER_SIZE)))
            {
                cmb_size_option.Items.Add(EnumItemOptionTable_Kor.MONSTER_SIZE_DMG_TYPE_KOR[(MONSTER_SIZE_DMG_TYPE)option]);
                cmb_size_option.Items.Add(EnumItemOptionTable_Kor.MONSTER_SIZE_REG_TYPE_KOR[(MONSTER_SIZE_REG_TYPE)option]);
                cmb_if_per_option.Items.Add(EnumItemOptionTable_Kor.MONSTER_SIZE_DMG_TYPE_KOR[(MONSTER_SIZE_DMG_TYPE)option]);
                cmb_if_add_option.Items.Add(EnumItemOptionTable_Kor.MONSTER_SIZE_DMG_TYPE_KOR[(MONSTER_SIZE_DMG_TYPE)option]);
                cmb_if_per_option.Items.Add(EnumItemOptionTable_Kor.MONSTER_SIZE_REG_TYPE_KOR[(MONSTER_SIZE_REG_TYPE)option]);
                cmb_if_add_option.Items.Add(EnumItemOptionTable_Kor.MONSTER_SIZE_REG_TYPE_KOR[(MONSTER_SIZE_REG_TYPE)option]);
            }
            foreach (TRIBE_TYPE option in Enum.GetValues(typeof(TRIBE_TYPE)))
            {
                cmb_tribe_option.Items.Add(EnumItemOptionTable_Kor.TRIBE_DMG_TYPE_KOR[(TRIBE_DMG_TYPE)option]);
                cmb_tribe_option.Items.Add(EnumItemOptionTable_Kor.TRIBE_REG_TYPE_KOR[(TRIBE_REG_TYPE)option]);
                cmb_if_per_option.Items.Add(EnumItemOptionTable_Kor.TRIBE_DMG_TYPE_KOR[(TRIBE_DMG_TYPE)option]);
                cmb_if_add_option.Items.Add(EnumItemOptionTable_Kor.TRIBE_DMG_TYPE_KOR[(TRIBE_DMG_TYPE)option]);
                cmb_if_per_option.Items.Add(EnumItemOptionTable_Kor.TRIBE_REG_TYPE_KOR[(TRIBE_REG_TYPE)option]);
                cmb_if_add_option.Items.Add(EnumItemOptionTable_Kor.TRIBE_REG_TYPE_KOR[(TRIBE_REG_TYPE)option]);
            }
            foreach (MONSTER_KINDS_TYPE option in Enum.GetValues(typeof(MONSTER_KINDS_TYPE)))
            {
                cmb_mobtype_option.Items.Add(EnumItemOptionTable_Kor.MONSTER_KINDS_DMG_TYPE_KOR[(MONSTER_KINDS_DMG_TYPE)option]);
                cmb_mobtype_option.Items.Add(EnumItemOptionTable_Kor.MONSTER_KINDS_REG_TYPE_KOR[(MONSTER_KINDS_REG_TYPE)option]);
                cmb_if_per_option.Items.Add(EnumItemOptionTable_Kor.MONSTER_KINDS_DMG_TYPE_KOR[(MONSTER_KINDS_DMG_TYPE)option]);
                cmb_if_add_option.Items.Add(EnumItemOptionTable_Kor.MONSTER_KINDS_DMG_TYPE_KOR[(MONSTER_KINDS_DMG_TYPE)option]);
                cmb_if_per_option.Items.Add(EnumItemOptionTable_Kor.MONSTER_KINDS_REG_TYPE_KOR[(MONSTER_KINDS_REG_TYPE)option]);
                cmb_if_add_option.Items.Add(EnumItemOptionTable_Kor.MONSTER_KINDS_REG_TYPE_KOR[(MONSTER_KINDS_REG_TYPE)option]);
            }
            foreach (ETC_TYPE option in Enum.GetValues(typeof(ETC_TYPE)))
            {
                string statusName = EnumItemOptionTable_Kor.ETC_TYPE_KOR[option];
                cmb_etc_option.Items.Add(statusName);
                cmb_if_per_option.Items.Add(statusName);
                cmb_if_add_option.Items.Add(statusName);
            }
            foreach (ETC_DMG_TYPE option in Enum.GetValues(typeof(ETC_DMG_TYPE)))
            {
                string statusName = EnumItemOptionTable_Kor.ETC_DMG_TYPE_KOR[option];
                cmb_etc_option.Items.Add(statusName);
                cmb_if_per_option.Items.Add(statusName);
                cmb_if_add_option.Items.Add(statusName);
            }
            
            //Refine
            cmb_if_per_option.Items.Add(EnumItemOptionTable_Kor.REFINE_TYPE_KOR[REFINE_TYPE.REFINE]);

            foreach (KeyValuePair<string, SkillInfo> skill in SkillWindow.SkillWindow._skill_db.Dic)
                cmb_skill_option.Items.Add(skill.Value.NAME_KOR);
            
        }
        void SetNowItemOption()
        {
            cmb_equip_type.SelectedIndex = (int)now_item.Equip_type;
            cmb_Item_image.SelectedIndex = _image_list.IndexOf(now_item.ImageName);
            cmb_set_name_list.SelectedIndex = _set_option_list.IndexOf(now_item.SetName);
            list_Job_limit.ItemsSource = new Job_Limite_List(ref now_item._wear_job_limit);
            list_iOption.ItemsSource = new ItemOptionListBox(now_item.NowRefineOption[ITEM_OPTION_TYPE.ITYPE]);
            list_dOption.ItemsSource = new ItemOptionListBox(now_item.NowRefineOption[ITEM_OPTION_TYPE.DTYPE]);
            list_ifOption.ItemsSource = new ItemOptionIfTypeListBox(now_item.Option_IF_TYPE);

            list_status_effect_option.ItemsSource = new ItemOptionListBox(now_item.NowRefineOption[ITEM_OPTION_TYPE.SE_ATK_RATE_TYPE], now_item.NowRefineOption[ITEM_OPTION_TYPE.SE_REG_RATE_TYPE]);
            list_element_option.ItemsSource = new ItemOptionListBox(now_item.NowRefineOption[ITEM_OPTION_TYPE.MONSTER_ELEMENT_DMG_TYPE], now_item.NowRefineOption[ITEM_OPTION_TYPE.ELEMENT_DMG_TYPE], now_item.NowRefineOption[ITEM_OPTION_TYPE.ELEMENT_REG_TYPE]);
            list_tribe_option.ItemsSource = new ItemOptionListBox(now_item.NowRefineOption[ITEM_OPTION_TYPE.TRIBE_DMG_TYPE], now_item.NowRefineOption[ITEM_OPTION_TYPE.TRIBE_REG_TYPE]);
            list_size_option.ItemsSource = new ItemOptionListBox(now_item.NowRefineOption[ITEM_OPTION_TYPE.MONSTER_SIZE_DMG_TYPE], now_item.NowRefineOption[ITEM_OPTION_TYPE.MONSTER_SIZE_REG_TYPE]);
            list_mobtype_option.ItemsSource = new ItemOptionListBox(now_item.NowRefineOption[ITEM_OPTION_TYPE.MONSTER_KINDS_DMG_TYPE], now_item.NowRefineOption[ITEM_OPTION_TYPE.MONSTER_KINDS_REG_TYPE]);
            list_etc_option.ItemsSource = new ItemOptionListBox(now_item.NowRefineOption[ITEM_OPTION_TYPE.ETC_TYPE], now_item.NowRefineOption[ITEM_OPTION_TYPE.ETC_DMG_TYPE]);
            list_skill_option.ItemsSource = new ItemOptionListBox(now_item.NowRefineOption[ITEM_OPTION_TYPE.SKILL_DMG_TYPE]);

            list_set_option.ItemsSource = new SetItemOptionListBox(now_item.SetPosition);
            
        }
        void InitializeContents()
        {
            if (now_DB == null)
                now_item.Id = 0;
            else
                now_item.Id = now_DB.Count;

            now_item.Name = "";
            now_item.SetName = "";
            now_item.ImageName = "";
            now_item.LevelLimit = 0;
            now_item.CardSlot = 0;
            now_item.EnchantSlot = 0;
            now_item.Item_type = (ITEM_TYPE_ENUM)cmb_item_type.SelectedIndex;
            now_item.Equip_type = (EQUIP_TYPE_ENUM)cmb_equip_type.SelectedIndex;
            now_item.Wear_job_limit.Clear();
            now_item.Option_IF_TYPE.Clear();
            now_item.SetPosition.Clear();
            
            foreach(KeyValuePair<ITEM_OPTION_TYPE, Dictionary<string,double>> item_option in now_item.Option)
            {
                item_option.Value.Clear();
            }
            foreach(KeyValuePair<int,Dictionary<ITEM_OPTION_TYPE, Dictionary<string,double>>> refine in now_item.Option_Refine)
            {
                foreach (KeyValuePair<ITEM_OPTION_TYPE, Dictionary<string, double>> item_option in refine.Value)
                    item_option.Value.Clear();
            }
            
            SetNowItemOption();
        }
        private Dictionary<int, ItemDB> SelectedItemType()
        {
            ITEM_TYPE_ENUM selected = (ITEM_TYPE_ENUM)cmb_item_type.SelectedIndex;

            switch (selected)
            {
                case ITEM_TYPE_ENUM.MONSTER_RESEARCH:
                    return _DB.Mob_research_db;
                case ITEM_TYPE_ENUM.STICKER:
                    return _DB.Sticker_db;
                case ITEM_TYPE_ENUM.DRESS_STYLE:
                    return _DB.Dress_style_db;
                case ITEM_TYPE_ENUM.EQUIPMENT:
                    return _DB.Equip_db[cmb_db_type.SelectedIndex];
                case ITEM_TYPE_ENUM.CARD:
                    return _DB.Card_db;
                case ITEM_TYPE_ENUM.ENCHANT:
                    return _DB.Enchant_db;
                case ITEM_TYPE_ENUM.GEAR:
                    return _DB.Gear_db;
                case ITEM_TYPE_ENUM.SET_OPTION:
                    return _DB.Set_Equip_db;
            }

            return null;
        }
        private void SetSelectedItemTypeUI()
        {
            ITEM_TYPE_ENUM selected = (ITEM_TYPE_ENUM)cmb_item_type.SelectedIndex;

            cmb_db_type.IsEnabled = false;
            cmb_equip_type.IsEnabled = false;
            list_Job_limit.IsEnabled = false;
            Item_EnchantSlot.IsEnabled = false;
            Item_CardSlot.IsEnabled = false;
            Item_Level.IsEnabled = false;
            cmb_Item_image.IsEnabled = false;
            cmb_set_name_list.IsEnabled = false;
            SetOptionPanel.Visibility = Visibility.Hidden;

            if (selected == ITEM_TYPE_ENUM.EQUIPMENT)
            {
                cmb_db_type.IsEnabled = true;
                cmb_equip_type.IsEnabled = true;
                list_Job_limit.IsEnabled = true;
                Item_EnchantSlot.IsEnabled = true;
                Item_CardSlot.IsEnabled = true;
                Item_Level.IsEnabled = true;
                cmb_Item_image.IsEnabled = true;
                cmb_set_name_list.IsEnabled = true;
            }
            else if (selected == ITEM_TYPE_ENUM.GEAR)
                list_Job_limit.IsEnabled = true;
            else if (selected == ITEM_TYPE_ENUM.CARD)
            {
                cmb_db_type.IsEnabled = true;
                cmb_equip_type.IsEnabled = true;
            }
            else if (selected == ITEM_TYPE_ENUM.SET_OPTION)
                SetOptionPanel.Visibility = Visibility.Visible;
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

            if (cmb_item_type.SelectedIndex == (int)ITEM_TYPE_ENUM.SET_OPTION)
                now_item.SetName = now_item.Name;

            now_DB[now_item.Id] = new ItemDB(now_item);
            BindingItemList.AddList(new ItemDB(now_item));

            InitializeContents();
            Item_name.Focus();
            DB_ListBox.SelectedIndex = -1;
            _isNew = true;
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
        private void cmb_db_type_SelectionChanged(object sender, SelectionChangedEventArgs e)
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
        private void cmb_equip_type_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            now_item.Equip_type = (EQUIP_TYPE_ENUM)cmb_equip_type.SelectedIndex;
        }
        private void Item_image_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((sender as ComboBox).SelectedItem != null)
                now_item.ImageName = (sender as ComboBox).SelectedItem.ToString();
        }
        private void cmb_set_name_list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((sender as ComboBox).SelectedItem != null)
                now_item.SetName = (sender as ComboBox).SelectedItem.ToString();
        }
        private void cmb_refine_num_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((sender as ComboBox).SelectedItem != null)
            {
                int refine = Convert.ToInt32((sender as ComboBox).SelectedItem.ToString());
                now_item.NowRefineOption = now_item.Option_Refine[refine];
                SetNowItemOption();
            }
        }
        #endregion
        #region normal option callback
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
            ITEM_OPTION_TYPE type = EnumItemOptionTable_Kor.GET_ITEM_OPTION_TYPE(ref type_name);
            Dictionary<string,double> item_option = GetItemOptionDictionary(type);
            item_option[type_name] = add_value;
            
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

            string type_name = (OptionList.SelectedItem as ItemOption_Binding).Type_name;
            ITEM_OPTION_TYPE type = EnumItemOptionTable.GET_ITEM_OPTION_TYPE(type_name);
            Dictionary<string, double> item_option = GetItemOptionDictionary(type);
            item_option.Remove(type_name);

            SetNowItemOption();
        }
        private void cmb_option_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            StackPanel parentStackpanel = (sender as ComboBox).Parent as StackPanel;
            TextBox AddValue = parentStackpanel.Children[1] as TextBox;

            AddValue.Text = "";
            AddValue.Focus();
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
        #endregion
        #region if type option callback
        private void cmb_if_add_option_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            StackPanel parentStackpanel = (sender as ComboBox).Parent as StackPanel;
            TextBox AddValue = parentStackpanel.Children[4] as TextBox;

            AddValue.Text = "";
            AddValue.Focus();
        }
        private void Add_if_Option_Click(object sender, RoutedEventArgs e)
        {
            StackPanel parentStackpanel = ((sender as Button).Parent as StackPanel).Parent as StackPanel;
            StackPanel OptionStack = parentStackpanel.Children[0] as StackPanel;

            ComboBox PerType = OptionStack.Children[0] as ComboBox;
            TextBox PerValue = OptionStack.Children[1] as TextBox;
            ComboBox AddType = OptionStack.Children[3] as ComboBox;
            TextBox AddValue = OptionStack.Children[4] as TextBox;
            TextBox MaxValue = OptionStack.Children[5] as TextBox;

            if (AddValue.Text == "")
                return;
            if (Convert.ToInt32(AddValue.Text) == 0)
                return;

            string per_type_name = PerType.SelectedItem.ToString();
            string add_type_name = AddType.SelectedItem.ToString();
            double per_value = Convert.ToDouble(PerValue.Text);
            double add_value = Convert.ToDouble(AddValue.Text);
            double max_value = Convert.ToDouble(MaxValue.Text);

            now_item.Option_IF_TYPE.Add(new AbilityPerStatus(per_type_name, per_value, add_type_name, add_value, max_value));

            SetNowItemOption();
            AddType.SelectedIndex = 0;
            PerValue.Text = null;
            AddValue.Text = null;
        }

        private void Del_if_Option_Click(object sender, RoutedEventArgs e)
        {
            StackPanel parentStackpanel = ((sender as Button).Parent as StackPanel).Parent as StackPanel;
            ListBox OptionList = parentStackpanel.Children[2] as ListBox;

            if (OptionList.SelectedItem == null)
                return;

            int selectIndex = OptionList.SelectedIndex;
            now_item.Option_IF_TYPE.RemoveAt(selectIndex);

            SetNowItemOption();
        }
        #endregion
        #region refine type option callback
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
            if (now_item.Option_Refine.ContainsKey(refine) == false)
                now_item.Option_Refine.Add(refine, new Dictionary<ITEM_OPTION_TYPE, Dictionary<string, double>>());

            if (now_item.Option_Refine[refine].ContainsKey(type) == false)
                now_item.Option_Refine[refine].Add(type, new Dictionary<string, double>());
            now_item.Option_Refine[refine][type][type_name] = add_value;

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

            int refine = (OptionList.SelectedItem as ItemOption_Refine_Binding).Refine;
            string type_name = (OptionList.SelectedItem as ItemOption_Refine_Binding).Type_name;
            ITEM_OPTION_TYPE type = EnumItemOptionTable.GET_ITEM_OPTION_TYPE(type_name);
            now_item.Option_Refine[refine][type].Remove(type_name);

            SetNowItemOption();
        }

        #endregion
        #region Set items option callback
        private void Del_Set_Equips_Click(object sender, RoutedEventArgs e)
        {
            StackPanel parentStackpanel = ((sender as Button).Parent as StackPanel).Parent as StackPanel;
            ListBox OptionList = parentStackpanel.Children[2] as ListBox;

            if (OptionList.SelectedItem == null)
                return;

            string type_name_kor = (OptionList.SelectedItem as SetItemOption_Binding).Type_name;
            EQUIP_TYPE_ENUM type = EnumBaseTable_Kor.EQUIP_TYPE_ENUM_KOR.FirstOrDefault(x => x.Value == type_name_kor).Key;
            now_item.SetPosition.Remove(type);
            SetNowItemOption();
        }

        private void Add_Set_Equips_Click(object sender, RoutedEventArgs e)
        {
            StackPanel parentStackpanel = ((sender as Button).Parent as StackPanel).Parent as StackPanel;
            StackPanel OptionStack = parentStackpanel.Children[0] as StackPanel;

            ComboBox AddType = OptionStack.Children[0] as ComboBox;

            string type_name_kor = AddType.SelectedItem.ToString();

            EQUIP_TYPE_ENUM type = EnumBaseTable_Kor.EQUIP_TYPE_ENUM_KOR.FirstOrDefault(x => x.Value == type_name_kor).Key;
            now_item.SetPosition.Add(type);

            SetNowItemOption();
            AddType.SelectedIndex = 0;
        }
        #endregion
        #region Skill option callback
        private void Add_Skill_Option_Click(object sender, RoutedEventArgs e)
        {
            StackPanel parentStackpanel = ((sender as Button).Parent as StackPanel).Parent as StackPanel;
            StackPanel OptionStack = parentStackpanel.Children[0] as StackPanel;

            ComboBox AddType = OptionStack.Children[0] as ComboBox;
            TextBox AddValue = OptionStack.Children[1] as TextBox;

            if (AddValue.Text == "")
                return;
            if (Convert.ToInt32(AddValue.Text) == 0)
                return;

            string type_name_kor = AddType.SelectedItem.ToString();
            double add_value = Convert.ToDouble(AddValue.Text);

            string type_name = GetSkillName(type_name_kor);
            now_item.Option_SKILL_DMG_TYPE[type_name] = add_value;

            SetNowItemOption();
            AddType.SelectedIndex = 0;
            AddValue.Text = null;
        }

        private void Del_Skill_Option_Click(object sender, RoutedEventArgs e)
        {
            StackPanel parentStackpanel = ((sender as Button).Parent as StackPanel).Parent as StackPanel;
            ListBox OptionList = parentStackpanel.Children[2] as ListBox;

            if (OptionList.SelectedItem == null)
                return;

            string type_name = (OptionList.SelectedItem as ItemOption_Binding).Type_name;
            now_item.Option_SKILL_DMG_TYPE.Remove(type_name);

            SetNowItemOption();
        }
        private string GetSkillName(string skill_name_kor)
        {
            string skill_name = null;
            skill_name = SwordmanSkill.SKILL_KOR.FirstOrDefault(x => x.Value == skill_name_kor).Key;
            if (skill_name != null) return skill_name;
            skill_name = LoadKnightSkill.SKILL_KOR.FirstOrDefault(x => x.Value == skill_name_kor).Key;
            if (skill_name != null) return skill_name;

            return null;
        }
        #endregion

        
    }
}
