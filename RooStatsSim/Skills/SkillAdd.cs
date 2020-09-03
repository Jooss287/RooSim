using RooStatsSim.Equation.Job;
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
            LordKnight temp = new LordKnight();
            int cnt = 0;
            //Clear();
            foreach (SkillInfo skill in temp.skillinfo)
            {
                Add(new SkillCheckBox(skill.Name, cnt));
                cnt++;
            }
        }

        public SkillAdd(List<SkillInfo> param_skillinfo)
        {
            int cnt = 0;
            //Clear();
            foreach (SkillInfo skill in param_skillinfo)
            {
                Add(new SkillCheckBox(skill.Name, cnt));
                cnt++;
            }
        }

        public ObservableCollection<SkillCheckBox> SkillListSync
        {
            get { 
                return this;
            }
            set
            {
            }
        }
    }
}
