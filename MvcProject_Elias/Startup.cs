using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcProject_Elias.Startup))]
namespace MvcProject_Elias
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
