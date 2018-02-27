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
            
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/summernote/js").Include(
                      "~/Scripts/summernote-lite.js"));



            bundles.Add(new ScriptBundle("~/bundles/materialize/js").Include(
                          "~/Scripts/materialize/materialize.js"));

            bundles.Add(new StyleBundle("~/bundles/materialize/css").Include(
                 "~/Content/materialize/css/materialize.css"));

            bundles.Add(new StyleBundle("~/bundles/colorpicker/css").Include(
                "~/Content/colorpicker/bootstrap-colorpicker.css"));
            
            bundles.Add(new StyleBundle("~/bundles/markdown/css").Include(
              "~/Content/markdown/editormd.min.css"));

            bundles.Add(new StyleBundle("~/bundles/jquery-ui/css").Include(
                     "~/Content/jquery-ui*"));


            bundles.Add(new StyleBundle("~/bundles/summernote/css").Include(
                      "~/Content/summernote-lite.css"));

            bundles.Add(new StyleBundle("~/Content/css").Include(                     
                      "~/Content/site.css"));
        }
    }
}
