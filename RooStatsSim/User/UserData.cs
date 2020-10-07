using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RooStatsSim.User
{
    // User data singleton design pattern
    public sealed class UserData
    {
        private UserData() { }
        private static UserData _instance = null;
        public static UserData GetInstance
        {
            get
            {
                if (_instance == null)
                    _instance = new UserData();
                return _instance;
            }
        }

        public Level Level = new Level();
        public Status Status = new Status();
    }
}
