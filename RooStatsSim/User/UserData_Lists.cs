using RooStatsSim.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace RooStatsSim.User
{
    public class ABILITTY<T> where T : struct
    {
        public T Point;
        public T AddPoint;
        public ABILITTY() { Point = default(T); AddPoint = default(T); }
    }

    public class LEVEL : List<ABILITTY<int>>
    {
        public LEVEL()
        {
            Add(new ABILITTY<int>());  //BASE
            Add(new ABILITTY<int>());
            Add(new ABILITTY<int>());  //JOB
            Add(new ABILITTY<int>());
        }
    }

    public class STATUS : List<ABILITTY<int>>
    {
        public STATUS()
        {
            Add(new ABILITTY<int>());  //STR
            Add(new ABILITTY<int>());
            Add(new ABILITTY<int>());
            Add(new ABILITTY<int>());
            Add(new ABILITTY<int>());
            Add(new ABILITTY<int>());  //LUK
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
        int _level;
        public int Level 
        { 
            get { return _level; } 
            set
            {
                if (MainWindow._roo_db == null)
                {
                    _level = 0;
                    return;
                }
                if ( (value <= MainWindow._roo_db._monster_research_db.Count) &&
                    (value >= 0) )
                    _level = value;
            }
        }
        public MONSTER_RESEARCH() { Level = 0; }
        public ItemDB GetOption()
        {
            ItemDB option = new ItemDB();
            for (int i = 0; i <= Level; i++)
            {
                option += MainWindow._roo_db._monster_research_db[i];
            }
            return option;
        }
    }
    public class DRESS_STYLE
    {
        int _level;
        public int Level {
            get { return _level; } 
            set
            {
                if (MainWindow._roo_db == null)
                {
                    _level = 0;
                    return;
                }
                if ((value <= MainWindow._roo_db._dress_style_db.Count) &&
                    (value >= 0))
                    _level = value;
            }
        }
        public DRESS_STYLE() { Level = 0; }
        public ItemDB GetOption()
        {
            ItemDB option = new ItemDB();
            for (int i = 0; i <= Level; i++)
            {
                option += MainWindow._roo_db.Dress_style_db[i];
            }
            return option;
        }
    }
    public class STICKER
    {
        int _level;
        public int Level {
            get { return _level; }
            set
            {
                if (MainWindow._roo_db == null)
                {
                    _level = 0;
                    return;
                }
                if ((value <= MainWindow._roo_db._sticker_db.Count) &&
                    (value >= 0))
                    _level = value;
            }
        }
        public STICKER() { Level = 0; }
        public ItemDB GetOption()
        {
            ItemDB option = new ItemDB();
            for( int i = 0; i <= Level; i++)
            {
                option += MainWindow._roo_db.Sticker_db[i];
            }
            return option;
        }
    }
    public class RIDING : List<int>
    {
        public RIDING()
        {
            foreach (string riding_name in Enum.GetNames(typeof(RIDING_ENUM)))
            {
                Add(0);
            }
        }
    }
}
