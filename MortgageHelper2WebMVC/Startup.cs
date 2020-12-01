using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MortgageHelper2WebMVC.Startup))]
namespace MortgageHelper2WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
