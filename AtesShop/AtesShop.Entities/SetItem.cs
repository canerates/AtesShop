using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtesShop.Entities
{
    [Table("ProductSetItems")]
    public class SetItem
    {
        [Key]
        public int ItemId { get; set; }

        [ForeignKey("Product")]
        public int ProductSetId { get; set; }

        public virtual Product Product { get; set; }

        public int ItemProductID { get; set; }

        public string ItemProductName { get; set; }

        public string ItemProductDescription { get; set; }

        public int ItemProductQuantity { get; set; }

        public int OrderId { get; set; }

        public bool isOptional { get; set; }

    }
}
