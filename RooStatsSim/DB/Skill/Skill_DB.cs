using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RooStatsSim.DB.Skill.JobSkill;

namespace RooStatsSim.DB.Skill
{
    public class Skill_DB
    {
        public static SwordmanSkill _swordman_skill = new SwordmanSkill();
        public static LoadKnightSkill _loadknight_skill = new LoadKnightSkill();
        public Dictionary<string, SkillInfo> Dic { get; set; }

        public Skill_DB()
        {
            Dic = new Dictionary<string, SkillInfo>();
            MakeSkillDB(_swordman_skill.Skill, _loadknight_skill.Skill);
        }
        
        void MakeSkillDB(params Dictionary<string, SkillInfo>[] param)
        {
            Dic.Clear();
            foreach(Dictionary<string, SkillInfo> skills in param)
            {
                foreach(KeyValuePair<string, SkillInfo> skill in skills)
                {
                    Dic.Add(skill.Key, skill.Value);
                }
            }
        }
    }
}
