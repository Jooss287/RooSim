using RooStatsSim.DB;
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
        GUILLOTINE_CROSS,
        SNIPER,
        HIGH_WIZARD,
        HIGH_PRIST
    }
    enum ATTACK_TYPE
    {
        MELEE_TYPE,
        RANGE_TYPE,
    }
    
    class JobSelect
    {
        List<dynamic> Job;
        readonly JOB_LIST JobNum = new JOB_LIST();

        public JobSelect(int param_job, ref Status param_status, ref ItemAbility param_ability, ref MonsterDB param_mobDB,
            double element_ratio, double size_panelty)
        {
            JobNum = (JOB_LIST)param_job;
            Job = new List<dynamic>()
            {
                new LoadKnight(ref param_status, ref param_ability, ref param_mobDB, ref element_ratio, ref size_panelty),
        };
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
