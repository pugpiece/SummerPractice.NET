using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Achievements.DAL
{
    public interface IUserDao
    {
        void AddUser(User value); //добавить пользователя
        IEnumerable<User> GetAllUsers(); //просмотреть перечень пользователей
        void RemoveUser(int index); //удалить пользователя по индексу
        void AddAchievement(int achievementID, int userID); //добавить пользователю достижение
    }
}
