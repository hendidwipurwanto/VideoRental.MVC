using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VideoRental.Web.Startup))]
namespace VideoRental.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
