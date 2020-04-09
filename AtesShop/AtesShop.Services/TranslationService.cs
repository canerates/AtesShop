using AtesShop.Database;
using AtesShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtesShop.Services
{
    public class TranslationService
    {
        
        public ProductTranslation GetProductTranslation(int id)
        {
            using (var context = new ASContext())
            {
                return context.ProductTranslations.Find(id);
            }
        }

        public ProductTranslation GetProductTranslationByProduct(int productId)
        {
            using (var context = new ASContext())
            {
                return context.ProductTranslations.Where(x => x.ProductId == productId).SingleOrDefault();
            }
        }

        public void SaveProductTranslation(ProductTranslation productTranslation)
        {
            using (var context = new ASContext())
            {
                context.Entry(productTranslation.Product).State = System.Data.Entity.EntityState.Unchanged;
                context.ProductTranslations.Add(productTranslation);
                context.SaveChanges();
            }
        }

        public void DeleteProductTranslation(int id)
        {
            using (var context = new ASContext())
            {
                var translation = context.ProductTranslations.Find(id);
                context.ProductTranslations.Remove(translation);
                context.SaveChanges();
            }
        }


        public CategoryTranslation GetCategoryTranslation(int id)
        {
            using (var context = new ASContext())
            {
                return context.CategoryTranslations.Find(id);
            }
        }

        public CategoryTranslation GetCategoryTranslationByCategory(int categoryId)
        {
            using (var context = new ASContext())
            {
                return context.CategoryTranslations.Where(x => x.CategoryId == categoryId).SingleOrDefault();
            }
        }

        public void SaveCategoryTranslation(CategoryTranslation categoryTranslation)
        {
            using (var context = new ASContext())
            {
                context.Entry(categoryTranslation.Category).State = System.Data.Entity.EntityState.Unchanged;
                context.CategoryTranslations.Add(categoryTranslation);
                context.SaveChanges();
            }
        }

        public void DeleteCategoryTranslation(int id)
        {
            using (var context = new ASContext())
            {
                var translation = context.CategoryTranslations.Find(id);
                context.CategoryTranslations.Remove(translation);
                context.SaveChanges();
            }
        }
        
    }
}
