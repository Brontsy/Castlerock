using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Optimization;

namespace Auslink.Web.New
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/admin/bundles/jquery").Include("~/Areas/Admin/Content/scripts/jquery/jquery-{version}.js").Include("~/Areas/Admin/Content/scripts/jquery/jquery-ui-1.10.4.custom.min.js"));
            bundles.Add(new ScriptBundle("~/admin/bundles/jqueryval").Include("~/Areas/Admin/Content/scripts/jquery/jquery.validate*"));

            //// Use the development version of Modernizr to develop with and learn from. Then, when you're
            //// ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/admin/bundles/modernizr").Include("~/Areas/Admin/Content/scripts/modernizr/modernizr-*"));

            bundles.Add(new ScriptBundle("~/admin/bundles/scripts")
                .Include("~/Areas/Admin/Content/scripts/bootstrap/*.js")
                .Include("~/Areas/Admin/Content/scripts/datepicker/*.js")
                .Include("~/Areas/Admin/Content/scripts/lightbox/*.js"));
                //.Include("~/Areas/Admin/Content/scripts/modules/*.js"));

        }
    }
}
