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
using DbManager.DB;
using DbManager.UI;

namespace DbManager
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        private DBlist _DB;
        private MonsterManager mob_manager = null;
        private ItemManager item_manager = null;
        public MainWindow()
        {
            _DB = new DBlist();
            DBSerizator.ReadDB(ref _DB);

            InitializeComponent();
        }

        private void ManagerSelector_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton source = e.Source as RadioButton;
            string contents = source.Content.ToString();

            if (frame_contents != null)
            {
                if (string.Compare(contents, "ItemDB") == 0)
                {
                    if (item_manager == null)
                        item_manager = new ItemManager(ref _DB);
                    frame_contents.Navigate(item_manager);
                }
                else
                {
                    if (mob_manager == null)
                        mob_manager = new MonsterManager(ref _DB);
                    frame_contents.Navigate(mob_manager);
                }
            }
        }

        private void DB_Save_Click(object sender, RoutedEventArgs e)
        {
            DBSerizator.SaveDataBase(ref _DB);
        }
    }
}
