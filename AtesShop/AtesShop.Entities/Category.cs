using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtesShop.Entities
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
        
        public virtual List<Product> Products { get; set; }

        public string ImageIdList { get; set; }

        public bool isHidden { get; set; }
        
    }
}
