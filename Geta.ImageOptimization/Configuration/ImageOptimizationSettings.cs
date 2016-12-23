using System.Configuration;

namespace Geta.ImageOptimization.Configuration
{
    public class ImageOptimizationSettings : ConfigurationElement
    {
        private static ImageOptimizationSettings _instance;
        private static readonly object Lock = new object();

        public static ImageOptimizationSettings Instance
        {
            get
            {
                lock (Lock)
                {
                    return _instance ?? (_instance = ImageOptimizationConfigurationSection.Instance.Settings);
                }
            }
        }

        /// <summary>
        /// Url prefix used for the images (needs to be public)
        /// </summary>
        [ConfigurationProperty("siteUrl")]
        public string SiteUrl
        {
            get { return base["siteUrl"] as string; }
            set { base["siteUrl"] = value; }
        }


        [ConfigurationProperty("apiKey")]
        public string ApiKey
        {
            get { return base["apiKey"] as string; }
            set { base["apiKey"] = value; }
        }

        [ConfigurationProperty("apiSecret")]
        public string ApiSecret
        {
            get { return base["apiSecret"] as string; }
            set { base["apiSecret"] = value; }
        }

        [ConfigurationProperty("bypassPreviouslyOptimized")]
        public bool BypassPreviouslyOptimized
        {
            get
            {
                if (base["bypassPreviouslyOptimized"] == null)
                {
                    return false;
                }

                return (bool) base["bypassPreviouslyOptimized"];
            }
            set { base["bypassPreviouslyOptimized"] = value; }
        }

		[ConfigurationProperty("includeContentAssets")]
		public bool IncludeContentAssets
		{
			get
			{
				if (base["includeContentAssets"] == null)
				{
					return false;
				}

				return (bool)base["includeContentAssets"];
			}
			set { base["includeContentAssets"] = value; }
		}

       
    }
}