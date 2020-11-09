using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RooStatsSim.DB
{
    public class Status
    {
        int _base;
        int _job;
        int _str;
        int _agi;
        int _vit;
        int _int;
        int _dex;
        int _luk;
        public int Base
        {
            get { return _base; }
            set { _base = value; }
        }
        public int Job
        {
            get { return _job; }
            set { _job = value; }
        }
        public int Str
        {
            get { return _str; }
            set { _str = value; }
        }
        public int Agi
        {
            get { return _agi; }
            set { _agi = value; }
        }
        public int Vit
        {
            get { return _vit; }
            set { _vit = value; }
        }
        public int Int
        {
            get { return _int; }
            set { _int = value; }
        }
        public int Dex
        {
            get { return _dex; }
            set { _dex = value; }
        }
        public int Luk
        {
            get { return _luk; }
            set { _luk = value; }
        }

        public Status() { }
        public Status(int BASE, int JOB, int STR, int AGI, int VIT, int INT, int DEX, int LUK)
        {
            _base = BASE;
            _job = JOB;
            _str = STR;
            _agi = AGI;
            _vit = VIT;
            _int = INT;
            _dex = DEX;
            _luk = LUK;
        }

        
    }
}
