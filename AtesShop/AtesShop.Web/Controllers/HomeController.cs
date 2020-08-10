using AtesShop.Resources;
using AtesShop.Services;
using AtesShop.Web.Code;
using AtesShop.Web.Helpers;
using AtesShop.Web.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AtesShop.Web.Controllers
{
    public class HomeController : BaseController
    {
        private ApplicationUserManager _userManager;
        private ApplicationRoleManager _roleManager;
        private CustomEmailService emailService = new CustomEmailService();

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
        
        private static IResourceProvider resourceProvider = new DbResourceProvider();

        public ActionResult Index()
        {
            string roleName;

            if (User.Identity.IsAuthenticated)
            {
                roleName = UserManager.GetRoles(User.Identity.GetUserId()).FirstOrDefault();

            }
            else
            {
                roleName = "User";
            }

            HomeViewModel model = new HomeViewModel();

            var products = ProductService.Instance.GetProducts(CultureInfo.CurrentUICulture.Name, roleName);
            
            products = CommonHelper.FormatCurrency(products, CultureInfo.CurrentUICulture.Name);

            model.FeaturedProducts = products.Where(x => x.isFeatured).ToList();

            model.NewProducts = products.Where(x => x.isNew).ToList();

            model.TopRatedProducts = products.Where(x => x.isTopRated).ToList();

            model.BestSellerProducts = products.Where(x => x.isBestSeller).ToList();
            

            return View(model);
        }

        [HttpGet]
        public ActionResult About()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Contact(ContactViewModel model)
        {

            if (ModelState.IsValid)
            {
                var toAddress = ConfigurationManager.AppSettings["PAEditorEmail"];
                var fromAddress = model.Email.ToString();
                var subject = "Message from " + model.Name;
                var messageBody = new StringBuilder();
                messageBody.Append("<p>Name: " + model.Name + "</p>");
                messageBody.Append("<p>Email: " + model.Email + "</p>");
                messageBody.Append("<p>Website: " + model.Website + "</p>");
                messageBody.Append("<p>Subject: " + model.Subject + "</p>");
                messageBody.Append(model.Message);
                var message = messageBody.ToString();

                await emailService.SendEmail(toAddress, fromAddress, subject, message);

            }

            return RedirectToAction("Contact", "Home");
        }

        [HttpGet]
        public ActionResult Error()
        {
            return View();
        } 
    }
}