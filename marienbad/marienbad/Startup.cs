using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(marienbad.Startup))]
namespace marienbad
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
