using AtesShop.Admin.ViewModels;
using AtesShop.Entities;
using AtesShop.Services;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AtesShop.Admin.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {

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
        
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ProductTable(string search)
        {
            List<ProductViewModel> model = new List<ProductViewModel>();
            var products = ProductService.Instance.GetProducts();

            if (!string.IsNullOrEmpty(search))
            {
                products = products.Where(p => p.Name != null && p.Name.ToLower().Contains(search.ToLower())).ToList();
            }

            foreach (var product in products)
            {
                ProductViewModel elem = new ProductViewModel();
                elem.Product = product;

                //Product Images
                List<Image> images = new List<Image>();

                    List<int> imageIdList = product.ImageIdList.Split(',').Select(int.Parse).ToList();

                    foreach (var id in imageIdList)
                    {
                        var image = ImageService.Instance.GetImage(id);
                        images.Add(image);
                    }
                    elem.Images = images;

                //Product Key Set

                var keySet = ResourceKeyService.Instance.GetProductKeySetByProductId(product.Id);

                elem.ProductNameResources = ResourceService.Instance.GetResourcesByKey(keySet.NameKey);
                elem.ProductDescriptionResources = ResourceService.Instance.GetResourcesByKey(keySet.DescriptionKey);

                //Price

                var priceResources = new List<PricesByCultureModel>();
                var cultures = PriceService.Instance.GetPriceDistinctCulturesByPriceKey(keySet.PriceKey);

                foreach (var cl in cultures)
                {
                    var pricesByCulture = new PricesByCultureModel();
                    pricesByCulture.Prices = PriceService.Instance.GetPricesByKeyAndCulture(keySet.PriceKey, cl);
                    pricesByCulture.Culture = cl;
                    priceResources.Add(pricesByCulture);
                }
                

                elem.ProductPriceResources = priceResources;

                elem.ResourceCount = ResourceService.Instance.GetResourcesCountByKey(keySet.NameKey);

                model.Add(elem);
            }
            return PartialView(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            NewProductViewModel model = new NewProductViewModel();
            model.AvailableImages = ImageService.Instance.GetImages();
            model.AvailableCategories = CategoryService.Instance.GetCategories();
            model.SelectedImages = new List<int>();
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Create(NewProductViewModel model)
        {
            //Product
            var newProduct = new Product();
            newProduct.Name = model.Name;
            newProduct.Description = model.Description;
            newProduct.Price = model.Price;
            newProduct.PrePrice = model.PrePrice;
            //newProduct.CategoryId = model.CategoryId;
            newProduct.Category = CategoryService.Instance.GetCategory(model.CategoryId);
            newProduct.isDiscount = model.isDiscount;
            newProduct.isFeatured = model.isFeatured;
            newProduct.isNew = model.isNew;
            newProduct.isTopRated = model.isTopRated;
            newProduct.isBestSeller = model.isBestSeller;

            if (ModelState.IsValid)
            {
                newProduct.ImageIdList = string.Join(",", model.SelectedImages);
            }
            ProductService.Instance.SaveProduct(newProduct);


            //Product Key Set
            
            var newProductKeySet = new ProductKey();
            newProductKeySet.Product = newProduct;
            newProductKeySet.NameKey = "ProductName" + newProduct.Id;
            newProductKeySet.DescriptionKey = "ProductDesc" + newProduct.Id;
            newProductKeySet.PriceKey = "ProductPrice" + newProduct.Id;

            ResourceKeyService.Instance.SaveProductKeySet(newProductKeySet);
            
            //Resource
            var productNameResource = generateResource(newProductKeySet.NameKey, model.Name, "en-us");
            var productDescriptionResource = generateResource(newProductKeySet.DescriptionKey, model.Description, "en-us");

            ResourceService.Instance.SaveResource(productNameResource);
            ResourceService.Instance.SaveResource(productDescriptionResource);
            
            //Price
            var productPriceResource = new Price();
            productPriceResource.Key = newProductKeySet.PriceKey;
            productPriceResource.Value = model.Price;
            productPriceResource.PreValue = model.PrePrice;
            productPriceResource.Culture = "en-us";
            productPriceResource.RoleName = "User";
            var role = RoleManager.FindByName("User");
            productPriceResource.RoleId = role.Id;

            PriceService.Instance.SavePrice(productPriceResource);

            //Rating
            var newRating = new Rating();
            newRating.Product = newProduct;
            newRating.IpAddress = "NULL";
            newRating.Rate = 4;

            RatingService.Instance.SaveProductRating(newRating);
            
            return RedirectToAction("ProductTable");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            EditProductViewModel model = new EditProductViewModel();
            var currentProduct = ProductService.Instance.GetProduct(id);
            var availableCategories = CategoryService.Instance.GetCategories();
            var availableImages = ImageService.Instance.GetImages();
            List<int> selectedImageIdList = currentProduct.ImageIdList.Split(',').Select(int.Parse).ToList();

            model.Id = currentProduct.Id;
            model.ImageIdList = currentProduct.ImageIdList;
            model.CategoryId = currentProduct.CategoryId;
            model.isDiscount = currentProduct.isDiscount;
            model.isFeatured = currentProduct.isFeatured;
            model.isNew = currentProduct.isNew;
            model.isTopRated = currentProduct.isTopRated;
            model.isBestSeller = currentProduct.isBestSeller;
            model.AvailableCategories = availableCategories;
            model.AvailableImages = availableImages;
            model.SelectedImages = selectedImageIdList;
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Edit(EditProductViewModel model)
        {
            //Products Table
            var currentProduct = ProductService.Instance.GetProduct(model.Id);
            currentProduct.ImageIdList = model.ImageIdList;
            currentProduct.CategoryId = model.CategoryId;
            currentProduct.isDiscount = model.isDiscount;
            currentProduct.isFeatured = model.isFeatured;
            currentProduct.isNew = model.isNew;
            currentProduct.isTopRated = model.isTopRated;
            currentProduct.isBestSeller = model.isBestSeller;
            
            if (ModelState.IsValid)
            {
                currentProduct.ImageIdList = string.Join(",", model.SelectedImages);
            }

            ProductService.Instance.UpdateProduct(currentProduct);
            
            return RedirectToAction("ProductTable");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var currentKeySet = ResourceKeyService.Instance.GetProductKeySetByProductId(id);

            ResourceService.Instance.DeleteResources(currentKeySet.NameKey);
            ResourceService.Instance.DeleteResources(currentKeySet.DescriptionKey);
            PriceService.Instance.DeletePrices(currentKeySet.PriceKey);
            
            ProductService.Instance.DeleteProduct(id);
            
            return RedirectToAction("ProductTable");
        }

        [HttpGet]
        public ActionResult AddTranslation(int id)
        {
            ProductTranslationResources model = new ProductTranslationResources();
            
            var currentKeySet = ResourceKeyService.Instance.GetProductKeySetByProductId(id);

            model.NameResources = ResourceService.Instance.GetResourcesByKey(currentKeySet.NameKey);
            model.DescriptionResources = ResourceService.Instance.GetResourcesByKey(currentKeySet.DescriptionKey);
            model.ResourceCount = ResourceService.Instance.GetResourcesCountByKey(currentKeySet.NameKey);

            model.KeySetId = currentKeySet.Id;
            
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult AddTranslation(NewProductTranslationModel model)
        {
            var currentKeySet = ResourceKeyService.Instance.GetProductKeySet(model.Id);

            //Resource
            var productNameResource = generateResource(currentKeySet.NameKey, model.Name, model.Culture);
            var productDescriptionResource = generateResource(currentKeySet.DescriptionKey, model.Description, model.Culture);

            ResourceService.Instance.SaveResource(productNameResource);
            ResourceService.Instance.SaveResource(productDescriptionResource);

            //Price
            var prices = PriceService.Instance.GetPricesByKeyAndCulture(currentKeySet.PriceKey, "en-us");
            
            foreach (var price in prices)
            {
                var newPrice = new Price();
                newPrice.Key = currentKeySet.PriceKey;
                newPrice.Value = "0";
                newPrice.RoleId = price.RoleId;
                newPrice.RoleName = price.RoleName;
                newPrice.Culture = model.Culture;

                PriceService.Instance.SavePrice(newPrice);

            }
            
            return RedirectToAction("ProductTable");
        }

        [HttpGet]
        public ActionResult EditTranslation(int id, string culture)
        {
            EditProductTranslationViewModel model = new EditProductTranslationViewModel();
            var currentKeySet = ResourceKeyService.Instance.GetProductKeySetByProductId(id);

            model.Id = currentKeySet.Id;
            model.Name = ResourceService.Instance.GetResourceByKeyCulture(currentKeySet.NameKey, culture).Value;
            model.Description = ResourceService.Instance.GetResourceByKeyCulture(currentKeySet.DescriptionKey, culture).Value;
            model.Culture = culture;
            
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult EditTranslation(EditProductTranslationViewModel model)
        {
            var currentKeySet = ResourceKeyService.Instance.GetProductKeySet(model.Id);

            var productNameResource = new Resource();
            productNameResource = ResourceService.Instance.GetResourceByKeyCulture(currentKeySet.NameKey, model.Culture);
            productNameResource.Value = model.Name;

            var productDescriptionResource = new Resource();
            productDescriptionResource = ResourceService.Instance.GetResourceByKeyCulture(currentKeySet.DescriptionKey, model.Culture);
            productDescriptionResource.Value = model.Description;

            ResourceService.Instance.UpdateResource(productNameResource);
            ResourceService.Instance.UpdateResource(productDescriptionResource);

            if (model.Culture == "en-us")
            {
                var currentProduct = ProductService.Instance.GetProduct(currentKeySet.ProductId);
                currentProduct.Name = model.Name;
                currentProduct.Description = model.Description;

                ProductService.Instance.UpdateProduct(currentProduct);
            }

            return RedirectToAction("ProductTable");
        }

        [HttpPost]
        public ActionResult DeleteTranslation(int id, string culture)
        {
            var currentKeySet = ResourceKeyService.Instance.GetProductKeySetByProductId(id);

            var productNameResourceId = ResourceService.Instance.GetResourceByKeyCulture(currentKeySet.NameKey, culture).Id;
            var productDescriptionId = ResourceService.Instance.GetResourceByKeyCulture(currentKeySet.DescriptionKey, culture).Id;
            var prices = PriceService.Instance.GetPricesByKeyAndCulture(currentKeySet.PriceKey, culture);

            ResourceService.Instance.DeleteResource(productNameResourceId);
            ResourceService.Instance.DeleteResource(productDescriptionId);

            foreach (var price in prices)
            {
                PriceService.Instance.DeletePrice(price.Id);
            }
            
            return RedirectToAction("ProductTable");
        }

        public Resource generateResource(string key, string value, string culture)
        {
            var resource = new Resource();
            resource.Key = key;
            resource.Value = value;
            resource.Culture = culture;
            return resource;
        }
    }
}