using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RooStatsSim.Skills
{
    class SkillCheckBox : INotifyPropertyChanged
    {
        string _name;
        string _nameEng;
        int _cnt;

        public SkillCheckBox(string name, int cnt)
        {
            _name = name;
            _cnt = cnt;
        }

        public string SkillNameEng
        {
            get { return _nameEng;}
            set
            {
                _nameEng = value;
                OnPropertyChanged("SkillNameEng");
            }
        }
        public string SkillName
        {
            get { return _name; }
            set {
                _name = value;
                OnPropertyChanged("SkillName");
            }
        }
        public string SkillListCnt
        {
            get { return Convert.ToString(_cnt); }
            set { 
                _cnt = Convert.ToInt32(value); 
                OnPropertyChanged("SkillListCnt");
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
