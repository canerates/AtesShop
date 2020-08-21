using AtesShop.Services;
using AtesShop.Web.Code;
using AtesShop.Web.Helpers;
using AtesShop.Web.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static AtesShop.Web.Helpers.SharedHelper;

namespace AtesShop.Web.Controllers
{
    [NoDirectAccess]
    [Authorize(Roles = "Admin")]
    public class OrderController : BaseController
    {
        private ApplicationUserManager _userManager;
        private ApplicationRoleManager _roleManager;

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public ApplicationRoleManager RoleManager
        {
            get
            {
                return _roleManager ?? HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
            }
            private set
            {
                _roleManager = value;
            }
        }

        // GET: Order
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult OrderList()
        {
            OrderListViewModel model = new OrderListViewModel();
            
            var orders = OrderService.Instance.GetOrders();
            model.Orders = orders;
            
            return PartialView(model);
        }

        public ActionResult OrderItem(int id)
        {
            SingleOrderViewModel model = new SingleOrderViewModel();

            var order = OrderService.Instance.GetOrder(id);
            var user = UserManager.FindById(order.UserId);

            OrderStatus status = (OrderStatus)Enum.Parse(typeof(OrderStatus), order.Status);
            order.Status = status.GetDisplayDescription();

            model.Order = order;
            model.UserEmail = user.Email;
            model.Username = user.FirstName + " " + user.LastName;

            return PartialView(model);
        }

        public ActionResult OrderItemInfo(int id)
        {
            SingleOrderInfoViewModel model = new SingleOrderInfoViewModel();

            var order = OrderService.Instance.GetOrder(id);
            var user = UserManager.FindById(order.UserId);
            var roles = UserManager.GetRoles(user.Id);

            OrderStatus status = (OrderStatus)Enum.Parse(typeof(OrderStatus), order.Status);
            order.Status = status.GetDisplayDescription();

            model.Order = order;
            model.BillingAddress = order.BillingAddress;
            model.ShippingAddress = order.ShippingAddress;
            model.CustomerEmail = user.Email;
            model.CustomerName = user.FirstName + " " + user.LastName;
            model.CustomerUserName = user.UserName; 
            model.CustomerRole = roles.FirstOrDefault();

            if (user.PhoneNumber != null)
            {
                model.CustomerPhone = user.PhoneNumber;
            }
            else
            {
                model.CustomerPhone = "-";
            }

            List<OrderItemViewModel> itemList = new List<OrderItemViewModel>();

            foreach (var item in order.OrderItems)
            {
                OrderItemViewModel element = new OrderItemViewModel();

                var product = ProductService.Instance.GetProductForOrderList(item.ProductId, CultureInfo.CurrentUICulture.Name, "User");
                element.Product = product;
                element.Quantity = item.Quantity;

                itemList.Add(element);

            }

            model.OrderItems = itemList;
            
            
            return PartialView(model);
        }

        [HttpGet]
        public ActionResult OrderItemEdit(int id)
        {
            SingleOrderEditViewModel model = new SingleOrderEditViewModel();

            var availableOrderStats = Enum.GetValues(typeof(OrderStatus)).OfType<OrderStatus>().ToList();
            
            var order = OrderService.Instance.GetOrder(id);

            OrderStatus selectedStatus = (OrderStatus)Enum.Parse(typeof(OrderStatus), order.Status);

            model.TrackingId = order.TrackingId;
            model.OrderId = order.OrderId;
            model.AvailableOrderStatus = availableOrderStats;
            model.SelectedOrderStatus = selectedStatus;
            model.Id = order.Id;

            return PartialView(model);
        }

        [HttpPost]
        public ActionResult OrderItemEdit(SingleOrderEditViewModel model)
        {
            var order = OrderService.Instance.GetOrder(model.Id);

            OrderStatus status = (OrderStatus)Enum.Parse(typeof(OrderStatus), model.SelectedOrderStatus.ToString());
            order.Status = model.SelectedOrderStatus.ToString();

            order.TrackingId = model.TrackingId;

            OrderService.Instance.UpdateOrder(order);

            return RedirectToAction("OrderList");
        }

    }
}