using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TixFix.WebMVC.Startup))]
namespace TixFix.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
