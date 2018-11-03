using System.Web.Optimization;

namespace PacDrive.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.unobtrusive*",
                "~/Scripts/jquery.validate*"));


            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.

            bundles.Add(new StyleBundle("~/Content/styles").Include(
                "~/Content/bootstrap.css",
                "~/Content/sweetalert/sweet-alert.css",
                "~/Content/Site.css"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/vendors").Include(
                "~/Scripts/modernizr-*",
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/bootstrap.js",
                 "~/Scripts/sweetAlert.min.js",
                "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                "~/Scripts/angular.min.js",
                "~/Scripts/angular-route.min.js",
                "~/Scripts/ui-bootstrap-tpls.min.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                "~/app/app.js"
                ));
        }
    }
}