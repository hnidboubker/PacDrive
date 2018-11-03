using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Optimization;

namespace PacDrive.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            
            

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.

            bundles.Add(new StyleBundle("~/Content/styles").Include(
                 "~/Content/bootstrap.css",
                 "~/Content/Site.css"));
            
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/vendors").Include(
                 "~/Scripts/modernizr-*",
                  "~/Scripts/jquery-{version}.js",
                "~/Scripts/bootstrap.js",
                "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(

            ));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
              
              ));

            
        }
    }
}
