using System.Windows;
using System.Windows.Controls;
using System.IO;
using RooStatsSim.DB;

using System.Text.Json;
using RooStatsSim.Extension;
using RooStatsSim.UI.Menu;

namespace RooStatsSim.UI.Manager
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class DBManager : Window
    {
        private DBlist _DB = MenuBox._roo_db;
        private MonsterManager mob_manager = null;
        private ItemManager item_manager = null;

        public DBManager()
        {
            mob_manager = new MonsterManager(ref _DB);
            item_manager = new ItemManager(ref _DB);

            InitializeComponent();

            frame_contents.Navigate(item_manager);
        }

        #region UI Binding, contents settings
        private void ManagerSelector_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton source = e.Source as RadioButton;
            string contents = source.Content.ToString();

            if (frame_contents != null)
            {
                if (string.Compare(contents, "ItemDB") == 0)
                {
                    this.Width = 1050;
                    this.Height = 900;
                    frame_contents.Navigate(item_manager);
                }
                else
                {
                    this.Width = 585;
                    this.Height = 477;
                    frame_contents.Navigate(mob_manager);
                }
            }
        }

        private void DB_Save_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult res = MessageBox.Show(" 저장하시겠습니까?", "Save", MessageBoxButton.YesNo);
            if (res == MessageBoxResult.Yes)
            {
                DBSerizator.SaveDataBase(ref _DB);
                mob_manager.IsNew = false;
                item_manager.IsNew = false;
            }
            
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if ( ( mob_manager.IsNew ) || ( item_manager.IsNew) )
            {
                MessageBoxResult res = MessageBox.Show("변경사항이 있습니다. 변경하시겠습니까?", "Save", MessageBoxButton.YesNo);
                if (res == MessageBoxResult.Yes)
                    DBSerizator.SaveDataBase(ref _DB);
            }    
        }
        #endregion

    }
}
