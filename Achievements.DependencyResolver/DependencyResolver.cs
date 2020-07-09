using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Achievements.DependencyResolver
{
    class DependencyResolver
    {
        private static NinjectBindings bindings = new NinjectBindings();
        public static StandardKernel Kernel = new StandardKernel(_bindings);
    }
}
