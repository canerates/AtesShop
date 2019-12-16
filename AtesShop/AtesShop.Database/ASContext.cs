using AtesShop.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtesShop.Database
{
    public class ASContext : DbContext
    {
        public ASContext() : base("AtesShopConnection")
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Properties { get; set; }

    }
}
