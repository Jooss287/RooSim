using RooStatsSim.DB;
using RooStatsSim.DB.Table;
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
    
    
    class JobSelect
    {
        List<dynamic> Job = new List<dynamic>()
            {
                new Novice(),
                new LordKnight(),
                new WhiteSmith(),
                new AssassinCross(),
                new Sniper(),
                new HighWizard(),
                new HighPrist()
            };

        private JOB_SELECT_LIST SelectedJob { get; set; }
        private int GetJobNum { get { return (int)SelectedJob / 100; } }


        public JobSelect(JOB_SELECT_LIST param_job = JOB_SELECT_LIST.NOVICE)
        {
            SelectedJob = param_job;
        }

        public double GetReverseATK(int sATK)
        {
            return Job.ElementAt(0).CalcReverseATK(sATK);
        }

        public double GetMinATK()
        {
            return Job.ElementAt(GetJobNum).CalcATKdamage(CALC_STANDARD.MIN_DAMAGE);
        }
        public double GetMaxATK()
        {
            return Job.ElementAt(GetJobNum).CalcATKdamage(CALC_STANDARD.MAX_DAMAGE);
        }
        public int GetWinATK()
        {
            return Job.ElementAt(GetJobNum).CalcStatusWinATK();
        }
    }
}
