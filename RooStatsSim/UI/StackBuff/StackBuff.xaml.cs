using System.Windows;
using System.Collections.Generic;
using RooStatsSim.User;
using System.Windows.Data;
using System.ComponentModel;
using System;
using System.Linq;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace RooStatsSim.UI.StackBuff
{
    /// <summary>
    /// StackBuff.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class StackBuff : Window, INotifyPropertyChanged
    {
        UserData _user_data;
        RidingList BindingRidingAbility;
        RidingList BindingRidingPersonality;
        MedalList BindingMedalPoint;
        public StackBuff()
        {
            _user_data = UserData.GetInstance;

            InitializeComponent();
            DataContext = this;

            BindingRidingAbility = new RidingList(ref _user_data.Riding_ability);
            RidingAbility.ItemsSource = BindingRidingAbility;
            BindingRidingPersonality = new RidingList(ref _user_data.Riding_personality);
            RidingPersonality.ItemsSource = BindingRidingPersonality;
            BindingMedalPoint = new MedalList(ref _user_data);
            MedalPoint.ItemsSource = BindingMedalPoint;
        }

        public int Monster_Research
        {
            get { return _user_data.Monster_Research.Level; }
            set {
                _user_data.Monster_Research.Level = value;
                OnPropertyChanged("Monster_Research");
            }
        }
        public int Dress_Style
        {
            get { return _user_data.Dress_Style.Level; }
            set
            {
                _user_data.Dress_Style.Level = value;
                OnPropertyChanged("Dress_Style");
            }
        }
        public int Sticker
        {
            get { return _user_data.Sticker.Level; }
            set
            {
                _user_data.Sticker.Level = value;
                OnPropertyChanged("Sticker");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        //public override string ToString() => _name;

        protected void OnPropertyChanged(string info)
        {
            var handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(info));
        }

        #region UI reaction function
        private void Monster_Research_Up_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Monster_Research++;
        }
        private void Monster_Research_Down_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Monster_Research--;
        }
        private void Monster_Research_MouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
        {
            if (e.Delta < 0)
                Monster_Research--;
            else
                Monster_Research++;
        }

        private void Dress_Up_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Dress_Style++;
        }
        private void Dress_Down_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Dress_Style--;
        }
        private void Dress_MouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
        {
            if (e.Delta < 0)
                Dress_Style--;
            else
                Dress_Style++;
        }

        private void Sticker_Up_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Sticker++;
        }
        private void Sticker_Down_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Sticker--;
        }
        private void Sticker_MouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
        {
            if (e.Delta < 0)
                Sticker--;
            else
                Sticker++;
        }

        private void Medal_Up_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var tb = sender as StackPanel;
            AbilityBinding dataCxtx = tb.DataContext as AbilityBinding;
            MedalPointChange(dataCxtx, 1);
        }
        private void Medal_Down_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var tb = sender as StackPanel;
            AbilityBinding dataCxtx = tb.DataContext as AbilityBinding;
            MedalPointChange(dataCxtx, -1);
        }
        private void Medal_MouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
        {
            var tb = sender as StackPanel;
            AbilityBinding dataCxtx = tb.DataContext as AbilityBinding;
            
            if (e.Delta < 0)
                MedalPointChange(dataCxtx, -1);
            else
                MedalPointChange(dataCxtx, +1);
        }
        private void Riding_Abaility_Up_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var tb = sender as StackPanel;
            AbilityBinding dataCxtx = tb.DataContext as AbilityBinding;
            RidingPointChange(ref _user_data.Riding_ability, ref BindingRidingAbility, dataCxtx, 1);
        }
        private void Riding_Abaility_Down_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var tb = sender as StackPanel;
            AbilityBinding dataCxtx = tb.DataContext as AbilityBinding;
            RidingPointChange(ref _user_data.Riding_ability, ref BindingRidingAbility, dataCxtx, -1);
        }
        private void Riding_Abaility_MouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
        {
            var tb = sender as StackPanel;
            AbilityBinding dataCxtx = tb.DataContext as AbilityBinding;

            if (e.Delta < 0)
                RidingPointChange(ref _user_data.Riding_ability, ref BindingRidingAbility, dataCxtx, -1);
            else
                RidingPointChange(ref _user_data.Riding_ability, ref BindingRidingAbility, dataCxtx, 1);
        }

        private void Riding_Personality_Up_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var tb = sender as StackPanel;
            AbilityBinding dataCxtx = tb.DataContext as AbilityBinding;
            RidingPointChange(ref _user_data.Riding_personality, ref BindingRidingPersonality, dataCxtx, 1);
        }
        private void Riding_Personality_Down_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var tb = sender as StackPanel;
            AbilityBinding dataCxtx = tb.DataContext as AbilityBinding;
            RidingPointChange(ref _user_data.Riding_personality, ref BindingRidingPersonality, dataCxtx, -1);
        }
        private void Riding_Personality_MouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
        {
            var tb = sender as StackPanel;
            AbilityBinding dataCxtx = tb.DataContext as AbilityBinding;

            if (e.Delta < 0)
                RidingPointChange(ref _user_data.Riding_personality, ref BindingRidingPersonality, dataCxtx, -1);
            else
                RidingPointChange(ref _user_data.Riding_personality, ref BindingRidingPersonality, dataCxtx, 1);
        }
        #endregion

        void MedalPointChange(AbilityBinding dataCxtx, int changingPoint)
        {
            MEDAL_ENUM_KOR medalName = (MEDAL_ENUM_KOR)Enum.Parse(typeof(MEDAL_ENUM_KOR), dataCxtx.Name);
            
            _user_data.Medal[(int)medalName] += changingPoint;
            BindingMedalPoint[(int)medalName].Point = _user_data.Medal[(int)medalName];
        }

        void RidingPointChange(ref RIDING riding, ref RidingList bindingList, AbilityBinding dataCxtx, int changingPoint)
        {
            RIDING_ENUM ridingName = (RIDING_ENUM)Enum.Parse(typeof(RIDING_ENUM), dataCxtx.EnumName);
            
            riding[(int)ridingName] += changingPoint;
            bindingList[(int)ridingName].Point = riding[(int)ridingName];
        }

    }
}
