using System.Web;
using System.Web.Optimization;

namespace CoolCareSystem
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-3.3.1.js",
                        "~/Scripts/jquery.dataTables.min.js",
                        "~/Scripts/dataTables.bootstrap.min.js",
                        "~/Scripts/ckeditor/ckeditor.js",
                        "~/Scripts/Datatable.js",
                        "~/Scripts/dx.all.js",
                        "~/Scripts/aspnet/dx.aspnet.mvc.js",
                        "~/Scripts/aspnet/dx.aspnet.data.js",
                        "~/Scripts/Site.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap-lumen.css",
                      "~/Content/jquery.dataTables.min.css",
                      "~/Content/dataTables.bootstrap.min.css",
                      "~/Content/dx.common.css",
                      "~/Content/dx.light.css",
                      "~/Content/site.css"));
        }
    }
}
