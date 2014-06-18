using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MedicMvc.Startup))]
namespace MedicMvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
