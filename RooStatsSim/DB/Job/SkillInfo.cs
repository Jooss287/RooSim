using System.Collections.Generic;

using RooStatsSim.User;
using RooStatsSim.DB;

namespace RooStatsSim.DB.Job
{
    public enum SKILL_TYPE
    {
        ACTIVE,
        PASSIVE,
        BUFF,
        DEBUFF,
    }

    public class SkillInfo
    {
        public string NAME { get; set; }
        public string NAME_KOR { get; set; }
        public int MAX_LV { get; set; }
        public SKILL_TYPE TYPE { get; set; }
        public bool HAS_DMG_EQUATION { get; set; }
        public List<double> DAMAGE { get; set; }
        public List<ItemDB> OPTION 
        {
            get { if (_option == null) _option = new List<ItemDB>();
                return _option; }
            set { _option = value; }
        }
        public delegate int DamageEquationPointer(UserData _user_data, CALC_STANDARD calc_dmg);
        public DamageEquationPointer CalcSkillDmg;
        public SkillInfo(string name, string name_kor, int max_lv=0, SKILL_TYPE type=SKILL_TYPE.ACTIVE, bool has_dmg_equation = false, DamageEquationPointer dmg_pointer = null)
        {
            NAME = name;
            NAME_KOR = name_kor;
            MAX_LV = max_lv;
            TYPE = type;
            HAS_DMG_EQUATION = has_dmg_equation;
            CalcSkillDmg = dmg_pointer;
        }

        List<ItemDB> _option;

        
    }
}
