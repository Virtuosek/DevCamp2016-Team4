using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BeeBack.Web.Startup))]
namespace BeeBack.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
