using AtesShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtesShop.Resources
{
    public abstract class BaseResourceProvider: IResourceProvider
    {
        private static Dictionary<string, Resource> resources = null;
        private static object lockResources = new object();

        public BaseResourceProvider()
        {
            Cache = true ;
        }

        protected bool Cache { get; set; }

        public object GetResource(string name, string culture)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Resource name cannot be null or empty.");

            if (string.IsNullOrWhiteSpace(culture))
                throw new ArgumentException("Culture name cannot be null or empty.");

            culture = culture.ToLowerInvariant();

            if (Cache && resources == null)
            {
                lock (lockResources)
                {
                    if (resources == null)
                    {
                        resources = ReadResources().ToDictionary(r => string.Format("{0}.{1}", r.Culture.ToLowerInvariant(), r.Key));
                    }
                }
            }

            if (Cache)
            {
                return resources[string.Format("{0}.{1}", culture, name)].Value;
            }

            return ReadResource(name, culture).Value;
        }

        protected abstract IList<Resource> ReadResources();

        protected abstract Resource ReadResource(string name, string culture);
        
        
    }
}
