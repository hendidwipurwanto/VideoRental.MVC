using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;

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

            // Service
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}