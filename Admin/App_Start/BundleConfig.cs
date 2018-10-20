using System.Web;
using System.Web.Optimization;

namespace Admin
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-2.1.1.js"));


            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));


            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/Site.css"));
            bundles.Add(new StyleBundle("~/Content/Footer/css").Include("~/Content/Footer/Rodape.css"));
            bundles.Add(new StyleBundle("~/Content/Login/css").Include("~/Content/Login/Login.css"));
            

            bundles.Add(new StyleBundle("~/Content/themes-out/base/css").Include(
                        "~/Content/themes-out/base/jquery.ui.core.css",
                        "~/Content/themes-out/base/jquery.ui.resizable.css",
                        "~/Content/themes-out/base/jquery.ui.selectable.css",
                        "~/Content/themes-out/base/jquery.ui.accordion.css",
                        "~/Content/themes-out/base/jquery.ui.autocomplete.css",
                        "~/Content/themes-out/base/jquery.ui.button.css",
                        "~/Content/themes-out/base/jquery.ui.dialog.css",
                        "~/Content/themes-out/base/jquery.ui.slider.css",
                        "~/Content/themes-out/base/jquery.ui.tabs.css",
                        "~/Content/themes-out/base/jquery.ui.datepicker.css",
                        "~/Content/themes-out/base/jquery.ui.progressbar.css",
                        "~/Content/themes-out/base/jquery.ui.theme.css"));

        }
    }
}
