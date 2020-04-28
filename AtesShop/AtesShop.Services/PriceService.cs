﻿using AtesShop.Database;
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
        public Price GetPrice(string key, string culture, string role)
        {
            using (var context = new ASContext())
            {
                return context.Prices
                    .Where(x => x.Key == key && x.Culture == culture && x.RoleName == role)
                    .FirstOrDefault();
            }
        }
        public Price GetPriceById(int id)
        {
            using (var context = new ASContext())
            {
                return context.Prices.Find(id);
            }
        }

        public List<Price> GetPrices()
        {
            using (var context = new ASContext())
            {
                return context.Prices.OrderBy(x => x.Key).ThenBy(x => x.Culture).ThenBy(x => x.RoleId).ToList();
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
        
        public int GetMaximumPrice(string culture, string role)
        {
            using (var context = new ASContext())
            {
                var prices = context.Prices.Where(x => x.Culture == culture && x.RoleName == role).ToList();

                if(prices.Count != 0)
                {
                    return (int)prices.Max(x => Convert.ToInt64(x.Value));
                }
                else
                {
                    return 10000;
                }
            }
        }

        public int GetMinimumPrice(string culture, string role)
        {
            using (var context = new ASContext())
            {
                var prices = context.Prices.Where(x => x.Culture == culture && x.RoleName == role).ToList();

                if (prices.Count != 0)
                {
                    return (int)prices.Min(x => Convert.ToInt64(x.Value));
                }
                else
                {
                    return 10;
                }
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
    }
}