using AutoMapper;
using Achievements.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Achievements.MVC.App_Start;
using Achievements.MVC.ViewModels.Achievement;
using Entities;

namespace Achievements.MVC.Models
{
    public class AchievementsModel
    {
        IAchievementLogic _achievementLogic;
        private IMapper _mapper = AutoMapperConfig.Config.CreateMapper();

        public AchievementsModel(IAchievementLogic achievementLogic)
        {
            _achievementLogic = achievementLogic;
        }

        public IEnumerable<ReadAchievementVM> GetAllAchivements()
        {
            return _mapper.Map<IEnumerable<ReadAchievementVM>>(_achievementLogic.GetAll());
        }

        public void CreateAchivement(CreateAchievementVM achievement)
        {
            _achievementLogic.Add(_mapper.Map<Achievement>(achievement));
        }

        public void RemoveAchivement(int id)
        {
            _achievementLogic.Remove(id);
        }

        public ReadAchievementVM FindId(int id)
        {
            return _mapper.Map<ReadAchievementVM>(_achievementLogic.FindId(id));

        }

        public ReadAchievementVM FindName(string name)
        {
            return _mapper.Map<ReadAchievementVM>(_achievementLogic.FindName(name));

        }

        public IEnumerable<ReadAchievementVM> GetAllUsers(int id)
        {
            return _mapper.Map<IEnumerable<ReadAchievementVM>>(_achievementLogic.GetAllUsers(id));
        }
    }
}