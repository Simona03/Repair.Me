using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FixMeApplication.Startup))]
namespace FixMeApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
