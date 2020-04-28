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

        ProductService productService = new ProductService();
        ImageService imageService = new ImageService();
        MenuService menuService = new MenuService();
        ResourceKeyService keyService = new ResourceKeyService();
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

            var products = productService.GetProducts();

            foreach (var product in products)
            {
                product.Images = imageService.GetImagesByList(product.ImageIdList);
                var keys = keyService.GetProductKeySetByProduct(product.Id);

                //Localization
                product.Name = resourceProvider.GetResource(keys.NameKey, CultureInfo.CurrentUICulture.Name) as string;
                product.Description = resourceProvider.GetResource(keys.DescriptionKey, CultureInfo.CurrentUICulture.Name) as string;
                product.Price = resourceProvider.GetPriceValue(keys.PriceKey, CultureInfo.CurrentUICulture.Name, roleName, false) as string;
                product.PrePrice = resourceProvider.GetPriceValue(keys.PriceKey, CultureInfo.CurrentUICulture.Name, roleName, true) as string;
            }
            
            products = CommonHelper.ProductsCurrencyFormat(products, CultureInfo.CurrentUICulture.Name);

            model.FeaturedProducts = products.Where(x => x.isFeatured).ToList();

            model.NewProducts = products.Where(x => x.isNew).ToList();

            model.TopRatedProducts = products.Where(x => x.isTopRated).ToList();

            model.BestSellerProducts = products.Where(x => x.isBestSeller).ToList();
            

            return View(model);
        }

        [HttpGet]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page. ";

            return View();
        }

        [HttpGet]
        public ActionResult Error()
        {
            ViewBag.Message = "Page Not Found";

            return View();
        } 

        public ActionResult ShowMenu()
        {
            MenuViewModel model = new MenuViewModel();
            model.MainMenuList = menuService.GetMainMenus();
            foreach (var main in model.MainMenuList)
            {
                main.Name = resourceProvider.GetResource(main.ResourceKey, CultureInfo.CurrentUICulture.Name) as string;
                main.SubMenus = menuService.GetSubMenuByParent(main.Id);

                foreach (var sub in main.SubMenus)
                {
                    sub.Name = resourceProvider.GetResource(sub.ResourceKey, CultureInfo.CurrentUICulture.Name) as string;
                }
            }
            
            return PartialView("_Menu", model);
        }

        public ActionResult ShowMobileMenu()
        {
            MenuViewModel model = new MenuViewModel();
            model.MainMenuList = menuService.GetMainMenus();
            foreach (var main in model.MainMenuList)
            {
                main.Name = resourceProvider.GetResource(main.ResourceKey, CultureInfo.CurrentUICulture.Name) as string;
                main.SubMenus = menuService.GetSubMenuByParent(main.Id);

                foreach (var sub in main.SubMenus)
                {
                    sub.Name = resourceProvider.GetResource(sub.ResourceKey, CultureInfo.CurrentUICulture.Name) as string;
                }
            }

            return PartialView("_MobileMenu", model);
        }

        public ActionResult ShowLangMenu()
        {
            LangMenuViewModel model = new LangMenuViewModel();

            Dictionary<string, string> languages = new Dictionary<string, string>();
            Dictionary<string, string> currencies = new Dictionary<string, string>();

            languages.Add("en-us", "English");
            languages.Add("tr-tr", "Türkçe");
            languages.Add("zh-tw", "中文");

            currencies.Add("en-us", "USD");
            currencies.Add("tr-tr", "TRY");
            currencies.Add("zh-tw", "NTD");

            model.Languages = languages;
            model.Currencies = currencies;

            if (Request.Cookies["_culture"] != null)
            {
                string culture = Request.Cookies["_culture"].Value;
                model.SelectedLanguage = languages[culture];
                model.SelectedCurrency = currencies[culture];
            }
            else
            {
                model.SelectedLanguage = languages["en-us"];
                model.SelectedCurrency = currencies["en-us"];
            }
            
            return PartialView("_LangMenu", model);
        }

        public ActionResult SetCulture(string culture)
        {
            // Validate input
            culture = CultureHelper.GetImplementedCulture(culture);

            RouteData.Values["culture"] = culture;
            

            // Save culture in a cookie
            
            HttpCookie cookie = new HttpCookie("_culture");
            cookie.Value = culture;
            cookie.Expires = DateTime.Now.AddYears(1);
            
            Response.Cookies.Add(cookie);

            return RedirectToAction("Index");
        }
    }
}