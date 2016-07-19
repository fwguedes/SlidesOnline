using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SlidesOnline.Startup))]
namespace SlidesOnline
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
