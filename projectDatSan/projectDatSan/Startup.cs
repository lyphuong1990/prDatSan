using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(projectDatSan.Startup))]
namespace projectDatSan
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
