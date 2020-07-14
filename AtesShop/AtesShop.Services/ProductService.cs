﻿using AtesShop.Database;
using AtesShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Globalization;

namespace AtesShop.Services
{
    public class ProductService
    {
        #region Singleton

        public static ProductService Instance
        {
            get
            {
                if (instance == null) instance = new ProductService();

                return instance;
            }
        }
        private static ProductService instance { get; set; }

        private ProductService()
        {
        }

        #endregion
        
        #region Admin
        
        public Product GetProduct(int productId)
        {
            using (var context = new ASContext())
            {
                return context.Products.Find(productId);
            }
        }

        public List<Product> GetProducts()
        {
            using (var context = new ASContext())
            {
                return context.Products.Include(x => x.Category).ToList();
            }
        }
        
        public void SaveProduct(Product product)
        {
            using (var context = new ASContext())
            {
                context.Entry(product.Category).State = System.Data.Entity.EntityState.Unchanged;
                context.Products.Add(product);
                context.SaveChanges();
            }
        }

        public void UpdateProduct(Product product)
        {
            using (var context = new ASContext())
            {
                context.Entry(product).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteProduct(int id)
        {
            using (var context = new ASContext())
            {
                //context.Entry(category).State = System.Data.Entity.EntityState.Deleted;
                var product = context.Products.Find(id);
                context.Products.Remove(product);
                context.SaveChanges();
            }
        }

        #endregion
        
        #region Web

        public Product GetProduct(int productId, string culture, string role)
        {
            using (var context = new ASContext())
            {
                var product = context.Products.Find(productId);
                return FormatProductInfo(product, culture, role);
            }
        }

        public List<Product> GetProducts(string culture, string role)
        {
            using (var context = new ASContext())
            {
                var products = context.Products.Include(x => x.Category).ToList();
                return FormatProductsInfo(products, culture, role);
            }
        }

        public List<Product> GetProductsByCategory(int categoryId, string culture, string role)
        {
            using (var context = new ASContext())
            {
                var products = context.Products.Where(x => x.Category.Id == categoryId).Include(x => x.Category).ToList();
                return FormatProductsInfo(products, culture, role);
            }
        }

        public List<Product> GetProductsByIdList(List<int> productIdList, string culture, string role)
        {
            using (var context = new ASContext())
            {
                var products = context.Products.Where(x => productIdList.Contains(x.Id)).ToList();
                return FormatProductsInfo(products, culture, role);
            }
        }

        public List<Product> SearchProducts(string searchKey, string culture, string role, int? categoryId, int? sortId, int? sortType, int pageNo, int pageSize, int? minimum, int? maximum)
        {
            using (var context = new ASContext())
            {
                var products = context.Products.ToList();

                if (categoryId.HasValue)
                {
                    products = products.Where(x => x.CategoryId == categoryId.Value).ToList();
                }

                if (sortId.HasValue && sortType.HasValue)
                {
                    switch (sortId.Value)
                    {
                        case 1:
                            products = sortType == 1 ? products.OrderBy(x => x.Id).ToList() : products.OrderByDescending(x => x.Id).ToList();
                            break;
                        case 2:
                            products = sortType == 1 ? products.OrderBy(x => x.Name).ToList() : products.OrderByDescending(x => x.Name).ToList();
                            break;
                        case 3:
                            var rates = context.Ratings.GroupBy(x => x.ProductId).Select(g => new { Key = g.Key, Value = g.Sum(s => s.Rate) }).ToList();
                            rates = sortType == 1 ? rates.OrderBy(x => x.Value).ToList() : rates.OrderByDescending(x => x.Value).ToList();
                            var idList = rates.Select(x => x.Key).ToList();
                            products = products.OrderBy(x => idList.IndexOf(x.Id)).ToList();
                            break;
                        case 4:
                            products = sortType == 1 ? products.OrderBy(x => x.Price).ToList() : products.OrderByDescending(x => x.Price).ToList();
                            break;
                        default:
                            products = sortType == 1 ? products.OrderBy(x => x.Id).ToList() : products.OrderByDescending(x => x.Id).ToList();
                            break;
                    }
                }

                products = FormatProductsInfo(products, culture, role);

                if (maximum.HasValue && minimum.HasValue)
                {
                    if (maximum.Value != 0 && minimum.Value != 0)
                    {
                        List<Product> excludedProducts = new List<Product>();

                        excludedProducts = products.Where(x => x.Price != "Contact Us").Where(x => int.Parse(x.Price) < minimum.Value || int.Parse(x.Price) > maximum.Value).ToList();
                        foreach (var product in excludedProducts)
                        {
                            products.Remove(product);
                        }
                    }
                }

                if (!string.IsNullOrEmpty(searchKey))
                {
                    products = products.Where(x => x.Name.ToLower().Contains(searchKey.ToLower()) || x.Description.ToLower().Contains(searchKey.ToLower())).ToList();
                }

                return products.Skip((pageNo - 1) * pageSize).Take(pageSize).ToList();

            }
        }

        public int GetProductsCount()
        {
            using (var context = new ASContext())
            {
                return context.Products.Count();
            }
        }
        
        public int SearchProductsCount(string searchKey, string culture, string role, int? categoryId, int? minimum, int? maximum)
        {
            using (var context = new ASContext())
            {
                var products = context.Products.ToList();

                if (categoryId.HasValue)
                {
                    products = products.Where(x => x.CategoryId == categoryId.Value).ToList();
                }

                products = FormatProductsInfo(products, culture, role);

                if (maximum.HasValue && minimum.HasValue)
                {
                    if (maximum.Value != 0 && minimum.Value != 0)
                    {
                        List<Product> excludedProducts = new List<Product>();

                        excludedProducts = products.Where(x => x.Price != "Contact Us").Where(x => int.Parse(x.Price) < minimum.Value || int.Parse(x.Price) > maximum.Value).ToList();
                        foreach (var product in excludedProducts)
                        {
                            products.Remove(product);
                        }
                    }
                }

                if (!string.IsNullOrEmpty(searchKey))
                {
                    products = products.Where(x => x.Name.ToLower().Contains(searchKey.ToLower()) || x.Description.ToLower().Contains(searchKey.ToLower())).ToList();
                }

                return products.Count();

            }
        }

        public List<Product> FormatProductsInfo(List<Product> products, string culture, string role)
        {
            List<Product> newProducts = new List<Product>();

            foreach (var product in products)
            {
                Product newProduct = new Product();
                newProduct = FormatProductInfo(product, culture, role);
                newProducts.Add(product);
            }

            return newProducts;
        }

        public Product FormatProductInfo(Product product, string culture, string role)
        {
            using (var context = new ASContext())
            {
                //Image List
                List<int> idList = product.ImageIdList.Split(',').Select(int.Parse).ToList();
                product.Images = context.Images.Where(x => idList.Contains(x.Id)).ToList();
                
                //Price
                var keys = context.ProductKeys.Where(x => x.ProductId == product.Id).FirstOrDefault();
                var price = new Price();

                if (culture == "tr-TR")
                {
                    price = context.Prices.Where(x => x.Key == keys.PriceKey && x.Culture == "en-US" && x.RoleName == role).FirstOrDefault();
                }
                else
                {
                    price = context.Prices.Where(x => x.Key == keys.PriceKey && x.Culture == culture && x.RoleName == role).FirstOrDefault();
                }
                
                if (price == null)
                {
                    product.Price = "Contact Us";
                    product.PrePrice = " ";
                }
                else
                {
                    product.Price = price.Value;
                    product.PrePrice = price.PreValue;
                }

                var name = context.Resources.Where(x => x.Key == keys.NameKey && x.Culture == culture).FirstOrDefault();
                if (name == null)
                {
                    var defaultCulture = "en-us";
                    product.Name = context.Resources.Where(x => x.Key == keys.NameKey && x.Culture == defaultCulture).FirstOrDefault().Value;
                }
                else
                {
                    product.Name = name.Value;
                }

                var description = context.Resources.Where(x => x.Key == keys.DescriptionKey && x.Culture == culture).FirstOrDefault();
                if (description == null)
                {
                    var defaultCulture = "en-us";
                    product.Description = context.Resources.Where(x => x.Key == keys.DescriptionKey && x.Culture == defaultCulture).FirstOrDefault().Value;
                }
                else
                {
                    product.Description = description.Value;
                }

                var rateTotal = context.Ratings.Where(x => x.ProductId == product.Id).Sum(x => x.Rate);
                var rateCount = context.Ratings.Where(x => x.ProductId == product.Id).Count();

                product.Rate = rateTotal / rateCount;
                
                return product;
            }
            
        }
        
        #endregion

    }
}
