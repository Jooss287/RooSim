using RooStatsSim.DB;
using RooStatsSim.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

namespace RooStatsSim.Equation.Job
{
    enum JOB_LIST
    {
        LOAD_KNIGHT,
        WHITE_SMITH,
        ASSASSIN_CROSS,
        SNIPER,
        HIGH_WIZARD,
        HIGH_PRIST
    }
    enum JOB_LIST_KOR
    {
        로드나이트,
        화이트스미스,
        어세신크로스,
        스나이퍼,
        하이위저드,
        하이프리스트
    }
    enum ATTACK_TYPE
    {
        MELEE_TYPE,
        RANGE_TYPE,
    }
    
    class JobSelect
    {
        List<dynamic> Job = new List<dynamic>()
            {
                new LordKnight(),
                new WhiteSmith(),
                new AssassinCross(),
                new Sniper(),
                new HighWizard(),
                new HighPrist()
            };
        private JOB_LIST JobNum = new JOB_LIST();


        public JobSelect(int param_job = (int)JOB_LIST.LOAD_KNIGHT)
        {
            JobNum = (JOB_LIST)param_job;
        }
        public JOB_LIST JobSelectNum
        {
            get { return JobNum; }
            set { JobNum = value; }
        }


        public void SetDB(ref Status param_status, ref ItemAbility param_abilities, ref MonsterDB param_mobDB,
            ref double param_element, ref double param_size, ref bool[] param_buff_list)
        {
            Job[Convert.ToInt32(JobNum)].SetDB(ref param_status, ref param_abilities, ref param_mobDB,
                ref param_element, ref param_size);
            Job[Convert.ToInt32(JobNum)].SetBuffList(ref param_buff_list);

        }
        public List<SkillInfo> GetSkillCnt(int param_job)
        {
            //if (param_job >= Job.Count)
            //    return null;
            return Job[param_job].skillinfo;
        }
        public double GetReverseATK(int sATK)
        {
            return Job.ElementAt(0).CalcReverseATK(sATK);
        }

        public double GetMinATK()
        {
            return Job.ElementAt(Convert.ToInt32(JobNum)).CalcATKdamage(CALC_STANDARD.MIN_DAMAGE);
        }
        public double GetMaxATK()
        {
            return Job.ElementAt(Convert.ToInt32(JobNum)).CalcATKdamage(CALC_STANDARD.MAX_DAMAGE);
        }
        public int GetWinATK()
        {
            return Job.ElementAt(Convert.ToInt32(JobNum)).CalcStatusWinATK();
        }
    }
}
