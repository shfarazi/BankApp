using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BankApp.UI.Startup))]
namespace BankApp.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
