using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Achievements.DAL;
using Achievements.DAL.Interfaces;
using Entities;

namespace Achievements.BLL
{
    public class AchievementLogic : IAchievementLogic
    {
        private IAchievementDao AchievementDao;
        private IUtoADao UtoADao;

        public AchievementLogic()
        {
            AchievementDao = new AchievementDaoDB();
            UtoADao = new UtoADaoDB();
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

        public Achievement FindName(string name)
        {
            Achievement result = AchievementDao.FindName(name);
            return result;
        }

        public IEnumerable<Achievement> GetAll()
        {
            IEnumerable<Achievement> result = AchievementDao.GetAll();
            return result;
        }

        public IEnumerable<Achievement> GetAllUsers(int index)
        {
            IEnumerable<Achievement> result = AchievementDao.GetAllUsers(index);
            return result;
        }

        public void Remove(int index)
        {
            UtoADao.RemoveAchievement(index);
            AchievementDao.Remove(index);
        }
    }
}
