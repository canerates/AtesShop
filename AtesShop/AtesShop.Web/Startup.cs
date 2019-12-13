using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AtesShop.Web.Startup))]
namespace AtesShop.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
