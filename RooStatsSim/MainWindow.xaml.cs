using System;
using System.Windows;
using System.IO;
using System.Collections.Generic;

using RooStatsSim.DB;
using RooStatsSim.User;
using RooStatsSim.UI.StatusWindow;
using RooStatsSim.UI.Manager;
using RooStatsSim.UI.ACK;
using RooStatsSim.UI.StackBuff;
using RooStatsSim.UI.Equipment;
using RooStatsSim.UI.Menu;
using RooStatsSim.UI.MonsterDamage;
using RooStatsSim.UI.SkillWindow;
using RooStatsSim.UI.ConsumableBuff;
using RooStatsSim.Extension;
using MDIXWindow;
using WPF.MDI;

namespace RooStatsSim
{
    public enum WINDOW_ENUM
    {
        MENU,
        STATUS,
        STACK_BUFF,
        EQUIP,
        DAMAGE_CHECK,
        SKILL,
        CONSUMABLE_BUFF,
    };
    public partial class MainWindow : Window
    {
        public static DBlist _roo_db;
        public static UserDataManager _user_data_manager;

        MdiChild _menu;
        MdiChild _status;
        MdiChild _stack_buff;
        MdiChild _equip;
        MdiChild _damage_check;
        MdiChild _skill;
        MdiChild _consumable_buff;

        public ProgramInfo _info;
        public DBManager _db_manager;

        public MainWindow()
        {
            Version();
            CreateFolder();

            _roo_db = new DBlist();
            DBSerializer.ReadDB(ref _roo_db);
            _user_data_manager = new UserDataManager();

            MaterialDesignWindow.RegisterCommands(this);
            InitializeComponent();

            InitializeMDI();
        }

        #region Initialize
        private void InitializeMDI()
        {
            if (Properties.Settings.Default.setting_window_pos == null)
            {
                Properties.Settings.Default.setting_window_pos = new List<Point>()
                {
                    new Point(0,0),
                    new Point(0,138),
                    new Point(1204, 0),
                    new Point(0, 490),
                    new Point(885, 490),
                    new Point(700, 0),
                };
            }
            if (Properties.Settings.Default.setting_window_W_H == null)
            {
                Properties.Settings.Default.setting_window_W_H = new List<Point>()
                {
                    new Point(698, 139),
                    new Point(1203, 352),
                    new Point(415, 415),
                    new Point(886, 378),
                    new Point(728, 258),
                    new Point(728, 258),
                };
            }

            _menu = new MdiChild()
            {
                Title = "MenuBox",
                Content = new MenuBox(this),
                Width = Properties.Settings.Default.setting_window_W_H[(int)WINDOW_ENUM.MENU].X,
                Height = Properties.Settings.Default.setting_window_W_H[(int)WINDOW_ENUM.MENU].Y,
                Position = new Point(Properties.Settings.Default.setting_window_pos[(int)WINDOW_ENUM.MENU].X,
                                    Properties.Settings.Default.setting_window_pos[(int)WINDOW_ENUM.MENU].Y),
                CloseBox = false,
            };
            _status = new MdiChild()
            {
                Title = "스테이터스",
                Content = new StatusWindow(),
                Width = Properties.Settings.Default.setting_window_W_H[(int)WINDOW_ENUM.STATUS].X,
                Height = Properties.Settings.Default.setting_window_W_H[(int)WINDOW_ENUM.STATUS].Y,
                Position = new Point(Properties.Settings.Default.setting_window_pos[(int)WINDOW_ENUM.STATUS].X,
                                    Properties.Settings.Default.setting_window_pos[(int)WINDOW_ENUM.STATUS].Y),
                CloseBox = false,
            };
            _stack_buff = new MdiChild()
            {
                Title = "StackBuff",
                Content = new StackBuffWindow(),
                Width = Properties.Settings.Default.setting_window_W_H[(int)WINDOW_ENUM.STACK_BUFF].X,
                Height = Properties.Settings.Default.setting_window_W_H[(int)WINDOW_ENUM.STACK_BUFF].Y, //284 257 14 38
                Position = new Point(Properties.Settings.Default.setting_window_pos[(int)WINDOW_ENUM.STACK_BUFF].X,
                                    Properties.Settings.Default.setting_window_pos[(int)WINDOW_ENUM.STACK_BUFF].Y),
                CloseBox = false,
            };
            _equip = new MdiChild()
            {
                Title = "장비창",
                Content = new Equip(),
                Width = Properties.Settings.Default.setting_window_W_H[(int)WINDOW_ENUM.EQUIP].X,
                Height = Properties.Settings.Default.setting_window_W_H[(int)WINDOW_ENUM.EQUIP].Y,
                Position = new Point(Properties.Settings.Default.setting_window_pos[(int)WINDOW_ENUM.EQUIP].X,
                                    Properties.Settings.Default.setting_window_pos[(int)WINDOW_ENUM.EQUIP].Y),
                CloseBox = false,
            };
            _damage_check = new MdiChild()
            {
                Title = "데미지 계산기",
                Content = new MonsterDamageCheck(),
                Width = Properties.Settings.Default.setting_window_W_H[(int)WINDOW_ENUM.DAMAGE_CHECK].X,
                Height = Properties.Settings.Default.setting_window_W_H[(int)WINDOW_ENUM.DAMAGE_CHECK].Y,
                Position = new Point(Properties.Settings.Default.setting_window_pos[(int)WINDOW_ENUM.DAMAGE_CHECK].X,
                                    Properties.Settings.Default.setting_window_pos[(int)WINDOW_ENUM.DAMAGE_CHECK].Y),
                CloseBox = false,
            };
            _skill = new MdiChild()
            {
                Title = "스킬",
                Content = new SkillWindow(),
                Width = Properties.Settings.Default.setting_window_W_H[(int)WINDOW_ENUM.SKILL].X,
                Height = Properties.Settings.Default.setting_window_W_H[(int)WINDOW_ENUM.SKILL].Y,
                Position = new Point(Properties.Settings.Default.setting_window_pos[(int)WINDOW_ENUM.SKILL].X,
                                    Properties.Settings.Default.setting_window_pos[(int)WINDOW_ENUM.SKILL].Y),
                CloseBox = false,
            };
            _consumable_buff = new MdiChild()
            {
                Title = "소모성 버프아이템",
                Content = new ConsumableBuffWindow(),
                Width = 728,
                Height = 258,   //132
                Position = new Point(700, 0),
                CloseBox = false,
            };

            RoosimContainer.Children.Add(_menu);
            RoosimContainer.Children.Add(_status);
            RoosimContainer.Children.Add(_stack_buff);
            RoosimContainer.Children.Add(_equip);
            RoosimContainer.Children.Add(_damage_check);
            RoosimContainer.Children.Add(_skill);
            RoosimContainer.Children.Add(_consumable_buff);
        }
        private void CreateFolder()
        {
            var path = Path.Combine(Environment.CurrentDirectory, "Img");
            ResourceExtension.CreateFolder(path);
            path = Path.Combine(Environment.CurrentDirectory, "user");
            ResourceExtension.CreateFolder(path);
        }
        #endregion
        #region UI Callback
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _user_data_manager.CheckUserDataChanged();
            SavedWindowPos();
        }
        private void Version()
        {
            if (ProgramInfo.IsLastestVer())
                return;

            MessageBoxResult MsgRes = MessageBox.Show("최신 버전이 아닙니다.최신 버전을 다운받으시겠습니까?", "VersionCheck", MessageBoxButton.YesNo);
            if (MsgRes == MessageBoxResult.Yes)
            {
                System.Diagnostics.Process.Start(ProgramInfo.GetLeastURL());
                this.Close();
            }
        }
        private void SavedWindowPos()
        {
            Properties.Settings.Default.setting_window_pos.Clear();
            Properties.Settings.Default.setting_window_W_H.Clear();
            foreach (MdiChild mdi in RoosimContainer.Children)
            {
                Properties.Settings.Default.setting_window_pos.Add(new Point(mdi.Position.X, mdi.Position.Y));
                Properties.Settings.Default.setting_window_W_H.Add(new Point(mdi.Width, mdi.Height));
            }
            Properties.Settings.Default.Save();
        }
        #endregion
    }
}
