using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SearchAndSaveRecipes.Startup))]
namespace SearchAndSaveRecipes
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
