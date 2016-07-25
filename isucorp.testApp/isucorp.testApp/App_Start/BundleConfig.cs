using System.Web;
using System.Web.Optimization;

namespace isucorp.testApp
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/knockout").Include(
                        "~/Scripts/knockout-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js",
                      "~/Scripts/bootstrap-datepicker.min.js",
                      "~/Scripts/editor.js"));

            bundles.Add(new ScriptBundle("~/bundles/isucorpList").Include(
                      "~/Scripts/isucorp.list.js"));

            bundles.Add(new ScriptBundle("~/bundles/isucorpCreate").Include(
                      "~/Scripts/isucorp.create.js"));

            bundles.Add(new ScriptBundle("~/bundles/ranking").Include(
                      "~/Scripts/jquery.barrating.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/font-awesome/font-awesome.min.css",
                      "~/Content/site.css",
                      "~/Content/bootstrap-datepicker3.min.css",
                      "~/Content/editor.css"));

            bundles.Add(new StyleBundle("~/Content/ranking").Include(
                      "~/Content/bootstrap-stars.css"));
        }
    }
}
