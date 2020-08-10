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

namespace RooStatsSim
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //radio_attack_type.Tag = 0;
        }

        private void CalcSim_Click(object sender, RoutedEventArgs e)
        {
            int attack_type = Convert.ToInt32(radio_attack_type.Tag);

            int atk_weapon = Convert.ToInt32(txt_atk_weapon.Text);
            int atk_equip = Convert.ToInt32(txt_atk_equip.Text);
            int atk_smelting = Convert.ToInt32(txt_atk_smelting.Text);
            int atk_mastery = Convert.ToInt32(txt_atk_mastery.Text);

            double pdamage_percent = Convert.ToDouble(txt_pdamage_percent.Text);
            int pdamage_add = Convert.ToInt32(txt_pdamage_add.Text);
            double pdamage_attack_type = Convert.ToDouble(txt_pdamage_attacktype.Text);
            double atk_percent = Convert.ToDouble(txt_atk_percent.Text);

            double def_ignore = Convert.ToDouble(txt_def_ignore.Text);
            double elemet_increse = Convert.ToDouble(txt_element_increse.Text);
            double tribe_increse = Convert.ToDouble(txt_tribe_increse.Text);

        }

        private void attack_type_Click(object sender, RoutedEventArgs e)
        {
            RadioButton source = e.Source as RadioButton;

            radio_attack_type.Tag = source.Tag;
        }
    }
}
