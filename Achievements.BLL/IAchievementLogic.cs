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
        void AddAchievement(Achievement value); //добавить достижение
        IEnumerable<Achievement> GetAllAchievements(); //просмотреть перечень достижений
        void RemoveAchievement(int index); //удалить достижение по индексу
    }
}
