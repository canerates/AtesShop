using AtesShop.Entities;
using AtesShop.Resources;
using AtesShop.Services;
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
using AtesShop.Web.Helpers;

namespace AtesShop.Web.Controllers
{
    
    public class ProductsController : BaseController
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
        CategoryService categoryService = new CategoryService();
        ImageService imageService = new ImageService();
        private static IResourceProvider resourceProvider = new DbResourceProvider();
        ResourceKeyService keyService = new ResourceKeyService();
        PriceService priceService = new PriceService();
        
        [HttpGet]
        public ActionResult Index(int? categoryId, string search)
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

            ProductViewModel model = new ProductViewModel();
            
            model.Categories = categoryService.GetCategories();
            model.ProductCount = productService.GetProductsCount();
            model.MaximumPrice = priceService.GetMaximumPrice(CultureInfo.CurrentUICulture.Name, roleName);
            model.MinimumPrice = priceService.GetMinimumPrice(CultureInfo.CurrentUICulture.Name, roleName);
            model.SearchKey = search;

            if (categoryId.HasValue)
            {
                model.CategoryId = categoryId.Value;
            }

            return View(model);
        }
        
        [HttpGet]
        [NoDirectAccess]
        public ActionResult ProductList(string search, int? categoryId, int? pageNo, int? minimumPrice, int? maximumPrice, int? sortId, int? sortType, bool isList = false)
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
            
            ProductListViewModel model = new ProductListViewModel();
            model.IsListView = isList;

            int pageSize = isList ? 5 : 9;
            pageNo = pageNo.HasValue ? pageNo.Value : 1;
            var totalProducts = model.Products.Count;

            //Resource Key

            model.Products = productService.SearchProducts(search, categoryId, sortId, sortType, pageNo.Value, pageSize);

            if (categoryId.HasValue && categoryId != 0) model.CategoryId = categoryId.Value;
            else model.CategoryId = 0;

            foreach (var product in model.Products)
            {
                product.Images = imageService.GetImagesByList(product.ImageIdList);
                var keys = keyService.GetProductKeySetByProduct(product.Id);

                //Localization
                product.Name = resourceProvider.GetResource(keys.NameKey, CultureInfo.CurrentUICulture.Name) as string;
                product.Description = resourceProvider.GetResource(keys.DescriptionKey, CultureInfo.CurrentUICulture.Name) as string;
                product.Price = resourceProvider.GetPriceValue(keys.PriceKey, CultureInfo.CurrentUICulture.Name, roleName, false) as string;
                product.PrePrice = resourceProvider.GetPriceValue(keys.PriceKey, CultureInfo.CurrentUICulture.Name, roleName, true) as string;
            }

            model.Products = CommonHelper.FilterProductsByMaxMinPrice(model.Products, maximumPrice, minimumPrice);
            model.Products = CommonHelper.ProductsCurrencyFormat(model.Products, CultureInfo.CurrentUICulture.Name);

            model.Pager = new Pager(totalProducts, pageNo, pageSize);
            model.SortId = sortId.HasValue ? sortId.Value : 1;
            model.SortType = sortType.HasValue ? sortType.Value : 1;
            
            return PartialView(model);
        }

        [HttpGet]
        public ActionResult Detail(int id)
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

            var product = productService.GetProduct(id);
            var keys = keyService.GetProductKeySetByProduct(product.Id);
            ProductDetailViewModel model = new ProductDetailViewModel();

            if(product != null)
            {
                model.Id = product.Id;
                model.Name = product.Name;
                model.Description = product.Description;
                model.Price = resourceProvider.GetPriceValue(keys.PriceKey, CultureInfo.CurrentUICulture.Name, roleName, false) as string;
                model.PrePrice = resourceProvider.GetPriceValue(keys.PriceKey, CultureInfo.CurrentUICulture.Name, roleName, true) as string;
                model.CategoryId = product.CategoryId;
                model.ProductImages = imageService.GetImagesByList(product.ImageIdList);


                model.RelatedProducts = productService.GetProductsByCategory(product.CategoryId).Where(p => p.Id != id).ToList();

                foreach (var relatedProduct in model.RelatedProducts)
                {
                    relatedProduct.Images = imageService.GetImagesByList(relatedProduct.ImageIdList);
                }
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult Image(int id)
        {
            var image = imageService.GetImage(id);
            return File(image.Data, image.ContentType);
        }
    }
}