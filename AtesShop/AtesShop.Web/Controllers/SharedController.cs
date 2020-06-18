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
    public class SharedController : Controller
    {
        private static IResourceProvider resourceProvider = new DbResourceProvider();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MenuTabs()
        {
            MenuViewModel model = new MenuViewModel();
            model.MainMenuList = MenuService.Instance.GetMainMenuList();
            foreach (var main in model.MainMenuList)
            {
                main.Name = resourceProvider.GetResource(main.ResourceKey, CultureInfo.CurrentUICulture.Name) as string;
                main.SubMenus = MenuService.Instance.GetSubMenuListByParent(main.Id);

                foreach (var sub in main.SubMenus)
                {
                    sub.Name = resourceProvider.GetResource(sub.ResourceKey, CultureInfo.CurrentUICulture.Name) as string;
                }
            }

            return PartialView(model);
        }

        public ActionResult MobileMenu()
        {
            MenuViewModel model = new MenuViewModel();
            model.MainMenuList = MenuService.Instance.GetMainMenuList();
            foreach (var main in model.MainMenuList)
            {
                main.Name = resourceProvider.GetResource(main.ResourceKey, CultureInfo.CurrentUICulture.Name) as string;
                main.SubMenus = MenuService.Instance.GetSubMenuListByParent(main.Id);

                foreach (var sub in main.SubMenus)
                {
                    sub.Name = resourceProvider.GetResource(sub.ResourceKey, CultureInfo.CurrentUICulture.Name) as string;
                }
            }

            return PartialView(model);
        }

        public ActionResult LanguageMenu()
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

            return PartialView(model);
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

            return RedirectToAction("Index", "Home");
        }
        
        public ActionResult CartMenu()
        {

            CartViewModel model = new CartViewModel();

            var totalPrice = 0;
            Dictionary<int, string> subtotal = new Dictionary<int, string>();
            var CartProductsCookie = Request.Cookies["CartProducts"];

            if (CartProductsCookie != null && CartProductsCookie.Value != "")
            {
                model.CartProductIdList = CartProductsCookie.Value.Split('-').Select(x => int.Parse(x)).ToList();
                model.CartProducts = ProductService.Instance.GetProductsByIdList(model.CartProductIdList, CultureInfo.CurrentUICulture.Name, "User");
                totalPrice = model.CartProducts.Sum(x => int.Parse(x.Price) * model.CartProductIdList.Where(productId => productId == x.Id).Count());

                foreach (var product in model.CartProducts)
                {
                    subtotal.Add(product.Id, (int.Parse(product.Price) * model.CartProductIdList.Where(productId => productId == product.Id).Count()).ToString("C", new CultureInfo(CultureInfo.CurrentUICulture.Name)));
                }

                model.CartProductsSubTotal = subtotal;

                model.CartProducts = CommonHelper.FormatCurrency(model.CartProducts, CultureInfo.CurrentUICulture.Name);
                model.CartTotalPrice = totalPrice.ToString("C", new CultureInfo(CultureInfo.CurrentUICulture.Name));
            }

            return PartialView(model);
        }
    }
}