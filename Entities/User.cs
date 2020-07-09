﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class User
    {
        public int id { get; set; }
        public string login { get; set; }
        public int password { get; set; }
        public List<int> AchievementsId { get; set; }

        public User() { AchievementsId = new List<int>(); }

        public User(string login, string password)
        {
            this.login = login;
            this.password = password.GetHashCode();
            AchievementsId = new List<int>();
        }

        public User(int id, string login)
        {
            this.id = id;
            this.login = login;
            AchievementsId = new List<int>();
        }


    }
}
