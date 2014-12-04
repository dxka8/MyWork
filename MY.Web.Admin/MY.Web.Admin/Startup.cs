using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MY.Web.Admin.Startup))]
namespace MY.Web.Admin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
