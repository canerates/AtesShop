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
        #region Singleton
        public static CategoryService Instance
        {
            get
            {
                if (instance == null) instance = new CategoryService();

                return instance;
            }
        }
        private static CategoryService instance { get; set; }

        private CategoryService()
        {
        }

        #endregion

        #region Admin

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
                var category = context.Categories.Find(id);
                context.Categories.Remove(category);
                context.SaveChanges();
            }
        }

        #endregion

        #region Web

        public List<Category> GetCategories(string culture)
        {
            using (var context = new ASContext())
            {
                var categories = context.Categories.Where(x => !x.isHidden).Include(x => x.Products).ToList();
                foreach (var category in categories)
                {
                    category.Products = category.Products.Where(x => x.isActive && !x.isSet && !x.isHidden).ToList();
                }
                return FormatCategoriesInfo(categories, culture);
            }
        }

        public List<Category> FormatCategoriesInfo(List<Category> categories, string culture)
        {
            using (var context = new ASContext())
            {
                foreach (var category in categories)
                {
                    var keys = context.CategoryKeys.Where(x => x.CategoryId == category.Id).FirstOrDefault();

                    var name = context.Resources.Where(x => x.Key == keys.NameKey && x.Culture == culture).FirstOrDefault();
                    if (name == null)
                    {
                        var defaultCulture = "en-us";
                        category.Name = context.Resources.Where(x => x.Key == keys.NameKey && x.Culture == defaultCulture).FirstOrDefault().Value;
                    }
                    else
                    {
                        category.Name = name.Value;
                    }

                    var description = context.Resources.Where(x => x.Key == keys.DescriptionKey && x.Culture == culture).FirstOrDefault();
                    if (description == null)
                    {
                        var defaultCulture = "en-us";
                        category.Description = context.Resources.Where(x => x.Key == keys.NameKey && x.Culture == defaultCulture).FirstOrDefault().Value;
                    }
                    else
                    {
                        category.Description = description.Value;
                    }
                }
                return categories;
            }
        }
        
        #endregion
    }
}
