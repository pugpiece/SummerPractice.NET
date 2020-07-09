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
        void Add(User value); //добавить пользователя
        IEnumerable<User> GetAll(); //просмотреть перечень пользователей
        void Remove(int index); //удалить пользователя по индексу
        bool Log(User value); //проверка логина и пароля
        User FindLogin(string login); //найти по логину
        User FindId(int id); //найти по id

    }
}
