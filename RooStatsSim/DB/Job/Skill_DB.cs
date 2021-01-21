using System;
using System.Collections.Generic;
using RooStatsSim.DB.Table;
using RooStatsSim.DB.Job;
using RooStatsSim.DB.Job.JobInfo;

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
            MakeDB(_swordman_skill.Skill, _loadknight_skill.Skill);
        }
        
        void MakeDB(params Dictionary<string, SkillInfo>[] param)
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

        public Dictionary<string, SkillInfo> GetJobInitSkills(JOB_SELECT_LIST job)
        {
            Dictionary<string, SkillInfo> skill_list = new Dictionary<string, SkillInfo>();
            List<Dictionary<string, SkillInfo>> list = new List<Dictionary<string, SkillInfo>>();

            switch((int)job/100*100)
            {
                case (int)JOB_SELECT_LIST.SWORDMAN:
                    list.Add(_swordman_skill.Skill);
                    break;
                case (int)JOB_SELECT_LIST.MARCHANT:
                    break;
                case (int)JOB_SELECT_LIST.THIEF:
                    break;
                case (int)JOB_SELECT_LIST.ARCHER:
                    break;
                case (int)JOB_SELECT_LIST.MAGICIAN:
                    break;
                case (int)JOB_SELECT_LIST.ACOLYTE:
                    break;
                default:
                    break;
            }

            switch(job)
            {
                case JOB_SELECT_LIST.KNIGHT:
                    list.Add(_loadknight_skill.Skill);
                    break;
                case JOB_SELECT_LIST.CRUSADER:
                    break;
                case JOB_SELECT_LIST.BLACKSMITH:
                    break;
                case JOB_SELECT_LIST.ALCHEMIST:
                    break;
                case JOB_SELECT_LIST.ASSASSIN:
                    break;
                case JOB_SELECT_LIST.LOGUE:
                    break;
                case JOB_SELECT_LIST.HUNTER:
                    break;
                case JOB_SELECT_LIST.BARD:
                    break;
                case JOB_SELECT_LIST.DANCER:
                    break;
                case JOB_SELECT_LIST.WIZARD:
                    break;
                case JOB_SELECT_LIST.SAGE:
                    break;
                case JOB_SELECT_LIST.PRIST:
                    break;
                case JOB_SELECT_LIST.MONK:
                    break;
                default:
                    break;
            }

            foreach (Dictionary<string, SkillInfo> skills in list)
            {
                foreach (KeyValuePair<string, SkillInfo> skill in skills)
                {
                    skill_list[skill.Key] = skill.Value;
                }
            }

            return skill_list;
        }
    }
}
