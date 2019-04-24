using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using EssentialTools.Models;
using Ninject.Web.Common;
using TempLibrary;

namespace EssentialTools.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel krnl)
        {
            kernel = krnl;
            AddBindings();
        }

        private void AddBindings()
        {
            kernel.Bind<IValueCalculator>().To<LinqValueCalculator>().InRequestScope();
            kernel.Bind<IDiscounthelper>().To<DefaultDiscountHelper>().WithPropertyValue("DiscountSize", 40m);
            kernel.Bind<IDiscounthelper>().To<FlexibleDiscountHelper>().WhenInjectedInto<LinqValueCalculator>();
            kernel.Bind<ITestCount>().To<TestCount>().InRequestScope();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
    }
}