using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Media.Imaging;

using RooStatsSim.DB.Table;
using RooStatsSim.DB.Enchant;
using RooStatsSim.User;
using RooStatsSim.Extension;

namespace RooStatsSim.UI.Equipment
{
    /// <summary>
    /// Equip.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Equip : UserControl
    {
        enum EQUIP_UI_ENUM
        {
            EQUIP_IMAGE,
            EQUIP_NAME,
            CARD_ITEM_CTRL,
            ENCHANT_ITEM_CTRL,
        }
        public static Enchant_DB _enchant_db = new Enchant_DB();

        UserData _user_data;
        ItemListFilter EquipItemList;
        ItemListFilter CardItemList;
        ItemListFilter EnchantList;
        Popup itemPopup = new Popup();

        EQUIP_TYPE_ENUM now_selected_equip_type = EQUIP_TYPE_ENUM.BACK_DECORATION+1;
        public Equip()
        {
            MainWindow._user_data_manager.JobDataChanged += new UserDataManager.JobChangedEventHandler(GetUserData);
            this.DataContext = this;
            InitializeComponent();
        }
        void GetUserData()
        {
            _user_data = MainWindow._user_data_manager.Data;

            foreach(KeyValuePair<EQUIP_TYPE_ENUM, EQUIP.EquipItem> equipment in _user_data.Equip.Dic)
            {
                if (equipment.Value == null)
                    continue;

                EquipId equip_id = new EquipId()
                {
                    Id = equipment.Value.EquipInfo.Id,
                    Name = equipment.Value.EquipInfo.Name,
                    Refine = equipment.Value.Refine,
                    ImageRoot = equipment.Value.EquipInfo.ImageName
                };
                SetUserItemChanged(equip_id, equipment.Key);
            }

            string job_name = Enum.GetName(typeof(JOB_SELECT_LIST), ((int)((int)_user_data.Job / 100) * 100)).ToLower();
            string filename = "Resources/Job/" + job_name + ".png";
            Image_Char.Source = new BitmapImage(ResourceExtension.GetAssemblyUri(filename));
        }

        #region Equipment Window UI
        private void EquipmentPanel_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            now_selected_equip_type = (EQUIP_TYPE_ENUM)Enum.Parse(typeof(EQUIP_TYPE_ENUM), (string)((sender as ContentControl).Tag));
            EquipItemList = new ItemListFilter(ref _user_data, ITEM_TYPE_ENUM.EQUIPMENT, now_selected_equip_type);
            ItemSelector.ItemsSource = EquipItemList;
            if (_user_data.Equip.Dic.ContainsKey(now_selected_equip_type))
            {
                CardItemList = new ItemListFilter(ref _user_data, ITEM_TYPE_ENUM.CARD, now_selected_equip_type);
                CardSelector.ItemsSource = CardItemList;
                EnchantList = new ItemListFilter(ITEM_TYPE_ENUM.ENCHANT, now_selected_equip_type);
                EnchantSelector.ItemsSource = EnchantList;

                SetUsedItem(now_selected_equip_type);
            }
            else
                ItemSelected.ItemsSource = new UsedItemList();
            
            ItemSlectorTab.SelectedIndex = 0;
        }
        void SetUserItemChanged(EquipId item, EQUIP_TYPE_ENUM equip_type, ITEM_TYPE_ENUM item_type = ITEM_TYPE_ENUM.EQUIPMENT)
        {
            StackPanel now_panel = GetEquipTypeItem(equip_type);
            if (now_panel == null)
                return;

            switch (item_type)
            {
                case ITEM_TYPE_ENUM.EQUIPMENT:
                    (now_panel.Children[(int)EQUIP_UI_ENUM.EQUIP_IMAGE] as Image).Source = item.ImageFile;
                    (now_panel.Children[(int)EQUIP_UI_ENUM.EQUIP_NAME] as TextBlock).Text = string.Format("+{0} {1}", item.Refine, item.Name);

                    CardItemList = new ItemListFilter(ref _user_data, ITEM_TYPE_ENUM.CARD, equip_type);
                    CardSelector.ItemsSource = CardItemList;
                    EnchantList = new ItemListFilter(ITEM_TYPE_ENUM.ENCHANT, equip_type);
                    EnchantSelector.ItemsSource = EnchantList;
                    break;
                case ITEM_TYPE_ENUM.CARD:
                    (now_panel.Children[(int)EQUIP_UI_ENUM.CARD_ITEM_CTRL] as ItemsControl).ItemsSource = new UsedItemList(_user_data.Equip.Dic[equip_type], ITEM_TYPE_ENUM.CARD, equip_type);
                    break;
                case ITEM_TYPE_ENUM.ENCHANT:
                    (now_panel.Children[(int)EQUIP_UI_ENUM.ENCHANT_ITEM_CTRL] as ItemsControl).ItemsSource = new UsedItemList(_user_data.Equip.Dic[equip_type], ITEM_TYPE_ENUM.ENCHANT, equip_type);
                    break;
                case ITEM_TYPE_ENUM.GEAR:
                    break;
                default:
                    break;
            }
            MainWindow._user_data_manager.CalcUserData();
        }
        void SetUsedItem(EQUIP_TYPE_ENUM equip_type)
        {
            StackPanel now_panel = GetEquipTypeItem(equip_type);
            if (now_panel == null)
                return;
            
            ItemSelected.ItemsSource = new UsedItemList(_user_data.Equip.Dic[equip_type], ITEM_TYPE_ENUM.EQUIPMENT, equip_type);
            CardSelected.ItemsSource = new UsedItemList(_user_data.Equip.Dic[equip_type], ITEM_TYPE_ENUM.CARD, equip_type);
            EnchantSelected.ItemsSource = new UsedItemList(_user_data.Equip.Dic[equip_type], ITEM_TYPE_ENUM.ENCHANT, equip_type);
        }
        private StackPanel GetEquipTypeItem(EQUIP_TYPE_ENUM equip_type)
        {
            switch (equip_type)
            {
                case EQUIP_TYPE_ENUM.HEAD_TOP:
                    return head_top_panel;
                case EQUIP_TYPE_ENUM.HEAD_MID:
                    return head_mid_panel;
                case EQUIP_TYPE_ENUM.HEAD_BOT:
                    return head_bot_panel;
                case EQUIP_TYPE_ENUM.WEAPON:
                    return main_weapon_panel;
                case EQUIP_TYPE_ENUM.SUB_WEAPON:
                    return sub_weapon_panel;
                case EQUIP_TYPE_ENUM.ARMOR:
                    return armor_panel;
                case EQUIP_TYPE_ENUM.CLOAK:
                    return cloak_panel;
                case EQUIP_TYPE_ENUM.SHOES:
                    return shoes_panel;
                case EQUIP_TYPE_ENUM.ACCESSORIES1:
                    return acc1_panel;
                case EQUIP_TYPE_ENUM.ACCESSORIES2:
                    return acc2_panel;
                case EQUIP_TYPE_ENUM.COSTUME:
                    return costume_panel;
                case EQUIP_TYPE_ENUM.BACK_DECORATION:
                    return back_deco_panel;
            }
            return null;
        }
        #endregion
        #region Common Function
        void SetItemTextBlock(EquipId item)
        {
            TextBlock PopupText = new TextBlock
            {
                Text = "+" + Convert.ToString(item.Refine) + " " + item.Name,
                Background = Brushes.Silver
            };
            itemPopup.Child = PopupText;
        }
        private void ContentControl_MouseEnter(object sender, MouseEventArgs e)
        {
            EquipId item = ((sender as ContentControl).Content as StackPanel).DataContext as EquipId;
            SetItemTextBlock(item);

            itemPopup.PlacementTarget = ((sender as ContentControl).Content as StackPanel).Children[0];
            itemPopup.IsOpen = true;
        }

        private void ContentControl_MouseLeave(object sender, MouseEventArgs e)
        {
            itemPopup.IsOpen = false;
        }
        #endregion

        #region Equipment Item Selector
        private void SelectItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            EquipId item = ((sender as ContentControl).Content as StackPanel).DataContext as EquipId;

            if (!_user_data.Equip.Dic.ContainsKey(now_selected_equip_type))
                _user_data.Equip.Dic[now_selected_equip_type] = new EQUIP.EquipItem();
            _user_data.Equip.Dic[now_selected_equip_type].EquipType = now_selected_equip_type;
            _user_data.Equip.Dic[now_selected_equip_type].Equip = item.Id;
            _user_data.Equip.Dic[now_selected_equip_type].Refine = item.Refine;

            SetUserItemChanged(item, now_selected_equip_type);
            ItemSlectorTab.SelectedIndex = 1;
        }
        private void Item_RefineWheel(object sender, MouseWheelEventArgs e)
        {
            EquipId item = ((sender as ContentControl).Content as StackPanel).DataContext as EquipId;
            item.Refine += e.Delta > 0 ? 1 : -1;
            SetItemTextBlock(item);
        }
        #endregion
        #region Card Item Selector
        private void SelectCard_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            EquipId item = ((sender as ContentControl).Content as StackPanel).DataContext as EquipId;

            _user_data.Equip.Dic[now_selected_equip_type].AddCard(item.Id);
            SetUserItemChanged(item, now_selected_equip_type, ITEM_TYPE_ENUM.CARD);
            SetUsedItem(now_selected_equip_type);
        }
        #endregion
        #region Enchant Item Selector
        private void Enchant_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            EquipId item = ((sender as ContentControl).Content as StackPanel).DataContext as EquipId;

            if (item.Point == 0)
                return;

            _user_data.Equip.Dic[now_selected_equip_type].AddEnchant(item.Name_Eng, item.Point - 1);
            SetUserItemChanged(item, now_selected_equip_type, ITEM_TYPE_ENUM.ENCHANT);
            SetUsedItem(now_selected_equip_type);
        }
        private void Enchant_Option_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            EquipId item = ((sender as ContentControl).Content as StackPanel).DataContext as EquipId;

            int changeValue = e.Delta > 0 ? 1 : -1;
            if ((Keyboard.IsKeyDown(Key.LeftShift)) || (Keyboard.IsKeyDown(Key.RightShift)))
                changeValue *= 10;
            item.Point += changeValue;
            SetEnchantTextBlock(item);
        }

        private void Enchant_Option_MouseEnter(object sender, MouseEventArgs e)
        {
            EquipId item = ((sender as ContentControl).Content as StackPanel).DataContext as EquipId;

            SetEnchantTextBlock(item);
            itemPopup.PlacementTarget = ((sender as ContentControl).Content as StackPanel).Children[0];
            itemPopup.IsOpen = true;
        }
        void SetEnchantTextBlock(EquipId item)
        {
            EnchantInfo enchant_info = Equip._enchant_db.Dic[item.Name_Eng];
            string txt;
            if (enchant_info.IsAdvanced)
                txt = enchant_info.NAME_KOR + " " + Convert.ToString(item.Point);
            else
                txt = enchant_info.NAME_KOR + " " + Convert.ToString(item.Point);

            TextBlock PopupText = new TextBlock
            {
                Text = txt,
                Background = Brushes.Silver
            };
            itemPopup.Child = PopupText;
        }
        #endregion
        #region Gear Item Selector
        private void SelectGear_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
        #endregion
    }
}
