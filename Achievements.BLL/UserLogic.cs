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
    public class UserLogic : IUserLogic
    {
        private IUserDao UserDao;
        private IUtoADao UtoADao;

        public UserLogic()
        {
            UserDao = new UserDaoDB();
            UtoADao = new UtoADaoDB();
        }

        public void Add(User value)
        {
            UserDao.Add(value);
        }

        public User FindId(int id)
        {
            User result = UserDao.FindId(id);
            return result;
        }

        public User FindLogin(string login)
        {
            User result = UserDao.FindLogin(login);
            return result;
        }

        public IEnumerable<User> GetAll()
        {
            IEnumerable<User> result = UserDao.GetAll();
            return result;
        }

        public bool Log(User value)
        {
            bool result = UserDao.Log(value);
            return result;
        }

        public void Remove(int index)
        {
            UtoADao.RemoveUser(index);
            UserDao.Remove(index);
        }
    }
}
