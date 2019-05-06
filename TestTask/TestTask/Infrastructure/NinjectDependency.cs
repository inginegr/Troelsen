using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StoreDataBase;
using StoreDataBase.EntityDataModel;


namespace TestTask.Infrastructure
{
    public class NinjectDependency : IDependencyResolver
    {
        private IKernel kernel;

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            kernel.Bind<IStoreDB>().To<StoreDBEntities>().InSingletonScope();
        }

        public NinjectDependency(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }
    }
}