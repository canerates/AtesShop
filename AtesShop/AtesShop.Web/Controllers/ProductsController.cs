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
        
        private static IResourceProvider resourceProvider = new DbResourceProvider();
        
        [HttpGet]
        [OutputCacheAttribute(VaryByParam = "*", Duration = 0, NoStore = true)]
        public ActionResult Index(int? categoryId, string search)
        {

            if (categoryId.HasValue)
            {
                var category = CategoryService.Instance.GetActiveCategory(categoryId.Value);
                if (category == null)
                {
                    return RedirectToAction("Error", "Home");
                }
            }


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
            
            model.Categories = CategoryService.Instance.GetCategories(CultureInfo.CurrentUICulture.Name);
            model.ProductCount = ProductService.Instance.GetProductsCount();
            model.MaximumPrice = PriceService.Instance.GetMaximumPrice(CultureInfo.CurrentUICulture.Name, roleName, categoryId);
            model.MinimumPrice = PriceService.Instance.GetMinimumPrice(CultureInfo.CurrentUICulture.Name, roleName, categoryId);
            model.SearchKey = search;
            model.IsListView = false;

            if (categoryId.HasValue)
            {
                model.CategoryId = categoryId.Value;
            }

            return View(model);
        }
        
        [HttpGet]
        [AjaxChildActionOnly]
        public ActionResult ProductList(string search, int? categoryId, int? pageNo, int? minimumPrice, int? maximumPrice, int? sortId, int? sortType, int? pageSize, bool isList)
        {
            string roleName;

            if (Request.IsAuthenticated)
            {
                roleName = UserManager.GetRoles(User.Identity.GetUserId()).FirstOrDefault();

            }
            else
            {
                roleName = "User";
            }
            
            ProductListViewModel model = new ProductListViewModel();
            model.IsListView = isList;


            model.MaximumPrice = maximumPrice.HasValue ? Request.IsAuthenticated ? maximumPrice.Value : 0 : 0;
            model.MinimumPrice = minimumPrice.HasValue ? Request.IsAuthenticated ? minimumPrice.Value : 0 : 0;

            //int pageSize = isList ? 4 : 9;
            pageNo = pageNo.HasValue ? pageNo.Value : 1;
            model.PageSize = pageSize.HasValue ? pageSize.Value : isList ? 4 : 6;
            model.SearchKey = search;
            
            model.Products = ProductService.Instance.SearchProducts(search, CultureInfo.CurrentUICulture.Name, roleName, categoryId, sortId, sortType, pageNo.Value, model.PageSize, minimumPrice, maximumPrice );

            if (categoryId.HasValue && categoryId != 0) model.CategoryId = categoryId.Value;
            else model.CategoryId = 0;
            
            model.Products = CommonHelper.FormatCurrency(model.Products, CultureInfo.CurrentUICulture.Name);

            if (Request.IsAuthenticated)
            {
                var userId = User.Identity.GetUserId();
                model.Products = CommonHelper.WishlistCheck(model.Products, userId);
            }

            var totalProductsCount = ProductService.Instance.SearchProductsCount(search, CultureInfo.CurrentUICulture.Name, roleName, categoryId, minimumPrice, maximumPrice);

            model.Pager = new Pager(totalProductsCount, pageNo, model.PageSize);
            model.SortId = sortId.HasValue ? sortId.Value : 1;
            model.SortType = sortType.HasValue ? sortType.Value : 1;
            
            return PartialView(model);
        }

        [HttpGet]
        [OutputCacheAttribute(VaryByParam = "*", Duration = 0, NoStore = true)]
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
            
            ProductDetailViewModel model = new ProductDetailViewModel();

            var product = ProductService.Instance.GetProduct(id, CultureInfo.CurrentUICulture.Name, roleName);


            if (product == null)
            {
                return RedirectToAction("Error", "Home");
            }

            product = CommonHelper.FormatCurrency(product, CultureInfo.CurrentUICulture.Name);

            if (Request.IsAuthenticated)
            {
                var userId = User.Identity.GetUserId();
                product = CommonHelper.WishlistCheck(product, userId);
            }

            var key = ResourceKeyService.Instance.GetProductKeySetByProduct(product.Id);

            model.Id = product.Id;
            model.Name = resourceProvider.GetResource(key.NameKey, CultureInfo.CurrentUICulture.Name) as string;
            model.Description = resourceProvider.GetResource(key.DescriptionKey, CultureInfo.CurrentUICulture.Name) as string;
            model.Price = product.Price;
            model.PrePrice = product.PrePrice;
            model.IsDiscount = product.isDiscount;
            model.CategoryId = product.CategoryId;
            model.IsWished = product.isWished;
            model.ProductImages = product.Images;
            model.Rate = product.Rate;
            model.Stock = product.Stock;

            if (product.FileIdList != null)
            {
                List<int> idList = product.FileIdList.Split(',').Select(int.Parse).ToList();
                model.SpecFiles = FileService.Instance.GetFiles().Where(x => idList.Contains(x.Id)).ToList();
            }

            var attributes = AttributeService.Instance.GetProductAttributes(product.Id);

            foreach (var attr in attributes)
            {
                attr.Key.Name = resourceProvider.GetResource("ASection" + attr.Key.AttributeSectionId, CultureInfo.CurrentUICulture.Name) as string;
                foreach (var val in attr.Value)
                {
                    val.AttributeType.Name = resourceProvider.GetResource("AType" + val.AttributeTypeId, CultureInfo.CurrentUICulture.Name) as string;
                    val.AttributeValue.Name = resourceProvider.GetResource("AValue" + val.AttributeValueId, CultureInfo.CurrentUICulture.Name) as string;
                }
            }

            model.Attributes = attributes;

            var features = FeatureService.Instance.GetProductFeatures(product.Id);

            foreach (var feature in features)
            {
                feature.FeatureValue = resourceProvider.GetResource("Feature" + feature.FeatureId, CultureInfo.CurrentUICulture.Name) as string;
            }

            model.ProductFeatures = features;
                            
            model.RelatedProducts = ProductService.Instance.GetProductsByCategory(product.CategoryId, CultureInfo.CurrentUICulture.Name, roleName).Where(p => p.Id != id).ToList();
            model.RelatedProducts = CommonHelper.FormatCurrency(model.RelatedProducts, CultureInfo.CurrentUICulture.Name);

            if (Request.IsAuthenticated)
            {
                var userId = User.Identity.GetUserId();
                model.RelatedProducts = CommonHelper.WishlistCheck(model.RelatedProducts, userId);
            }
                
            
            
            return View(model);
        }
        
    }
}