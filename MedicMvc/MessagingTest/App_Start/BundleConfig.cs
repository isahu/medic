using BundleTransformer.Core.Builders;
using BundleTransformer.Core.Orderers;
using BundleTransformer.Core.Transformers;
using System.Web;
using System.Web.Optimization;

namespace MessagingTest
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            // Variables
            bundles.UseCdn = true;
            var nullBuilder = new NullBuilder();
            var cssTransformer = new CssTransformer();
            var jsTransformer = new JsTransformer();
            var nullOrderer = new NullOrderer();

            // JavaScript

            // jQuery
            var jquery = new Bundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js");
            jquery.Builder = nullBuilder;
            jquery.Transforms.Add(jsTransformer);
            jquery.Orderer = nullOrderer;

            bundles.Add(jquery);

            // Modernizr
            var modernizr = new Bundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-2.6.2.js");
            modernizr.Builder = nullBuilder;
            modernizr.Transforms.Add(jsTransformer);
            modernizr.Orderer = nullOrderer;

            bundles.Add(modernizr);

            // Scripts
            var js = new Bundle("~/bundles/js").Include(
                "~/Scripts/bootstrap.min.js",
                "~/Scripts/respond.js",
                "~/Scripts/knockout-{version}.js",
                "~/Scripts/jquery.signalR-{version}.js");
            js.Builder = nullBuilder;
            js.Transforms.Add(jsTransformer);
            js.Orderer = nullOrderer;

            bundles.Add(js);

            // POST: Validation
            var jqueryVal = new Bundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.validate.unobtrusive.min.js",
                "~/Scripts/jquery.validate.min.js");
            jqueryVal.Builder = nullBuilder;
            jqueryVal.Transforms.Add(jsTransformer);
            jqueryVal.Orderer = nullOrderer;

            bundles.Add(jqueryVal);

            // Styles
            var css = new Bundle("~/bundles/css").Include(
                "~/Content/bootstrap/bootstrap.less",
                "~/Content/site.css");
            css.Builder = nullBuilder;
            css.Transforms.Add(cssTransformer);
            css.Transforms.Add(new CssMinify());
            css.Orderer = nullOrderer;

            bundles.Add(css);

            BundleTable.EnableOptimizations = true;

            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.validate*"));

            //// Use the development version of Modernizr to develop with and learn from. Then, when you're
            //// ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js",
            //          "~/Scripts/respond.js"));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/bootstrap.css",
            //          "~/Content/site.css"));

            //bundles.Add(new ScriptBundle("~/bundles/knockout").Include(
            //        "~/Scripts/knockout-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/signalr").Include(
            //        "~/Scripts/jquery.signalR-{version}.js"));

            //// Set EnableOptimizations to false for debugging. For more information,
            //// visit http://go.microsoft.com/fwlink/?LinkId=301862
            //BundleTable.EnableOptimizations = true;
        }
    }
}
