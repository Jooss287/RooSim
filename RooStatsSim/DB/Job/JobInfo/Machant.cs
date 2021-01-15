using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RooStatsSim.DB.Table;

namespace RooStatsSim.DB.Job.JobInfo
{
    public enum MACHANT_SKILL
    {
        
    }
    public class MachantSkill
    {
        public static Dictionary<string, string> SKILL_KOR = new Dictionary<string, string>()
        {
            
        };
        public Dictionary<string, SkillInfo> Skill { get; set; }
        public MachantSkill()
        {
            Skill = new Dictionary<string, SkillInfo>();
            foreach (string name in Enum.GetNames(typeof(SWORDMAN_SKILL)))
            {
                Skill.Add(name, new SkillInfo(name, SKILL_KOR[name]));
            }
        }
    }

    public class MachantJobBonus
    {
        public Dictionary<int, ItemDB> Bonus { get; set; }
        public MachantJobBonus()
        {
//            블스
//5 힘2 덱1
//10 덱1 바탈2
//15 덱1 럭2
//20 힘1 바탈2
//25 인트2 덱스2
//30 덱스2 바탈2
//35 힘3 덱스2
//40 어질2 덱스3
//화스
//5 인트3 어질2
//10 덱3 럭2
//15 어질2 럭3
//20 힘3 바탈3
//25 덱3 럭3
//30 인트3 덱3
//35 덱3 바탈3
//40 힘3 어질3
        }
    }
}
