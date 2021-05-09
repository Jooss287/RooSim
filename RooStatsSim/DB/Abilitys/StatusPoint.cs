using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RooStatsSim.DB.Abilitys
{
    public class StatusPoint
    {
        public int Str { get; set; }
        public int Vit { get; set; }
        public int Agi { get; set; }
        public int Int { get; set; }
        public int Dex { get; set; }
        public int Luk { get; set; }

        public static StatusPoint operator +(StatusPoint lhs, StatusPoint rhs)
        {
            lhs.Str += rhs.Str;
            lhs.Vit += rhs.Vit;
            lhs.Agi += rhs.Agi;
            lhs.Int += rhs.Int;
            lhs.Dex += rhs.Dex;
            lhs.Luk += rhs.Luk;
            return lhs;
        }
    }
}
