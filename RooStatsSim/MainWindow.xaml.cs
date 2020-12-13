using System;
using System.Windows;
using System.IO;

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
        ADDITIONAL_BUFF,
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
            _menu = new MdiChild()
            {
                Title = "MenuBox",
                Content = new MenuBox(this),
                Width = 698,
                Height = 139,
                Position = new Point(0, 0),
                CloseBox = false,
            };
            _status = new MdiChild()
            {
                Title = "스테이터스",
                Content = new StatusWindow(),
                Width = 1203,
                Height = 352,
                Position = new Point(0, 138),
                CloseBox = false,
            };
            _stack_buff = new MdiChild()
            {
                Title = "StackBuff",
                Content = new StackBuffWindow(),
                Width = 415,    //284 257 14 38
                Height = 415,
                Position = new Point(1204, 0),
                CloseBox = false,
            };
            _equip = new MdiChild()
            {
                Title = "장비창",
                Content = new Equip(),
                Width = 886,
                Height = 378,
                Position = new Point(0, 490),
                CloseBox = false,
            };
            _damage_check = new MdiChild()
            {
                Title = "데미지 계산기",
                Content = new MonsterDamageCheck(),
                Width = 728,
                Height = 258,
                Position = new Point(885, 490),
                CloseBox = false,
            };
            _skill = new MdiChild()
            {
                Title = "스킬",
                Content = new SkillWindow(),
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
        #endregion
    }
}
