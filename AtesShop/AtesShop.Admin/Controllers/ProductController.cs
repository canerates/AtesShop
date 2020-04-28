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

        ProductService productService = new ProductService();
        CategoryService categoryService = new CategoryService();
        ImageService imageService = new ImageService();
        ResourceService resourceService = new ResourceService();
        ResourceKeyService keyService = new ResourceKeyService();
        PriceService priceService = new PriceService();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ProductTable(string search)
        {
            List<ProductViewModel> model = new List<ProductViewModel>();
            var products = productService.GetProducts();

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
                        var image = imageService.GetImage(id);
                        images.Add(image);
                    }
                    elem.Images = images;

                //Product Key Set

                var keySet = keyService.GetProductKeySetByProduct(product.Id);

                elem.ProductNameResources = resourceService.GetResourcesByKey(keySet.NameKey);
                elem.ProductDescriptionResources = resourceService.GetResourcesByKey(keySet.DescriptionKey);

                //Price

                var priceResources = new List<PricesByCultureModel>();
                var cultures = priceService.GetPriceDistinctCulturesByPriceKey(keySet.PriceKey);

                foreach (var cl in cultures)
                {
                    var pricesByCulture = new PricesByCultureModel();
                    pricesByCulture.Prices = priceService.GetPricesByKeyAndCulture(keySet.PriceKey, cl);
                    pricesByCulture.Culture = cl;
                    priceResources.Add(pricesByCulture);
                }
                

                elem.ProductPriceResources = priceResources;

                elem.ResourceCount = resourceService.GetResourcesCountByKey(keySet.NameKey);

                model.Add(elem);
            }
            return PartialView(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            NewProductViewModel model = new NewProductViewModel();
            model.AvailableImages = imageService.GetImages();
            model.AvailableCategories = categoryService.GetCategories();
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
            //newProduct.CategoryId = model.CategoryId;
            newProduct.Category = categoryService.GetCategory(model.CategoryId);
            newProduct.isDiscount = model.isDiscount;
            newProduct.isFeatured = model.isFeatured;
            newProduct.isNew = model.isNew;
            newProduct.isTopRated = model.isTopRated;
            newProduct.isBestSeller = model.isBestSeller;

            if (ModelState.IsValid)
            {
                newProduct.ImageIdList = string.Join(",", model.SelectedImages);
            }
            productService.SaveProduct(newProduct);


            //Product Key Set
            
            var newProductKeySet = new ProductKey();
            newProductKeySet.Product = newProduct;
            newProductKeySet.NameKey = "ProductName" + newProduct.Id;
            newProductKeySet.DescriptionKey = "ProductDesc" + newProduct.Id;
            newProductKeySet.PriceKey = "ProductPrice" + newProduct.Id;

            keyService.SaveProductKeySet(newProductKeySet);
            
            //Resource
            var productNameResource = generateResource(newProductKeySet.NameKey, model.Name, "en-us");
            var productDescriptionResource = generateResource(newProductKeySet.DescriptionKey, model.Description, "en-us");

            resourceService.SaveResource(productNameResource);
            resourceService.SaveResource(productDescriptionResource);
            
            //Price
            var productPriceResource = new Price();
            productPriceResource.Key = newProductKeySet.PriceKey;
            productPriceResource.Value = model.Price.ToString();
            productPriceResource.Culture = "en-us";
            productPriceResource.RoleName = "User";
            var role = RoleManager.FindByName("User");
            productPriceResource.RoleId = role.Id;

            priceService.SavePrice(productPriceResource);
            
            return RedirectToAction("ProductTable");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            EditProductViewModel model = new EditProductViewModel();
            var currentProduct = productService.GetProduct(id);
            var availableCategories = categoryService.GetCategories();
            var availableImages = imageService.GetImages();
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
            var currentProduct = productService.GetProduct(model.Id);
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

            productService.UpdateProduct(currentProduct);
            
            return RedirectToAction("ProductTable");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var currentKeySet = keyService.GetProductKeySetByProduct(id);
            
            resourceService.DeleteResources(currentKeySet.NameKey);
            resourceService.DeleteResources(currentKeySet.DescriptionKey);
            priceService.DeletePrices(currentKeySet.PriceKey);
            
            productService.DeleteProduct(id);
            
            return RedirectToAction("ProductTable");
        }

        [HttpGet]
        public ActionResult AddTranslation(int id)
        {
            ProductTranslationResources model = new ProductTranslationResources();
            
            var currentKeySet = keyService.GetProductKeySetByProduct(id);

            model.NameResources = resourceService.GetResourcesByKey(currentKeySet.NameKey);
            model.DescriptionResources = resourceService.GetResourcesByKey(currentKeySet.DescriptionKey);
            model.ResourceCount = resourceService.GetResourcesCountByKey(currentKeySet.NameKey);

            model.KeySetId = currentKeySet.Id;
            
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult AddTranslation(NewProductTranslationModel model)
        {
            var currentKeySet = keyService.GetProductKeySet(model.Id);

            //Resource
            var productNameResource = generateResource(currentKeySet.NameKey, model.Name, model.Culture);
            var productDescriptionResource = generateResource(currentKeySet.DescriptionKey, model.Description, model.Culture);

            resourceService.SaveResource(productNameResource);
            resourceService.SaveResource(productDescriptionResource);

            //Price
            var prices = priceService.GetPricesByKeyAndCulture(currentKeySet.PriceKey, "en-us");
            
            foreach (var price in prices)
            {
                var newPrice = new Price();
                newPrice.Key = currentKeySet.PriceKey;
                newPrice.Value = "0";
                newPrice.RoleId = price.RoleId;
                newPrice.RoleName = price.RoleName;
                newPrice.Culture = model.Culture;

                priceService.SavePrice(newPrice);

            }
            
            return RedirectToAction("ProductTable");
        }

        [HttpGet]
        public ActionResult EditTranslation(int id, string culture)
        {
            EditProductTranslationViewModel model = new EditProductTranslationViewModel();
            var currentKeySet = keyService.GetProductKeySetByProduct(id);

            model.Id = currentKeySet.Id;
            model.Name = resourceService.GetResource(currentKeySet.NameKey, culture).Value;
            model.Description = resourceService.GetResource(currentKeySet.DescriptionKey, culture).Value;
            model.Culture = culture;
            
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult EditTranslation(EditProductTranslationViewModel model)
        {
            var currentKeySet = keyService.GetProductKeySet(model.Id);

            var productNameResource = new Resource();
            productNameResource = resourceService.GetResource(currentKeySet.NameKey, model.Culture);
            productNameResource.Value = model.Name;

            var productDescriptionResource = new Resource();
            productDescriptionResource = resourceService.GetResource(currentKeySet.DescriptionKey, model.Culture);
            productDescriptionResource.Value = model.Description;
            
            resourceService.UpdateResource(productNameResource);
            resourceService.UpdateResource(productDescriptionResource);

            if (model.Culture == "en-us")
            {
                var currentProduct = productService.GetProduct(currentKeySet.ProductId);
                currentProduct.Name = model.Name;
                currentProduct.Description = model.Description;

                productService.UpdateProduct(currentProduct);
            }

            return RedirectToAction("ProductTable");
        }

        [HttpPost]
        public ActionResult DeleteTranslation(int id, string culture)
        {
            var currentKeySet = keyService.GetProductKeySetByProduct(id);

            var productNameResourceId = resourceService.GetResource(currentKeySet.NameKey, culture).Id;
            var productDescriptionId = resourceService.GetResource(currentKeySet.DescriptionKey, culture).Id;
            var prices = priceService.GetPricesByKeyAndCulture(currentKeySet.PriceKey, culture);

            resourceService.DeleteResource(productNameResourceId);
            resourceService.DeleteResource(productDescriptionId);

            foreach (var price in prices)
            {
                priceService.DeletePrice(price.Id);
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