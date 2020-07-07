using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Achievements.DAL;
using Entities;

namespace Achievements.BLL
{
    class UserLogic : IUserLogic
    {
        private IUserDao UserDao;

        public UserLogic()
        {
            UserDao = new UserDaoDB();
        }

        public void AddAchievement(int achievementID, int userID)
        {
            UserDao.AddAchievement(achievementID, userID);
        }

        public void AddUser(User value)
        {
            UserDao.AddUser(value);
        }

        public IEnumerable<User> GetAllUsers()
        {
            IEnumerable<User> result = UserDao.GetAllUsers();
            return result;
        }

        public void RemoveUser(int index)
        {
            UserDao.RemoveUser(index);
        }
    }
}
