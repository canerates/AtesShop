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

        protected override IList<Price> ReadPrices()
        {
            var prices = PriceService.Instance.GetPrices();

            return prices;
        }

        protected override Price ReadPrice(string name, string culture, string role)
        {
            Price price = PriceService.Instance.GetPrice(name, culture, role);
            
            if (price == null)
            {
                price = new Price();
                price.Key = "DefaultKey";
                price.Value = "Contact Us";
                price.PreValue = " ";
                price.RoleName = "DefaultRole";
                price.RoleId = "1";
                
            }
            
            return price;
        }
    }
}
