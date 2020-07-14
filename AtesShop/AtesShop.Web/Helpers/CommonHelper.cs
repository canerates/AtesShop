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
        
        internal static List<Product> FormatCurrency(List<Product> products, string culture)
        {
            foreach (var product in products)
            {
                if (product.Price != "Contact Us")
                {
                    culture = culture == "tr-TR" ? "en-US" : culture;
                    var priceValue = Int64.Parse(product.Price);
                    var prePriceValue = Int64.Parse(product.PrePrice);
                    product.Price = priceValue.ToString("c", new CultureInfo(culture));
                    product.PrePrice = prePriceValue.ToString("c", new CultureInfo(culture));
                }
            }
            return products;
        }
        
        internal static Product FormatCurrency( Product product, string culture)
        {
            if (product.Price != "Contact Us")
            {
                culture = culture == "tr-TR" ? "en-US" : culture;
                var priceValue = Int64.Parse(product.Price);
                var prePriceValue = Int64.Parse(product.PrePrice);
                product.Price = priceValue.ToString("C", new CultureInfo(culture));
                product.PrePrice = prePriceValue.ToString("C", new CultureInfo(culture));
            }
            return product;
        }

        internal static List<Product> WishlistCheck(List<Product> products, string userId)
        {
            var wishlist = UserService.Instance.GetAllWishlistForUser(userId);

            foreach (var product in products)
            {
                bool contains = wishlist.Any(x => x.ProductId == product.Id);
                product.isWished = contains ? true : false;
            }
            return products;
        }

        internal static Product WishlistCheck(Product product, string userId)
        {
            bool contains = UserService.Instance.GetAllWishlistForUser(userId).Any(x => x.ProductId == product.Id);
            product.isWished = contains ? true : false;
            return product;
        }

    }
}