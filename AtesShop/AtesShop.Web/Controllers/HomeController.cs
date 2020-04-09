using AtesShop.Resources;
using AtesShop.Services;
using AtesShop.Web.Helpers;
using AtesShop.Web.ViewModels;
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
        ProductService productService = new ProductService();
        ImageService imageService = new ImageService();
        MenuService menuService = new MenuService();
        private static IResourceProvider resourceProvider = new DbResourceProvider();

        public ActionResult Index()
        {
            HomeViewModel model = new HomeViewModel();

            model.FeaturedProducts = productService.GeFeaturedProducts();

            foreach (var product in model.FeaturedProducts)
            {
                product.Images = imageService.GetImagesByList(product.ImageIdList);
            }

            model.NewProducts = productService.GetNewProducts();

            foreach (var product in model.NewProducts)
            {
                product.Images = imageService.GetImagesByList(product.ImageIdList);
            }

            model.TopRatedProducts = productService.GetTopRatedProducts();

            foreach (var product in model.TopRatedProducts)
            {
                product.Images = imageService.GetImagesByList(product.ImageIdList);
            }

            model.BestSellerProducts = productService.GetBestSellerProducts();

            foreach (var product in model.BestSellerProducts)
            {
                product.Images = imageService.GetImagesByList(product.ImageIdList);
            }

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