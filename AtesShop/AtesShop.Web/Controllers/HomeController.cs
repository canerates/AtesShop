using AtesShop.Services;
using AtesShop.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AtesShop.Web.Controllers
{
    public class HomeController : Controller
    {
        ProductService productService = new ProductService();
        ImageService imageService = new ImageService();
        MenuService menuService = new MenuService();

        public ActionResult Index()
        {
            HomeViewModel model = new HomeViewModel();

            model.FeaturedProducts = productService.GeFeaturedProducts();

            foreach (var product in model.FeaturedProducts)
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
            ViewBag.Message = "Your contact page.";

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
                main.SubMenus = menuService.GetSubMenus(main.Id);
            }
            
            return PartialView("_Menu", model);
        }
    }
}