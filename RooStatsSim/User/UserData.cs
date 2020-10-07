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
                { 
                    _instance = new UserData();
                }
                return _instance;
            }
        }

        public Level Level = new Level();
        public Status Status = new Status();
        public List<int> Madel = new List<int>();
        public int Monster_Research { get; set; }
        public int Dress_Style { get; set; }
        public int Sticker { get; set; }
    }
}
