using System;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using PirateThis.Domain.Entities;
using PirateThis.Domain.Abstract;
using System.Collections.Generic;
using System.Linq;
using Moq;
using PirateThis.Domain.Concrete;
using PirateThis.WebUI.Infrastructure.Abstract;
using PirateThis.WebUI.Infrastructure.Concrete;

namespace PirateThis.WebUI.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernel;

        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)ninjectKernel.Get(controllerType);
        }

        private void AddBindings()
        {
            ninjectKernel.Bind<ISongRepository>().To<EFSongRepository>();

            ninjectKernel.Bind<ICommentRepository>().To<EFCommentRepository>();

            ninjectKernel.Bind<IAuthProvider>().To<FormsAuthProvider>();
        }
    }
}