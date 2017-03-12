using System.Web;
using System.Web.Optimization;

namespace Multitronics
{
    public class BundleConfig
    {
        // Дополнительные сведения о Bundling см. по адресу http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
            //            "~/Scripts/jquery-ui-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.unobtrusive*",
            //            "~/Scripts/jquery.validate*"));

            // Используйте версию Modernizr для разработчиков, чтобы учиться работать. Когда вы будете готовы перейти к работе,
            // используйте средство построения на сайте http://modernizr.com, чтобы выбрать только нужные тесты.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            //bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));

            //bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
            //            "~/Content/themes/base/jquery.ui.core.css",
            //            "~/Content/themes/base/jquery.ui.resizable.css",
            //            "~/Content/themes/base/jquery.ui.selectable.css",
            //            "~/Content/themes/base/jquery.ui.accordion.css",
            //            "~/Content/themes/base/jquery.ui.autocomplete.css",
            //            "~/Content/themes/base/jquery.ui.button.css",
            //            "~/Content/themes/base/jquery.ui.dialog.css",
            //            "~/Content/themes/base/jquery.ui.slider.css",
            //            "~/Content/themes/base/jquery.ui.tabs.css",
            //            "~/Content/themes/base/jquery.ui.datepicker.css",
            //            "~/Content/themes/base/jquery.ui.progressbar.css",
            //            "~/Content/themes/base/jquery.ui.theme.css"));

            bundles.Add(new StyleBundle("~/bundles/styles").Include(
                "~/Content/libs/bootstrap/bootstrap-grid-3.3.1.css", //Not min
                "~/Content/libs/font-awesome-4.7.0/css/font-awesome.css",
                "~/Content/libs/fancybox/jquery.fancybox.css",
                "~/Content/libs/owl-carousel/owl.carousel.css",
                "~/Content/libs/countdown/jquery.countdown.css",
                "~/Content/fonts.css",
                "~/Content/main.css",
                "~/Content/media.css"));
            bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
                "~/Content/libs/jquery/jquery-1.11.1.js", //Not min
                "~/Content/libs/jquery-mousewheel/jquery.mousewheel.js", //Not min
                "~/Content/libs/fancybox/jquery.fancybox.pack.js",
                "~/Content/libs/waypoints/waypoints-2.0.0.js", //Not min
                "~/Content/libs/scrollto/jquery.scrollTo.js", //Not min
                "~/Content/libs/owl-carousel/owl.carousel.js",
                "~/Content/libs/countdown/jquery.plugin.js",
                "~/Content/libs/countdown/jquery.countdown.js", //Not min
                "~/Content/libs/countdown/jquery.countdown-ru.js",
                "~/Content/libs/landing-nav/navigation.js",
                "~/Scripts/common.js"));
            bundles.Add(new ScriptBundle("~/bundles/VueJS").Include(
                "~/Scripts/vue.js"));
        }
    }
}