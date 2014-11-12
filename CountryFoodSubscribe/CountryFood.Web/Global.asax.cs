namespace CountryFood.Web
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Web;
    using System.Web.Compilation;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;

    using CountryFood.Web.Infrastructure.Mappings;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            BuildManager.GetReferencedAssemblies();

            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var automapperConfig = new AutoMapperConfig(Assembly.GetExecutingAssembly());
            automapperConfig.Execute();
        }
    }
}
