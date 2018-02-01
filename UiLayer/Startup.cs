using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UiLayer.Startup))]
namespace UiLayer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
