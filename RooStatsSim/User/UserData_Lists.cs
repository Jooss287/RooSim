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

    public class LEVEL : List<ABILITTY>
    {
        public LEVEL()
        {
            Add(new ABILITTY());  //BASE
            Add(new ABILITTY());
            Add(new ABILITTY());  //JOB
            Add(new ABILITTY());
        }
    }

    public class STATUS : List<ABILITTY>
    {
        public STATUS()
        {
            Add(new ABILITTY());  //STR
            Add(new ABILITTY());
            Add(new ABILITTY());
            Add(new ABILITTY());
            Add(new ABILITTY());
            Add(new ABILITTY());  //LUK
        }
    }

    public class MEDAL : List<int>
    {
        public MEDAL()
        {
            foreach(string medal_name in Enum.GetNames(typeof(MEDAL_ENUM)))
            {
                Add(0);
            }
        }
    }

    public class MONSTER_RESEARCH
    {
        public int Level { get; set; }
        public MONSTER_RESEARCH() { Level = 0; }
    }
    public class DRESS_STYLE
    {
        public int Level { get; set; }
        public DRESS_STYLE() { Level = 0; }
    }
    public class STICKER
    {
        public int Level { get; set; }
        public STICKER() { Level = 0; }
    }
}
