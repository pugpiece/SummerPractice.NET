using AutoMapper;
using Achievements.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Achievements.MVC.App_Start;
using Achievements.MVC.ViewModels.Achievement;
using Entities;
using Achievements.MVC.ViewModels.User;

namespace Achievements.MVC.Models
{
    public class UsersModel
    {
        IUserLogic _userLogic;
        private IMapper _mapper = AutoMapperConfig.Config.CreateMapper();

        public UsersModel(IUserLogic userLogic)
        {
            _userLogic = userLogic;
        }
        public IEnumerable<ReadUserVM> GetAllUsers()
        {
            return _mapper.Map<IEnumerable<ReadUserVM>>(_userLogic.GetAll());
        }

        public void CreateUser(CreateUserVM user)
        {
            _userLogic.Add(_mapper.Map<User>(user));
        }

        public void RemoveUser(ReadUserVM user)
        {
            _userLogic.Remove(_mapper.Map<User>(user).id);
        }

        public bool Log(ReadUserVM user)
        {
            return _userLogic.Log(_mapper.Map<User>(user));
        }
        public ReadUserVM FindId(int id)
        {
            return _mapper.Map<ReadUserVM>(_userLogic.FindId(id));

        }

        public ReadUserVM FindLogin(string name)
        {
            return _mapper.Map<ReadUserVM>(_userLogic.FindLogin(name));

        }
    }
}