using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

using RooStatsSim.DB;
using RooStatsSim.DB.Table;

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

    public class MEDAL
    {
        public ObservableCollection<int> List { get; }
        
        public MEDAL()
        {
            List = new ObservableCollection<int>();
            List.CollectionChanged += OnListChanged;

            foreach(string medal_name in Enum.GetNames(typeof(MEDAL_ENUM)))
            {
                List.Add(0);
            }
        }

        private void OnListChanged(object sender, NotifyCollectionChangedEventArgs args)
        {
            if ( Convert.ToInt32(args.NewItems[0]) < 0)
            {
                List[args.NewStartingIndex] = Convert.ToInt32(args.OldItems[0]);
            }
        }
        public ItemDB GetOption()
        {
            ItemDB option = new ItemDB();
            int atk = 0;
            double hp = 0.0;
            double damage = 0.0;

            for (int i = 0; i < List[(int)MEDAL_ENUM.VALOR]; i++)
                atk += MedalTable.Get_ATK_MATK(i);
            option.i_option[ITYPE.ATK] = atk;
            option.i_option[ITYPE.MATK] = atk;

            for (int i = 0; i <= List[(int)MEDAL_ENUM.GUARDIAN]; i++)
            {
                hp += MedalTable.Get_MaxHP(i);
                damage += MedalTable.Get_P_M_Damage(i);
            }
            option.i_option[ITYPE.HP] = (int)hp;
            option.d_option[DTYPE.PHYSICAL_DAMAGE] = damage;

            hp = 0;
            damage = 0.0;
            for (int i = 0; i <= List[(int)MEDAL_ENUM.WISDOM]; i++)
            {
                hp += MedalTable.Get_MaxHP(i);
                damage += MedalTable.Get_P_M_Damage(i);
            }
            option.i_option[ITYPE.HP] += (int)hp;
            option.d_option[DTYPE.MAGICAL_DAMAGE] = damage;

            damage = 0.0;
            for (int i = 0; i <= List[(int)MEDAL_ENUM.CHARM]; i++)
                damage += MedalTable.Get_Dec_Damage(i);
            option.d_option[DTYPE.PHYSICAL_DEC_DAMAGE] = damage;

            damage = 0.0;
            for (int i = 0; i <= List[(int)MEDAL_ENUM.GALE]; i++)
                damage += MedalTable.Get_Dec_Damage(i);
            option.d_option[DTYPE.MAGICAL_DEC_DAMAGE] = damage;

            return option;
        }
    }

    public class RIDING
    {
        public ObservableCollection<double> List { get; }
        public RIDING()
        {
            List = new ObservableCollection<double>();
            List.CollectionChanged += OnListChanged;

            foreach (string riding_name in Enum.GetNames(typeof(RIDING_ENUM)))
            {
                List.Add(0);
            }
        }
        private void OnListChanged(object sender, NotifyCollectionChangedEventArgs args)
        {
            if (Convert.ToInt32(args.NewItems[0]) < 0)
            {
                List[args.NewStartingIndex] = Convert.ToInt32(args.OldItems[0]);
            }
        }

        public ItemDB GetOption()
        {
            ItemDB option = new ItemDB();

            option.i_option[ITYPE.ATK] = (int)List[(int)RIDING_ENUM.ATK_MATK];
            option.i_option[ITYPE.MATK] = (int)List[(int)RIDING_ENUM.ATK_MATK];

            option.i_option[ITYPE.HP] = (int)List[(int)RIDING_ENUM.MAX_HP];
            
            option.d_option[DTYPE.ATK_P] = List[(int)RIDING_ENUM.ATK_MATK_PERCENT];
            option.d_option[DTYPE.MATK_P] = List[(int)RIDING_ENUM.ATK_MATK_PERCENT];

            return option;
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
                if ( (value < MainWindow._roo_db._monster_research_db.Count) &&
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
                if ((value < MainWindow._roo_db._dress_style_db.Count) &&
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
                if ((value < MainWindow._roo_db._sticker_db.Count) &&
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
    
}
