namespace CountryFood.Web
{
    using System.Web;
    using System.Web.Optimization;

    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.IgnoreList.Clear();

            BundleScripts(bundles);
            BundleStyles(bundles);

            BundleTable.EnableOptimizations = true;
        }

        private static void BundleScripts(BundleCollection bundles)
        {
            bundles.Add(new 
                ScriptBundle("~/bundles/jquery").Include(
                       "~/Scripts/kendo/jquery.min.js"));

            bundles.Add(new
                ScriptBundle("~/bundles/jquery-unobtrusive").Include(
                "~/Scripts/jquery.unobtrusive-ajax.js"));

            bundles.Add(new
               ScriptBundle("~/bundles/kendo-scripts").Include(
                        "~/Scripts/kendo/kendo.all.min.js",
                        "~/Scripts/kendo/kendo.aspnetmvc.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));
        }

        private static void BundleStyles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.cerulean.css"));

            bundles.Add(new StyleBundle("~/Content/kendo-styles").Include(
                        "~/Content/kendo/kendo.common.min.css",
                        "~/Content/kendo/kendo.common-bootstrap.min.css",
                        "~/Content/kendo/kendo.default.min.css"));

            bundles.Add(new StyleBundle("~/Content/css-custom").Include(
                      "~/Content/site.css"));
        }
    }
}
