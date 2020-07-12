using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Achievements.DAL
{
    public interface IAchievementDao
    {
        void Add(Achievement value); //добавить достижение
        IEnumerable<Achievement> GetAll(); //просмотреть перечень достижений
        void Remove(int index); //удалить достижение по индексу
        Achievement FindId(int index); //найти по индексу
        Achievement FindName(string index); //найти по индексу
        IEnumerable<Achievement> GetAllUsers(int index); //просмотреть перечень достижений определенного пользователя

    }
}
