using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Iteration1.Startup))]
namespace Iteration1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
