﻿using AtesShop.Resources;
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
        private static IResourceProvider resourceProvider = new DbResourceProvider();

        [HttpGet]
        public ActionResult Index(int? categoryId, string search)
        {
            ShopViewModel model = new ShopViewModel();
            
            model.Categories = CategoryService.Instance.GetCategories();
            model.ProductCount = ProductService.Instance.GetProductsCount();
            model.MaximumPrice = PriceService.Instance.GetMaximumPrice(CultureInfo.CurrentUICulture.Name, "User");
            model.MinimumPrice = PriceService.Instance.GetMinimumPrice(CultureInfo.CurrentUICulture.Name, "User");
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

            model.MaximumPrice = maximumPrice.HasValue ? maximumPrice.Value : 0;
            model.MinimumPrice = minimumPrice.HasValue ? minimumPrice.Value : 0;

            int pageSize = isList ? 5 : 9;
            pageNo = pageNo.HasValue ? pageNo.Value : 1;
            
            model.Products = ProductService.Instance.SearchProducts(search, CultureInfo.CurrentUICulture.Name, "User", categoryId, sortId, sortType, pageNo.Value, pageSize, minimumPrice, maximumPrice);

            if (categoryId.HasValue && categoryId != 0) model.CategoryId = categoryId.Value;
            else model.CategoryId = 0;

            foreach (var product in model.Products)
            {
                var keys = ResourceKeyService.Instance.GetProductKeySetByProduct(product.Id);

                //Localization
                product.Name = resourceProvider.GetResource(keys.NameKey, CultureInfo.CurrentUICulture.Name) as string;
                product.Description = resourceProvider.GetResource(keys.DescriptionKey, CultureInfo.CurrentUICulture.Name) as string;

            }
            model.Products = CommonHelper.ProductsCurrencyFormat(model.Products, CultureInfo.CurrentUICulture.Name);
            var totalProductsCount = ProductService.Instance.SearchProductsCount(search, CultureInfo.CurrentUICulture.Name, "User", categoryId, minimumPrice, maximumPrice);

            model.Pager = new Pager(totalProductsCount, pageNo, pageSize);
            model.SortId = sortId.HasValue ? sortId.Value : 1;
            model.SortType = sortType.HasValue ? sortType.Value : 1;

            return PartialView(model);
        }

        public ActionResult Detail(int id)
        {
            ShopDetailViewModel model = new ShopDetailViewModel();
            var product = ProductService.Instance.GetProduct(id, CultureInfo.CurrentUICulture.Name, "User");

            if (product != null)
            {
                product = CommonHelper.ProductCurrencyFormat(product, CultureInfo.CurrentUICulture.Name);

                model.Id = product.Id;
                model.Name = product.Name;
                model.Description = product.Description;
                model.Price = product.Price;
                model.PrePrice = product.PrePrice;
                model.isDiscount = product.isDiscount;
                model.CategoryId = product.CategoryId;
                model.ProductImages = product.Images;

                model.RelatedProducts = ProductService.Instance.GetProductsByCategory(product.CategoryId, CultureInfo.CurrentUICulture.Name, "User").Where(p => p.Id != id).ToList();
                model.RelatedProducts = CommonHelper.ProductsCurrencyFormat(model.RelatedProducts, CultureInfo.CurrentUICulture.Name);
            
                return View(model);
            }
            else { return HttpNotFound(); }
        }

    }
}