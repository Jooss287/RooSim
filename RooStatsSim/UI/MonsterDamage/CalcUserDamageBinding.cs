using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RooStatsSim.UI.MonsterDamage
{
    class CalcUserDamageBinding : ObservableCollection<CalcUserDamageBinding_Ability>
    {
        public CalcUserDamageBinding()
        {
            Add(new CalcUserDamageBinding_Ability("평타", "0 ~ 0"));
        }
        public CalcUserDamageBinding(string name, string damage)
        {
            Add(new CalcUserDamageBinding_Ability(name, damage));
        }
        //public CalcUserDamageBinding(ref UserData param_status)
        //{
        //    foreach (STATUS_ENUM status in Enum.GetValues(typeof(STATUS_ENUM)))
        //    {
        //        string statusName = Enum.GetName(typeof(STATUS_ENUM), status);
        //        Add(new AbilityBinding<int>(statusName, param_status.Status.List[(int)status].Point, param_status.User_Item.i_option[(ITYPE)status], statusName));
        //    }
        //}
        public void AddDamageBinding(string name, string damage)
        {
            Add(new CalcUserDamageBinding_Ability(name, damage));
        }
    }

    class CalcUserDamageBinding_Ability : INotifyPropertyChanged
    {
        string _skill_name;
        string _damage_range;
        public CalcUserDamageBinding_Ability(string skill_name, string damage_range)
        {
            SkillName = skill_name;
            DamageRange = damage_range;
        }

        public string SkillName
        {
            get { return _skill_name; }
            set { _skill_name = value; OnPropertyChanged("SkillName"); }
        }
        public string DamageRange
        {
            get { return _damage_range; }
            set { _damage_range = value; OnPropertyChanged("DamageRange"); }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public override string ToString() => _skill_name;

        protected void OnPropertyChanged(string info)
        {
            var handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(info));
        }
    }
}
