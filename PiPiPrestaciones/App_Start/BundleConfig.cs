using System.Web;
using System.Web.Optimization;

namespace PiPiPrestaciones
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap/css").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/materialize/js").Include(
                          "~/Script/materialize/materialize.js"));


            bundles.Add(new StyleBundle("~/bundles/materialize/css").Include(
                 "~/Content/materialize/css/materialize.css"));

            bundles.Add(new StyleBundle("~/Content/css").Include(                     
                      "~/Content/site.css"));
        }
    }
}
