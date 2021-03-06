﻿using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using RooStatsSim.DB;
using RooStatsSim.DB.Table;

namespace RooStatsSim.User
{
    [Serializable]
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

    [Serializable]
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

    [Serializable]
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

    [Serializable]
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
        public ObservableCollection<StatPoint> List { get; set; }
        public STATUS()
        {
            List = new ObservableCollection<StatPoint>();
            List.CollectionChanged += OnListChanged;

            foreach (string stats_name in Enum.GetNames(typeof(STATUS_ENUM)))
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
        public int GetStatus(STATUS_ENUM status_name)
        {
            return List[(int)status_name].Point + List[(int)status_name].AddPoint;
        }
        public void SetAddStatus(ItemDB db)
        {
            List[(int)STATUS_ENUM.STR].AddPoint = (int)db.Option_ITYPE[Enum.GetName(typeof(ITYPE), ITYPE.STR)];
            List[(int)STATUS_ENUM.AGI].AddPoint = (int)db.Option_ITYPE[Enum.GetName(typeof(ITYPE), ITYPE.AGI)];
            List[(int)STATUS_ENUM.VIT].AddPoint = (int)db.Option_ITYPE[Enum.GetName(typeof(ITYPE), ITYPE.VIT)];
            List[(int)STATUS_ENUM.DEX].AddPoint = (int)db.Option_ITYPE[Enum.GetName(typeof(ITYPE), ITYPE.DEX)];
            List[(int)STATUS_ENUM.INT].AddPoint = (int)db.Option_ITYPE[Enum.GetName(typeof(ITYPE), ITYPE.INT)];
            List[(int)STATUS_ENUM.LUK].AddPoint = (int)db.Option_ITYPE[Enum.GetName(typeof(ITYPE), ITYPE.LUK)];
        }
    }
}
