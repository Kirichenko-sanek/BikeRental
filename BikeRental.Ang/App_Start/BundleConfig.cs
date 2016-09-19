using System.Web.Optimization;

namespace BikeRental.Ang
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

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/assets/js/headroom.min.js",
                      "~/assets/js/jQuery.headroom.min.js",
                      "~/assets/js/template.js",
                      "~/Scripts/build/jquery.datetimepicker.full.min.js",
                      "~/node_modules/angular/angular.min.js",
                      "~/node_modules/angular-route/angular-route.min.js",
                      "~/node_modules/angular-cookies/angular-cookies.min.js",
                      "~/node_modules/angular-base64/angular-base64.min.js",
                      "~/node_modules/angular-mocks/angular-mocks.js"));

            bundles.Add(new ScriptBundle("~/bundles/apps").Include(
                "~/app/common.core.js",
                "~/app/common.ui.js",
                "~/app/app.js",
                "~/app/apiService.js",
                "~/app/notificationService.js",                
                "~/app/LogIn/LogInService.js",
                "~/app/LogIn/LogInController.js",
                "~/app/Index/IndexController.js"
                ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/assets/css/bootstrap.min.css",
                      "~/assets/css/font-awesome.min.css",
                      "~/assets/css/bootstrap-theme.css",
                      "~/assets/css/main.css",
                      "~/Content/jquery.datetimepicker.css"));
        }
    }
}
