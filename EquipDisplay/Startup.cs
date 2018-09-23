using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EquipDisplay.Startup))]
namespace EquipDisplay
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
