using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;

namespace Achievements.DependencyResolver
{
    public class DependencyResolver
    {
        private static NinjectBindings bindings = new NinjectBindings();
        public static StandardKernel Kernel = new StandardKernel(bindings);
    }
}
