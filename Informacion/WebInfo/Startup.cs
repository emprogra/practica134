using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebInfo.Startup))]
namespace WebInfo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
