using Achievements.BLL;
using Achievements.MVC.Models;
using Achievements.MVC.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Achievements.MVC.Controllers
{
    public class UserController : Controller
    {
        private UsersModel _usersModel;

        public UserController(UsersModel usersModel)
        {
            _usersModel = usersModel;
        }

        public UserController()
        {
            _usersModel = new UsersModel(new UserLogic());
        }


        public ActionResult GetUsers()
        {
            var users = new SelectList(_usersModel.GetAllUsers(), "Id", "Login");
            return View(users);
        }

        public ActionResult DeleteAchievement(int id)
        {
            _usersModel.RemoveUser(_usersModel.FindId(id));
            return RedirectToAction("GetUsers");
        }

        public ActionResult AddAchievement(CreateUserVM user)
        {
            _usersModel.CreateUser(user);
            return RedirectToAction("GetUsers");
        }
    }
}