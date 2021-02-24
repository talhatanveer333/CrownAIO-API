using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CrownAIO.Startup))]
namespace CrownAIO
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
