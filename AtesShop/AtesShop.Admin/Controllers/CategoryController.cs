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
    //[Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        CategoryService categoryService = new CategoryService();
        ImageService imageService = new ImageService();
        ResourceKeyService keyService = new ResourceKeyService();
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

                //Category Key Set

                var keySet = keyService.GetCategoryKeySetByCategory(category.Id);

                elem.CategoryNameResources = resourceService.GetResourcesByKey(keySet.NameKey);
                elem.CategoryDescriptionResources = resourceService.GetResourcesByKey(keySet.DescriptionKey);

                elem.ResourceCount = resourceService.GetResourcesCountByKey(keySet.NameKey);
                
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

            //Category Key Set

            var newCategoryKeySet = new CategoryKey();
            newCategoryKeySet.Category = newCategory;
            newCategoryKeySet.NameKey = "CategoryName" + newCategory.Id;
            newCategoryKeySet.DescriptionKey = "CategoryDesc" + newCategory.Id;

            keyService.SaveCategoryKeySet(newCategoryKeySet);

            //Resource

            var categoryNameResource = generateResource(newCategoryKeySet.NameKey, model.Name, "en-us");
            var categoryDescriptionResource = generateResource(newCategoryKeySet.DescriptionKey, model.Name, "en-us");

            resourceService.SaveResource(categoryNameResource);
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
            
            return RedirectToAction("CategoryTable");
        }
        
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var currentKeySet = keyService.GetCategoryKeySetByCategory(id);

            resourceService.DeleteResources(currentKeySet.NameKey);
            resourceService.DeleteResources(currentKeySet.DescriptionKey);
            
            categoryService.DeleteCategory(id);

            return RedirectToAction("CategoryTable");
        }

        [HttpGet]
        public ActionResult AddTranslation(int id)
        {
            CategoryTranslationResources model = new CategoryTranslationResources();

            var currentKeySet = keyService.GetCategoryKeySetByCategory(id);

            model.NameResources = resourceService.GetResourcesByKey(currentKeySet.NameKey);
            model.DescriptionResources = resourceService.GetResourcesByKey(currentKeySet.DescriptionKey);
            model.ResourceCount = resourceService.GetResourcesCountByKey(currentKeySet.NameKey);

            model.KeySetId = currentKeySet.Id;

            return PartialView(model);
        }

        [HttpPost]
        public ActionResult AddTranslation(NewCategoryTranslationModel model)
        {
            var currentKeySet = keyService.GetCategoryKeySet(model.Id);

            //Resource
            var categoryNameResource = generateResource(currentKeySet.NameKey, model.Name, model.Culture);
            var categoryDescriptionResource = generateResource(currentKeySet.DescriptionKey, model.Description, model.Culture);
            
            resourceService.SaveResource(categoryNameResource);
            resourceService.SaveResource(categoryDescriptionResource);
            
            return RedirectToAction("CategoryTable");
        }

        [HttpGet]
        public ActionResult EditTranslation(int id, string culture)
        {
            EditCategoryTranslationViewModel model = new EditCategoryTranslationViewModel();
            var currentKeySet = keyService.GetCategoryKeySetByCategory(id);

            model.Id = currentKeySet.Id;
            model.Name = resourceService.GetResource(currentKeySet.NameKey, culture).Value;
            model.Description = resourceService.GetResource(currentKeySet.DescriptionKey, culture).Value;
            model.Culture = culture;

            return PartialView(model);
        }

        [HttpPost]
        public ActionResult EditTranslation(EditCategoryTranslationViewModel model)
        {
            var currentKeySet = keyService.GetCategoryKeySet(model.Id);
            
            var categoryNameResource = new Resource();
            categoryNameResource = resourceService.GetResource(currentKeySet.NameKey, model.Culture);
            categoryNameResource.Value = model.Name;

            var categoryDescriptionResource = new Resource();
            categoryDescriptionResource = resourceService.GetResource(currentKeySet.DescriptionKey, model.Culture);
            categoryDescriptionResource.Value = model.Description;

            resourceService.UpdateResource(categoryNameResource);
            resourceService.UpdateResource(categoryDescriptionResource);

            if (model.Culture == "en-us")
            {
                var currentCategory = categoryService.GetCategory(currentKeySet.CategoryId);
                currentCategory.Name = model.Name;
                currentCategory.Description = model.Description;

                categoryService.UpdateCategory(currentCategory);
            }

            return RedirectToAction("CategoryTable");
        }

        [HttpPost]
        public ActionResult DeleteTranslation(int id, string culture)
        {
            var currentKeySet = keyService.GetCategoryKeySetByCategory(id);

            var categoryNameResourceId = resourceService.GetResource(currentKeySet.NameKey, culture).Id;
            var categoryDescriptionId = resourceService.GetResource(currentKeySet.DescriptionKey, culture).Id;

            resourceService.DeleteResource(categoryNameResourceId);
            resourceService.DeleteResource(categoryDescriptionId);

            return RedirectToAction("CategoryTable");
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