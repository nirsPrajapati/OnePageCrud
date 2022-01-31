using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(onePageCrudAjax.Startup))]
namespace onePageCrudAjax
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
