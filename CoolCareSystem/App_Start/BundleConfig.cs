using System.Web;
using System.Web.Optimization;

namespace CoolCareSystem
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-3.3.1.js",
                        "~/Scripts/jquery.dataTables.min.js",
                        "~/Scripts/dataTables.bootstrap.min.js",
                        "~/Scripts/ckeditor/ckeditor.js",
                        "~/Scripts/Datatable.js",
                        "~/Scripts/quill.min.js",
                        "~/Scripts/dx.all.js",
                        "~/Scripts/aspnet/dx.aspnet.mvc.js",
                        "~/Scripts/aspnet/dx.aspnet.data.js",
                        "~/Scripts/Site.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Contentdark/css").Include(
                      "~/Content/bootstrap-customdark.css",
                      "~/Content/jquery.dataTables.min.css",
                      "~/Content/dataTables.bootstrap.min.css",
                      "~/Content/dx.common.css",
                      "~/Content/dx.customthemedark.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Contentlight/css").Include(
                      "~/Content/bootstrap-customlight.css",
                      "~/Content/jquery.dataTables.min.css",
                      "~/Content/dataTables.bootstrap.min.css",
                      "~/Content/dx.common.css",
                      "~/Content/dx.light.css",
                      "~/Content/site.css"));
        }
    }
}
