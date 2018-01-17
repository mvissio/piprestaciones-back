﻿using System.Web;
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

            bundles.Add(new StyleBundle("~/bundles/bootstrap/css").Include(
                "~/Content/bootstrap.css"));

            bundles.Add(new StyleBundle("~/Content/css").Include(                     
                      "~/Content/site.css"));
        }
    }
}
