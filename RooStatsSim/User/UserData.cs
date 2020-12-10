using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using RooStatsSim.Extension;
using RooStatsSim.DB.Table;
using RooStatsSim.Equation;
using RooStatsSim.User;



namespace RooStatsSim.User
{
    [Serializable]
    public sealed class UserData
    {
        public UserData() { Initializor(); }

        public BASE_LEVEL Base_Level { get; set; }
        public JOB_LEVEL Job_Level { get; set; }
        public STATUS Status { get; set; }
        public JOB_SELECT_LIST Job { get; set; }

        public EQUIP Equip { get; set; }
        public GEAR Gear { get; set; }

        public MEDAL Medal { get; set; }
        public MONSTER_RESEARCH Monster_Research { get; set; }
        public DRESS_STYLE Dress_Style { get; set; }
        public STICKER Sticker { get; set; }
        public RIDING Riding_ability { get; set; }
        public RIDING Riding_personality { get; set; }
        

        public UserItem User_Item { get; set; }
        public int SelectedEnemy { get; set; }

        void Initializor()
        {
            Base_Level = new BASE_LEVEL();
            Job_Level = new JOB_LEVEL();
            Status = new STATUS();
            Job = JOB_SELECT_LIST.NOVICE;
            Equip = new EQUIP();
            Gear = new GEAR();
            Medal = new MEDAL();
            Monster_Research = new MONSTER_RESEARCH();
            Dress_Style = new DRESS_STYLE();
            Sticker = new STICKER();
            Riding_ability = new RIDING();
            Riding_personality = new RIDING();
            User_Item = new UserItem();
            SelectedEnemy = 0;
        }
        
        #region Userdata event
        public delegate void UserDataChangedEventHandler();
        public event UserDataChangedEventHandler itemDataChanged;

        
        public void CalcUserData()
        {
            UserItem CalcUserItem = new UserItem();

            //직업별 추가 능력치

            //Stack Options
            CalcUserItem += Monster_Research.GetOption();
            CalcUserItem += Dress_Style.GetOption();
            CalcUserItem += Sticker.GetOption();
            CalcUserItem += Medal.GetOption();
            CalcUserItem += Riding_ability.GetOption();
            CalcUserItem += Riding_personality.GetOption();
            //장비 옵션
            CalcUserItem += Equip.GetOption();
            //스텟 옵션
            CalcUserItem.Option_ITYPE[Enum.GetName(typeof(ITYPE), ITYPE.STATUS_ATK)] = StatusATK.GetStatusATK(ATTACK_TYPE.MELEE_TYPE, this);
            Status.SetAddStatus(User_Item);
            //조건부 옵션 계산
            User_Item.CalcIftypeValues(this);

            User_Item = CalcUserItem;
            if (itemDataChanged != null)
                itemDataChanged();
            MainWindow._user_data_edited = true;
        }
        #endregion
    }
}
