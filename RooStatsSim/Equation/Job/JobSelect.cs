using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

using RooStatsSim.DB;
using RooStatsSim.DB.Table;
using RooStatsSim.User;

namespace RooStatsSim.Equation.Job
{
    public class JobSelect
    {
        List<dynamic> Job = new List<dynamic>()
            {
                new Novice(),
                new LordKnight(),
                new WhiteSmith(),
                new AssassinCross(),
                new Sniper(),
                new HighWizard(),
                new HighPriest()
            };

        private JOB_SELECT_LIST SelectedJob { get; set; }
        private int GetJobNum { get { return (int)SelectedJob / 100; } }


        public JobSelect(UserData Data, JOB_SELECT_LIST param_job = JOB_SELECT_LIST.NOVICE)
        {
            SelectedJob = param_job;
        }
        public void SetUserData(UserData user)
        {
            Job.ElementAt(GetJobNum).User = new GetValue(user);
        }

        public ItemDB GetOption()
        {
            return Job.ElementAt(GetJobNum).GetOption();
        }
        #region Equations
        public double GetReverseATK(int sATK)
        {
            return Job.ElementAt(GetJobNum).CalcReverseATK(sATK);
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
        #endregion
    }
}
