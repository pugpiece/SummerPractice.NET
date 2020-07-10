using Achievements.DAL.Interfaces;
using Achievements.DAL;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Achievements.BLL.Interfaces;
using Achievements.BLL;

namespace Achievements.DependencyResolver
{
    public class NinjectBindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IUtoADao>().To<UtoADaoDB>();
            Bind<IAchievementDao>().To<AchievementDaoDB>();
            Bind<IUserDao>().To<UserDaoDB>();

            Bind<IUtoALogic>().To<UtoALogic>();
            Bind<IAchievementLogic>().To<AchievementLogic>();
            Bind<IUserLogic>().To<UserLogic>();
        }
    }
}
