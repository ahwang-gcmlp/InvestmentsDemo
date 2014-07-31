using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Optimization;
using dotless.Core;

namespace UserExperience
{
    public class GcmHeaderBundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Styles/VendorCSS").Include(
                "~/Styles/vendor/bootstrap.css",
                "~/Styles/gcmStyles.css",
                "~/Styles/gcm-iconfonts-v4.css"
				));

	        bundles.Add(new Bundle("~/Scripts/VendorJs").Include(
				"~/Scripts/vendor/jquery.1.11.1.js",
				"~/Scripts/vendor/bootstrap.js",
				"~/Scripts/vendor/underscore.js"
		        ));

			var lessBundles = new List<Bundle> {
                    new Bundle("~/Styles/MainCSS").Include("~/Styles/main.less")
                };

			foreach (var lessBundle in lessBundles)
			{
				lessBundle.Transforms.Add(new LessTransform());
				lessBundle.Transforms.Add(new CssMinify());
				bundles.Add(lessBundle);
			}
        }
    }
}