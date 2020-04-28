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
using System.Web.Security;
using static AtesShop.Web.Helpers.SharedHelper;

namespace AtesShop.Web.Controllers
{
    public class ShopController : BaseController
    {
        ProductService productService = new ProductService();
        CategoryService categoryService = new CategoryService();
        ImageService imageService = new ImageService();
        PriceService priceService = new PriceService();
        private static IResourceProvider resourceProvider = new DbResourceProvider();
        ResourceKeyService keyService = new ResourceKeyService();

        [HttpGet]
        public ActionResult Index(int? categoryId, string search)
        {
            ShopViewModel model = new ShopViewModel();
            
            model.Categories = categoryService.GetCategories();
            model.ProductCount = productService.GetProductsCount();
            model.MaximumPrice = priceService.GetMaximumPrice(CultureInfo.CurrentUICulture.Name, "User");
            model.MinimumPrice = priceService.GetMinimumPrice(CultureInfo.CurrentUICulture.Name, "User");
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
            
            ShopListViewModel model = new ShopListViewModel();
            model.IsListView = isList;

            int pageSize = isList ? 5 : 9;
            pageNo = pageNo.HasValue ? pageNo.Value : 1;
            
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
                product.Price = resourceProvider.GetPriceValue(keys.PriceKey, CultureInfo.CurrentUICulture.Name, "User", false) as string;
                product.PrePrice = resourceProvider.GetPriceValue(keys.PriceKey, CultureInfo.CurrentUICulture.Name, "User", true) as string;

            }
            model.Products = CommonHelper.FilterProductsByMaxMinPrice(model.Products, maximumPrice, minimumPrice);
            model.Products = CommonHelper.ProductsCurrencyFormat(model.Products, CultureInfo.CurrentUICulture.Name);
            var totalProducts = model.Products.Count;

            model.Pager = new Pager(totalProducts, pageNo, pageSize);
            model.SortId = sortId.HasValue ? sortId.Value : 1;
            model.SortType = sortType.HasValue ? sortType.Value : 1;

            return PartialView(model);
        }

        public ActionResult Detail(int id)
        {
            var product = productService.GetProduct(id);
            var keys = keyService.GetProductKeySetByProduct(id);
            ShopDetailViewModel model = new ShopDetailViewModel();
            
            if (product != null)
            {
                model.Id = product.Id;
                model.Name = product.Name;
                model.Description = product.Description;
                model.Price = resourceProvider.GetPriceValue(keys.PriceKey, CultureInfo.CurrentUICulture.Name, "User", false) as string;
                model.PrePrice = resourceProvider.GetPriceValue(keys.PriceKey, CultureInfo.CurrentUICulture.Name, "User", true) as string;
                model.isDiscount = product.isDiscount;
                model.CategoryId = product.CategoryId;
                model.ProductImages = imageService.GetImagesByList(product.ImageIdList);
                
                model.RelatedProducts = productService.GetProductsByCategory(product.CategoryId).Where(p => p.Id != id).ToList();

                foreach (var relatedProduct in model.RelatedProducts)
                {
                    relatedProduct.Images = imageService.GetImagesByList(relatedProduct.ImageIdList);
                }

                return View(model);
            }
            else { return HttpNotFound(); }
        }

    }
}