using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RooStatsSim.User
{
    public class ABILITTY
    {
        public int Point;
        public int AddPoint;
        public ABILITTY() { Point = 1; AddPoint = 0; }
    }

    public class Level : List<ABILITTY>
    {
        public Level()
        {
            Add(new ABILITTY());  //BASE
            Add(new ABILITTY());
            Add(new ABILITTY());  //JOB
            Add(new ABILITTY());
        }
    }

    public class Status : List<ABILITTY>
    {
        public Status()
        {
            Add(new ABILITTY());  //STR
            Add(new ABILITTY());
            Add(new ABILITTY());
            Add(new ABILITTY());
            Add(new ABILITTY());
            Add(new ABILITTY());  //LUK
        }
    }

    
}
