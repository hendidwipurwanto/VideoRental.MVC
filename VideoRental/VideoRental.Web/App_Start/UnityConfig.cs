using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using VideoRental.Repository.IRepositories;
using VideoRental.Repository.Implementations;

namespace VideoRental.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // Repository 
            container.RegisterType<IGenderRepository, GenderRepository>();
            container.RegisterType<IUserDetailRepository, UserDetailRepository>();

            // Service

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}