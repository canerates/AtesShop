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
    public class ProductController : Controller
    {
        ProductService productService = new ProductService();
        CategoryService categoryService = new CategoryService();
        ImageService imageService = new ImageService();

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
                List<Image> images = new List<Image>();

                
                    List<int> imageIdList = product.ImageIdList.Split(',').Select(int.Parse).ToList();

                    foreach (var id in imageIdList)
                    {
                        var image = imageService.GetImage(id);
                        images.Add(image);
                    }
                    elem.Images = images;
                
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
            var newProduct = new Product();
            newProduct.Name = model.Name;
            newProduct.Description = model.Description;
            newProduct.Price = model.Price;
            newProduct.CategoryId = model.CategoryId;

            if (ModelState.IsValid)
            {
                newProduct.ImageIdList = string.Join(",", model.SelectedImages);
            }
            
            
      
            productService.SaveProduct(newProduct);
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
            model.AvailableCategories = availableCategories;
            model.AvailableImages = availableImages;
            model.SelectedImages = selectedImageIdList;
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Edit(EditProductViewModel model)
        {
            var currentProduct = productService.GetProduct(model.Id);
            currentProduct.Name = model.Name;
            currentProduct.Description = model.Description;
            currentProduct.Price = model.Price;
            currentProduct.ImageIdList = model.ImageIdList;
            currentProduct.CategoryId = model.CategoryId;

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
            productService.DeleteProduct(id);
            return RedirectToAction("ProductTable");
        }
    }
}