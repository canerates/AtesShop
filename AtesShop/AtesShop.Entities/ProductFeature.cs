using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtesShop.Entities
{
    public class ProductFeature
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Feature")]
        public int FeatureId { get; set; }

        public virtual Feature Feature { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        public int OrderId { get; set; }

    }
}
