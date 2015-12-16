using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JeuDeNim.Startup))]
namespace JeuDeNim
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
