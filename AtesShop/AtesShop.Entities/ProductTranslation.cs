using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtesShop.Entities
{
    public class ProductTranslation
    {
        
        public int Id { get; set; }
        
        public string ProductNameResourceKey { get; set; }
        
        public string ProductDescriptionResourceKey { get; set; }
        
        public string ProductPriceResourceKey { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
        
    }
}
