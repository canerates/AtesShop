using AtesShop.Database;
using AtesShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace AtesShop.Services
{
    public class ProductService
    {
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

        public List<Product> GetProducts(int pageNo, int pageSize)
        {
            using (var context = new ASContext())
            {
                return context.Products
                    .OrderBy(x => x.Id)
                    .Skip((pageNo - 1) * pageSize)
                    .Take(pageSize).Include(x => x.Category)
                    .ToList();
            }
        }

        public int GetMaximumPrice()
        {
            using (var context = new ASContext())
            {
                return (int)(context.Products.Max(x => x.Price));
            }
        }

        public int GetMinimumPrice()
        {
            using (var context = new ASContext())
            {
                return (int)(context.Products.Min(x => x.Price));
            }
        }

        public List<Product> GetProductsByCategory(int categoryId)
        {
            using (var context = new ASContext())
            {
                return context.Products
                    .Where(x => x.Category.Id == categoryId)
                    .Include(x => x.Category)
                    .ToList();
            }
        }

        public List<Product> GetProductsByCategory(int categoryId, int pageNo, int pageSize)
        {
            using (var context = new ASContext())
            {
                return context.Products
                    .Where(x => x.Category.Id == categoryId)
                    .OrderBy(x => x.Id)
                    .Skip((pageNo - 1) * pageSize)
                    .Take(pageSize)
                    .Include(x => x.Category)
                    .ToList();
            }
        }

        public List<Product> GeFeaturedProducts()
        {
            using (var context= new ASContext())
            {
                return context.Products
                    .Where(x => x.isFeatured)
                    .ToList();
            }
        }

        public int GetProductsCount()
        {
            using (var context = new ASContext())
            {
                return context.Products.Count();
            }
        }
        public int GetProductsCountByCategory(int categoryId)
        {
            using (var context = new ASContext())
            {
                return context.Products
                    .Where(x => x.Category.Id == categoryId)
                    .Count();
            }
        }

        public List<Product> SearchProducts(string searchKey, int? categoryId, int? maximumPrice, int? minimumPrice, int? sortId, int? sortType, int pageNo, int pageSize)
        {
            using (var context = new ASContext())
            {
                var products = context.Products.ToList();

                if (categoryId.HasValue)
                {
                    products = products.Where(x => x.CategoryId == categoryId.Value).ToList();
                }

                if (!string.IsNullOrEmpty(searchKey))
                {
                    products = products.Where(x => x.Name.ToLower().Contains(searchKey.ToLower())).ToList();
                }

                if (minimumPrice.HasValue)
                {
                    products = products.Where(x => x.Price >= minimumPrice.Value).ToList();
                }

                if (maximumPrice.HasValue)
                {
                    products = products.Where(x => x.Price <= maximumPrice.Value).ToList();
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
                            products = sortType == 1 ? products.OrderBy(x => x.Price).ToList() : products.OrderByDescending(x => x.Price).ToList();
                            break;
                        default:
                            products = sortType == 1 ? products.OrderBy(x => x.Id).ToList() : products.OrderByDescending(x => x.Id).ToList();
                            break;
                    }
                }

                return products.Skip((pageNo - 1) * pageSize).Take(pageSize).ToList();
                
            }
        }

        public int SearchProductsCount(string searchKey, int? categoryId, int? maximumPrice, int? minimumPrice, int? sortBy)
        {
            using (var context = new ASContext())
            {
                var products = context.Products.ToList();

                if (categoryId.HasValue)
                {
                    products = products.Where(x => x.CategoryId == categoryId.Value).ToList();
                }

                if (!string.IsNullOrEmpty(searchKey))
                {
                    products = products.Where(x => x.Name.ToLower().Contains(searchKey.ToLower())).ToList();
                }

                if (minimumPrice.HasValue)
                {
                    products = products.Where(x => x.Price >= minimumPrice.Value).ToList();
                }

                if (maximumPrice.HasValue)
                {
                    products = products.Where(x => x.Price <= maximumPrice.Value).ToList();
                }

                if (sortBy.HasValue)
                {
                    switch (sortBy.Value)
                    {
                        case 2:
                            products = products.OrderByDescending(x => x.Id).ToList();
                            break;
                        case 3:
                            products.OrderBy(x => x.Price).ToList();
                            break;
                        default:
                            products = products.OrderByDescending(x => x.Price).ToList();
                            break;
                    }
                }

                return products.Count();

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
    }
}
