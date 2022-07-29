using RegulusWeb.Domain.Abstract;
using RegulusWeb.Domain.Concrete;
using RegulusWeb.Domain.Entity;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace RegulusWeb.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernel;
        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBindgs();
        }
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)ninjectKernel.Get(controllerType);
        }
        private void AddBindgs()
        {
            ninjectKernel.Bind<IUser>().To<EFUserRepository>();
            ninjectKernel.Bind<IMessage>().To<EFMessageRepository>();
        }
    }
}