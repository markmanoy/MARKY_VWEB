using System.Web.Optimization;

namespace Marky_VWeb
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/CommonScripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/CommonScripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/CommonScripts/jquery.unobtrusive*",
                        "~/Scripts/CommonScripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/CommonScripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/App_Themes/Default/Content/css").Include("~/App_Themes/Default/Content/site.css"));

            bundles.Add(new StyleBundle("~/App_Themes/Default/Content/themes/base/css").Include(
                        "~/App_Themes/Default/Content/themes/base/jquery.ui.core.css",
                        "~/App_Themes/Default/Content/themes/base/jquery.ui.resizable.css",
                        "~/App_Themes/Default/Content/themes/base/jquery.ui.selectable.css",
                        "~/App_Themes/Default/Content/themes/base/jquery.ui.accordion.css",
                        "~/App_Themes/Default/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/App_Themes/Default/Content/themes/base/jquery.ui.button.css",
                        "~/App_Themes/Default/Content/themes/base/jquery.ui.dialog.css",
                        "~/App_Themes/Default/Content/themes/base/jquery.ui.slider.css",
                        "~/App_Themes/Default/Content/themes/base/jquery.ui.tabs.css",
                        "~/App_Themes/Default/Content/themes/base/jquery.ui.datepicker.css",
                        "~/App_Themes/Default/Content/themes/base/jquery.ui.progressbar.css",
                        "~/App_Themes/Default/Content/themes/base/jquery.ui.theme.css"));
        }
    }
}