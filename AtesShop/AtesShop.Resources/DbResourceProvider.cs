using AtesShop.Entities;
using AtesShop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtesShop.Resources
{
    public class DbResourceProvider: BaseResourceProvider
    {
        ResourceService resourceService = new ResourceService();

        protected override IList<Resource> ReadResources()
        {
            var resources = resourceService.GetResources();

            return resources;
        }

        protected override Resource ReadResource(string name, string culture)
        {
            Resource resource = resourceService.GetResource(name, culture);

            if (resource == null)
            {
                var defaultCulture = "en-US";
                resource = resourceService.GetResource(name, defaultCulture);

            }

            return resource;
        }
    }
}
