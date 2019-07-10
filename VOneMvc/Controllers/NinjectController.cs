using System;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using VOneBusiness.Interfaces;
using VOneBusiness.Services;
using VOneBussines.Interfaces;
using VOneBussines.Services;

namespace VOneMvc.Controllers
{
    public class NinjectController : DefaultControllerFactory
    {
        private IKernel ninjectKernel;

        public NinjectController()
        {
            ninjectKernel = new StandardKernel();
            AddBinding();
        }

        void AddBinding()
        {
            ninjectKernel.Bind<IProductBusiness>().To<ProductBusiness>();
            ninjectKernel.Bind<IUserBusiness>().To<UserBusiness>();
            ninjectKernel.Bind<ITraktBusiness>().To<TraktBusiness>();

        }


        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)ninjectKernel.Get(controllerType);
        }

    }
}