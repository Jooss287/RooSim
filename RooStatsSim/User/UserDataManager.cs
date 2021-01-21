using RooStatsSim.DB.Table;
using RooStatsSim.Equation;
using RooStatsSim.Equation.Job;
using System;
using System.Collections.Generic;
using System.Windows;

namespace RooStatsSim.User
{
    public class UserDataManager
    {
        private Dictionary<int, UserData> _dic_user_data = new Dictionary<int, UserData>();
        private int _data_number;
        public UserData Data { set; get; }

        public bool _user_data_edited = false;
        public int SavePointNumber 
        { 
            set { _data_number = value; Data = _dic_user_data[_data_number]; }
            get { return _data_number; }
        }
        
        public UserDataManager() {}

        public void SetUserData(int number)
        {
            CheckUserDataChanged();
            if (!_dic_user_data.ContainsKey(number))
            {
                UserData user = new UserData();
                User_Serializer.ReadDB(ref user, number);
                _dic_user_data.Add(number, user);
            }
            SavePointNumber = number;

            JobChanged(_dic_user_data[number].Job);
            //JobDataChanged?.Invoke();
            CalcUserData(_user_data_edited);
        }
        public void CheckUserDataChanged()
        {
            if (_user_data_edited)
            {
                MessageBoxResult res = MessageBox.Show("변경사항이 있습니다. 변경하시겠습니까?", "Save", MessageBoxButton.YesNo);
                if (res == MessageBoxResult.Yes)
                    User_Serializer.SaveDataBase(_dic_user_data[SavePointNumber], SavePointNumber);
                _user_data_edited = false;
            }
        }
        public UserData GetUserData()
        {
            return _dic_user_data[SavePointNumber];
        }
        #region Item Changed Event
        public delegate void UserDataChangedEventHandler();
        public event UserDataChangedEventHandler itemDataChanged;
        public void CalcUserData(bool _new_edit = true)
        {
            UserItem CalcUserItem = new UserItem(true);

            //직업별 추가 능력치
            CalcUserItem += Data.JobSelect.GetOption();
            CalcUserItem += Data.User_Skill.GetOption();
            //Stack Options
            CalcUserItem += Data.Monster_Research.GetOption();
            CalcUserItem += Data.Dress_Style.GetOption();
            CalcUserItem += Data.Sticker.GetOption();
            CalcUserItem += Data.Medal.GetOption();
            CalcUserItem += Data.Riding_ability.GetOption();
            CalcUserItem += Data.Riding_personality.GetOption();
            //소모품 버프
            CalcUserItem += Data.User_ConBuff.GetOption();
            //장비 옵션
            CalcUserItem += Data.Equip.GetOption();
            //스텟 옵션
            CalcUserItem.Option_ITYPE[Enum.GetName(typeof(ITYPE), ITYPE.STATUS_ATK)] = StatusATK.GetStatusATK(ATTACK_TYPE.MELEE_TYPE, Data);
            Data.Status.SetAddStatus(_dic_user_data[SavePointNumber].User_Item);
            //조건부 옵션 계산
            Data.User_Item.CalcIftypeValues(Data);

            Data.User_Item = CalcUserItem;
            itemDataChanged?.Invoke();
            _user_data_edited = _new_edit;
        }
        #endregion

        #region Job Changed Event
        public delegate void JobChangedEventHandler();
        public event JobChangedEventHandler JobDataChanged;
        public void JobChanged(JOB_SELECT_LIST job, bool initialize = false)
        {
            if (initialize)
                Data.Initializor();
            Data.Job = job;
            Data.JobSelect = new JobSelect(Data, job);

            // Job가 변경되면 설정되어야 할 것들

            JobDataChanged?.Invoke();
        }
        #endregion
    }
}
