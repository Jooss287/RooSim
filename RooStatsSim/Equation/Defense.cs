
namespace RooStatsSim.Equation
{
    class Defense
    {
        static public double GetDefRatio(int MobDefense, int SmeltingDefense, int Vitdefense, double Defense_ignore)
        {
            double def_ignore = 1 - 0.01 * Defense_ignore;
            double def_ratio = (4000 + (MobDefense * def_ignore)) / (4000 + (MobDefense * def_ignore * 10));
            return def_ratio;
        }
    }
}
