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
        private static Dictionary<string, Price> prices = null;
        private static object lockResources = new object();

        public BaseResourceProvider()
        {
            Cache = false ;
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

        public object GetPriceValue(string name, string culture, string role, bool isPrev)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Resource name cannot be null or empty.");

            if (string.IsNullOrWhiteSpace(culture))
                throw new ArgumentException("Culture name cannot be null or empty.");

            if (string.IsNullOrWhiteSpace(role))
                throw new ArgumentException("Role name cannot be null or empty.");

            culture = culture.ToLowerInvariant();

            if (Cache && prices == null)
            {
                lock (lockResources)
                {
                    if (prices == null)
                    {
                        prices = ReadPrices().ToDictionary(r => string.Format("{0}.{1}.{2}", r.Culture.ToLowerInvariant(), r.Key, r.RoleName));
                    }
                }
            }
            
            if (Cache)
            {
                if (!isPrev) return prices[string.Format("{0}.{1}.{2}", culture, name, role)].Value;
                else return prices[string.Format("{0}.{1}.{2}", culture, name, role)].PreValue;
            }
            else
            {
                if (!isPrev) return ReadPrice(name, culture, role).Value;
                else return ReadPrice(name, culture, role).PreValue;
            }
            
        }

        protected abstract IList<Price> ReadPrices();

        protected abstract Price ReadPrice(string name, string culture, string role);


    }
}
