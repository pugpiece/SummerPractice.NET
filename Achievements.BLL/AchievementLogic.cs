using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Achievements.DAL;
using Entities;

namespace Achievements.BLL
{
    class AchievementLogic : IAchievementLogic
    {
        private IAchievementDao AchievementDao;

        public AchievementLogic()
        {
            AchievementDao = new AchievementDaoDB();
        }

        public void AddAchievement(Achievement value)
        {
            AchievementDao.AddAchievement(value);
        }

        public IEnumerable<Achievement> GetAllAchievements()
        {
            IEnumerable<Achievement>  result = AchievementDao.GetAllAchievements();
            return result;
        }

        public void RemoveAchievement(int index)
        {
            AchievementDao.RemoveAchievement(index);
        }
    }
}
