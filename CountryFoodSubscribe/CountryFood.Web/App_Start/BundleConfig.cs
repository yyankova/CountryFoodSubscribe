using System.Web;
using System.Web.Optimization;

namespace CountryFood.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            BundleScripts(bundles);
            BundleStyles(bundles);

            bundles.IgnoreList.Clear();

            // Set EnableOptimizations to false for debugging. For more information,
            // visit http://go.microsoft.com/fwlink/?LinkId=301862
            BundleTable.EnableOptimizations = true;
        }

        private static void BundleScripts(BundleCollection bundles)
        {
            bundles.Add(new 
                ScriptBundle("~/bundles/jquery").Include(
                //      "~/Scripts/jquery-{version}.js",
                       "~/Scripts/Kendo/jquery.min.js"
                        ));

            bundles.Add(new
                ScriptBundle("~/bundles/jquery-unobtrusive").Include(
                "~/Scripts/jquery.unobtrusive-ajax.js"));

            bundles.Add(new
               ScriptBundle("~/bundles/kendo").Include(
                        "~/Scripts/kendo/kendo.all.min.js",
                        "~/Scripts/kendo/kendo.aspnetmvc.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));
        }

        private static void BundleStyles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.cerulean.css",
                      "~/Content/site.css"));

            bundles.Add(new
               StyleBundle("~/Content/kendo").Include(
                        "~/Content/kendo/kendo.common-bootstrap.min.css",
                        "~/Content/kendo/kendo.default.min.css"));

        }
    }
}
