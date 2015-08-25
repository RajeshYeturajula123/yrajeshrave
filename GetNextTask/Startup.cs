using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GetNextTest1.Startup))]
namespace GetNextTest1
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
