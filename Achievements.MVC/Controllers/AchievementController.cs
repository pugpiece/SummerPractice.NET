using Achievements.BLL;
using Achievements.MVC.Models;
using Achievements.MVC.ViewModels.Achievement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Achievements.MVC.Controllers
{
    public class AchievementController : Controller
    {
        private AchievementsModel _achievementsModel;

        public AchievementController(AchievementsModel achievementsModel)
        {
            _achievementsModel = achievementsModel;
        }

        public AchievementController()
        {
            _achievementsModel = new AchievementsModel(new AchievementLogic());
        }


        public ActionResult GetAchievements()
        {
            var achievements = new SelectList(_achievementsModel.GetAllAchivements(), "Id", "Name", "Description");
            return View(achievements);
        }

        public ActionResult DeleteAchievement(int id)
        {
            _achievementsModel.RemoveAchivement(_achievementsModel.FindId(id));
            return RedirectToAction("GetAchievements");
        }

        public ActionResult AddAchievement(CreateAchievementVM achievement)
        {
            _achievementsModel.CreateAchivement(achievement);
            return RedirectToAction("GetAchievements");
        }


    }
}