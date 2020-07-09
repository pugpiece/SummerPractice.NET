using Achievements.BLL.Interfaces;
using Achievements.DAL;
using Achievements.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Achievements.BLL
{
    class UtoALogic : IUtoALogic
    {
        private IUtoADao UtoADao;

        public UtoALogic()
        {
            UtoADao = new UtoADaoDB();
        }

        public void Add(int idUser, int idAchievement)
        {
            UtoADao.Add(idUser, idAchievement);
        }

        public void Remove(int idUser, int idAchievement)
        {
            UtoADao.Remove(idUser, idAchievement);
        }

        public void RemoveAchievement(int idAchievement)
        {
            UtoADao.RemoveAchievement(idAchievement);
        }

        public void RemoveUser(int idUser)
        {
            UtoADao.RemoveUser(idUser);
        }
    }
}
