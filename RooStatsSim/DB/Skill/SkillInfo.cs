using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RooStatsSim.DB.Skill
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
        public List<double> DAMAGE { get; set; }
        public List<ItemDB> OPTION 
        {
            get { if (_option == null) _option = new List<ItemDB>();
                return _option; }
            set { _option = value; }
        }
        public ItemDB ADD_EFFECT 
        {
            get { if (_add_effect == null) _add_effect = new ItemDB();
                    return _add_effect; }
            set { _add_effect = value; }
        }
        public SkillInfo(string name, string name_kor, int max_lv=0, SKILL_TYPE type=SKILL_TYPE.ACTIVE)
        {
            NAME = name;
            NAME_KOR = name_kor;
            MAX_LV = max_lv;
            TYPE = type;
        }

        List<ItemDB> _option;
        ItemDB _add_effect;
    }
}
