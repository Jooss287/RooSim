using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RooStatsSim.DB
{
    static class AllSkillList
    {
        enum SKILL_TYPE
        {
            ACTIVE,
            PASSIVE,
            BUFF,
            DEBUFF,
        }
        class SkillInfo
        {
            public int ID { get; set; }
            public string NAME { get; set; }
            public string NAME_KOR { get; set; }
            public int MAX_LV { get; set; }
            public SKILL_TYPE TYPE { get; set; }
            public List<int> PERCENT { get; set; }
            public ItemDB ADD_EFFECT { get; set; }
            public SkillInfo(int id, string name, string name_kor, int max_lv, SKILL_TYPE type, List<int> percent, ItemDB add_effect = null)
            {
                ID = id;
                NAME = name;
                NAME_KOR = name_kor;
                MAX_LV = max_lv;
                TYPE = type;
                PERCENT = percent;
                ADD_EFFECT = add_effect;
            }
        }

        static List<SkillInfo> Skill_List = new List<SkillInfo>()
        {
            {new SkillInfo(0, "chivalry", "기사도", 0, SKILL_TYPE.PASSIVE, new List<int>() {0, }) },
            {new SkillInfo(1, "sword_mastery", "검계열 수련", 10, SKILL_TYPE.PASSIVE, new List<int>() {0,2,4,6,8,10,12,14,16,18,20}) },
            {new SkillInfo(2, "bash", "배쉬", 10, SKILL_TYPE.ACTIVE, new List<int>() { }) },
            {new SkillInfo(3, "magnum brake", "매그넘 브레이크", 10, SKILL_TYPE.ACTIVE, new List<int>() { }) },
            {new SkillInfo(4, "provoque", "프로보크", 10, SKILL_TYPE.DEBUFF, new List<int>() { }) },
            {new SkillInfo(5, "endure", "인듀어", 10, SKILL_TYPE.BUFF, new List<int>() { }) }
        };
    }
}
