using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HSBC.Startup))]
namespace HSBC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
