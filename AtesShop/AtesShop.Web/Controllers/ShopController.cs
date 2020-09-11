using AtesShop.Entities;
using AtesShop.Resources;
using AtesShop.Services;
using AtesShop.Web.Code;
using AtesShop.Web.Helpers;
using AtesShop.Web.Models;
using AtesShop.Web.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using static AtesShop.Web.Helpers.SharedHelper;

namespace AtesShop.Web.Controllers
{

    [NoDirectAccess]
    public class ShopController : BaseController
    {
        private static IResourceProvider resourceProvider = new DbResourceProvider();
        private CustomEmailService emailService = new CustomEmailService();

        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

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

        [HttpGet]
        [OutputCacheAttribute(VaryByParam = "*", Duration = 0, NoStore = true)]
        public ActionResult Index(int? categoryId, string search)
        {
            ShopViewModel model = new ShopViewModel();

            model.Categories = CategoryService.Instance.GetCategories(CultureInfo.CurrentUICulture.Name);
            model.ProductCount = ProductService.Instance.GetProductsCount();
            model.MaximumPrice = PriceService.Instance.GetMaximumPrice(CultureInfo.CurrentUICulture.Name, "User", categoryId);
            model.MinimumPrice = PriceService.Instance.GetMinimumPrice(CultureInfo.CurrentUICulture.Name, "User", categoryId);
            model.SearchKey = search;
            model.IsListView = false;

            if (categoryId.HasValue)
            {
                model.CategoryId = categoryId.Value;
            }

            return View(model);
        }

        [HttpGet]
        [AjaxChildActionOnly]
        public ActionResult ProductList(string search, int? categoryId, int? pageNo, int? minimumPrice, int? maximumPrice, int? sortId, int? sortType, int? pageSize, bool isList)
        {

            ShopListViewModel model = new ShopListViewModel();
            model.IsListView = isList;

            model.MaximumPrice = maximumPrice.HasValue ? maximumPrice.Value : 0;
            model.MinimumPrice = minimumPrice.HasValue ? minimumPrice.Value : 0;

            //int pageSize = isList ? 4 : 9;
            pageNo = pageNo.HasValue ? pageNo.Value : 1;
            model.PageSize = pageSize.HasValue ? pageSize.Value : isList ? 4 : 6;
            model.SearchKey = search;

            model.Products = ProductService.Instance.SearchProducts(search, CultureInfo.CurrentUICulture.Name, "User", categoryId, sortId, sortType, pageNo.Value, model.PageSize, minimumPrice, maximumPrice);

            if (categoryId.HasValue && categoryId != 0) model.CategoryId = categoryId.Value;
            else model.CategoryId = 0;
            
            model.Products = CommonHelper.FormatCurrency(model.Products, CultureInfo.CurrentUICulture.Name);
            if (Request.IsAuthenticated)
            {
                var userId = User.Identity.GetUserId();
                model.Products = CommonHelper.WishlistCheck(model.Products, userId);
            }
            var totalProductsCount = ProductService.Instance.SearchProductsCount(search, CultureInfo.CurrentUICulture.Name, "User", categoryId, minimumPrice, maximumPrice);

            model.Pager = new Pager(totalProductsCount, pageNo, model.PageSize);
            model.SortId = sortId.HasValue ? sortId.Value : 1;
            model.SortType = sortType.HasValue ? sortType.Value : 1;

            return PartialView(model);
        }

        [HttpGet]
        [OutputCacheAttribute(VaryByParam = "*", Duration = 0, NoStore = true)]
        public ActionResult Detail(int id)
        {
            ShopDetailViewModel model = new ShopDetailViewModel();
            var product = ProductService.Instance.GetProduct(id, CultureInfo.CurrentUICulture.Name, "User");

            if (product != null)
            {
                product = CommonHelper.FormatCurrency(product, CultureInfo.CurrentUICulture.Name);

                if (Request.IsAuthenticated)
                {
                    var userId = User.Identity.GetUserId();
                    product = CommonHelper.WishlistCheck(product, userId);
                }

                var key = ResourceKeyService.Instance.GetProductKeySetByProduct(product.Id);

                model.Id = product.Id;
                model.Name = resourceProvider.GetResource(key.NameKey, CultureInfo.CurrentUICulture.Name) as string;
                model.Description = resourceProvider.GetResource(key.DescriptionKey, CultureInfo.CurrentUICulture.Name) as string;
                model.Price = product.Price;
                model.PrePrice = product.PrePrice;
                model.IsDiscount = product.isDiscount;
                model.CategoryId = product.CategoryId;
                model.IsWished = product.isWished;
                model.ProductImages = product.Images;
                model.Rate = product.Rate;
                model.Stock = product.Stock;

                if (product.FileIdList != null)
                {
                    List<int> idList = product.FileIdList.Split(',').Select(int.Parse).ToList();
                    model.SpecFiles = FileService.Instance.GetFiles().Where(x => idList.Contains(x.Id)).ToList();
                }

                var attributes = AttributeService.Instance.GetProductAttributes(product.Id);

                foreach (var attr in attributes)
                {
                    attr.Key.Name = resourceProvider.GetResource("ASection" + attr.Key.AttributeSectionId, CultureInfo.CurrentUICulture.Name) as string;
                    foreach (var val in attr.Value)
                    {
                        val.AttributeType.Name = resourceProvider.GetResource("AType" + val.AttributeTypeId, CultureInfo.CurrentUICulture.Name) as string;
                        val.AttributeValue.Name = resourceProvider.GetResource("AValue" + val.AttributeValueId, CultureInfo.CurrentUICulture.Name) as string;
                    }
                }

                model.Attributes = attributes;

                var features = FeatureService.Instance.GetProductFeatures(product.Id);

                foreach (var feature in features)
                {
                    feature.FeatureValue = resourceProvider.GetResource("Feature" + feature.FeatureId, CultureInfo.CurrentUICulture.Name) as string;
                }

                model.ProductFeatures = features;

                model.RelatedProducts = ProductService.Instance.GetProductsByCategory(product.CategoryId, CultureInfo.CurrentUICulture.Name, "User").Where(p => p.Id != id).ToList();
                model.RelatedProducts = CommonHelper.FormatCurrency(model.RelatedProducts, CultureInfo.CurrentUICulture.Name);

                if (Request.IsAuthenticated)
                {
                    var userId = User.Identity.GetUserId();
                    model.RelatedProducts = CommonHelper.WishlistCheck(model.RelatedProducts, userId);
                }
                
                return View(model);
            }
            else { return HttpNotFound(); }
        }

        [HttpGet]
        [OutputCacheAttribute(VaryByParam = "*", Duration = 0, NoStore = true)]
        public ActionResult Cart()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CartProducts()
        {
            CartViewModel model = new CartViewModel();

            var totalPrice = 0;
            //double taxPrice = 0;
            //double totalPriceWithTax = 0;

            Dictionary<int, string> subtotal = new Dictionary<int, string>();
            var CartProductsCookie = Request.Cookies["CartProducts"];

            if (CartProductsCookie != null && CartProductsCookie.Value != "")
            {
                model.CartProductIdList = CartProductsCookie.Value.Split('-').Select(x => int.Parse(x)).ToList();
                model.CartProducts = ProductService.Instance.GetProductsByIdListForCart(model.CartProductIdList, CultureInfo.CurrentUICulture.Name, "User");
                model.CartProducts = model.CartProducts.Where(x => x.Stock != null || x.Stock.Available != 0).ToList();
                totalPrice = model.CartProducts.Sum(x => int.Parse(x.Price) * model.CartProductIdList.Where(productId => productId == x.Id).Count());
                //taxPrice = (0.05) * totalPrice;
                //totalPriceWithTax = totalPrice + taxPrice;

                foreach (var product in model.CartProducts)
                {
                    subtotal.Add(product.Id, (int.Parse(product.Price) * model.CartProductIdList.Where(productId => productId == product.Id).Count()).ToString("C", new CultureInfo(CultureInfo.CurrentUICulture.Name)));
                }

                model.CartProductsSubTotal = subtotal;

                model.CartProducts = CommonHelper.FormatCurrency(model.CartProducts, CultureInfo.CurrentUICulture.Name);
                model.CartTotalPrice = totalPrice.ToString("C", new CultureInfo(CultureInfo.CurrentUICulture.Name));
                //model.CartTaxPrice = taxPrice.ToString("C", new CultureInfo(CultureInfo.CurrentUICulture.Name));
                //model.CartTotalPriceWithTax = totalPriceWithTax.ToString("C", new CultureInfo(CultureInfo.CurrentUICulture.Name));
            }

            return PartialView(model);
        }

        [HttpGet]
        [Authorize]
        public ActionResult Checkout()
        {
            CheckoutViewModel model = new CheckoutViewModel();
            
            var totalPrice = 0;
            //double taxPrice = 0;
            //double totalPriceWithTax = 0;
            double shipmentFee = 0;
            double totalPriceWithShipment = 0;

            List<string> countries = new List<string>();

            countries.Add(Resources.Resources.Taiwan);
            //countries.Add(Resources.Resources.Vietnam);
            //countries.Add(Resources.Resources.Turkey);
            //countries.Add(Resources.Resources.USA);

            Dictionary<int, string> subtotal = new Dictionary<int, string>();
            var CartProductsCookie = Request.Cookies["CartProducts"];

            if (CartProductsCookie != null && CartProductsCookie.Value != "")
            {
                var cartProductIdList = CartProductsCookie.Value.Split('-').Select(x => int.Parse(x)).ToList();
                //model.CartProductIdList = CartProductsCookie.Value.Split('-').Select(x => int.Parse(x)).ToList();
                model.CartProducts = ProductService.Instance.GetProductsByIdListForCart(cartProductIdList, CultureInfo.CurrentUICulture.Name, "User");
                totalPrice = model.CartProducts.Sum(x => int.Parse(x.Price) * cartProductIdList.Where(productId => productId == x.Id).Count());

                var shipmentPrice = PriceService.Instance.GetPriceByKeyAndCulture("ShipmentFee", CultureInfo.CurrentUICulture.Name).Value;
                shipmentFee = Double.Parse(shipmentPrice);

                //taxPrice = (0.05) * totalPrice;
                //totalPriceWithTax = totalPrice + taxPrice + shipmentFee;
                totalPriceWithShipment = totalPrice + shipmentFee;
                
                List<ProductsQuantityViewModel> quantityList = new List<ProductsQuantityViewModel>();

                foreach (var product in model.CartProducts)
                {
                    var newQuantityModel = new ProductsQuantityViewModel();
                    newQuantityModel.productId = product.Id;
                    newQuantityModel.productQuantity = cartProductIdList.Where(productId => productId == product.Id).Count();
                    quantityList.Add(newQuantityModel);

                    subtotal.Add(product.Id, (int.Parse(product.Price) * newQuantityModel.productQuantity).ToString("C", new CultureInfo(CultureInfo.CurrentUICulture.Name)));
                }

                model.Quantities = quantityList;
                model.CartProductsSubTotal = subtotal;

                model.CartProducts = CommonHelper.FormatCurrency(model.CartProducts, CultureInfo.CurrentUICulture.Name);
                model.CartTotalPrice = totalPrice.ToString("C", new CultureInfo(CultureInfo.CurrentUICulture.Name));
                //model.CartTaxPrice = taxPrice.ToString("C", new CultureInfo(CultureInfo.CurrentUICulture.Name));
                //model.CartTotalPriceWithTax = totalPriceWithTax.ToString("C", new CultureInfo(CultureInfo.CurrentUICulture.Name));
                model.ShipmentFee = shipmentFee.ToString("C", new CultureInfo(CultureInfo.CurrentUICulture.Name));
                model.CartTotalPriceWithShipment = totalPriceWithShipment.ToString("C", new CultureInfo(CultureInfo.CurrentUICulture.Name));

                model.CountryList = countries;
            }

            if (Request.IsAuthenticated)
            {
                model.User = UserManager.FindById(User.Identity.GetUserId());
                model.UserAddressList = UserService.Instance.GetUserAddressList(model.User.Id);
            }


            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Checkout(CheckoutViewModel model)
        {
            ModelState["EmailOrUserName"].Errors.Clear();
            ModelState["Password"].Errors.Clear();

            //if (model.SelectedAddress != 0)
            //{
            //    ModelState["Bill.FirstName"].Errors.Clear();
            //    ModelState["Bill.LastName"].Errors.Clear();
            //    ModelState["Bill.Address1"].Errors.Clear();
            //    ModelState["Bill.City"].Errors.Clear();
            //    ModelState["Bill.State"].Errors.Clear();
            //    ModelState["Bill.ZipCode"].Errors.Clear();
            //    ModelState["Bill.Email"].Errors.Clear();
            //    ModelState["Bill.Phone"].Errors.Clear();

            //}

            if (!ModelState.IsValid)
            {
                return RedirectToAction("Error", "Home");
            }

            var orderId = "";
            var billAddress = new OrderAddress();
            var shipAddress = new OrderAddress();

            if (Request.IsAuthenticated)
            {
                if (model.SelectedAddress != 0)
                {
                    var selectedAddress = UserService.Instance.GetUserAddress(model.SelectedAddress);

                    //Create bill order address
                    billAddress = generateOrderAddress(selectedAddress.FirstName, selectedAddress.LastName, selectedAddress.CompanyName, selectedAddress.Email, selectedAddress.Phone, selectedAddress.Country, selectedAddress.State, selectedAddress.City, selectedAddress.ZipCode, selectedAddress.Line1, selectedAddress.Line2);
                    OrderService.Instance.SaveOrderAddress(billAddress);

                }
                else
                {
                    //Create bill order address
                    billAddress = generateOrderAddress(model.Bill.FirstName, model.Bill.LastName, model.Bill.CompanyName, model.Bill.Email, model.Bill.PhoneNumber, model.Bill.Country, model.Bill.State, model.Bill.City, model.Bill.ZipCode, model.Bill.Address1, model.Bill.Address2);
                    OrderService.Instance.SaveOrderAddress(billAddress);

                    //Save user adress
                    if (model.Bill.SaveAddress)
                    {
                        var newUserAddress = new UserAddress();
                        newUserAddress.FirstName = billAddress.FirstName;
                        newUserAddress.LastName = billAddress.LastName;
                        newUserAddress.CompanyName = billAddress.CompanyName;
                        newUserAddress.Email = billAddress.Email;
                        newUserAddress.Phone = billAddress.Phone;
                        newUserAddress.Country = billAddress.Country;
                        newUserAddress.State = billAddress.State;
                        newUserAddress.City = billAddress.City;
                        newUserAddress.ZipCode = billAddress.ZipCode;
                        newUserAddress.Line1 = billAddress.Line1;
                        newUserAddress.Line2 = billAddress.Line2;
                        newUserAddress.UserId = User.Identity.GetUserId();

                        UserService.Instance.SaveUserAddress(newUserAddress);
                    }
                }

                if (model.Ship.isShipDifferent)
                {
                    //Create ship order address
                    shipAddress = generateOrderAddress(model.Ship.FirstName, model.Ship.LastName, model.Ship.CompanyName, model.Ship.Email, model.Ship.PhoneNumber, model.Ship.Country, model.Ship.State, model.Ship.City, model.Ship.ZipCode, model.Ship.Address1, model.Ship.Address2);
                    OrderService.Instance.SaveOrderAddress(shipAddress);
                }
                else
                {
                    shipAddress = billAddress;
                }

                //Create order
                var newOrder = new Order();
                newOrder.BillingAddress = billAddress;
                newOrder.ShippingAddress = shipAddress;
                newOrder.Date = DateTime.Now;
                newOrder.Status = OrderStatus.Pending.ToString();
                newOrder.TotalPrice = model.CartTotalPriceWithShipment;
                newOrder.UserId = User.Identity.GetUserId();
                newOrder.PaymentType = "Not Confirmed.";
                newOrder.OrderNote = model.OrderNote;
                OrderService.Instance.SaveOrder(newOrder);

                //Update order
                var suffix = newOrder.Id.ToString("D8");
                newOrder.OrderId = "PA" + suffix;
                OrderService.Instance.UpdateOrder(newOrder);

                orderId = newOrder.OrderId;

                //Create order items

                foreach (var qty in model.Quantities)
                {
                    var product = ProductService.Instance.GetProduct(qty.productId);

                    var newOrderItem = new OrderItem();
                    newOrderItem.Order = newOrder;
                    newOrderItem.Product = product;
                    newOrderItem.Quantity = qty.productQuantity;

                    OrderService.Instance.SaveOrderItem(newOrderItem);

                    var inventory = InventoryService.Instance.GetInventory(qty.productId);

                    inventory.Allocation = inventory.Allocation + qty.productQuantity;
                    inventory.Available = inventory.Available - qty.productQuantity;

                    InventoryService.Instance.UpdateInventory(inventory);

                }

                //Send Mail

                var toAddress = shipAddress.Email;
                var subject = "Your order " + newOrder.OrderId + " registered!";
                
                var message = emailService.PopulateNewOrderMail(billAddress.FirstName, billAddress.LastName, newOrder.OrderId, newOrder.Date.ToString(), billAddress.Email, newOrder.TotalPrice);
                
                await emailService.SendEmail(toAddress, subject, message);

            }
            else
            {
                ////Create account 
                //if (model.Account.CreateAccount)
                //{
                //    var user = new ApplicationUser { UserName = model.Account.UserName, Email = model.Account.Email, FirstName = model.Bill.FirstName, LastName = model.Bill.LastName };
                //    var result = UserManager.Create(user, model.Account.Password);

                //    if (result.Succeeded)
                //    {
                //        result = UserManager.AddToRole(user.Id, "User");
                //        SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                //    }
                //    else
                //    {
                //        return View(model);
                //    }
                //}
                
                //Create bill order address
                billAddress = generateOrderAddress(model.Bill.FirstName, model.Bill.LastName, model.Bill.CompanyName, model.Bill.Email, model.Bill.PhoneNumber, model.Bill.Country, model.Bill.State, model.Bill.City, model.Bill.ZipCode, model.Bill.Address1, model.Bill.Address2);
                OrderService.Instance.SaveOrderAddress(billAddress);

                if (model.Ship.isShipDifferent)
                {
                    //Create ship order address
                    shipAddress = generateOrderAddress(model.Ship.FirstName, model.Ship.LastName, model.Ship.CompanyName, model.Ship.Email, model.Ship.PhoneNumber, model.Ship.Country, model.Ship.State, model.Ship.City, model.Ship.ZipCode, model.Ship.Address1, model.Ship.Address2);
                    OrderService.Instance.SaveOrderAddress(shipAddress);
                }
                else
                {
                    shipAddress = billAddress;
                }

                //Create order
                var newOrder = new Order();
                newOrder.BillingAddress = billAddress;
                newOrder.ShippingAddress = shipAddress;
                newOrder.Date = DateTime.Now;
                newOrder.Status = OrderStatus.Pending.ToString();
                newOrder.TotalPrice = model.CartTotalPriceWithShipment;
                newOrder.UserId = "NULL";
                newOrder.PaymentType = "Not Confirmed.";
                newOrder.OrderNote = model.OrderNote;
                
                //Save order
                OrderService.Instance.SaveOrder(newOrder);

                //Update order

                var suffix = newOrder.Id.ToString("D8");
                newOrder.OrderId = "PA" + suffix;
                OrderService.Instance.UpdateOrder(newOrder);

                orderId = newOrder.OrderId;

                //Create order items

                foreach (var qty in model.Quantities)
                {
                    var product = ProductService.Instance.GetProduct(qty.productId);

                    var newOrderItem = new OrderItem();
                    newOrderItem.Order = newOrder;
                    newOrderItem.Product = product;
                    newOrderItem.Quantity = qty.productQuantity;

                    OrderService.Instance.SaveOrderItem(newOrderItem);

                    var inventory = InventoryService.Instance.GetInventory(qty.productId);

                    inventory.Allocation = inventory.Allocation + qty.productQuantity;
                    inventory.Available = inventory.Available - qty.productQuantity;

                    InventoryService.Instance.UpdateInventory(inventory);
                }
            }

            if (Request.Cookies["CartProducts"] != null)
            {
                String cookieName = Request.Cookies["CartProducts"].Name;
                HttpCookie cartCookie = new HttpCookie(cookieName);
                cartCookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(cartCookie);
            }

            return RedirectToAction("Success", "Shop", new { orderId = orderId });
        }
        
        [HttpGet]
        //[NoDirectAccess]
        public ActionResult Success(string orderId)
        {
            OrderSuccessViewModel model = new OrderSuccessViewModel();
            model.OrderId = orderId.ToUpper();

            return View(model);
        }
        
        private OrderAddress generateOrderAddress(
            string firstname, 
            string lastname, 
            string companyname, 
            string email, 
            string phone, 
            string country, 
            string state, 
            string city, 
            string zipcode, 
            string line1, 
            string line2
            )
        {
            var newAddress = new OrderAddress();
            newAddress.FirstName = firstname;
            newAddress.LastName = lastname;
            newAddress.CompanyName = companyname;
            newAddress.Email = email;
            newAddress.Phone = phone;
            newAddress.Country = country;
            newAddress.State = state;
            newAddress.City = city;
            newAddress.ZipCode = zipcode;
            newAddress.Line1 = line1;
            newAddress.Line2 = line2;

            return newAddress;
        }
        
    }
}