using RooStatsSim.DB;
using RooStatsSim.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RooStatsSim.UI.Equipment
{
    /// <summary>
    /// Equip.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Equip : Window
    {
        UserData _user_data;
        EquipList equipList;
        ItemListFilter EquipItemList;
        ItemListFilter CardItemList;
        ItemListFilter EnchantList;

        EQUIP_TYPE_ENUM now_selected_equip_type;
        public Equip()
        {
            _user_data = UserData.GetInstance;

            InitializeComponent();
        }

        private void SelectEquipment_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            now_selected_equip_type = (EQUIP_TYPE_ENUM)Enum.Parse(typeof(EQUIP_TYPE_ENUM), (string)((sender as ContentControl).Tag));
            EquipItemList = new ItemListFilter(ref _user_data, ITEM_TYPE_ENUM.EQUIPMENT, now_selected_equip_type);
            ItemSelector.ItemsSource = EquipItemList;
            ItemSlectorTab.SelectedIndex = 0;
        }

        private void SelectItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            EquipId item = ((sender as ContentControl).Content as StackPanel).DataContext as EquipId;

            _user_data.Equip.List[(int)now_selected_equip_type].Equip = MainWindow._roo_db.Equip_db[item.Id];
            main_weapon_tree.Header = item.Name;
            main_weapon_tree.ItemsSource = new EquipList(_user_data.Equip.List[(int)now_selected_equip_type]);

            CardItemList = new ItemListFilter(ref _user_data, ITEM_TYPE_ENUM.CARD, now_selected_equip_type);
            CardSelector.ItemsSource = CardItemList;
            //EnchantList = new ItemListFilter(ref _user_data, ITEM_TYPE_ENUM.ENCHANT, now_selected_equip_type);

            ItemSlectorTab.SelectedIndex = 1;
        }

        private void SelectCard_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            EquipId item = ((sender as ContentControl).Content as StackPanel).DataContext as EquipId;

            _user_data.Equip.List[(int)now_selected_equip_type].AddCard(MainWindow._roo_db.Card_db[item.Id]);
            main_weapon_tree.ItemsSource = new EquipList(_user_data.Equip.List[(int)now_selected_equip_type]);
        }
    }
}
