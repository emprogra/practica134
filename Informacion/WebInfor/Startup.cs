using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebInfor.Startup))]
namespace WebInfor
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
