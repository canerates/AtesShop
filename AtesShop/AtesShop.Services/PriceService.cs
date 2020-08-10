using AtesShop.Database;
using AtesShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtesShop.Services
{
    public class PriceService
    {
        #region Singleton
        public static PriceService Instance
        {
            get
            {
                if (instance == null) instance = new PriceService();

                return instance;
            }
        }
        private static PriceService instance { get; set; }

        private PriceService()
        {
        }

        #endregion

        #region Admin

        public Price GetPriceById(int id)
        {
            using (var context = new ASContext())
            {
                return context.Prices.Find(id);
            }
        }

        public List<Price> GetPricesByKey(string key)
        {
            using (var context = new ASContext())
            {
                return context.Prices.Where(x => x.Key == key).OrderBy(x => x.Culture).ThenBy(x => x.RoleId).ToList();
            }
        }

        public List<Price> GetPricesByKeyAndCulture(string key, string culture)
        {
            using (var context = new ASContext())
            {
                return context.Prices
                    .Where(x => x.Key == key && x.Culture == culture)
                    .ToList();
            }
        }

        public List<string> GetPriceDistinctKeys()
        {
            using (var context = new ASContext())
            {
                return context.Prices.Select(x => x.Key).Distinct().ToList();
            }
        }

        public List<string> GetPriceDistinctCulturesByPriceKey(string key)
        {
            using (var context = new ASContext())
            {
                return context.Prices
                    .Where(x => x.Key == key)
                    .Select(x => x.Culture).Distinct().ToList();
            }
        }

        public int GetPriceCountByKey(string key)
        {
            using (var context = new ASContext())
            {
                return context.Prices
                    .Where(x => x.Key == key)
                    .Count();
            }
        }

        public int GetPriceCountByKeyAndCulture(string key, string culture)
        {
            using (var context = new ASContext())
            {
                return context.Prices
                    .Where(x => x.Key == key && x.Culture == culture)
                    .Count();
            }
        }

        public void SavePrice(Price price)
        {
            using (var context = new ASContext())
            {
                context.Prices.Add(price);
                context.SaveChanges();
            }
        }

        public void UpdatePrice(Price price)
        {
            using (var context = new ASContext())
            {
                context.Entry(price).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeletePrice(int id)
        {
            using (var context = new ASContext())
            {
                var price = context.Prices.Find(id);
                context.Prices.Remove(price);
                context.SaveChanges();
            }
        }

        public void DeletePrices(string key)
        {
            using (var context = new ASContext())
            {
                var prices = context.Prices.Where(x => x.Key == key).ToList();
                context.Prices.RemoveRange(prices);
                context.SaveChanges();
            }
        }

        #endregion

        #region Web

        public int GetMaximumPrice(string culture, string role, int? categoryId)
        {
            using (var context = new ASContext())
            {

                culture = culture == "tr-TR" ? "en-US" : culture;
                var prices = new List<Price>();
                var products = new List<Product>();

                if (categoryId.HasValue)
                {
                    products = context.Products.Where(x => x.isActive && !x.isSet && !x.isHidden &&  x.CategoryId == categoryId.Value).ToList();
                }
                else
                {
                    products = context.Products.Where(x => x.isActive && !x.isSet && !x.isHidden).ToList();
                }

                if (products != null && products.Count != 0)
                {
                    foreach (var product in products)
                    {
                        var key = context.ProductKeys.Where(x => x.ProductId == product.Id).FirstOrDefault();
                        var price = context.Prices.Where(x => x.Key == key.PriceKey && x.Culture == culture && x.RoleName == role).FirstOrDefault();
                        prices.Add(price);
                    }
                }
                
                if (prices.Count != 0)
                {
                    return (int)prices.Max(x => Convert.ToInt64(x.Value));
                }
                else
                {
                    return 0;
                }
            }
        }

        public int GetMinimumPrice(string culture, string role, int? categoryId)
        {
            using (var context = new ASContext())
            {

                culture = culture == "tr-TR" ? "en-US" : culture;
                var prices = new List<Price>();
                var products = new List<Product>();

                if (categoryId.HasValue)
                {
                    products = context.Products.Where(x => x.isActive && !x.isSet && !x.isHidden && x.CategoryId == categoryId.Value).ToList();
                }
                else
                {
                    products = context.Products.Where(x => x.isActive && !x.isSet && !x.isHidden).ToList();
                }

                if (products != null && products.Count != 0)
                {
                    foreach (var product in products)
                    {
                        var key = context.ProductKeys.Where(x => x.ProductId == product.Id).FirstOrDefault();
                        var price = context.Prices.Where(x => x.Key == key.PriceKey && x.Culture == culture && x.RoleName == role).FirstOrDefault();
                        prices.Add(price);
                    }
                }

                if (prices.Count != 0)
                {
                    return (int)prices.Min(x => Convert.ToInt64(x.Value));
                }
                else
                {
                    return 0;
                }
            }
        }

        public Price GetPriceByKeyAndCulture(string key, string culture)
        {
            using (var context = new ASContext())
            {
                return context.Prices.Where(x => x.Key == key && x.Culture == culture).FirstOrDefault();
            }
        }

        public Price GetPriceForUserByKeyAndCulture(string key, string culture)
        {
            using (var context = new ASContext())
            {
                return context.Prices.Where(x => x.Key == key && x.Culture == culture && x.RoleName == "User").FirstOrDefault();
            }
        }

        #endregion
    }
}
