using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtesShop.Entities
{
    public class Order
    {
        public int Id { get; set; }

        [ForeignKey("BillingDetail")]
        public int BillingDetailId { get; set; }
        
        public virtual OrderDetail BillingDetail { get; set; }

        [ForeignKey("ShippingDetail")]
        public int? ShippingDetailId { get; set; }
        
        public virtual OrderDetail ShippingDetail { get; set; }

        public DateTime Date { get; set; }

        public string Status { get; set; }

        public string TotalPrice { get; set; }

        public virtual List<OrderItem> OrderItems { get; set; }
        
    }
}
