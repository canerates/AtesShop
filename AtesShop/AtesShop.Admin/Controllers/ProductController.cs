using AtesShop.Admin.ViewModels;
using AtesShop.Entities;
using AtesShop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AtesShop.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {
        ProductService productService = new ProductService();
        CategoryService categoryService = new CategoryService();
        ImageService imageService = new ImageService();
        ResourceService resourceService = new ResourceService();
        TranslationService translationService = new TranslationService();

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

                //Translations

                var translation = translationService.GetProductTranslationByProduct(product.Id);

                elem.ProductNameResources = resourceService.GetResourcesByKey(translation.ProductNameResourceKey);
                elem.ProductDescriptionResources = resourceService.GetResourcesByKey(translation.ProductDescriptionResourceKey);
                elem.ProductPriceResources = resourceService.GetResourcesByKey(translation.ProductPriceResourceKey);

                elem.ResourceCount = resourceService.GetResourcesCountByKey(translation.ProductNameResourceKey);

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
            newProduct.isFeatured = model.isFeatured;
            newProduct.isNew = model.isNew;
            newProduct.isTopRated = model.isTopRated;
            newProduct.isBestSeller = model.isBestSeller;

            if (ModelState.IsValid)
            {
                newProduct.ImageIdList = string.Join(",", model.SelectedImages);
            }
            productService.SaveProduct(newProduct);


            //ProductTranslation
            
            var newTranslation = new ProductTranslation();
            newTranslation.Product = newProduct;
            newTranslation.ProductNameResourceKey = "ProductName" + newProduct.Id;
            newTranslation.ProductDescriptionResourceKey = "ProductDesc" + newProduct.Id; 
            newTranslation.ProductPriceResourceKey = "ProductPrice" + newProduct.Id;

            translationService.SaveProductTranslation(newTranslation);


            //Resource
            var productNameResource = new Resource();
            productNameResource.Key = newTranslation.ProductNameResourceKey;
            productNameResource.Value = model.Name;
            productNameResource.Culture = "en-us";

            resourceService.SaveResource(productNameResource);

            var productDescriptionResource = new Resource();
            productDescriptionResource.Key = newTranslation.ProductDescriptionResourceKey;
            productDescriptionResource.Value = model.Description;
            productDescriptionResource.Culture = "en-us";

            resourceService.SaveResource(productDescriptionResource);

            var productPriceResource = new Resource();
            productPriceResource.Key = newTranslation.ProductPriceResourceKey;
            productPriceResource.Value = model.Price.ToString();
            productPriceResource.Culture = "en-us";

            resourceService.SaveResource(productPriceResource);
            
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
            model.Name = currentProduct.Name;
            model.Description = currentProduct.Description;
            model.Price = currentProduct.Price;
            model.ImageIdList = currentProduct.ImageIdList;
            model.CategoryId = currentProduct.CategoryId;
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
            currentProduct.Name = model.Name;
            currentProduct.Description = model.Description;
            currentProduct.Price = model.Price;
            currentProduct.ImageIdList = model.ImageIdList;
            currentProduct.CategoryId = model.CategoryId;
            currentProduct.isFeatured = model.isFeatured;
            currentProduct.isNew = model.isNew;
            currentProduct.isTopRated = model.isTopRated;
            currentProduct.isBestSeller = model.isBestSeller;
            
            if (ModelState.IsValid)
            {
                currentProduct.ImageIdList = string.Join(",", model.SelectedImages);
            }

            productService.UpdateProduct(currentProduct);

            //Resource Table
            var currentTranslation = translationService.GetProductTranslationByProduct(model.Id);

            var productNameResource = new Resource();
            productNameResource = resourceService.GetResource(currentTranslation.ProductNameResourceKey, "en-us");
            productNameResource.Value = model.Name;

            resourceService.UpdateResource(productNameResource);

            var productDescriptionResource = new Resource();
            productDescriptionResource = resourceService.GetResource(currentTranslation.ProductDescriptionResourceKey, "en-us");
            productDescriptionResource.Value = model.Description;

            resourceService.UpdateResource(productDescriptionResource);

            var productPriceResource = new Resource();
            productPriceResource = resourceService.GetResource(currentTranslation.ProductPriceResourceKey, "en-us");
            productPriceResource.Value = model.Price.ToString();
            
            resourceService.UpdateResource(productPriceResource);
            
            return RedirectToAction("ProductTable");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var currentTranslation = translationService.GetProductTranslationByProduct(id);
            
            resourceService.DeleteResources(currentTranslation.ProductNameResourceKey);
            resourceService.DeleteResources(currentTranslation.ProductDescriptionResourceKey);
            resourceService.DeleteResources(currentTranslation.ProductPriceResourceKey);
            
            productService.DeleteProduct(id);
            
            return RedirectToAction("ProductTable");
        }

        [HttpGet]
        public ActionResult AddTranslation(int id)
        {
            ProductTranslationResources model = new ProductTranslationResources();
            
            var currentTranslation = translationService.GetProductTranslationByProduct(id);

            model.NameResources = resourceService.GetResourcesByKey(currentTranslation.ProductNameResourceKey);
            model.DescriptionResources = resourceService.GetResourcesByKey(currentTranslation.ProductDescriptionResourceKey);
            model.PriceResources = resourceService.GetResourcesByKey(currentTranslation.ProductPriceResourceKey);
            model.ResourceCount = resourceService.GetResourcesCountByKey(currentTranslation.ProductNameResourceKey);

            model.TranslationId = currentTranslation.Id;
            
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult AddTranslation(NewProductTranslationModel model)
        {
            var translation = translationService.GetProductTranslation(model.Id);

            //Resource
            var productNameResource = new Resource();
            productNameResource.Key = translation.ProductNameResourceKey;
            productNameResource.Value = model.Name;
            productNameResource.Culture = model.Culture;

            resourceService.SaveResource(productNameResource);

            var productDescriptionResource = new Resource();
            productDescriptionResource.Key = translation.ProductDescriptionResourceKey;
            productDescriptionResource.Value = model.Description;
            productDescriptionResource.Culture = model.Culture;

            resourceService.SaveResource(productDescriptionResource);

            var productPriceResource = new Resource();
            productPriceResource.Key = translation.ProductPriceResourceKey;
            productPriceResource.Value = model.Price;
            productPriceResource.Culture = model.Culture;

            resourceService.SaveResource(productPriceResource);

            return RedirectToAction("ProductTable");
        }

        [HttpGet]
        public ActionResult EditTranslation(int id, string culture)
        {
            EditProductTranslationViewModel model = new EditProductTranslationViewModel();
            var translation = translationService.GetProductTranslationByProduct(id);

            model.Id = translation.Id;
            model.Name = resourceService.GetResource(translation.ProductNameResourceKey, culture).Value;
            model.Description = resourceService.GetResource(translation.ProductDescriptionResourceKey, culture).Value;
            model.Price = resourceService.GetResource(translation.ProductPriceResourceKey, culture).Value;
            model.Culture = culture;
            
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult EditTranslation(EditProductTranslationViewModel model)
        {
            var translation = translationService.GetProductTranslation(model.Id);

            var productNameResource = new Resource();
            productNameResource = resourceService.GetResource(translation.ProductNameResourceKey, model.Culture);
            productNameResource.Value = model.Name;

            var productDescriptionResource = new Resource();
            productDescriptionResource = resourceService.GetResource(translation.ProductDescriptionResourceKey, model.Culture);
            productDescriptionResource.Value = model.Description;

            var productPriceResource = new Resource();
            productPriceResource = resourceService.GetResource(translation.ProductPriceResourceKey, model.Culture);
            productPriceResource.Value = model.Price;

            resourceService.UpdateResource(productNameResource);
            resourceService.UpdateResource(productDescriptionResource);
            resourceService.UpdateResource(productPriceResource);

            return RedirectToAction("ProductTable");
        }

        [HttpPost]
        public ActionResult DeleteTranslation(int id, string culture)
        {
            var translation = translationService.GetProductTranslationByProduct(id);

            var productNameResourceId = resourceService.GetResource(translation.ProductNameResourceKey, culture).Id;
            var productDescriptionId = resourceService.GetResource(translation.ProductDescriptionResourceKey, culture).Id;
            var productPriceId = resourceService.GetResource(translation.ProductPriceResourceKey, culture).Id;

            resourceService.DeleteResource(productNameResourceId);
            resourceService.DeleteResource(productDescriptionId);
            resourceService.DeleteResource(productPriceId);
            
            return RedirectToAction("ProductTable");
        }
    }
}