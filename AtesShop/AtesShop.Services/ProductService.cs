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

        public List<Product> GetProductsByCategory(int categoryId)
        {
            using (var context = new ASContext())
            {
                return context.Products.Where(x => x.Category.Id == categoryId).ToList();
            }
        }

        public int GetProductsCount()
        {
            using (var context = new ASContext())
            {
                return context.Products.Count();
            }
        }

        public void SaveProduct(Product product)
        {
            using (var context = new ASContext())
            {
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
