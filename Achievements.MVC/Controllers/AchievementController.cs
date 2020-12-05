using Achievements.MVC.Models;
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

        [ChildActionOnly]
        public ActionResult ShowAchievements()
        {
            ViewBag.IdAchievement = new MultiSelectList(_achievementsModel.GetAllAchivements(), "Id", "Name", "Description");
            return PartialView("~/Views/PartialViews/DisplayModelView/_DisplayAuthorsDropDown.cshtml");
        }


    }
}