using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RooStatsSim.DB
{
    class Status
    {
        public Status(int BASE, int STR, int AGI, int VIT, int INT, int DEX, int LUK)
        {

            _str = STR;
            _agi = AGI;
            _vit = VIT;
            _int = INT;
            _dex = DEX;
            _luk = LUK;
        }
        public Status() { }

        public int _base;
        public int _str;
        public int _agi;
        public int _vit;
        public int _int;
        public int _dex;
        public int _luk;
    }
}
