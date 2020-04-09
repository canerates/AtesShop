using AtesShop.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtesShop.Database
{
    public class ASContext : DbContext, IDisposable
    {
        public ASContext() : base("AtesShop-DB")
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<MainMenu> MainMenus { get; set; }
        public DbSet<SubMenu> SubMenus { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<ProductTranslation> ProductTranslations { get; set; }
        public DbSet<CategoryTranslation> CategoryTranslations { get; set; }
        
    }
}
