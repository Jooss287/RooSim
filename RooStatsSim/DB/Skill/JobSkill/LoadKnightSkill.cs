using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RooStatsSim.DB.Table;

namespace RooStatsSim.DB.Skill.JobSkill
{
    public enum LOADKNIGHT_SKILL
    {
        //2차
        SPEAR_MASTERY,
        FIERCE,
        BRANDISH_SPEAR,
        SPEAR_BOOMERANG,
        CHARGE_ATTACK,
        SOLID_BLOW,
        RYAN_RAPIDS,
        SWORD_QUIKEN,
        BOWLING_BASH,
        VANGUARD_CHASE,
        //3차
        CONCENTRATION,
        HEAD_CRUSH,
        VITAL_STRIKE,
        SPIRAL_PIERCE,
        AURA_BALDE,
        BERSERK,
    }
    public class LoadKnightSkill
    {
        public static Dictionary<LOADKNIGHT_SKILL, string> SWORDMAN_SKILL_KOR = new Dictionary<LOADKNIGHT_SKILL, string>()
        {
            {LOADKNIGHT_SKILL.SPEAR_MASTERY, "스피어 마스터리" },
            {LOADKNIGHT_SKILL.FIERCE, "피어스" },
            {LOADKNIGHT_SKILL.BRANDISH_SPEAR, "브랜디쉬 스피어" },
            {LOADKNIGHT_SKILL.SPEAR_BOOMERANG, "스피어 부메랑" },
            {LOADKNIGHT_SKILL.CHARGE_ATTACK, "차지 어택" },
            {LOADKNIGHT_SKILL.SOLID_BLOW, "견고한 타격" },
            {LOADKNIGHT_SKILL.RYAN_RAPIDS, "라이언 래피드" },
            {LOADKNIGHT_SKILL.SWORD_QUIKEN, "소드 퀴큰" },
            {LOADKNIGHT_SKILL.BOWLING_BASH, "볼링 배쉬" },
            {LOADKNIGHT_SKILL.VANGUARD_CHASE, "뱅가드 체이스" },

            {LOADKNIGHT_SKILL.CONCENTRATION, "컨센트레이션" },
            {LOADKNIGHT_SKILL.HEAD_CRUSH, "헤드 크러쉬" },
            {LOADKNIGHT_SKILL.VITAL_STRIKE, "조인트 비트" },
            {LOADKNIGHT_SKILL.SPIRAL_PIERCE, "스파이럴 피어스" },
            {LOADKNIGHT_SKILL.AURA_BALDE, "오라 블레이드" },
            {LOADKNIGHT_SKILL.BERSERK, "버서크" },
        };
        public Dictionary<string, SkillInfo> Skill { get; set; }
        public LoadKnightSkill()
        {
            foreach (string name in Enum.GetNames(typeof(LOADKNIGHT_SKILL)))
            {
                Skill.Add(name, new SkillInfo(name, SWORDMAN_SKILL_KOR[(LOADKNIGHT_SKILL)Enum.Parse(typeof(LOADKNIGHT_SKILL), name)]));
            }
            //스피어 마스터리
            Skill[Enum.GetName(typeof(LOADKNIGHT_SKILL), LOADKNIGHT_SKILL.SPEAR_MASTERY)].MAX_LV = 10;
            Skill[Enum.GetName(typeof(LOADKNIGHT_SKILL), LOADKNIGHT_SKILL.SPEAR_MASTERY)].TYPE = SKILL_TYPE.PASSIVE;
            for (int i = 1; i <= 10; i++)
            {
                ItemDB opt = new ItemDB();
                opt.Option_ITYPE[Enum.GetName(typeof(ITYPE), ITYPE.MASTERY_ATK)] = i * 5;
                Skill[Enum.GetName(typeof(LOADKNIGHT_SKILL), LOADKNIGHT_SKILL.SPEAR_MASTERY)].OPTION.Add(opt);
            }
            //피어스
            Skill[Enum.GetName(typeof(LOADKNIGHT_SKILL), LOADKNIGHT_SKILL.FIERCE)].MAX_LV = 10;
            Skill[Enum.GetName(typeof(LOADKNIGHT_SKILL), LOADKNIGHT_SKILL.FIERCE)].TYPE = SKILL_TYPE.ACTIVE;
            Skill[Enum.GetName(typeof(LOADKNIGHT_SKILL), LOADKNIGHT_SKILL.FIERCE)].DAMAGE = new List<double>() { 1.10, 1.20, 1.30, 1.40, 1.50, 1.60, 1.70, 1.80, 1.90, 2.00 };
            //브랜디쉬 스피어
            Skill[Enum.GetName(typeof(LOADKNIGHT_SKILL), LOADKNIGHT_SKILL.FIERCE)].MAX_LV = 10;
            Skill[Enum.GetName(typeof(LOADKNIGHT_SKILL), LOADKNIGHT_SKILL.FIERCE)].TYPE = SKILL_TYPE.ACTIVE;
            Skill[Enum.GetName(typeof(LOADKNIGHT_SKILL), LOADKNIGHT_SKILL.FIERCE)].DAMAGE = new List<double>() { 1.40, 1.60, 1.80, 2.00, 2.20, 2.40, 2.60, 2.80, 3.00, 3.20 };
            //스피어 부메랑
            Skill[Enum.GetName(typeof(LOADKNIGHT_SKILL), LOADKNIGHT_SKILL.FIERCE)].MAX_LV = 2;
            Skill[Enum.GetName(typeof(LOADKNIGHT_SKILL), LOADKNIGHT_SKILL.FIERCE)].TYPE = SKILL_TYPE.ACTIVE;
            Skill[Enum.GetName(typeof(LOADKNIGHT_SKILL), LOADKNIGHT_SKILL.FIERCE)].DAMAGE = new List<double>() { 1.40, 1.80 };
            //차지 어택
            Skill[Enum.GetName(typeof(LOADKNIGHT_SKILL), LOADKNIGHT_SKILL.FIERCE)].MAX_LV = 1;
            Skill[Enum.GetName(typeof(LOADKNIGHT_SKILL), LOADKNIGHT_SKILL.FIERCE)].TYPE = SKILL_TYPE.ACTIVE;
            Skill[Enum.GetName(typeof(LOADKNIGHT_SKILL), LOADKNIGHT_SKILL.FIERCE)].DAMAGE = new List<double>() { 1.50 };
            //견고한 타격
            Skill[Enum.GetName(typeof(LOADKNIGHT_SKILL), LOADKNIGHT_SKILL.FIERCE)].MAX_LV = 10;
            Skill[Enum.GetName(typeof(LOADKNIGHT_SKILL), LOADKNIGHT_SKILL.FIERCE)].TYPE = SKILL_TYPE.ACTIVE;
            Skill[Enum.GetName(typeof(LOADKNIGHT_SKILL), LOADKNIGHT_SKILL.FIERCE)].DAMAGE = new List<double>() { 1.40, 1.60, 1.80, 2.00, 2.20, 2.40, 2.60, 2.80, 3.00, 3.20 };
            //라이언 래피드
            Skill[Enum.GetName(typeof(LOADKNIGHT_SKILL), LOADKNIGHT_SKILL.FIERCE)].MAX_LV = 10;
            Skill[Enum.GetName(typeof(LOADKNIGHT_SKILL), LOADKNIGHT_SKILL.FIERCE)].TYPE = SKILL_TYPE.ACTIVE;
            Skill[Enum.GetName(typeof(LOADKNIGHT_SKILL), LOADKNIGHT_SKILL.FIERCE)].DAMAGE = new List<double>() { 1.40, 1.80, 2.20, 2.60, 3.00, 3.40, 3.80, 4.20, 4.60, 5.00 };
            //소드 퀴큰
            Skill[Enum.GetName(typeof(LOADKNIGHT_SKILL), LOADKNIGHT_SKILL.FIERCE)].MAX_LV = 10;
            Skill[Enum.GetName(typeof(LOADKNIGHT_SKILL), LOADKNIGHT_SKILL.FIERCE)].TYPE = SKILL_TYPE.BUFF;
            for (int i = 1; i <= 10; i++)
            {
                ItemDB opt = new ItemDB();
                opt.Option_DTYPE[Enum.GetName(typeof(DTYPE), DTYPE.ASPD)] = 10 + i * 2;
                Skill[Enum.GetName(typeof(LOADKNIGHT_SKILL), LOADKNIGHT_SKILL.SPEAR_MASTERY)].OPTION.Add(opt);
            }
            //볼링 배쉬
            Skill[Enum.GetName(typeof(LOADKNIGHT_SKILL), LOADKNIGHT_SKILL.FIERCE)].MAX_LV = 10;
            Skill[Enum.GetName(typeof(LOADKNIGHT_SKILL), LOADKNIGHT_SKILL.FIERCE)].TYPE = SKILL_TYPE.ACTIVE;
            Skill[Enum.GetName(typeof(LOADKNIGHT_SKILL), LOADKNIGHT_SKILL.FIERCE)].DAMAGE = new List<double>() { 1.25, 1.50, 1.75, 2.00, 2.25, 2.50, 2.75, 3.00, 3.25, 3.50 };
            //뱅가드 체이스
            Skill[Enum.GetName(typeof(LOADKNIGHT_SKILL), LOADKNIGHT_SKILL.FIERCE)].MAX_LV = 10;
            Skill[Enum.GetName(typeof(LOADKNIGHT_SKILL), LOADKNIGHT_SKILL.FIERCE)].TYPE = SKILL_TYPE.ACTIVE;
            Skill[Enum.GetName(typeof(LOADKNIGHT_SKILL), LOADKNIGHT_SKILL.FIERCE)].DAMAGE = new List<double>() { 3.40,  };

            //컨센트레이션
            Skill[Enum.GetName(typeof(LOADKNIGHT_SKILL), LOADKNIGHT_SKILL.FIERCE)].MAX_LV = 10;
            Skill[Enum.GetName(typeof(LOADKNIGHT_SKILL), LOADKNIGHT_SKILL.FIERCE)].TYPE = SKILL_TYPE.BUFF;
            for (int i = 1; i <= 10; i++)
            {
                ItemDB opt = new ItemDB();
                opt.Option_ITYPE[Enum.GetName(typeof(ITYPE), ITYPE.HIT)] = i * 5;
                opt.Option_DTYPE[Enum.GetName(typeof(DTYPE), DTYPE.DEF_P)] = i * -2;
                Skill[Enum.GetName(typeof(LOADKNIGHT_SKILL), LOADKNIGHT_SKILL.SPEAR_MASTERY)].OPTION.Add(opt);
            }
            //Skill[Enum.GetName(typeof(LOADKNIGHT_SKILL), LOADKNIGHT_SKILL.FIERCE)].DAMAGE = new List<double>() { 2, 4, 6, 8, 10, 13, 16, 19, 22, 25};
            //헤드 크러쉬
            Skill[Enum.GetName(typeof(LOADKNIGHT_SKILL), LOADKNIGHT_SKILL.FIERCE)].MAX_LV = 5;
            Skill[Enum.GetName(typeof(LOADKNIGHT_SKILL), LOADKNIGHT_SKILL.FIERCE)].TYPE = SKILL_TYPE.ACTIVE;
            Skill[Enum.GetName(typeof(LOADKNIGHT_SKILL), LOADKNIGHT_SKILL.FIERCE)].DAMAGE = new List<double>() { 1.40, 1.80, 2.20, 2.60, 3.00 };
            //조인트 비트
            Skill[Enum.GetName(typeof(LOADKNIGHT_SKILL), LOADKNIGHT_SKILL.FIERCE)].MAX_LV = 10;
            Skill[Enum.GetName(typeof(LOADKNIGHT_SKILL), LOADKNIGHT_SKILL.FIERCE)].TYPE = SKILL_TYPE.ACTIVE;
            Skill[Enum.GetName(typeof(LOADKNIGHT_SKILL), LOADKNIGHT_SKILL.FIERCE)].DAMAGE = new List<double>() { 0.60, 0.70, 0.80, 0.90, 1.00, 1.10, 1.20, 1.30, 1.40, 1.50 };
            //스파이럴 피어스
            Skill[Enum.GetName(typeof(LOADKNIGHT_SKILL), LOADKNIGHT_SKILL.FIERCE)].MAX_LV = 10;
            Skill[Enum.GetName(typeof(LOADKNIGHT_SKILL), LOADKNIGHT_SKILL.FIERCE)].TYPE = SKILL_TYPE.ACTIVE;
            Skill[Enum.GetName(typeof(LOADKNIGHT_SKILL), LOADKNIGHT_SKILL.FIERCE)].DAMAGE = new List<double>() { 3.00, 4.00, 5.00, 6.00, 7.00, 8.00, 9.00, 10.00, 11.00, 12.00 };
            //오라 블레이드
            Skill[Enum.GetName(typeof(LOADKNIGHT_SKILL), LOADKNIGHT_SKILL.FIERCE)].MAX_LV = 10;
            Skill[Enum.GetName(typeof(LOADKNIGHT_SKILL), LOADKNIGHT_SKILL.FIERCE)].TYPE = SKILL_TYPE.BUFF;
            for (int i = 1; i <= 10; i++)
            {
                ItemDB opt = new ItemDB();
                opt.Option_ITYPE[Enum.GetName(typeof(ITYPE), ITYPE.PHYSICAL_DAMAGE_ADDITIONAL)] = i * 20;
                Skill[Enum.GetName(typeof(LOADKNIGHT_SKILL), LOADKNIGHT_SKILL.SPEAR_MASTERY)].OPTION.Add(opt);
            }
            //버서크
            Skill[Enum.GetName(typeof(LOADKNIGHT_SKILL), LOADKNIGHT_SKILL.FIERCE)].MAX_LV = 5;
            Skill[Enum.GetName(typeof(LOADKNIGHT_SKILL), LOADKNIGHT_SKILL.FIERCE)].TYPE = SKILL_TYPE.BUFF;
        }
    }
}
