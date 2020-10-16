using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using RooStatsSim.DB;
using RooStatsSim.DB.Table;

namespace RooStatsSim.User
{
    public class ABILITTY<T> where T : struct
    {
        public T _point;
        public T _add_point;

        public T Point
        {
            get { return _point; }
            set
            {
                if (Convert.ToInt32(value) >= 0)
                    _point = value;
            }
        }
        public T AddPoint
        {
            get { return _add_point; }
            set
            {
                //if (Convert.ToInt32(value) >= 0)
                    _add_point = value;
            }
        }
        public ABILITTY() { Point = default(T); AddPoint = default(T); }
    }

    public class BASE_LEVEL
    {
        int _point = 1;
        int _remain_point = 0;
        public int Point
        {
            get { return _point; }
            set
            {
                if (value <= 0)
                    return;
                
                if ( _point < value)
                    RemainPoint += StatsPointTable.LevelChangeStatusPoint(_point, value);
                else
                    RemainPoint -= StatsPointTable.LevelChangeStatusPoint(value, _point);
                _point = value;
            }
        }
        public int RemainPoint
        {
            get { return _remain_point; }
            set {
                _remain_point = value;
            }
        }
    }

    public class JOB_LEVEL
    {
        int _point = 1;
        int _remain_point = 0;
        public int Point
        {
            get { return _point; }
            set
            {
                if (value > 0)
                    _point = value;
            }
        }
        public int RemainPoint
        {
            get { return _remain_point; }
            set
            {
                _remain_point = value;
            }
        }
    }

    public class STATUS
    {
        public class StatPoint
        {
            int _point = 1;
            int _add_point = 0;
            int _necessary_point = 2;
            public int Point
            {
                get { return _point; }
                set
                {
                    if (value > 0)
                    {
                        _point = value;
                        _necessary_point = StatsPointTable.StatNecessaryPoint(_point);
                    }
                }
            }
            public int AddPoint
            {
                get { return _add_point; }
                set
                {
                    if (value > 0)
                        _add_point = value;
                }
            }
            public int NecessaryPoint
            {
                get { return _necessary_point; }
                set
                {
                    _necessary_point = value;
                }
            }
        }
        public ObservableCollection<StatPoint> List { get; }
        public STATUS()
        {
            List = new ObservableCollection<StatPoint>();
            List.CollectionChanged += OnListChanged;

            foreach (string medal_name in Enum.GetNames(typeof(STATUS_ENUM)))
            {
                List.Add(new StatPoint());
            }
        }
        private void OnListChanged(object sender, NotifyCollectionChangedEventArgs args)
        {
            //if (Convert.ToInt32(args.NewItems[0]) < 0)
            //{
            //    List[args.NewStartingIndex] = Convert.ToInt32(args.OldItems[0]);
            //}
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
