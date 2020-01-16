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
    public class CategoryService
    {
        public Category GetCategory(int id)
        {
            using (var context = new ASContext())
            {
                return context.Categories.Find(id);
            }
        }

        public List<Category> GetCategories()
        {
            using (var context = new ASContext())
            {
                return context.Categories.Include(x => x.Products).ToList();
            }
        }

        public void SaveCategory(Category category)
        {
            using (var context = new ASContext())
            {
                context.Categories.Add(category);

                context.SaveChanges();
            }
        }

        public void UpdateCategory(Category category)
        {
            using (var context = new ASContext())
            {
                context.Entry(category).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteCategory(int id)
        {
            using (var context = new ASContext())
            {
                //context.Entry(category).State = System.Data.Entity.EntityState.Deleted;
                var category = context.Categories.Find(id);
                context.Categories.Remove(category);
                context.SaveChanges();
            }
        }


    }
}
