using AtesShop.Database;
using AtesShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtesShop.Services
{
    public class OrderService
    {
        #region Singleton
        public static OrderService Instance
        {
            get
            {
                if (instance == null) instance = new OrderService();

                return instance;
            }
        }
        private static OrderService instance { get; set; }

        private OrderService()
        {
        }

        #endregion

        #region Admin

        #endregion

        #region Web

        #region OrderItem

        public List<OrderItem> GetOrderItems()
        {
            using (var context = new ASContext())
            {
                return context.OrderItems.ToList();
            }
        }

        public void SaveOrderItem(OrderItem item)
        {
            using (var context = new ASContext())
            {
                context.Entry(item.Product).State = System.Data.Entity.EntityState.Unchanged;
                context.Entry(item.Order).State = System.Data.Entity.EntityState.Unchanged;
                context.OrderItems.Add(item);
                context.SaveChanges();
            }
        }

        #endregion
        
        #region Order

        public List<Order> GetOrders()
        {
            using (var context = new ASContext())
            {
                return context.Orders.ToList();
            }
        }

        public void SaveOrder(Order order)
        {
            using (var context = new ASContext())
            {
                context.Entry(order.BillingDetail).State = System.Data.Entity.EntityState.Unchanged;
                context.Entry(order.ShippingDetail).State = System.Data.Entity.EntityState.Unchanged;
                context.Orders.Add(order);
                context.SaveChanges();
            }
        }

        #endregion

        #region OrderDetail

        public List<OrderDetail> GetOrderDetails()
        {
            using (var context = new ASContext())
            {
                return context.OrderDetails.ToList();
            }
        }

        public void SaveOrderDetail(OrderDetail orderDetail)
        {
            using (var context = new ASContext())
            {
                context.Entry(orderDetail.Address).State = System.Data.Entity.EntityState.Unchanged;
                context.OrderDetails.Add(orderDetail);
                context.SaveChanges();
            }
        }

        #endregion

        #region Address

        public List<Address> GetAddresses()
        {
            using (var context = new ASContext())
            {
                return context.Addresses.ToList();
            }
        }

        public void SaveAddress(Address address)
        {
            using (var context = new ASContext())
            {
                context.Addresses.Add(address);
                context.SaveChanges();
            }
        }

        #endregion
        
        #endregion

    }
}
