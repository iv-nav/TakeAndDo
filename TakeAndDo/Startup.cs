using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TakeAndDo.Startup))]
namespace TakeAndDo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
