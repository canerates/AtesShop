using AtesShop.Entities;
using AtesShop.Resources;
using AtesShop.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace AtesShop.Web.Helpers
{
    public class CommonHelper
    {
        internal static List<Product> FilterProductsByMaxMinPrice(List<Product> products ,int? max, int? min)
        {
            if (max.HasValue && min.HasValue)
            {
                List<Product> nonPriceProducts = new List<Product>();
                nonPriceProducts = products.Where(x => x.Price == "Contact Us").ToList();

                products = products.Where(x => x.Price != "Contact Us").ToList();
                products = products.Where(x => int.Parse(x.Price) <= max.Value && int.Parse(x.Price) >= min.Value).ToList();

                products.AddRange(nonPriceProducts);
            }
            return products;
        }

        internal static List<Product> ProductsCurrencyFormat(List<Product> products, string culture)
        {
            foreach (var product in products)
            {
                if (product.Price != "Contact Us")
                {
                    var priceValue = Int64.Parse(product.Price);
                    var prePriceValue = Int64.Parse(product.PrePrice);
                    product.Price = priceValue.ToString("c", new CultureInfo(culture));
                    product.PrePrice = prePriceValue.ToString("c", new CultureInfo(culture));
                }
            }

            return products;
        }
        
    }
}