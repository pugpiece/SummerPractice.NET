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

                cfg.CreateMap<CreateAchievementVM, Achievement>()
                    .ForMember(dest => dest.id, src => src.Ignore());
                cfg.CreateMap<Achievement, ReadAchievementVM>();

                cfg.CreateMap<CreateUserVM, User>()
                    .ForMember(dest => dest.id, src => src.Ignore())
                    .ForMember(dest => dest.AchievementsId, src => src.Ignore());
                cfg.CreateMap<User, ReadUserVM>();


            });
            Config.AssertConfigurationIsValid();
        }
    }
}