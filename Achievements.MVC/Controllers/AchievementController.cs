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


        public ActionResult GetAll()
        {
            return View("~/Views/Achievement/GetAll.cshtml", _achievementsModel.GetAllAchivements());
        }

        public ActionResult Create()
        {
            return View("Create", new CreateAchievementVM());
        }

        [HttpPost]

        public ActionResult Create(CreateAchievementVM user)
        {
            _achievementsModel.CreateAchivement(user);
            return RedirectToAction("GetAll");
        }

        public ActionResult Delete(int id)
        {
            _achievementsModel.RemoveAchivement(id);
            return RedirectToAction("GetAll");
        }

        public ActionResult FindId(int id)
        {
            var user = _achievementsModel.FindId(id);
            return View(user);
        }


    }
}