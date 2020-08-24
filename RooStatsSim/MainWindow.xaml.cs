using RooStatsSim.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using System.Windows.Threading;

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

            Initialize_value();
            Initialize_value_test();
            CalcDamage();
        }

        readonly Dictionary<ELEMENT_TYPE, string> element_dict = new Dictionary<ELEMENT_TYPE, string>()
        {
            {ELEMENT_TYPE.NORMAL, "무" },
            {ELEMENT_TYPE.WIND, "풍" },
            {ELEMENT_TYPE.EARTH, "지" },
            {ELEMENT_TYPE.FIRE, "화" },
            {ELEMENT_TYPE.WATER, "수" },
            {ELEMENT_TYPE.POISON, "독" },
            {ELEMENT_TYPE.HOLY, "성" },
            {ELEMENT_TYPE.DARK, "암" },
            {ELEMENT_TYPE.ASTRAL, "염" },
            {ELEMENT_TYPE.UNDEAD, "불사" },
        };

        private void InputUIData()
        {

        }
        private void CalcDamage()
        {
            int attack_type = Convert.ToInt32(radio_attack_type.Tag);

            ItemAbility ability = new ItemAbility();

            ability.ATK_weapon = Convert.ToInt32(txt_atk_weapon.Text);
            ability.ATK_equipment = Convert.ToInt32(txt_atk_equip.Text);
            ability.ATK_smelting = Convert.ToInt32(txt_atk_smelting.Text);
            ability.ATK_mastery = Convert.ToInt32(txt_atk_mastery.Text);

            ability.PDamage_percent = Convert.ToDouble(txt_pdamage_percent.Text);
            ability.PDamage_addition = Convert.ToInt32(txt_pdamage_add.Text);
            ability.PDamage_attack_type = Convert.ToDouble(txt_pdamage_attacktype.Text);
            ability.ATK_percent = Convert.ToDouble(txt_atk_percent.Text);

            ability.def_ignore = Convert.ToDouble(txt_def_ignore.Text);
            ability.element_increse = Convert.ToDouble(txt_element_increse.Text);
            ability.tribe_increse = Convert.ToDouble(txt_tribe_increse.Text);
            ability.size_increse = Convert.ToDouble(txt_size_increse.Text);
            ability.boss_increse = Convert.ToDouble(txt_boss_increse.Text);

            Status status = new Status();
            status._base = Convert.ToInt32(txt_LvlBase.Text);
            status._str = Convert.ToInt32(txt_StrBase.Text) + Convert.ToInt32(txt_StrAdd.Text);
            status._dex = Convert.ToInt32(txt_DexBase.Text) + Convert.ToInt32(txt_DexAdd.Text);
            status._luk = Convert.ToInt32(txt_LukBase.Text) + Convert.ToInt32(txt_LukAdd.Text);

            MonsterDB mobDB = new MonsterDB();
            mobDB.defense = Convert.ToInt32(txt_monster_def.Text);

            ELEMENT_TYPE player_element = (ELEMENT_TYPE)cmb_player_element.SelectedIndex;
            ELEMENT_TYPE monster_element = (ELEMENT_TYPE)cmb_monster_element.SelectedIndex;
            AdvantageTable advantage_table = new AdvantageTable();
            double element_ratio = advantage_table.GetElementRatio(player_element, monster_element);


            Equations equ = new Equations(attack_type, status, ability, mobDB);
            equ.element_inc = element_ratio;
            equ.size_panelty = Convert.ToInt32(txt_weapon_size_panelty.Text);

            int calcATK_min = (int)(equ.CalcATKdamage(CALC_STANDARD.MIN_DAMAGE) * (Convert.ToInt32(txt_skill_percent.Text) + Convert.ToInt32(txt_skill_add_percent.Text)) * 0.01);
            int calcATK_max = (int)(equ.CalcATKdamage(CALC_STANDARD.MAX_DAMAGE) * (Convert.ToInt32(txt_skill_percent.Text) + Convert.ToInt32(txt_skill_add_percent.Text)) * 0.01);
            string strRetCalc;
            strRetCalc = Convert.ToString(calcATK_min) + " ~ " + Convert.ToString(calcATK_max);
            retCalc.Text = strRetCalc;
        }

        private void CAlcIngameATK()
        {
            int attack_type = Convert.ToInt32(radio_attack_type.Tag);

            ItemAbility ability = new ItemAbility();

            ability.ATK_weapon = Convert.ToInt32(txt_atk_weapon.Text);
            ability.ATK_equipment = Convert.ToInt32(txt_atk_equip.Text);
            ability.ATK_smelting = Convert.ToInt32(txt_atk_smelting.Text);
            ability.ATK_mastery = Convert.ToInt32(txt_atk_mastery.Text);

            ability.PDamage_percent = Convert.ToDouble(txt_pdamage_percent.Text);
            ability.PDamage_addition = Convert.ToInt32(txt_pdamage_add.Text);
            ability.PDamage_attack_type = Convert.ToDouble(txt_pdamage_attacktype.Text);
            ability.ATK_percent = Convert.ToDouble(txt_atk_percent.Text);

            ability.def_ignore = Convert.ToDouble(txt_def_ignore.Text);
            ability.element_increse = Convert.ToDouble(txt_element_increse.Text);
            ability.tribe_increse = Convert.ToDouble(txt_tribe_increse.Text);
            ability.size_increse = Convert.ToDouble(txt_size_increse.Text);
            ability.boss_increse = Convert.ToDouble(txt_boss_increse.Text);

            Status status = new Status();
            status._base = Convert.ToInt32(txt_LvlBase.Text);
            status._str = Convert.ToInt32(txt_StrBase.Text) + Convert.ToInt32(txt_StrAdd.Text);
            status._dex = Convert.ToInt32(txt_DexBase.Text) + Convert.ToInt32(txt_DexAdd.Text);
            status._luk = Convert.ToInt32(txt_LukBase.Text) + Convert.ToInt32(txt_LukAdd.Text);

            MonsterDB mobDB = new MonsterDB();
            mobDB.defense = Convert.ToInt32(txt_monster_def.Text);

            ELEMENT_TYPE player_element = (ELEMENT_TYPE)cmb_player_element.SelectedIndex;
            ELEMENT_TYPE monster_element = (ELEMENT_TYPE)cmb_monster_element.SelectedIndex;
            AdvantageTable advantage_table = new AdvantageTable();
            double element_ratio = advantage_table.GetElementRatio(player_element, monster_element);


            Equations equ = new Equations(attack_type, status, ability, mobDB);
            equ.element_inc = element_ratio;
            equ.size_panelty = Convert.ToInt32(txt_weapon_size_panelty.Text);

            int calcStatusWinATK = (int)(equ.CalcStatusWinATK(CALC_STANDARD.NONE));
            string strRetCalc;
            strRetCalc = Convert.ToString(calcStatusWinATK);
            retCalc.Text = strRetCalc;
        }
        private void CalcSim_Click(object sender, RoutedEventArgs e)
        {
            CalcDamage();
            //CAlcIngameATK();
        }

        private void attack_type_Click(object sender, RoutedEventArgs e)
        {
            RadioButton source = e.Source as RadioButton;

            radio_attack_type.Tag = source.Tag;
        }

        private void Initialize_Value_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult ret = MessageBox.Show("스텟, 아이템 옵션 수치를 초기화하시겠습니까?", "value clear", MessageBoxButton.YesNo);
            if ( ret == MessageBoxResult.Yes)
                Initialize_value();
        }

        private void Initialize_value()
        {
            radio_attack_type.Tag = 0;

            txt_LvlBase.Text = "1";
            txt_StrBase.Text = "1";
            txt_StrAdd.Text = "0";
            txt_DexBase.Text = "1";
            txt_DexAdd.Text = "0";
            txt_LukBase.Text = "1";
            txt_LukAdd.Text = "0";

            txt_atk_weapon.Text = "100";
            txt_atk_equip.Text = "50";
            txt_atk_smelting.Text = "0";
            txt_atk_mastery.Text = "0";
            txt_pdamage_add.Text = "0";
            txt_def_ignore.Text = "0";
            txt_monster_def.Text = "0";
            txt_weapon_size_panelty.Text = "100";

            cmb_monster_element.Items.Clear();
            cmb_player_element.Items.Clear();
            foreach(KeyValuePair<ELEMENT_TYPE, string> element_items in element_dict)
            {
                cmb_player_element.Items.Add(element_items.Value);
                cmb_monster_element.Items.Add(element_items.Value);
            }
            cmb_player_element.SelectedIndex = 0;
            cmb_monster_element.SelectedIndex = 0;

            txt_pdamage_percent.Text = "0";
            txt_pdamage_attacktype.Text = "0";
            txt_atk_percent.Text = "0";
            txt_element_increse.Text = "0";
            txt_tribe_increse.Text = "0";
            txt_size_increse.Text = "0";
            txt_boss_increse.Text = "0";
            txt_skill_percent.Text = "100";
            txt_skill_add_percent.Text = "0";
        }

        private void Initialize_value_test()
        {
            radio_attack_type.Tag = 0;

            txt_sATK.Text = "1392";
            txt_LvlBase.Text = "79";
            txt_StrBase.Text = "99";
            txt_StrAdd.Text = "59";
            txt_DexBase.Text = "11";
            txt_DexAdd.Text = "25";
            txt_LukBase.Text = "1";
            txt_LukAdd.Text = "9";

            txt_atk_weapon.Text = "338";
            txt_atk_equip.Text = "346";
            txt_atk_smelting.Text = "249";
            txt_atk_mastery.Text = "60";
            txt_pdamage_add.Text = "116";
            txt_def_ignore.Text = "0";
            txt_monster_def.Text = "52";
            txt_weapon_size_panelty.Text = "100";

            cmb_monster_element.Items.Clear();
            cmb_player_element.Items.Clear();
            foreach (KeyValuePair<ELEMENT_TYPE, string> element_items in element_dict)
            {
                cmb_player_element.Items.Add(element_items.Value);
                cmb_monster_element.Items.Add(element_items.Value);
            }
            cmb_player_element.SelectedIndex = (int)ELEMENT_TYPE.NORMAL;
            cmb_monster_element.SelectedIndex = (int)ELEMENT_TYPE.NORMAL;

            txt_pdamage_percent.Text = "13.75";
            txt_pdamage_attacktype.Text = "0";
            txt_atk_percent.Text = "18.62";
            txt_element_increse.Text = "20";
            txt_tribe_increse.Text = "26";
            txt_size_increse.Text = "0";
            txt_boss_increse.Text = "0";
            txt_skill_percent.Text = "100";
            txt_skill_add_percent.Text = "0";
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

        private void ATK_ReverseClick(object sender, RoutedEventArgs e)
        {
            int attack_type = Convert.ToInt32(radio_attack_type.Tag);

            ItemAbility ability = new ItemAbility();

            ability.ATK_weapon = Convert.ToInt32(txt_atk_weapon.Text);
            ability.ATK_equipment = Convert.ToInt32(txt_atk_equip.Text);
            ability.ATK_smelting = Convert.ToInt32(txt_atk_smelting.Text);
            ability.ATK_mastery = Convert.ToInt32(txt_atk_mastery.Text);

            ability.PDamage_percent = Convert.ToDouble(txt_pdamage_percent.Text);
            ability.PDamage_addition = Convert.ToInt32(txt_pdamage_add.Text);
            ability.PDamage_attack_type = Convert.ToDouble(txt_pdamage_attacktype.Text);
            ability.ATK_percent = Convert.ToDouble(txt_atk_percent.Text);

            ability.def_ignore = Convert.ToDouble(txt_def_ignore.Text);
            ability.element_increse = Convert.ToDouble(txt_element_increse.Text);
            ability.tribe_increse = Convert.ToDouble(txt_tribe_increse.Text);
            ability.size_increse = Convert.ToDouble(txt_size_increse.Text);
            ability.boss_increse = Convert.ToDouble(txt_boss_increse.Text);

            Status status = new Status();
            status._base = Convert.ToInt32(txt_LvlBase.Text);
            status._str = Convert.ToInt32(txt_StrBase.Text) + Convert.ToInt32(txt_StrAdd.Text);
            status._dex = Convert.ToInt32(txt_DexBase.Text) + Convert.ToInt32(txt_DexAdd.Text);
            status._luk = Convert.ToInt32(txt_LukBase.Text) + Convert.ToInt32(txt_LukAdd.Text);

            MonsterDB mobDB = new MonsterDB();
            mobDB.defense = Convert.ToInt32(txt_monster_def.Text);

            ELEMENT_TYPE player_element = (ELEMENT_TYPE)cmb_player_element.SelectedIndex;
            ELEMENT_TYPE monster_element = (ELEMENT_TYPE)cmb_monster_element.SelectedIndex;
            AdvantageTable advantage_table = new AdvantageTable();
            double element_ratio = advantage_table.GetElementRatio(player_element, monster_element);


            Equations equ = new Equations(attack_type, status, ability, mobDB);
            equ.element_inc = element_ratio;
            equ.size_panelty = Convert.ToInt32(txt_weapon_size_panelty.Text);

            txt_atk_equip.Text = Convert.ToString(equ.CalcReverseATK(Convert.ToInt32(txt_sATK.Text)));
        }
    }
}
