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
        ItemListFilter normalPropertyList;
        public Equip()
        {
            _user_data = UserData.GetInstance;

            InitializeComponent();

            normalPropertyList = new ItemListFilter(ref _user_data);
            ItemSelector.ItemsSource = normalPropertyList;
            //equipList = new EquipList(MainWindow._roo_db.Dress_style_db[0]);

        }
    }
}
