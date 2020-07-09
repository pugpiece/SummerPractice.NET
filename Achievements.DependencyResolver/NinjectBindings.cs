using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Achievements.DependencyResolver
{
    public class NinjectBindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IUtoADao>().To<UtoADao>();
            Bind<IAchievementDao>().To<AchievementDao>();
            Bind<IUserDao>().To<UserDao>();

            Bind<IUtoALogic>().To<UtoALogic>();
            Bind<IAchievementLogic>().To<AchievementLogic>();
            Bind<IUserLogic>().To<UserLogic>();
        }
    }
}
