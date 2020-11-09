using RooStatsSim.DB;
using RooStatsSim.Equation;
using System.Diagnostics;

namespace RooStatsSim.User
{
    // User data singleton design pattern
    public sealed class UserData
    {
        #region Single Pattern
        private UserData() { }
        private static UserData _instance = null;
        public static UserData GetInstance
        {
            get
            {
                if (_instance == null)
                { 
                    _instance = new UserData();
                }
                return _instance;
            }
        }
        #endregion

        public BASE_LEVEL Base_Level = new BASE_LEVEL();
        public JOB_LEVEL Job_Level = new JOB_LEVEL();
        public STATUS Status = new STATUS();
        public JOB_SELECT_LIST Job = JOB_SELECT_LIST.KNIGHT;

        public EQUIP Equip = new EQUIP();
        public GEAR Gear = new GEAR();

        public MEDAL Medal = new MEDAL();
        public MONSTER_RESEARCH Monster_Research = new MONSTER_RESEARCH();
        public DRESS_STYLE Dress_Style = new DRESS_STYLE();
        public STICKER Sticker = new STICKER();
        public RIDING Riding_ability = new RIDING();
        public RIDING Riding_personality = new RIDING();
        

        public UserItem User_Item = new UserItem();

        #region Userdata event
        public delegate void UserDataChangedEventHandler();
        public event UserDataChangedEventHandler itemDataChanged;
        //public event UserDataChangedEventHandler StatusDataChanged;

        public void CalcUserData()
        {
            UserItem CalcUserItem = new UserItem();

            CalcUserItem.i_option[ITYPE.STATUS_ATK] = StatusATK.GetStatusATK(Equation.Job.ATTACK_TYPE.MELEE_TYPE, this);

            CalcUserItem += Monster_Research.GetOption();
            CalcUserItem += Dress_Style.GetOption();
            CalcUserItem += Sticker.GetOption();
            CalcUserItem += Medal.GetOption();
            CalcUserItem += Riding_ability.GetOption();
            CalcUserItem += Riding_personality.GetOption();

            CalcUserItem += Equip.GetOption();

            User_Item = CalcUserItem;

            if (itemDataChanged != null)
                itemDataChanged();
        }
        #endregion
    }
}
