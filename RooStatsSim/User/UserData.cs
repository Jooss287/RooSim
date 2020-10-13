﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using RooStatsSim.DB;

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

        public LEVEL Level = new LEVEL();
        public STATUS Status = new STATUS();
        public MEDAL Medal = new MEDAL();
        public MONSTER_RESEARCH Monster_Research = new MONSTER_RESEARCH();
        public DRESS_STYLE Dress_Style = new DRESS_STYLE();
        public STICKER Sticker = new STICKER();
        public RIDING Riding_ability = new RIDING();
        public RIDING Riding_personality = new RIDING();

        public UserItem User_Item = new UserItem();

        #region Userdata event
        public delegate void UserDataChangedEventHandler();
        public event UserDataChangedEventHandler dataChanged;

        public void CalcUserData()
        {
            UserItem CalcUserItem = new UserItem();

            CalcUserItem += Monster_Research.GetOption();
            CalcUserItem += Dress_Style.GetOption();
            CalcUserItem += Sticker.GetOption();

            User_Item = CalcUserItem;

            if (dataChanged != null)
                dataChanged();
        }
        #endregion
    }
}
