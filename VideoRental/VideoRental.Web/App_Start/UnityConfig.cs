using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using VideoRental.Repository.Interfaces;
using VideoRental.Repository.Implementations;
using VideoRental.Service.Interfaces;
using VideoRental.Service.Implementations;
using VideoRental.Web.DbContext;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using VideoRental.Web.Controllers;

namespace VideoRental.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            container.RegisterType<System.Data.Entity.DbContext, ApplicationDbContext>(new HierarchicalLifetimeManager());
            container.RegisterType<UserManager<ApplicationUser>>(new HierarchicalLifetimeManager());
            container.RegisterType<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>(new HierarchicalLifetimeManager());
            container.RegisterType<AccountController>(new InjectionConstructor());

            // Repository 
            container.RegisterType<IGenderRepository, GenderRepository>();
            container.RegisterType<IUserDetailRepository, UserDetailRepository>();

            // Service
            container.RegisterType<IUserDetailService, UserDetailService>();
            container.RegisterType<IGenderService, GenderService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}