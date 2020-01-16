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
    public class CategoryController : Controller
    {
        CategoryService categoryService = new CategoryService();
        ImageService imageService = new ImageService();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CategoryTable(string search)
        {
            List<CategoryViewModel> model = new List<CategoryViewModel>();
            
            var categories = categoryService.GetCategories();

            if (!string.IsNullOrEmpty(search))
            {
                categories = categories.Where(p => p.Name != null && p.Name.ToLower().Contains(search.ToLower())).ToList();
            }

            foreach (var category in categories)
            {
                CategoryViewModel elem = new CategoryViewModel();
                elem.Category = category;
                List<Image> images = new List<Image>();

                List<int> imageIdList = category.ImageIdList.Split(',').Select(int.Parse).ToList();

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
            NewCategoryViewModel model = new NewCategoryViewModel();
            model.AvailableImages = imageService.GetImages();
            model.SelectedImages = new List<int>();
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Create(NewCategoryViewModel model)
        {
            var newCategory = new Category();
            newCategory.Name = model.Name;
            newCategory.Description = model.Description;

            if (ModelState.IsValid)
            {
                newCategory.ImageIdList = string.Join(",", model.SelectedImages);
            }

            categoryService.SaveCategory(newCategory);
            return RedirectToAction("CategoryTable");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            EditCategoryViewModel model = new EditCategoryViewModel();
            var currentCategory = categoryService.GetCategory(id);
            var availableImages = imageService.GetImages();
            List<int> selectedImageIdList = currentCategory.ImageIdList.Split(',').Select(int.Parse).ToList();

            model.Id = currentCategory.Id;
            model.Name = currentCategory.Name;
            model.Description = currentCategory.Description;
            model.ImageIdList = currentCategory.ImageIdList;
            model.AvailableImages = availableImages;
            model.SelectedImages = selectedImageIdList;
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Edit(EditCategoryViewModel model)
        {
            var currentCategory = categoryService.GetCategory(model.Id);
            currentCategory.Name = model.Name;
            currentCategory.Description = model.Description;

            if (ModelState.IsValid)
            {
                currentCategory.ImageIdList = string.Join(",", model.SelectedImages);
            }
            
            categoryService.UpdateCategory(currentCategory);

            return RedirectToAction("CategoryTable");
        }
        
        [HttpPost]
        public ActionResult Delete(Category category)
        {
            categoryService.DeleteCategory(category.Id);
            return RedirectToAction("CategoryTable");
        }
    }
}