using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RooStatsSim.AbstractClass
{
    class AbilityInfo
    {
        protected string _name;
        protected int _point;
        protected int _add_point;

        public AbilityInfo() { }
        public AbilityInfo(ref AbilityInfo param_ability)
        {
            Name = param_ability.Name;
            Point = param_ability.Point;
            AddPoint = param_ability.AddPoint;
        }
        public AbilityInfo(string name, ref int point, ref int add_point)
        {
            _name = name;
            _point = point;
            _add_point = add_point;
        }
        public AbilityInfo(string name, int point, int add_point)
        {
            _name = name;
            _point = point;
            _add_point = add_point;
        }


        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public int Point
        {
            get { return _point; }
            set { _point= value; }
        }
        public int AddPoint
        {
            get { return _add_point; }
            set { _add_point= value; }
        }
    }
}
