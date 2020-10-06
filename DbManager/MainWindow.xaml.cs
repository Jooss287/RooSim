using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.IO;
using DbManager.DB;
using DbManager.UI;

using System.Text.Json;
using System.Text.Json.Serialization;
using DbManager.Extension;

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
                    frame_contents.Navigate(item_manager);
                }
                else
                {
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var serializeOptions = new JsonSerializerOptions();
            serializeOptions.Converters.Add(new JsonConvertExt_Dic_int_DB());
            serializeOptions.Converters.Add(new JsonConvertExt_Dic_Enum_BasicType());
            serializeOptions.WriteIndented = true;

            string jsonString;
            jsonString = JsonSerializer.Serialize(_DB, serializeOptions);
            File.WriteAllText("roo_json.roo", jsonString);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var serializeOptions = new JsonSerializerOptions();
            serializeOptions.Converters.Add(new JsonConvertExt_Dic_int_DB());
            serializeOptions.Converters.Add(new JsonConvertExt_Dic_Enum_BasicType());
            serializeOptions.WriteIndented = true;

            string jsonString = File.ReadAllText("roo_json.roo");
            DBlist _Test = JsonSerializer.Deserialize<DBlist>(jsonString, serializeOptions);
        }
    }

    public class Product
    {
        public MonsterDB mobDB { get; set; }
        public Dictionary<int, MonsterDB> Dic { get; set; }
        public Dictionary<ITYPE, int> Dic_Itype { get; set; }
    }
}
