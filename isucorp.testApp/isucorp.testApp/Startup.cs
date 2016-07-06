using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(isucorp.testApp.Startup))]
namespace isucorp.testApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
