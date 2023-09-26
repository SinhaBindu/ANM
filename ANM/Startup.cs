using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ANM.Startup))]
namespace ANM
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
