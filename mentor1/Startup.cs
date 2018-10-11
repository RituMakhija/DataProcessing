using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(mentor1.Startup))]
namespace mentor1
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
