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
    public class CategoryController : Controller
    {
        CategoryService categoryService = new CategoryService();
        ImageService imageService = new ImageService();
        TranslationService translationService = new TranslationService();
        ResourceService resourceService = new ResourceService();

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

                //Category Images

                List<Image> images = new List<Image>();

                List<int> imageIdList = category.ImageIdList.Split(',').Select(int.Parse).ToList();

                foreach (var id in imageIdList)
                {
                    var image = imageService.GetImage(id);
                    images.Add(image);
                }
                elem.Images = images;

                //Translations

                var translation = translationService.GetCategoryTranslationByCategory(category.Id);

                elem.CategoryNameResources = resourceService.GetResourcesByKey(translation.CategoryNameResourceKey);
                elem.CategoryDescriptionResources = resourceService.GetResourcesByKey(translation.CategoryDescriptionResourceKey);

                elem.ResourceCount = resourceService.GetResourcesCountByKey(translation.CategoryNameResourceKey);
                
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
            //Category
            var newCategory = new Category();
            newCategory.Name = model.Name;
            newCategory.Description = model.Description;

            if (ModelState.IsValid)
            {
                newCategory.ImageIdList = string.Join(",", model.SelectedImages);
            }

            categoryService.SaveCategory(newCategory);

            //CategoryTranslation

            var newTranslation = new CategoryTranslation();
            newTranslation.Category = newCategory;
            newTranslation.CategoryNameResourceKey = "CategoryName" + newCategory.Id;
            newTranslation.CategoryDescriptionResourceKey = "CategoryDesc" + newCategory.Id;

            translationService.SaveCategoryTranslation(newTranslation);

            //Resource

            var categoryNameResource = new Resource();
            categoryNameResource.Key = newTranslation.CategoryNameResourceKey;
            categoryNameResource.Value = model.Name;
            categoryNameResource.Culture = "en-us";

            resourceService.SaveResource(categoryNameResource);

            var categoryDescriptionResource = new Resource();
            categoryDescriptionResource.Key = newTranslation.CategoryDescriptionResourceKey;
            categoryDescriptionResource.Value = model.Description;
            categoryDescriptionResource.Culture = "en-us";

            resourceService.SaveResource(categoryDescriptionResource);
            
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
            //Categories Table
            var currentCategory = categoryService.GetCategory(model.Id);
            currentCategory.Name = model.Name;
            currentCategory.Description = model.Description;

            if (ModelState.IsValid)
            {
                currentCategory.ImageIdList = string.Join(",", model.SelectedImages);
            }
            
            categoryService.UpdateCategory(currentCategory);

            //Resource Table
            var currentTranslation = translationService.GetCategoryTranslationByCategory(model.Id);

            var categoryNameResource = new Resource();
            categoryNameResource = resourceService.GetResource(currentTranslation.CategoryNameResourceKey, "en-us");
            categoryNameResource.Value = model.Name;

            resourceService.UpdateResource(categoryNameResource);

            var categoryDescriptionResource = new Resource();
            categoryDescriptionResource = resourceService.GetResource(currentTranslation.CategoryDescriptionResourceKey, "en-us");
            categoryDescriptionResource.Value = model.Description;

            resourceService.UpdateResource(categoryDescriptionResource);

            return RedirectToAction("CategoryTable");
        }
        
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var currentTranslation = translationService.GetCategoryTranslationByCategory(id);

            resourceService.DeleteResources(currentTranslation.CategoryNameResourceKey);
            resourceService.DeleteResources(currentTranslation.CategoryDescriptionResourceKey);

            categoryService.DeleteCategory(id);
            return RedirectToAction("CategoryTable");
        }

        [HttpGet]
        public ActionResult AddTranslation(int id)
        {
            CategoryTranslationResources model = new CategoryTranslationResources();

            var currentTranslation = translationService.GetCategoryTranslationByCategory(id);

            model.NameResources = resourceService.GetResourcesByKey(currentTranslation.CategoryNameResourceKey);
            model.DescriptionResources = resourceService.GetResourcesByKey(currentTranslation.CategoryDescriptionResourceKey);
            model.ResourceCount = resourceService.GetResourcesCountByKey(currentTranslation.CategoryNameResourceKey);

            model.TranslationId = currentTranslation.Id;

            return PartialView(model);
        }

        [HttpPost]
        public ActionResult AddTranslation(NewCategoryTranslationModel model)
        {
            var translation = translationService.GetCategoryTranslation(model.Id);

            //Resource
            var categoryNameResource = new Resource();
            categoryNameResource.Key = translation.CategoryNameResourceKey;
            categoryNameResource.Value = model.Name;
            categoryNameResource.Culture = model.Culture;

            resourceService.SaveResource(categoryNameResource);

            var categoryDescriptionResource = new Resource();
            categoryDescriptionResource.Key = translation.CategoryDescriptionResourceKey;
            categoryDescriptionResource.Value = model.Description;
            categoryDescriptionResource.Culture = model.Culture;

            resourceService.SaveResource(categoryDescriptionResource);
            
            return RedirectToAction("CategoryTable");
        }

        [HttpGet]
        public ActionResult EditTranslation(int id, string culture)
        {
            EditCategoryTranslationViewModel model = new EditCategoryTranslationViewModel();
            var translation = translationService.GetCategoryTranslationByCategory(id);

            model.Id = translation.Id;
            model.Name = resourceService.GetResource(translation.CategoryNameResourceKey, culture).Value;
            model.Description = resourceService.GetResource(translation.CategoryDescriptionResourceKey, culture).Value;
            model.Culture = culture;

            return PartialView(model);
        }

        [HttpPost]
        public ActionResult EditTranslation(EditCategoryTranslationViewModel model)
        {
            var translation = translationService.GetCategoryTranslation(model.Id);

            var categoryNameResource = new Resource();
            categoryNameResource = resourceService.GetResource(translation.CategoryNameResourceKey, model.Culture);
            categoryNameResource.Value = model.Name;

            var categoryDescriptionResource = new Resource();
            categoryDescriptionResource = resourceService.GetResource(translation.CategoryDescriptionResourceKey, model.Culture);
            categoryDescriptionResource.Value = model.Description;

            resourceService.UpdateResource(categoryNameResource);
            resourceService.UpdateResource(categoryDescriptionResource);

            return RedirectToAction("CategoryTable");
        }

        [HttpPost]
        public ActionResult DeleteTranslation(int id, string culture)
        {
            var translation = translationService.GetCategoryTranslationByCategory(id);

            var categoryNameResourceId = resourceService.GetResource(translation.CategoryNameResourceKey, culture).Id;
            var categoryDescriptionId = resourceService.GetResource(translation.CategoryDescriptionResourceKey, culture).Id;

            resourceService.DeleteResource(categoryNameResourceId);
            resourceService.DeleteResource(categoryDescriptionId);

            return RedirectToAction("CategoryTable");
        }
    }
}