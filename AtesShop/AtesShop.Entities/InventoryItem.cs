using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtesShop.Entities
{
    [Table("Inventory")]
    public class InventoryItem
    {
        [Key, ForeignKey("Product")]
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        public int Total { get; set; }

        public int Available { get; set; }

        public int Allocation { get; set; }
        
    }
}
