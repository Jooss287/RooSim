using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RooStatsSim.DB
{
    class MonsterDB
    {
        int _mob_id;
        string _name;
        int _atk;
        int _matk;
        int _hp;
        int _def;
        int _mdef;
        int _hit;
        int _flee;

        public int MobId
        {
            get { return _mob_id; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public int Atk
        {
            get { return _atk; }
            set { _atk = value; }
        }
        public int Matk
        {
            get { return _matk; }
            set { _matk = value; }
        }
        public int Hp
        {
            get { return _hp; }
            set { _hp = value; }
        }
        public int Def
        {
            get { return _def; }
            set { _def= value; }
        }
        public int Mdef
        {
            get { return _mdef; }
            set { _mdef = value; }
        }
        public int Hit
        {
            get { return _hit; }
            set { _hit = value; }
        }
        public int Flee
        {
            get { return _flee; }
            set { _flee = value; }
        }
    }
}
