using System.Web;
using System.Web.Optimization;

namespace helpdesk_asp
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/bundle/login-styles")
            .Include("~/Content/bootstrap.min.css")
            .Include("~/Content/font-awesome.min.css")
            .Include("~/Content/custom.css")
            .Include("~/Content/medical_icons/wfmi-style.css")
            .Include("~/Content/medical_icons/custom_medical_font.css"));

            bundles.Add(new ScriptBundle("~/bundle/login-scripts")
            .Include("~/Scripts/jquery-1.10.2.min.js")
            .Include("~/Scripts/bootstrap.min.js")
            .Include("~/Scripts/jquery.backstretch.min.js"));

            bundles.Add(new StyleBundle("~/bundle/styleMaster")
            .Include("~/Content/bootstrap.min.css")
            .Include("~/Content/font-awesome.min.css")
            .Include("~/Content/ionic-v1.2.4/ionicons.min.css")
            .Include("~/Content/dist/css/AdminLTE.min.css")
            .Include("~/Content/dist/css/skins/_all-skins.min.css")
            .Include("~/Content/plugins/iCheck/flat/blue.css")
            .Include("~/Content/plugins/morris/morris.css")
            .Include("~/Content/plugins/jvectormap/jquery-jvectormap-1.2.2.css")
            .Include("~/Content/plugins/datepicker/datepicker3.css")
            .Include("~/Content/plugins/daterangepicker/daterangepicker-bs3.css")
            .Include("~/Content/plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.min.css")
            .Include("~/Content/medical_icons/wfmi-style.css")
            .Include("~/Content/medical_icons/custom_medical_font.css"));

            bundles.Add(new ScriptBundle("~/bundle/scriptMaster")
            .Include("~/Content/plugins/jQuery/jQuery-2.2.0.min.js")
            .Include("~/Scripts/bootstrap.min.js")
            .Include("~/Content/dist/js/app.min.js"));
        }
    }
}
