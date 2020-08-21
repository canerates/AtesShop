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

        public string UserId { get; set; }
        
        [ForeignKey("BillingAddress")]
        public int BillingAddressId { get; set; }
        
        public virtual OrderAddress BillingAddress { get; set; }

        [ForeignKey("ShippingAddress")]
        public int? ShippingAddressId { get; set; }
        
        public virtual OrderAddress ShippingAddress { get; set; }

        public DateTime Date { get; set; }

        public string Status { get; set; }

        public string PaymentType { get; set; }

        public string TotalPrice { get; set; }

        public string OrderNote { get; set; }

        public string TrackingId { get; set; }

        public string OrderId { get; set; }
        
        public virtual List<OrderItem> OrderItems { get; set; }
        
    }
}
