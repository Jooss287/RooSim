using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;

using RooStatsSim.User;

namespace RooStatsSim.UI.SkillWindow
{
    class SkillWindowBinding : ObservableCollection<SkillBindingInfo>
    {
        public SkillWindowBinding() { }

        public SkillWindowBinding(UserSkill user_skill)
        {
            foreach(UserSkill.UserSkillInfo skill in user_skill.List)
            {
                
            }
        }
    }

    class SkillBindingInfo : INotifyPropertyChanged
    {
        public SkillBindingInfo(UserSkill.UserSkillInfo info)
        {
            Name = info.Name;
            Level = info.Level;
        }

        string _name;
        int _level;
        UserSkill.UserSkillInfo _skill_info;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        public int Level
        {
            get { return _level; }
            set
            {
                _level = value;
                OnPropertyChanged("Level");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public override string ToString() => _name;

        protected void OnPropertyChanged(string info)
        {
            var handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(info));
        }
    }
}
