using AtesShop.Entities;
using AtesShop.Resources;
using AtesShop.Services;
using AtesShop.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static AtesShop.Web.Helpers.SharedHelper;

namespace AtesShop.Web.Controllers
{
    
    public class ProductsController : BaseController
    {
        ProductService productService = new ProductService();
        CategoryService categoryService = new CategoryService();
        ImageService imageService = new ImageService();
        private static IResourceProvider resourceProvider = new DbResourceProvider();
        TranslationService translationService = new TranslationService();

        [HttpGet]
        public ActionResult Index(int? categoryId, string search)
        {
            ProductViewModel model = new ProductViewModel();
            
            model.Categories = categoryService.GetCategories();
            model.ProductCount = productService.GetProductsCount();
            model.MaximumPrice = productService.GetMaximumPrice();
            model.MinimumPrice = productService.GetMinimumPrice();
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
            ProductListViewModel model = new ProductListViewModel();
            model.IsListView = isList;

            int pageSize = isList ? 5 : 9;
            pageNo = pageNo.HasValue ? pageNo.Value : 1;
            var totalProducts = productService.SearchProductsCount(search, categoryId, maximumPrice, minimumPrice, sortId);
            
            //translation
            

            model.Products = productService.SearchProducts(search, categoryId, maximumPrice, minimumPrice, sortId, sortType, pageNo.Value, pageSize);

            if (categoryId.HasValue && categoryId != 0) model.CategoryId = categoryId.Value;
            else model.CategoryId = 0;

            foreach (var product in model.Products)
            {
                product.Images = imageService.GetImagesByList(product.ImageIdList);
                var translation = translationService.GetProductTranslationByProduct(product.Id);

                //Localization
                product.Name = resourceProvider.GetResource(translation.ProductNameResourceKey, CultureInfo.CurrentUICulture.Name) as string;
                product.Description = resourceProvider.GetResource(translation.ProductDescriptionResourceKey, CultureInfo.CurrentUICulture.Name) as string;
                //product.Price = resourceProvider.GetResource(product.Translation.ProductPriceResourceKey, CultureInfo.CurrentUICulture.Name) as string;
            }

            model.Pager = new Pager(totalProducts, pageNo, pageSize);
            model.SortId = sortId.HasValue ? sortId.Value : 1;
            model.SortType = sortType.HasValue ? sortType.Value : 1;

            return PartialView(model);
        }

        [HttpGet]
        public ActionResult Detail(int id)
        {
            var product = productService.GetProduct(id);
            ProductDetailViewModel model = new ProductDetailViewModel();

            if(product != null)
            {
                model.Id = product.Id;
                model.Name = product.Name;
                model.Description = product.Description;
                model.Price = product.Price;
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