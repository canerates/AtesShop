using AtesShop.Resources;
using AtesShop.Services;
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

namespace AtesShop.Web.Controllers
{
    public class HomeController : BaseController
    {
        private ApplicationUserManager _userManager;
        private ApplicationRoleManager _roleManager;

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

        [HttpGet]
        public ActionResult Error()
        {
            return View();
        } 
    }
}