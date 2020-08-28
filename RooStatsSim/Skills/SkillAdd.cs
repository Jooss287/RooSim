using RooStatsSim.Skills;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RooStatsSim.Skills
{
    class SkillAdd : ObservableCollection<SkillCheckBox>
    {
        public SkillAdd()
        {
            Add(new SkillCheckBox("컨센트레이션", 1));
            Add(new SkillCheckBox("오러블레이드", 2));
            Add(new SkillCheckBox("매그넘브레이크", 3));
        }
    }
}
