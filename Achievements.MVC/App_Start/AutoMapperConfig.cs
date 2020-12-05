using Achievements.MVC.ViewModels.Achievement;
using Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Achievements.MVC.ViewModels.User;

namespace Achievements.MVC.App_Start
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration Config { get; private set; }
        public static void RegisterMaps()
    {
        Config = new MapperConfiguration(cfg =>
        {

            cfg.CreateMap<CreateAchievementVM, Achievement>();
            cfg.CreateMap<ReadAchievementVM, Achievement>();
            cfg.CreateMap<CreateUserVM, User>();
            cfg.CreateMap<ReadUserVM, User>();

        });
        Config.AssertConfigurationIsValid();
    }
}