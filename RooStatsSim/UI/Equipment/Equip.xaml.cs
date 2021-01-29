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
        public static Enchant_DB _enchant_db = new Enchant_DB();

        UserData _user_data;
        ItemListFilter EquipItemList;
        ItemListFilter CardItemList;
        ItemListFilter EnchantList;
        Popup itemPopup = new Popup();

        EQUIP_TYPE_ENUM now_selected_equip_type;
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
        void SetUserItemChanged(EquipId item, EQUIP_TYPE_ENUM equip_type, ITEM_TYPE_ENUM item_type = ITEM_TYPE_ENUM.EQUIPMENT)
        {
            switch (item_type)
            {
                case ITEM_TYPE_ENUM.EQUIPMENT:
                    GetEquipTypeItem(equip_type).Header = string.Format("+{0} {1}", item.Refine, item.Name);
                    GetEquipTypeItem(equip_type).ItemsSource = new EquipList(_user_data.Equip.Dic[equip_type]);

                    CardItemList = new ItemListFilter(ref _user_data, ITEM_TYPE_ENUM.CARD, equip_type);
                    CardSelector.ItemsSource = CardItemList;
                    EnchantList = new ItemListFilter(ITEM_TYPE_ENUM.ENCHANT, equip_type);
                    EnchantSelector.ItemsSource = EnchantList;
                    ItemSelected.ItemsSource = new UsedItemList(_user_data.Equip.Dic[equip_type], ITEM_TYPE_ENUM.EQUIPMENT, now_selected_equip_type);
                    break;
                case ITEM_TYPE_ENUM.CARD:
                case ITEM_TYPE_ENUM.ENCHANT:
                    GetEquipTypeItem(equip_type).ItemsSource = new EquipList(_user_data.Equip.Dic[equip_type]);
                    break;
                default:
                    break;
            }
            MainWindow._user_data_manager.CalcUserData();
        }

        private TreeViewItem GetEquipTypeItem(EQUIP_TYPE_ENUM equip_type)
        {
            switch (equip_type)
            {
                case EQUIP_TYPE_ENUM.HEAD_TOP:
                    return head_top_tree;
                case EQUIP_TYPE_ENUM.HEAD_MID:
                    return head_mid_tree;
                case EQUIP_TYPE_ENUM.HEAD_BOT:
                    return head_bot_tree;
                case EQUIP_TYPE_ENUM.WEAPON:
                    return main_weapon_tree;
                case EQUIP_TYPE_ENUM.SUB_WEAPON:
                    return sub_weapon_tree;
                case EQUIP_TYPE_ENUM.ARMOR:
                    return armor_tree;
                case EQUIP_TYPE_ENUM.CLOAK:
                    return cloak_tree;
                case EQUIP_TYPE_ENUM.SHOES:
                    return shoes_tree;
                case EQUIP_TYPE_ENUM.ACCESSORIES1:
                    return acc1_tree;
                case EQUIP_TYPE_ENUM.ACCESSORIES2:
                    return acc2_tree;
                case EQUIP_TYPE_ENUM.COSTUME:
                    return costume_tree;
                case EQUIP_TYPE_ENUM.BACK_DECORATION:
                    return backdeco_tree;
            }
            return null;
        }

        #region Equipment Window UI
        private void SelectEquipment_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            now_selected_equip_type = (EQUIP_TYPE_ENUM)Enum.Parse(typeof(EQUIP_TYPE_ENUM), (string)((sender as ContentControl).Tag));
            EquipItemList = new ItemListFilter(ref _user_data, ITEM_TYPE_ENUM.EQUIPMENT, now_selected_equip_type);
            ItemSelector.ItemsSource = EquipItemList;
            if (_user_data.Equip.Dic.ContainsKey(now_selected_equip_type))
            { 
                ItemSelected.ItemsSource = new UsedItemList(_user_data.Equip.Dic[now_selected_equip_type], ITEM_TYPE_ENUM.EQUIPMENT, now_selected_equip_type);
                CardSelected.ItemsSource = new UsedItemList(_user_data.Equip.Dic[now_selected_equip_type], ITEM_TYPE_ENUM.CARD, now_selected_equip_type);
                EnchantSelected.ItemsSource = new UsedItemList(_user_data.Equip.Dic[now_selected_equip_type], ITEM_TYPE_ENUM.ENCHANT, now_selected_equip_type);
            }
            else
            {
                ItemSelected.ItemsSource = new UsedItemList();
                CardSelected.ItemsSource = new UsedItemList();
                EnchantSelected.ItemsSource = new UsedItemList();
            }
            ItemSlectorTab.SelectedIndex = 0;
        }
        #endregion

        #region Common function
        void SetItemTextBlock(EquipId item)
        {
            TextBlock PopupText = new TextBlock
            {
                Text = "+" + Convert.ToString(item.Refine) + " " + item.Name,
                Background = Brushes.Silver
            };
            itemPopup.Child = PopupText;
        }
        private void Item_RefineWheel(object sender, MouseWheelEventArgs e)
        {
            EquipId item = ((sender as ContentControl).Content as StackPanel).DataContext as EquipId;
            item.Refine += e.Delta > 0 ? 1 : -1;
            SetItemTextBlock(item);
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

        #region Equip list
        private void SelectItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            EquipId item = ((sender as ContentControl).Content as StackPanel).DataContext as EquipId;
            
            if (!_user_data.Equip.Dic.ContainsKey(now_selected_equip_type))
                _user_data.Equip.Dic[now_selected_equip_type] = new EQUIP.EquipItem();
            
            EQUIP.EquipItem user_item = _user_data.Equip.Dic[now_selected_equip_type];
            user_item.EquipType = now_selected_equip_type;
            user_item.Equip = item.Id;
            user_item.Refine = item.Refine;

            SetUserItemChanged(item, now_selected_equip_type);
            ItemSlectorTab.SelectedIndex = 1;
        }
        #endregion

        #region Card list
        private void SelectCard_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            EquipId item = ((sender as ContentControl).Content as StackPanel).DataContext as EquipId;

            _user_data.Equip.Dic[now_selected_equip_type].AddCard(item.Id);
            SetUserItemChanged(item, now_selected_equip_type, ITEM_TYPE_ENUM.CARD);
        }
        #endregion

        #region Enchant list
        void SetEnchantTextBlock(EquipId item)
        {
            EnchantInfo enchant_info = Equip._enchant_db.Dic[item.Name_Eng];
            string txt = "";
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

        private void Enchant_Option_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            EquipId item = (sender as ContentControl).DataContext as EquipId;

            int changeValue = e.Delta > 0 ? 1 : -1;
            if ((Keyboard.IsKeyDown(Key.LeftShift)) || (Keyboard.IsKeyDown(Key.RightShift)))
                changeValue *= 10;
            item.Point += changeValue;
            SetEnchantTextBlock(item);
        }

        private void Enchant_Option_MouseEnter(object sender, MouseEventArgs e)
        {
            EquipId item = (sender as ContentControl).DataContext as EquipId;

            SetEnchantTextBlock(item);
            itemPopup.PlacementTarget = (sender as ContentControl).Content as TextBlock;
            itemPopup.IsOpen = true;
        }

        private void Enchant_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            EquipId item = (sender as ContentControl).DataContext as EquipId;

            _user_data.Equip.Dic[now_selected_equip_type].AddEnchant(item.Name_Eng, item.Point);
            SetUserItemChanged(item, now_selected_equip_type, ITEM_TYPE_ENUM.ENCHANT);
        }
        #endregion

        #region Gear list
        private void SelectGear_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
        #endregion
    }
}
