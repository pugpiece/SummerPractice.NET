using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Achievements.DAL.Interfaces
{
    public interface IUtoADao
    {
        void Add(int idUser, int idAchievement); //добавить человеку достижение
        void Remove(int idUser, int idAchievement); //убрать у человека достижение
        void RemoveUser(int idUser); //убрать все записи о человеке
        void RemoveAchievement(int idAchievement); //убрать все записи о достижении
    }
}
