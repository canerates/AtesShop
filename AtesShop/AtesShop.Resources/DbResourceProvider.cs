using AtesShop.Entities;
using AtesShop.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtesShop.Resources
{
    public class DbResourceProvider: BaseResourceProvider
    {
        
        protected override IList<Resource> ReadResources()
        {
            var resources = ResourceService.Instance.GetResources();

            return resources;
        }

        protected override Resource ReadResource(string name, string culture)
        {
            Resource resource = ResourceService.Instance.GetResource(name, culture);

            if (resource == null)
            {
                var defaultCulture = "en-US";
                resource = ResourceService.Instance.GetResource(name, defaultCulture);

            }

            return resource;
        }
        
    }
}
