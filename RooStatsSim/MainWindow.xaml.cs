using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

using RooStatsSim.DB;
using RooStatsSim.DB.Table;
using RooStatsSim.Equation.Job;
using RooStatsSim.Skills;
using RooStatsSim.UI.Status;
using RooStatsSim.UI.Manager;
using RooStatsSim.UI.ACK;
using RooStatsSim.User;
using RooStatsSim.UI.StackBuff;
using RooStatsSim.UI.Equipment;

namespace RooStatsSim
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        DBManager _db_manager = new DBManager();
        StatusWindow _status = new StatusWindow();
        ProgramInfo _info = new ProgramInfo();
        StackBuff _stacK_buff = new StackBuff();
        EquipWindow _equip = new EquipWindow();

        public MainWindow()
        {
            //Version Check

            InitializeComponent();

            _user_data = UserData.GetInstance;

            Initialize_value();
            Initialize_value_test();
            //Initialize_value_marduk();

            job_UI_setting((int)(JOB_LIST.LOAD_KNIGHT));

            //DB생성, Window open 등

            _status.Show();
            _stacK_buff.Show();
            _equip.Show();
            
        }

        #region Initialize

        private void Initialize_value()
        {
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
            foreach (KeyValuePair<ELEMENT_TYPE, string> element_items in element_dict)
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
            txt_atk_weapon.Text = "338";
            txt_atk_equip.Text = "346";
            txt_atk_smelting.Text = "249";
            txt_atk_mastery.Text = "60";
            txt_pdamage_add.Text = "116";
            txt_def_ignore.Text = "0";
            txt_monster_def.Text = "21";
            txt_weapon_size_panelty.Text = "75";

            cmb_monster_element.Items.Clear();
            cmb_player_element.Items.Clear();
            foreach (KeyValuePair<ELEMENT_TYPE, string> element_items in element_dict)
            {
                cmb_player_element.Items.Add(element_items.Value);
                cmb_monster_element.Items.Add(element_items.Value);
            }
            cmb_player_element.SelectedIndex = (int)ELEMENT_TYPE.WATER;
            cmb_monster_element.SelectedIndex = (int)ELEMENT_TYPE.FIRE;

            txt_pdamage_percent.Text = "14.00";
            txt_pdamage_attacktype.Text = "0";
            txt_atk_percent.Text = "18.62";
            txt_element_increse.Text = "0";
            txt_tribe_increse.Text = "0";
            txt_size_increse.Text = "0";
            txt_boss_increse.Text = "0";
            txt_skill_percent.Text = "100";
            txt_skill_add_percent.Text = "0";
        }
        private void Initialize_value_marduk()
        {
            txt_sATK.Text = "1387";

            txt_atk_weapon.Text = "338";
            txt_atk_equip.Text = "346";
            txt_atk_smelting.Text = "249";
            txt_atk_mastery.Text = "60";
            txt_pdamage_add.Text = "116";
            txt_def_ignore.Text = "0";
            txt_monster_def.Text = "66";
            txt_weapon_size_panelty.Text = "100";

            cmb_monster_element.Items.Clear();
            cmb_player_element.Items.Clear();
            foreach (KeyValuePair<ELEMENT_TYPE, string> element_items in element_dict)
            {
                cmb_player_element.Items.Add(element_items.Value);
                cmb_monster_element.Items.Add(element_items.Value);
            }
            cmb_player_element.SelectedIndex = (int)ELEMENT_TYPE.WATER;
            cmb_monster_element.SelectedIndex = (int)ELEMENT_TYPE.FIRE;

            txt_pdamage_percent.Text = "13.75";
            txt_pdamage_attacktype.Text = "0";
            txt_atk_percent.Text = "18.62";
            txt_element_increse.Text = "0";
            txt_tribe_increse.Text = "0";
            txt_size_increse.Text = "0";
            txt_boss_increse.Text = "0";
            txt_skill_percent.Text = "100";
            txt_skill_add_percent.Text = "0";
        }
        #endregion

        #region UI Variable Define
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


        ItemAbility ability;
        //Status status;
        UserData _user_data;
        MonsterDB mobDB;
        AdvantageTable advantage_table;
        JobSelect job_selection = new JobSelect();
        int job_select = (int)(JOB_LIST.LOAD_KNIGHT);
        double element_ratio;
        double size_panelty;
        bool[] BuffList;
        #endregion

        #region UI Setting
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
        private void job_UI_setting(int param_job_select)
        {
            List<SkillInfo> skillNames = job_selection.GetSkillCnt(job_select);
            BuffList = new bool[skillNames.Count];

            if (SkillListBox != null)
                SkillListBox.ItemsSource = new SkillAdd(skillNames);
        }

        private void job_sel_Click(object sender, RoutedEventArgs e)
        {
            RadioButton source = e.Source as RadioButton;
            job_select = Convert.ToInt32(source.Tag);
            
            job_selection.JobSelectNum = (JOB_LIST)job_select;
            job_UI_setting(job_select);   
        }

        private void Initialize_Value_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult ret = MessageBox.Show("스텟, 아이템 옵션 수치를 초기화하시겠습니까?", "value clear", MessageBoxButton.YesNo);
            if (ret == MessageBoxResult.Yes)
                Initialize_value();
        }
        #endregion


        private void InputUIData()
        {
            ability = new ItemAbility()
            {
                ATK_weapon = Convert.ToInt32(txt_atk_weapon.Text),
                ATK_equipment = Convert.ToInt32(txt_atk_equip.Text),
                ATK_smelting = Convert.ToInt32(txt_atk_smelting.Text),
                ATK_mastery = Convert.ToInt32(txt_atk_mastery.Text),

                PDamage_percent = 1 + 0.01 * Convert.ToDouble(txt_pdamage_percent.Text),
                PDamage_addition = Convert.ToInt32(txt_pdamage_add.Text),
                PDamage_attack_type = 1 + 0.01 * Convert.ToDouble(txt_pdamage_attacktype.Text),
                ATK_percent = 1 + 0.01 * Convert.ToDouble(txt_atk_percent.Text),

                def_ignore = 0.01 * Convert.ToDouble(txt_def_ignore.Text),
                element_increse = 1 + 0.01 * Convert.ToDouble(txt_element_increse.Text),
                tribe_increse = 1 + 0.01 * Convert.ToDouble(txt_tribe_increse.Text),
                size_increse = 1 + 0.01 * Convert.ToDouble(txt_size_increse.Text),
                boss_increse = 1 + 0.01 * Convert.ToDouble(txt_boss_increse.Text),
            };

            mobDB = new MonsterDB()
            {
                Def = Convert.ToInt32(txt_monster_def.Text),
            };

            ELEMENT_TYPE player_element = (ELEMENT_TYPE)cmb_player_element.SelectedIndex;
            ELEMENT_TYPE monster_element = (ELEMENT_TYPE)cmb_monster_element.SelectedIndex;
            advantage_table = new AdvantageTable();
            element_ratio = 1 + advantage_table.GetElementRatio(player_element, monster_element);
            size_panelty = 0.01 * Convert.ToInt32(txt_weapon_size_panelty.Text);

            job_selection.SetDB(ref ability, ref mobDB, ref element_ratio, ref size_panelty, ref BuffList);
        }

        private void ATK_ReverseClick(object sender, RoutedEventArgs e)
        {
            InputUIData();

            txt_atk_equip.Text = Convert.ToString(job_selection.GetReverseATK(Convert.ToInt32(txt_sATK.Text)));
        }
        private void CalcSim_Click(object sender, RoutedEventArgs e)
        {
            InputUIData();

            double skill_damage = (Convert.ToInt32(txt_skill_percent.Text) + Convert.ToInt32(txt_skill_add_percent.Text)) * 0.01;
            int calcATK_min = Convert.ToInt32(Math.Floor(job_selection.GetMinATK() * skill_damage));
            int calcATK_max = Convert.ToInt32(Math.Floor(job_selection.GetMaxATK() * skill_damage));

            retCalc.Text = Convert.ToString(calcATK_min) + " ~ " + Convert.ToString(calcATK_max);
            txt_sATK.Text = Convert.ToString(job_selection.GetWinATK());
        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            BuffList[Convert.ToInt32(((e.Source as CheckBox).Tag))] = (bool)((e.Source as CheckBox).IsChecked);

            MessageBox.Show(Convert.ToString((e.Source as CheckBox).IsChecked));
        }

        private void Status_window_Click(object sender, RoutedEventArgs e)
        {
            if (_status.IsVisible)
                _status.Hide();
            else
                _status.Show();
        }

        private void DBManager_window_Click(object sender, RoutedEventArgs e)
        {
            if (_db_manager.IsVisible)
                _db_manager.Hide();
            else
                _db_manager.Show();
        }

        private void Info_window_Click(object sender, RoutedEventArgs e)
        {
            if (_info.IsVisible)
                _info.Hide();
            else
                _info.Show();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _status.Close();
            _info.Close();
            _db_manager.Close();
        }

        private void StackBuff_window_Click(object sender, RoutedEventArgs e)
        {
            if (_stacK_buff.IsVisible)
                _stacK_buff.Hide();
            else
                _stacK_buff.Show();
        }

        private void Skill_window_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Equip_window_Click(object sender, RoutedEventArgs e)
        {
            if (_equip.IsVisible)
                _equip.Hide();
            else
                _equip.Show();
        }
    }
}
