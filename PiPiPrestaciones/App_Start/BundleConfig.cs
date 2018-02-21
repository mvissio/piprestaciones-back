using System.Web;
using System.Web.Optimization;

namespace PiPiPrestaciones
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery/js").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery-ui/js").Include(
                       "~/Scripts/jquery-ui.js"));

            bundles.Add(new ScriptBundle("~/bundles/colorpicker/js").Include(
                       "~/Scripts/colorpicker/bootstrap-colorpicker.js"));

            bundles.Add(new ScriptBundle("~/bundles/ace/js").Include(
                      "~/Scripts/ace.js"));

            bundles.Add(new ScriptBundle("~/bundles/markdown/js").Include(
                      "~/Scripts/markdown/editormd.min.js",
                      "~/lib/languages/en.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                      "~/Scripts/jquery.validate.*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap/js").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/materialize/js").Include(
                          "~/Scripts/materialize/materialize.js",
                         "~/Scripts/materialize/materialize.min.js"));

            bundles.Add(new StyleBundle("~/bundles/materialize/css").Include(
                 "~/Content/materialize/css/materialize.css"));

            bundles.Add(new StyleBundle("~/bundles/colorpicker/css").Include(
                "~/Content/colorpicker/bootstrap-colorpicker.css"));

            bundles.Add(new StyleBundle("~/bundles/bootstrap/css").Include(
               "~/Content/bootstrap.css", "~/Content/bootstrap.min.css"));

            bundles.Add(new StyleBundle("~/bundles/markdown/css").Include(
              "~/Content/markdown/editormd.min.css"));

            bundles.Add(new StyleBundle("~/bundles/jquery-ui/css").Include(
                     "~/Content/jquery-ui*"));



            bundles.Add(new StyleBundle("~/Content/css").Include(                     
                      "~/Content/site.css"));
        }
    }
}
