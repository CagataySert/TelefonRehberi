using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using TelefonReberiBLL.Abstract;
using TelefonReberiBLL.Concrete;
using TelefonRehberiDAL.EfDal.Concrete;

namespace TelefonRehberiUI.NinjectController
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private readonly IKernel ninjectKernel;

        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBllBindings();
        }

        private void AddBllBindings()
        {
            ninjectKernel.Bind<IEmployeeService>()
                .To<EmployeeManager>()
                .WithConstructorArgument("employeeDal",EfEmployeeDal.CreateAsSingleton());

            ninjectKernel.Bind<IManagerService>()
                .To<ManagerManager>()
                .WithConstructorArgument("managerDal", EfManagerDal.CreateAsSingleton());

            ninjectKernel.Bind<IDepartmentService>()
                .To<DepartmentManager>()
                .WithConstructorArgument("departmentDal", EfDepartmentDal.CreateAsSingleton());
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)ninjectKernel.Get(controllerType);
        }
    }
}