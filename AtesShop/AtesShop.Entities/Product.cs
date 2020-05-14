using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtesShop.Entities
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Price { get; set; }

        public string PrePrice { get; set; }
        
        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public string ImageIdList { get; set; }

        public bool isDiscount { get; set; }
        
        public bool isFeatured { get; set; }

        public bool isNew { get; set; }

        //temp
        public bool isTopRated { get; set; }

        //temp
        public bool isBestSeller { get; set; }
        
        [NotMapped]
        public List<Image> Images { get; set; }

        public virtual List<Rating> Ratings { get; set; }

        [NotMapped]
        public decimal Rate { get; set; }
        

        public virtual List<ProductAttribute> Attributes { get; set; }
        
    }
}
