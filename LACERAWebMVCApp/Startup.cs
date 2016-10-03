using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LACERAWebMVCApp.Startup))]
namespace LACERAWebMVCApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
