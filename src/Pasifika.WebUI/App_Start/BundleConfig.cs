using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Pasifika.WebUI
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/js/libs/jquery.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/js/libs/bootstrap.js",
                "~/js/libs/bootstrap3-typeahead.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/flexslider").Include(
                "~/js/libs/flexslider.js"));

            bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
                "~/js/libs/scripts.js"));

            bundles.Add(new ScriptBundle("~/bundles/select2").Include(
                "~/js/libs/select2.js",
                //"~/js/libs/plugins/angularjs-select/select.min.js",
                "~/js/libs/jquery.nouislider.all.min.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/helpers").Include(
                "~/js/libs/helpers/helpers.js"));

            bundles.Add(new StyleBundle("~/Content/css/styles").Include(
                "~/css/app.css"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                "~/js/libs/angular.min.js",
                "~/js/libs/angular.min.js.map",
                "~/js/libs/angular.nouislider.js",
                "~/js/libs/angular-resource.min.js",
                "~/js/libs/angular-resource.min.js.map"
            ));

            bundles.Add(new ScriptBundle("~/bundles/angular/myApp").Include(
                "~/Content/angularjs/app.module.js",
                "~/Content/angularjs/components/tipo1/tipo1Controller.js",
                "~/Content/angularjs/components/tipo2/tipo2Controller.js"
            ));

            BundleTable.EnableOptimizations = false;
        }
    }
}