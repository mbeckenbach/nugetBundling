using nugetBundling.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Optimization;

namespace nugetBundling
{
    public static class JSBundle
    {
        /// <summary>
        /// Create a JS bundle called "~/bundles/js/{packageId}", include the cdn path and fallback expression
        /// </summary>
        /// <param name="packageId">The id of your package can be found in packages.config</param>
        /// <param name="cdnUrl">A url pointing to your cdn. Replace the version by {version}. Example: "//ajax.googleapis.com/ajax/libs/jquery/{version}/jquery.min.js"</param>
        /// <param name="cdnFallBackExpression">Script to test if the library has been loaded from cdn. Example: window.jQuery</param>
        /// <param name="localFile">A local file to fall back to, when cdn does not work. Use {version} to point to the installed version</param>
        /// <returns>A bundle called "~/bundles/js/{packageId}"</returns>
        public static Bundle Create(string packageId, string cdnUrl, string cdnFallBackExpression, string localFile)
        {
            var packageReader = new NugetReader(HttpContext.Current.Server.MapPath("~/"));
            var bundle = new Bundle("~/bundles/js/" + packageId, cdnUrl.Replace("{version}", packageReader.FindPackageByName(packageId).Version));
            bundle.CdnFallbackExpression = cdnFallBackExpression;
            return bundle;
        }

        /// <summary>
        /// Create a JS bundle called as you name it with bundleName, include the cdn path and fallback expression
        /// </summary>
        /// <param name="packageId">The id of your package can be found in packages.config</param>
        /// <param name="bundleName">Example: "~/Bundles/JavaScript/Whatever"</param>
        /// <param name="cdnUrl">A url pointing to your cdn. Replace the version by {version}. Example: "//ajax.googleapis.com/ajax/libs/jquery/{version}/jquery.min.js"</param>
        /// <param name="CdnFallBackExpression">Script to test if the library has been loaded from cdn. Example: window.jQuery</param>
        /// <param name="localFile">A local file to fall back to, when cdn does not work. Use {version} to point to the installed version</param>
        /// <returns>A bundle called "~/Bundles/JavaScript/Whatever"</returns>
        public static Bundle Create(string packageId, string bundleName, string cdnUrl, string CdnFallBackExpression, string localFile)
        {
            var packageReader = new NugetReader(HttpContext.Current.Server.MapPath("~/"));
            var bundle = new Bundle(bundleName, cdnUrl.Replace("{version}", packageReader.FindPackageByName(packageId).Version));
            bundle.CdnFallbackExpression = CdnFallBackExpression;
            return bundle;
        }
    }
}
