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
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CategoryTable(string search)
        {
            List<CategoryViewModel> model = new List<CategoryViewModel>();
            
            var categories = CategoryService.Instance.GetCategories();

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
                    var image = ImageService.Instance.GetImage(id);
                    images.Add(image);
                }
                elem.Images = images;

                //Category Key Set

                var keySet = ResourceKeyService.Instance.GetCategoryKeySetByCategoryId(category.Id);

                elem.CategoryNameResources = ResourceService.Instance.GetResourcesByKey(keySet.NameKey);
                elem.CategoryDescriptionResources = ResourceService.Instance.GetResourcesByKey(keySet.DescriptionKey);

                elem.ResourceCount = ResourceService.Instance.GetResourcesCountByKey(keySet.NameKey);
                
                model.Add(elem);
            }
            
            return PartialView(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            NewCategoryViewModel model = new NewCategoryViewModel();
            model.AvailableImages = ImageService.Instance.GetImages();
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

            CategoryService.Instance.SaveCategory(newCategory);

            //Category Key Set

            var newCategoryKeySet = new CategoryKey();
            newCategoryKeySet.Category = newCategory;
            newCategoryKeySet.NameKey = "CategoryName" + newCategory.Id;
            newCategoryKeySet.DescriptionKey = "CategoryDesc" + newCategory.Id;

            ResourceKeyService.Instance.SaveCategoryKeySet(newCategoryKeySet);

            //Resource

            var categoryNameResource = generateResource(newCategoryKeySet.NameKey, model.Name, "en-us");
            var categoryDescriptionResource = generateResource(newCategoryKeySet.DescriptionKey, model.Name, "en-us");

            ResourceService.Instance.SaveResource(categoryNameResource);
            ResourceService.Instance.SaveResource(categoryDescriptionResource);
            
            return RedirectToAction("CategoryTable");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            EditCategoryViewModel model = new EditCategoryViewModel();
            var currentCategory = CategoryService.Instance.GetCategory(id);
            var availableImages = ImageService.Instance.GetImages();
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
            var currentCategory = CategoryService.Instance.GetCategory(model.Id);
            currentCategory.Name = model.Name;
            currentCategory.Description = model.Description;

            if (ModelState.IsValid)
            {
                currentCategory.ImageIdList = string.Join(",", model.SelectedImages);
            }

            CategoryService.Instance.UpdateCategory(currentCategory);
            
            return RedirectToAction("CategoryTable");
        }
        
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var currentKeySet = ResourceKeyService.Instance.GetCategoryKeySetByCategoryId(id);

            ResourceService.Instance.DeleteResources(currentKeySet.NameKey);
            ResourceService.Instance.DeleteResources(currentKeySet.DescriptionKey);

            CategoryService.Instance.DeleteCategory(id);

            return RedirectToAction("CategoryTable");
        }

        [HttpGet]
        public ActionResult AddTranslation(int id)
        {
            CategoryTranslationResources model = new CategoryTranslationResources();

            var currentKeySet = ResourceKeyService.Instance.GetCategoryKeySetByCategoryId(id);

            model.NameResources = ResourceService.Instance.GetResourcesByKey(currentKeySet.NameKey);
            model.DescriptionResources = ResourceService.Instance.GetResourcesByKey(currentKeySet.DescriptionKey);
            model.ResourceCount = ResourceService.Instance.GetResourcesCountByKey(currentKeySet.NameKey);

            model.KeySetId = currentKeySet.Id;

            return PartialView(model);
        }

        [HttpPost]
        public ActionResult AddTranslation(NewCategoryTranslationModel model)
        {
            var currentKeySet = ResourceKeyService.Instance.GetCategoryKeySet(model.Id);

            //Resource
            var categoryNameResource = generateResource(currentKeySet.NameKey, model.Name, model.Culture);
            var categoryDescriptionResource = generateResource(currentKeySet.DescriptionKey, model.Description, model.Culture);

            ResourceService.Instance.SaveResource(categoryNameResource);
            ResourceService.Instance.SaveResource(categoryDescriptionResource);
            
            return RedirectToAction("CategoryTable");
        }

        [HttpGet]
        public ActionResult EditTranslation(int id, string culture)
        {
            EditCategoryTranslationViewModel model = new EditCategoryTranslationViewModel();
            var currentKeySet = ResourceKeyService.Instance.GetCategoryKeySetByCategoryId(id);

            model.Id = currentKeySet.Id;
            model.Name = ResourceService.Instance.GetResourceByKeyCulture(currentKeySet.NameKey, culture).Value;
            model.Description = ResourceService.Instance.GetResourceByKeyCulture(currentKeySet.DescriptionKey, culture).Value;
            model.Culture = culture;

            return PartialView(model);
        }

        [HttpPost]
        public ActionResult EditTranslation(EditCategoryTranslationViewModel model)
        {
            var currentKeySet = ResourceKeyService.Instance.GetCategoryKeySet(model.Id);
            
            var categoryNameResource = new Resource();
            categoryNameResource = ResourceService.Instance.GetResourceByKeyCulture(currentKeySet.NameKey, model.Culture);
            categoryNameResource.Value = model.Name;

            var categoryDescriptionResource = new Resource();
            categoryDescriptionResource = ResourceService.Instance.GetResourceByKeyCulture(currentKeySet.DescriptionKey, model.Culture);
            categoryDescriptionResource.Value = model.Description;

            ResourceService.Instance.UpdateResource(categoryNameResource);
            ResourceService.Instance.UpdateResource(categoryDescriptionResource);

            if (model.Culture == "en-us")
            {
                var currentCategory = CategoryService.Instance.GetCategory(currentKeySet.CategoryId);
                currentCategory.Name = model.Name;
                currentCategory.Description = model.Description;

                CategoryService.Instance.UpdateCategory(currentCategory);
            }

            return RedirectToAction("CategoryTable");
        }

        [HttpPost]
        public ActionResult DeleteTranslation(int id, string culture)
        {
            var currentKeySet = ResourceKeyService.Instance.GetCategoryKeySetByCategoryId(id);

            var categoryNameResourceId = ResourceService.Instance.GetResourceByKeyCulture(currentKeySet.NameKey, culture).Id;
            var categoryDescriptionId = ResourceService.Instance.GetResourceByKeyCulture(currentKeySet.DescriptionKey, culture).Id;

            ResourceService.Instance.DeleteResource(categoryNameResourceId);
            ResourceService.Instance.DeleteResource(categoryDescriptionId);

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