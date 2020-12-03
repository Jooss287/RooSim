using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RooStatsSim.DB.Table;

namespace RooStatsSim.DB.Skill.JobSkill
{
    public enum SWORDMAN_SKILL
    {
        CHIVALRY,
        SWORD_MASTERY,
        BASH,
        MAGNUM_BRAKE,
        PROVOQUE,
        ENDURE,
    }
    public class SwordmanSkill
    {
        public static Dictionary<SWORDMAN_SKILL, string> SWORDMAN_SKILL_KOR = new Dictionary<SWORDMAN_SKILL, string>()
        {
            {SWORDMAN_SKILL.CHIVALRY, "기사도" },
            {SWORDMAN_SKILL.SWORD_MASTERY, "검계열 수련" },
            {SWORDMAN_SKILL.BASH, "배쉬" },
            {SWORDMAN_SKILL.MAGNUM_BRAKE, "매그넘 브레이크" },
            {SWORDMAN_SKILL.PROVOQUE, "프로보크" },
            {SWORDMAN_SKILL.ENDURE, "인듀어" },
        };
        public Dictionary<string, SkillInfo> Skill { get; set; }
        public SwordmanSkill()
        {
            Skill = new Dictionary<string, SkillInfo>();
            foreach (string name in Enum.GetNames(typeof(SWORDMAN_SKILL)))
            {
                Skill.Add(name, new SkillInfo(name, SWORDMAN_SKILL_KOR[(SWORDMAN_SKILL)Enum.Parse(typeof(SWORDMAN_SKILL), name)]));
            }
            //기사도
            Skill[Enum.GetName(typeof(SWORDMAN_SKILL), SWORDMAN_SKILL.CHIVALRY)].MAX_LV = 0;
            Skill[Enum.GetName(typeof(SWORDMAN_SKILL), SWORDMAN_SKILL.CHIVALRY)].TYPE = SKILL_TYPE.PASSIVE;
            Skill[Enum.GetName(typeof(SWORDMAN_SKILL), SWORDMAN_SKILL.CHIVALRY)].ADD_EFFECT.Option_ITYPE[Enum.GetName(typeof(ITYPE), ITYPE.ATK)] = 10;
            //소드 마스터리
            Skill[Enum.GetName(typeof(SWORDMAN_SKILL), SWORDMAN_SKILL.SWORD_MASTERY)].MAX_LV = 10;
            Skill[Enum.GetName(typeof(SWORDMAN_SKILL), SWORDMAN_SKILL.SWORD_MASTERY)].TYPE = SKILL_TYPE.PASSIVE;
            for (int i = 1; i <= 10; i++)
            {
                ItemDB opt = new ItemDB();
                opt.Option_ITYPE[Enum.GetName(typeof(ITYPE), ITYPE.MASTERY_ATK)] = i * 2;
                Skill[Enum.GetName(typeof(SWORDMAN_SKILL), SWORDMAN_SKILL.SWORD_MASTERY)].OPTION.Add(opt);
            }
            //배쉬
            Skill[Enum.GetName(typeof(SWORDMAN_SKILL), SWORDMAN_SKILL.BASH)].MAX_LV = 10;
            Skill[Enum.GetName(typeof(SWORDMAN_SKILL), SWORDMAN_SKILL.BASH)].TYPE = SKILL_TYPE.ACTIVE;
            Skill[Enum.GetName(typeof(SWORDMAN_SKILL), SWORDMAN_SKILL.BASH)].DAMAGE = new List<double>() { 1.20, 1.45, 1.70, 1.95, 2.20, 2.45, 2.70, 2.95, 3.20, 3.50 };

            //매그넘 브레이크
            Skill[Enum.GetName(typeof(SWORDMAN_SKILL), SWORDMAN_SKILL.MAGNUM_BRAKE)].MAX_LV = 10;
            Skill[Enum.GetName(typeof(SWORDMAN_SKILL), SWORDMAN_SKILL.MAGNUM_BRAKE)].TYPE = SKILL_TYPE.ACTIVE;
            Skill[Enum.GetName(typeof(SWORDMAN_SKILL), SWORDMAN_SKILL.MAGNUM_BRAKE)].DAMAGE = new List<double>() { 1.60, 1.70, 1.80, 1.90, 2.00, 2.10, 2.20, 2.30, 2.40, 2.50 };
            Skill[Enum.GetName(typeof(SWORDMAN_SKILL), SWORDMAN_SKILL.MAGNUM_BRAKE)].ADD_EFFECT = new ItemDB();
            Skill[Enum.GetName(typeof(SWORDMAN_SKILL), SWORDMAN_SKILL.MAGNUM_BRAKE)].ADD_EFFECT.Option_ITYPE[Enum.GetName(typeof(ELEMENT_DMG_TYPE), ELEMENT_DMG_TYPE.FIRE_DMG)] = 20;
            //프로보크
            Skill[Enum.GetName(typeof(SWORDMAN_SKILL), SWORDMAN_SKILL.PROVOQUE)].MAX_LV = 10;
            Skill[Enum.GetName(typeof(SWORDMAN_SKILL), SWORDMAN_SKILL.PROVOQUE)].TYPE = SKILL_TYPE.DEBUFF;
            //인듀어
            Skill[Enum.GetName(typeof(SWORDMAN_SKILL), SWORDMAN_SKILL.ENDURE)].MAX_LV = 10;
            Skill[Enum.GetName(typeof(SWORDMAN_SKILL), SWORDMAN_SKILL.ENDURE)].TYPE = SKILL_TYPE.BUFF;
            for(int i = 1; i <= 10; i++)
            {
                ItemDB opt = new ItemDB();
                opt.Option_ITYPE[Enum.GetName(typeof(ITYPE), ITYPE.MDEF)] = i;
                Skill[Enum.GetName(typeof(SWORDMAN_SKILL), SWORDMAN_SKILL.ENDURE)].OPTION.Add(opt);
            }
        }
    }
}
