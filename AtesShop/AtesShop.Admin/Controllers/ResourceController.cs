﻿using AtesShop.Admin.ViewModels;
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
        ResourceService resourceService = new ResourceService();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ResourceTable(string search)
        {
            List<ResourceKeyViewModel> model = new List<ResourceKeyViewModel>();
            var resourceKeys = resourceService.GetResourceDistinctKeys();
            
            foreach (var key in resourceKeys)
            {
                ResourceKeyViewModel elem = new ResourceKeyViewModel();
                elem.ResourceKey = key;
                elem.ResourceCount = resourceService.GetResourcesCountByKey(key);

                var resources = resourceService.GetResourcesByKey(key);

                if (!string.IsNullOrEmpty(search))
                {
                    resources = resources.Where(r => r.Value != null && r.Value.ToLower().Contains(search.ToLower())).ToList();
                }

                elem.Resources = resources;
                

                model.Add(elem);
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

            resourceService.SaveResource(newResource);

            return RedirectToAction("ResourceTable");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ResourceViewModel model = new ResourceViewModel();
            var currentResource = resourceService.GetResourceById(id);

            model.Id = id;
            model.Key = currentResource.Key;
            model.Culture = currentResource.Culture;
            model.Value = currentResource.Value;
            
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Edit(ResourceViewModel model)
        {
            var currentResource = resourceService.GetResourceById(model.Id);
            currentResource.Value = model.Value;

            resourceService.UpdateResource(currentResource);

            return RedirectToAction("ResourceTable");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            resourceService.DeleteResource(id);

            return RedirectToAction("ResourceTable");
        }

        [HttpGet]
        public ActionResult AddTranslation(int id)
        {
            ResourceViewModel model = new ResourceViewModel();
            var currentResource = resourceService.GetResourceById(id);
            
            model.Id = id;
            model.Key = currentResource.Key;
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult AddTranslation(ResourceViewModel model)
        {
            var resources = resourceService.GetResourcesByKey(model.Key);

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

            resourceService.SaveResource(newResource);


            return RedirectToAction("ResourceTable");
        }
    }
}