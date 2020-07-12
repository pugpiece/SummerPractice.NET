using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Achievements.BLL
{
    public interface IAchievementLogic
    {
        void Add(Achievement value); //добавить достижение
        IEnumerable<Achievement> GetAll(); //просмотреть перечень достижений
        void Remove(int index); //удалить достижение по индексу
        Achievement FindId(int index); //найти по индексу
        Achievement FindName(string name); //найти по индексу
        IEnumerable<Achievement> GetAllUsers(int index); //просмотреть перечень достижений определенного пользователя

    }
}
