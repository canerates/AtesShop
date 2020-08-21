using AtesShop.Entities;
using AtesShop.Web.Code;
using Foolproof;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AtesShop.Web.ViewModels
{

    public class OrderListViewModel
    {
        public List<Order> Orders { get; set; }
    }

    public class SingleOrderViewModel
    {
        public string Username { get; set; }
        public string UserEmail { get; set; }
        public string UserRole { get; set; }

        public Order Order { get; set; }

        public OrderAddress BillingAddress { get; set; }
        public OrderAddress ShippingAddress { get; set; }
        
        public List<OrderItem> OrderItems { get; set; }
        
    }

    public class SingleOrderInfoViewModel
    {
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerRole { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerUserName { get; set; }

        public Order Order { get; set; }

        public OrderAddress BillingAddress { get; set; }
        public OrderAddress ShippingAddress { get; set; }

        public List<OrderItemViewModel> OrderItems { get; set; }
    }

    public class SingleOrderEditViewModel
    {
        public int Id { get; set; }
        public string OrderId { get; set; }
        public string TrackingId { get; set; }
        public List<OrderStatus> AvailableOrderStatus { get; set; }
        public OrderStatus SelectedOrderStatus { get; set; }


    }

    public class OrderItemViewModel
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }

    }


}