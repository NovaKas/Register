using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Register.Startup))]
namespace Register
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
