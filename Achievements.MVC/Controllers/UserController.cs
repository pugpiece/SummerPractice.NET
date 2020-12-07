using Achievements.BLL;
using Achievements.MVC.Models;
using Achievements.MVC.ViewModels.User;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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


        public ActionResult GetAll()
        {
            return View("~/Views/User/GetAll.cshtml", _usersModel.GetAllUsers());
        }

        public ActionResult Create()
        {
            return View("Create", new CreateUserVM());
        }

        [HttpPost]

        public ActionResult Create(CreateUserVM user)
        {
            _usersModel.CreateUser(user);
            return RedirectToAction("GetAll");
        }

        public ActionResult Delete(int id)
        {
            _usersModel.RemoveUser(id);
            return RedirectToAction("GetAll");
        }

        public ActionResult FindId(int id)
        {
            var user = _usersModel.FindId(id);
            return View(user);
        }

        public ActionResult FindLogin(string login)
        {
            var user = _usersModel.FindLogin(login);
            return View(user);
        }
    }
}