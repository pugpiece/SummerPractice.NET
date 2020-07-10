﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Achievements.DAL;
using Entities;

namespace Achievements.BLL
{
    public class AchievementLogic : IAchievementLogic
    {
        private IAchievementDao AchievementDao;

        public AchievementLogic()
        {
            AchievementDao = new AchievementDaoDB();
        }

        public void Add(Achievement value)
        {
            AchievementDao.Add(value);
        }

        public Achievement FindId(int index)
        {
            Achievement result = AchievementDao.FindId(index);
            return result;
        }

        public IEnumerable<Achievement> GetAll()
        {
            IEnumerable<Achievement> result = AchievementDao.GetAll();
            return result;
        }

        public void Remove(int index)
        {
            AchievementDao.Remove(index);
        }
    }
}
