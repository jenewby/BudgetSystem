using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BudgetSystem.Startup))]
namespace BudgetSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
