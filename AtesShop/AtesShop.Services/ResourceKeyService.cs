﻿using AtesShop.Database;
using AtesShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtesShop.Services
{
    public class ResourceKeyService
    {
        #region Singleton
        public static ResourceKeyService Instance
        {
            get
            {
                if (instance == null) instance = new ResourceKeyService();

                return instance;
            }
        }
        private static ResourceKeyService instance { get; set; }

        private ResourceKeyService()
        {
        }

        #endregion

        #region Admin

        #region ProductKey

        public ProductKey GetProductKeySet(int id)
        {
            using (var context = new ASContext())
            {
                return context.ProductKeys.Find(id);
            }
        }

        public ProductKey GetProductKeySetByProductId(int productId)
        {
            using (var context = new ASContext())
            {
                return context.ProductKeys.Where(x => x.ProductId == productId).SingleOrDefault();
            }
        }

        public ProductKey GetProductKeySetByPriceKey(string priceKey)
        {
            using (var context = new ASContext())
            {
                return context.ProductKeys.Include("Product").Where(x => x.PriceKey == priceKey).SingleOrDefault();
            }
        }

        public void SaveProductKeySet(ProductKey productKeySet)
        {
            using (var context = new ASContext())
            {
                context.Entry(productKeySet.Product).State = System.Data.Entity.EntityState.Unchanged;
                context.ProductKeys.Add(productKeySet);
                context.SaveChanges();
            }
        }

        public void DeleteProductKeySet(int id)
        {
            using (var context = new ASContext())
            {
                var productKeySet = context.ProductKeys.Find(id);
                context.ProductKeys.Remove(productKeySet);
                context.SaveChanges();
            }
        }

        #endregion

        #region CategoryKey

        public CategoryKey GetCategoryKeySet(int id)
        {
            using (var context = new ASContext())
            {
                return context.CategoryKeys.Find(id);
            }
        }

        public CategoryKey GetCategoryKeySetByCategoryId(int categoryId)
        {
            using (var context = new ASContext())
            {
                return context.CategoryKeys.Where(x => x.CategoryId == categoryId).SingleOrDefault();
            }
        }

        public void SaveCategoryKeySet(CategoryKey categoryKeySet)
        {
            using (var context = new ASContext())
            {
                context.Entry(categoryKeySet.Category).State = System.Data.Entity.EntityState.Unchanged;
                context.CategoryKeys.Add(categoryKeySet);
                context.SaveChanges();
            }
        }

        public void DeleteCategoryKeySet(int id)
        {
            using (var context = new ASContext())
            {
                var categoryKeySet = context.CategoryKeys.Find(id);
                context.CategoryKeys.Remove(categoryKeySet);
                context.SaveChanges();
            }
        }

        #endregion

        #endregion

        #region Web

        public ProductKey GetProductKeySetByProduct(int productId)
        {
            using (var context = new ASContext())
            {
                return context.ProductKeys.Where(x => x.ProductId == productId).SingleOrDefault();
            }
        }

        public CategoryKey GetCategoryKeySetByCategory(int categoryId)
        {
            using (var context = new ASContext())
            {
                return context.CategoryKeys.Where(x => x.CategoryId == categoryId).SingleOrDefault();
            }
        }

        #endregion

    }
}
