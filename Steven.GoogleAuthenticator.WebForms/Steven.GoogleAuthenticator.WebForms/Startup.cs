using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Steven.GoogleAuthenticator.WebForms.Startup))]
namespace Steven.GoogleAuthenticator.WebForms
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
