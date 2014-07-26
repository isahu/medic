using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MessagingTest.Startup))]
namespace MessagingTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
