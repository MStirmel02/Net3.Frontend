using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Net3.Frontend.Startup))]
namespace Net3.Frontend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
