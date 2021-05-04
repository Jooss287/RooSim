using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RooStatsSim.DB.Abilitys
{
    public class StatusPoint
    {
        public int _point = 0;
        
        public int Point {
            get {
                return _point;
            }
            set
            {
                if (value < 0)
                    return;
                _point = value;
            }
        }
    }
}
