using RooStatsSim.DB;
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

            ItemAbility abaility = new ItemAbility();

            abaility.ATK_weapon = Convert.ToInt32(txt_atk_weapon.Text);
            abaility.ATK_equipment = Convert.ToInt32(txt_atk_equip.Text);
            abaility.ATK_smelting = Convert.ToInt32(txt_atk_smelting.Text);
            abaility.ATK_mastery = Convert.ToInt32(txt_atk_mastery.Text);

            abaility.PDamage_percent = Convert.ToDouble(txt_pdamage_percent.Text);
            abaility.PDamage_addition = Convert.ToInt32(txt_pdamage_add.Text);
            abaility.PDamage_attack_type = Convert.ToDouble(txt_pdamage_attacktype.Text);
            abaility.ATK_percent = Convert.ToDouble(txt_atk_percent.Text);

            abaility.def_ignore = Convert.ToDouble(txt_def_ignore.Text);
            abaility.element_increse = Convert.ToDouble(txt_element_increse.Text);
            abaility.tribe_increse = Convert.ToDouble(txt_tribe_increse.Text);

            Status status = new Status();
            status._base = Convert.ToInt32(txt_LvlBase.Text);
            status._str = Convert.ToInt32(txt_StrBase.Text) + Convert.ToInt32(txt_StrAdd.Text);
            status._dex = Convert.ToInt32(txt_DexBase.Text) + Convert.ToInt32(txt_DexAdd.Text);
            status._luk = Convert.ToInt32(txt_LukBase.Text) + Convert.ToInt32(txt_LukAdd.Text);

            Equations equ = new Equations(0, status, abaility);
            retCalc.Text = Convert.ToString(equ.CalcATKdamage());
        }

        private void attack_type_Click(object sender, RoutedEventArgs e)
        {
            RadioButton source = e.Source as RadioButton;

            radio_attack_type.Tag = source.Tag;
        }
    }
}
