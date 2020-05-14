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
    public class ResourceController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ResourceTable(string search)
        {
            List<ResourceKeyViewModel> model = new List<ResourceKeyViewModel>();
            var resourceKeys = ResourceService.Instance.GetResourceDistinctKeys();
            
            foreach (var key in resourceKeys)
            {
                ResourceKeyViewModel elem = new ResourceKeyViewModel();
                elem.ResourceKey = key;
                elem.ResourceCount = ResourceService.Instance.GetResourcesCountByKey(key);

                var resources = ResourceService.Instance.GetResourcesByKey(key);
                
                elem.Resources = resources;

                if (!string.IsNullOrEmpty(search))
                {
                    resources = resources.Where(r => r.Value != null && r.Value.ToLower().Contains(search.ToLower())).ToList();
                }

                if (resources.Count != 0)
                {
                    model.Add(elem);
                }
            }
            
            return PartialView(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Create(ResourceViewModel model)
        {
            var newResource = new Resource();

            newResource.Culture = model.Culture;
            newResource.Key = model.Key;
            newResource.Value = model.Value;

            ResourceService.Instance.SaveResource(newResource);

            return RedirectToAction("ResourceTable");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ResourceViewModel model = new ResourceViewModel();
            var currentResource = ResourceService.Instance.GetResourceById(id);

            model.Id = id;
            model.Key = currentResource.Key;
            model.Culture = currentResource.Culture;
            model.Value = currentResource.Value;
            
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Edit(ResourceViewModel model)
        {
            var currentResource = ResourceService.Instance.GetResourceById(model.Id);
            currentResource.Value = model.Value;

            ResourceService.Instance.UpdateResource(currentResource);

            return RedirectToAction("ResourceTable");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            ResourceService.Instance.DeleteResource(id);

            return RedirectToAction("ResourceTable");
        }

        [HttpGet]
        public ActionResult AddTranslation(int id)
        {
            ResourceViewModel model = new ResourceViewModel();
            var currentResource = ResourceService.Instance.GetResourceById(id);
            
            model.Id = id;
            model.Key = currentResource.Key;
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult AddTranslation(ResourceViewModel model)
        {
            var resources = ResourceService.Instance.GetResourcesByKey(model.Key);

            foreach (var resource in resources)
            {
                if (resource.Culture.Contains(model.Culture))
                {
                    return RedirectToAction("ResourceTable");
                }
            }

            var newResource = new Resource();
            newResource.Culture = model.Culture;
            newResource.Key = model.Key;
            newResource.Value = model.Value;

            ResourceService.Instance.SaveResource(newResource);


            return RedirectToAction("ResourceTable");
        }
    }
}