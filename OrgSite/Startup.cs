using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OrgSite.Startup))]
namespace OrgSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
