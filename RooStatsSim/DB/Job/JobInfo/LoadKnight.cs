using System;
using System.Collections.Generic;
using RooStatsSim.DB.Table;

namespace RooStatsSim.DB.Job.JobInfo
{
    public enum LOADKNIGHT_SKILL
    {
        //2차
        SPEAR_MASTERY,
        PIERCE,
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
        public static Dictionary<string, string> SKILL_KOR = new Dictionary<string, string>()
        {
            {Enum.GetName(typeof(LOADKNIGHT_SKILL),LOADKNIGHT_SKILL.SPEAR_MASTERY), "스피어 마스터리" },
            {Enum.GetName(typeof(LOADKNIGHT_SKILL),LOADKNIGHT_SKILL.PIERCE), "피어스" },
            {Enum.GetName(typeof(LOADKNIGHT_SKILL),LOADKNIGHT_SKILL.BRANDISH_SPEAR), "브랜디쉬 스피어" },
            {Enum.GetName(typeof(LOADKNIGHT_SKILL),LOADKNIGHT_SKILL.SPEAR_BOOMERANG), "스피어 부메랑" },
            {Enum.GetName(typeof(LOADKNIGHT_SKILL),LOADKNIGHT_SKILL.CHARGE_ATTACK), "차지 어택" },
            {Enum.GetName(typeof(LOADKNIGHT_SKILL),LOADKNIGHT_SKILL.SOLID_BLOW), "견고한 타격" },
            {Enum.GetName(typeof(LOADKNIGHT_SKILL),LOADKNIGHT_SKILL.RYAN_RAPIDS), "라이언 래피드" },
            {Enum.GetName(typeof(LOADKNIGHT_SKILL),LOADKNIGHT_SKILL.SWORD_QUIKEN), "소드 퀴큰" },
            {Enum.GetName(typeof(LOADKNIGHT_SKILL),LOADKNIGHT_SKILL.BOWLING_BASH), "볼링 배쉬" },
            {Enum.GetName(typeof(LOADKNIGHT_SKILL),LOADKNIGHT_SKILL.VANGUARD_CHASE), "뱅가드 체이스" },

            {Enum.GetName(typeof(LOADKNIGHT_SKILL),LOADKNIGHT_SKILL.CONCENTRATION), "컨센트레이션" },
            {Enum.GetName(typeof(LOADKNIGHT_SKILL),LOADKNIGHT_SKILL.HEAD_CRUSH), "헤드 크러쉬" },
            {Enum.GetName(typeof(LOADKNIGHT_SKILL),LOADKNIGHT_SKILL.VITAL_STRIKE), "조인트 비트" },
            {Enum.GetName(typeof(LOADKNIGHT_SKILL),LOADKNIGHT_SKILL.SPIRAL_PIERCE), "스파이럴 피어스" },
            {Enum.GetName(typeof(LOADKNIGHT_SKILL),LOADKNIGHT_SKILL.AURA_BALDE), "오라 블레이드" },
            {Enum.GetName(typeof(LOADKNIGHT_SKILL),LOADKNIGHT_SKILL.BERSERK), "버서크" },
        };
        public Dictionary<string, SkillInfo> Skill { get; set; }
        public LoadKnightSkill()
        {
            Skill = new Dictionary<string, SkillInfo>();
            foreach (string name in Enum.GetNames(typeof(LOADKNIGHT_SKILL)))
            {
                Skill.Add(name, new SkillInfo(name, SKILL_KOR[name]));
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
            Skill[Enum.GetName(typeof(LOADKNIGHT_SKILL), LOADKNIGHT_SKILL.PIERCE)].MAX_LV = 10;
            Skill[Enum.GetName(typeof(LOADKNIGHT_SKILL), LOADKNIGHT_SKILL.PIERCE)].TYPE = SKILL_TYPE.ACTIVE;
            Skill[Enum.GetName(typeof(LOADKNIGHT_SKILL), LOADKNIGHT_SKILL.PIERCE)].DAMAGE = new List<double>() { 1.10, 1.20, 1.30, 1.40, 1.50, 1.60, 1.70, 1.80, 1.90, 2.00 };
            //브랜디쉬 스피어
            Skill[Enum.GetName(typeof(LOADKNIGHT_SKILL), LOADKNIGHT_SKILL.BRANDISH_SPEAR)].MAX_LV = 10;
            Skill[Enum.GetName(typeof(LOADKNIGHT_SKILL), LOADKNIGHT_SKILL.BRANDISH_SPEAR)].TYPE = SKILL_TYPE.ACTIVE;
            Skill[Enum.GetName(typeof(LOADKNIGHT_SKILL), LOADKNIGHT_SKILL.BRANDISH_SPEAR)].DAMAGE = new List<double>() { 1.40, 1.60, 1.80, 2.00, 2.20, 2.40, 2.60, 2.80, 3.00, 3.20 };
            //스피어 부메랑
            Skill[Enum.GetName(typeof(LOADKNIGHT_SKILL), LOADKNIGHT_SKILL.SPEAR_BOOMERANG)].MAX_LV = 2;
            Skill[Enum.GetName(typeof(LOADKNIGHT_SKILL), LOADKNIGHT_SKILL.SPEAR_BOOMERANG)].TYPE = SKILL_TYPE.ACTIVE;
            Skill[Enum.GetName(typeof(LOADKNIGHT_SKILL), LOADKNIGHT_SKILL.SPEAR_BOOMERANG)].DAMAGE = new List<double>() { 1.40, 1.80 };
            //차지 어택
            Skill[Enum.GetName(typeof(LOADKNIGHT_SKILL), LOADKNIGHT_SKILL.CHARGE_ATTACK)].MAX_LV = 1;
            Skill[Enum.GetName(typeof(LOADKNIGHT_SKILL), LOADKNIGHT_SKILL.CHARGE_ATTACK)].TYPE = SKILL_TYPE.ACTIVE;
            Skill[Enum.GetName(typeof(LOADKNIGHT_SKILL), LOADKNIGHT_SKILL.CHARGE_ATTACK)].DAMAGE = new List<double>() { 1.50 };
            //견고한 타격
            Skill[Enum.GetName(typeof(LOADKNIGHT_SKILL), LOADKNIGHT_SKILL.SOLID_BLOW)].MAX_LV = 10;
            Skill[Enum.GetName(typeof(LOADKNIGHT_SKILL), LOADKNIGHT_SKILL.SOLID_BLOW)].TYPE = SKILL_TYPE.ACTIVE;
            Skill[Enum.GetName(typeof(LOADKNIGHT_SKILL), LOADKNIGHT_SKILL.SOLID_BLOW)].DAMAGE = new List<double>() { 1.40, 1.60, 1.80, 2.00, 2.20, 2.40, 2.60, 2.80, 3.00, 3.20 };
            //라이언 래피드
            Skill[Enum.GetName(typeof(LOADKNIGHT_SKILL), LOADKNIGHT_SKILL.RYAN_RAPIDS)].MAX_LV = 10;
            Skill[Enum.GetName(typeof(LOADKNIGHT_SKILL), LOADKNIGHT_SKILL.RYAN_RAPIDS)].TYPE = SKILL_TYPE.ACTIVE;
            Skill[Enum.GetName(typeof(LOADKNIGHT_SKILL), LOADKNIGHT_SKILL.RYAN_RAPIDS)].DAMAGE = new List<double>() { 1.40, 1.80, 2.20, 2.60, 3.00, 3.40, 3.80, 4.20, 4.60, 5.00 };
            //소드 퀴큰
            Skill[Enum.GetName(typeof(LOADKNIGHT_SKILL), LOADKNIGHT_SKILL.SWORD_QUIKEN)].MAX_LV = 10;
            Skill[Enum.GetName(typeof(LOADKNIGHT_SKILL), LOADKNIGHT_SKILL.SWORD_QUIKEN)].TYPE = SKILL_TYPE.BUFF;
            for (int i = 1; i <= 10; i++)
            {
                ItemDB opt = new ItemDB();
                opt.Option_DTYPE[Enum.GetName(typeof(DTYPE), DTYPE.ASPD)] = 10 + i * 2;
                Skill[Enum.GetName(typeof(LOADKNIGHT_SKILL), LOADKNIGHT_SKILL.SWORD_QUIKEN)].OPTION.Add(opt);
            }
            //볼링 배쉬
            Skill[Enum.GetName(typeof(LOADKNIGHT_SKILL), LOADKNIGHT_SKILL.BOWLING_BASH)].MAX_LV = 10;
            Skill[Enum.GetName(typeof(LOADKNIGHT_SKILL), LOADKNIGHT_SKILL.BOWLING_BASH)].TYPE = SKILL_TYPE.ACTIVE;
            Skill[Enum.GetName(typeof(LOADKNIGHT_SKILL), LOADKNIGHT_SKILL.BOWLING_BASH)].DAMAGE = new List<double>() { 1.25, 1.50, 1.75, 2.00, 2.25, 2.50, 2.75, 3.00, 3.25, 3.50 };
            //뱅가드 체이스
            Skill[Enum.GetName(typeof(LOADKNIGHT_SKILL), LOADKNIGHT_SKILL.VANGUARD_CHASE)].MAX_LV = 10;
            Skill[Enum.GetName(typeof(LOADKNIGHT_SKILL), LOADKNIGHT_SKILL.VANGUARD_CHASE)].TYPE = SKILL_TYPE.ACTIVE;
            Skill[Enum.GetName(typeof(LOADKNIGHT_SKILL), LOADKNIGHT_SKILL.VANGUARD_CHASE)].DAMAGE = new List<double>() { 3.40,  };

            //컨센트레이션
            Skill[Enum.GetName(typeof(LOADKNIGHT_SKILL), LOADKNIGHT_SKILL.CONCENTRATION)].MAX_LV = 10;
            Skill[Enum.GetName(typeof(LOADKNIGHT_SKILL), LOADKNIGHT_SKILL.CONCENTRATION)].TYPE = SKILL_TYPE.BUFF;
            for (int i = 1; i <= 10; i++)
            {
                ItemDB opt = new ItemDB();
                opt.Option_ITYPE[Enum.GetName(typeof(ITYPE), ITYPE.HIT)] = i * 5;
                opt.Option_DTYPE[Enum.GetName(typeof(DTYPE), DTYPE.DEF_P)] = i * -2;
                Skill[Enum.GetName(typeof(LOADKNIGHT_SKILL), LOADKNIGHT_SKILL.CONCENTRATION)].OPTION.Add(opt);
            }
            //Skill[Enum.GetName(typeof(LOADKNIGHT_SKILL), LOADKNIGHT_SKILL.FIERCE)].DAMAGE = new List<double>() { 2, 4, 6, 8, 10, 13, 16, 19, 22, 25};
            //헤드 크러쉬
            Skill[Enum.GetName(typeof(LOADKNIGHT_SKILL), LOADKNIGHT_SKILL.HEAD_CRUSH)].MAX_LV = 5;
            Skill[Enum.GetName(typeof(LOADKNIGHT_SKILL), LOADKNIGHT_SKILL.HEAD_CRUSH)].TYPE = SKILL_TYPE.ACTIVE;
            Skill[Enum.GetName(typeof(LOADKNIGHT_SKILL), LOADKNIGHT_SKILL.HEAD_CRUSH)].DAMAGE = new List<double>() { 1.40, 1.80, 2.20, 2.60, 3.00 };
            //조인트 비트
            Skill[Enum.GetName(typeof(LOADKNIGHT_SKILL), LOADKNIGHT_SKILL.VITAL_STRIKE)].MAX_LV = 10;
            Skill[Enum.GetName(typeof(LOADKNIGHT_SKILL), LOADKNIGHT_SKILL.VITAL_STRIKE)].TYPE = SKILL_TYPE.ACTIVE;
            Skill[Enum.GetName(typeof(LOADKNIGHT_SKILL), LOADKNIGHT_SKILL.VITAL_STRIKE)].DAMAGE = new List<double>() { 0.60, 0.70, 0.80, 0.90, 1.00, 1.10, 1.20, 1.30, 1.40, 1.50 };
            //스파이럴 피어스
            Skill[Enum.GetName(typeof(LOADKNIGHT_SKILL), LOADKNIGHT_SKILL.SPIRAL_PIERCE)].MAX_LV = 10;
            Skill[Enum.GetName(typeof(LOADKNIGHT_SKILL), LOADKNIGHT_SKILL.SPIRAL_PIERCE)].TYPE = SKILL_TYPE.ACTIVE;
            Skill[Enum.GetName(typeof(LOADKNIGHT_SKILL), LOADKNIGHT_SKILL.SPIRAL_PIERCE)].DAMAGE = new List<double>() { 3.00, 4.00, 5.00, 6.00, 7.00, 8.00, 9.00, 10.00, 11.00, 12.00 };
            //오라 블레이드
            Skill[Enum.GetName(typeof(LOADKNIGHT_SKILL), LOADKNIGHT_SKILL.AURA_BALDE)].MAX_LV = 10;
            Skill[Enum.GetName(typeof(LOADKNIGHT_SKILL), LOADKNIGHT_SKILL.AURA_BALDE)].TYPE = SKILL_TYPE.BUFF;
            for (int i = 1; i <= 10; i++)
            {
                ItemDB opt = new ItemDB();
                opt.Option_ITYPE[Enum.GetName(typeof(ITYPE), ITYPE.PHYSICAL_DAMAGE_ADDITIONAL)] = i * 20;
                Skill[Enum.GetName(typeof(LOADKNIGHT_SKILL), LOADKNIGHT_SKILL.AURA_BALDE)].OPTION.Add(opt);
            }
            //버서크
            Skill[Enum.GetName(typeof(LOADKNIGHT_SKILL), LOADKNIGHT_SKILL.BERSERK)].MAX_LV = 5;
            Skill[Enum.GetName(typeof(LOADKNIGHT_SKILL), LOADKNIGHT_SKILL.BERSERK)].TYPE = SKILL_TYPE.BUFF;
        }
    }
    public class LoadKnightJobBonus
    {
        public Dictionary<int, ItemDB> Bonus { get; set; }
        public LoadKnightJobBonus()
        {
            Bonus = new Dictionary<int, ItemDB>();
            Bonus[0] = new ItemDB();
            for (int i = 5; i <= 40; i += 5)
                Bonus[i] = new ItemDB();

            //Knight
            Bonus[0].Option_ITYPE[Enum.GetName(typeof(ITYPE), ITYPE.STR)] = 8;
            Bonus[0].Option_ITYPE[Enum.GetName(typeof(ITYPE), ITYPE.AGI)] = 2;
            Bonus[0].Option_ITYPE[Enum.GetName(typeof(ITYPE), ITYPE.VIT)] = 10;
            Bonus[0].Option_ITYPE[Enum.GetName(typeof(ITYPE), ITYPE.DEX)] = 6;
            Bonus[0].Option_ITYPE[Enum.GetName(typeof(ITYPE), ITYPE.LUK)] = 4;
            //LoadKnight
            Bonus[5].Option_ITYPE[Enum.GetName(typeof(ITYPE), ITYPE.INT)] = 2;
            Bonus[5].Option_ITYPE[Enum.GetName(typeof(ITYPE), ITYPE.AGI)] = 3;
            Bonus[10].Option_ITYPE[Enum.GetName(typeof(ITYPE), ITYPE.DEX)] = 3;
            Bonus[10].Option_ITYPE[Enum.GetName(typeof(ITYPE), ITYPE.VIT)] = 2;
            Bonus[15].Option_ITYPE[Enum.GetName(typeof(ITYPE), ITYPE.VIT)] = 2;
            Bonus[15].Option_ITYPE[Enum.GetName(typeof(ITYPE), ITYPE.LUK)] = 3;
            Bonus[20].Option_ITYPE[Enum.GetName(typeof(ITYPE), ITYPE.STR)] = 4;
            Bonus[20].Option_ITYPE[Enum.GetName(typeof(ITYPE), ITYPE.DEX)] = 2;
            Bonus[25].Option_ITYPE[Enum.GetName(typeof(ITYPE), ITYPE.STR)] = 4;
            Bonus[25].Option_ITYPE[Enum.GetName(typeof(ITYPE), ITYPE.AGI)] = 2;
            Bonus[30].Option_ITYPE[Enum.GetName(typeof(ITYPE), ITYPE.STR)] = 2;
            Bonus[30].Option_ITYPE[Enum.GetName(typeof(ITYPE), ITYPE.DEX)] = 4;
            Bonus[35].Option_ITYPE[Enum.GetName(typeof(ITYPE), ITYPE.STR)] = 2;
            Bonus[35].Option_ITYPE[Enum.GetName(typeof(ITYPE), ITYPE.VIT)] = 4;
            Bonus[40].Option_ITYPE[Enum.GetName(typeof(ITYPE), ITYPE.STR)] = 3;
            Bonus[40].Option_ITYPE[Enum.GetName(typeof(ITYPE), ITYPE.AGI)] = 3;
        }
    }

}
