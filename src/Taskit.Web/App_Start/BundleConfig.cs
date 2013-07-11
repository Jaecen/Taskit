using System.Web;
using System.Web.Optimization;

namespace Taskit.Web
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include(
                        "~/Content/css/bootstrap.css",
                        "~/Content/css/bootstrap-responsive.css",
                        "~/Content/css/jquery-ui.css",
                        "~/Content/css/style.css" //keep this last
                        ));

            bundles.Add(new ScriptBundle("~/Content/js").Include(
                "~/Content/js/bootstrap-modal.js"
                ));
        }
    }
}