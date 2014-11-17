using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CountryFood.Web.Startup))]

namespace CountryFood.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}
