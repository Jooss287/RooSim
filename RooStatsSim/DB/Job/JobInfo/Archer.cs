using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RooStatsSim.DB.Table;

namespace RooStatsSim.DB.Job.JobInfo
{
    public enum ARCHER_SKILL
    {
        
    }
    public class ArcherSkill
    {
        public static Dictionary<string, string> SKILL_KOR = new Dictionary<string, string>()
        {
            
        };
        public Dictionary<string, SkillInfo> Skill { get; set; }
        public ArcherSkill()
        {
            Skill = new Dictionary<string, SkillInfo>();
            foreach (string name in Enum.GetNames(typeof(SWORDMAN_SKILL)))
            {
                Skill.Add(name, new SkillInfo(name, SKILL_KOR[name]));
            }
        }
    }

    public class ArcherJobBonus
    {
        public Dictionary<int, ItemDB> Bonus { get; set; }
        public ArcherJobBonus()
        {
//            궁수					//쪼꼬
//5 힘1 덱1
//10 힘1 어질1
//15 인트1 덱1
//20 힘1 덱1
//25 바탈1 어질1
//30 인트1 럭1
//35 어질1 덱2
//40 덱2 럭1
//헌터
//5 힘1 덱2
//10 어질1 바탈2
//15 힘1 어질 2
//20 덱1 럭2
//25 덱2 럭2
//30 인트2 덱2
//35 힘2 덱3
//40 인트2 어질3
//스나
//5 인트3 바탈2
//10 어질3 럭2
//15 인트3 덱2
//20 힘4 인트2
//25 바탈3 럭3
//30 덱3 바탈3
//35 인트3 바탈3
//40 바탈3 럭3
        }
    }
}
