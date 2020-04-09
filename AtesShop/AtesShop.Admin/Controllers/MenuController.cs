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
    public class MenuController : Controller
    {
        MenuService menuService = new MenuService();
        ResourceService resourceService = new ResourceService();

        [HttpGet]
        public ActionResult Index(int type)
        {
            ViewBag.type = type;
            return View();
        }

        [HttpGet]
        public ActionResult MenuTable(string search, int type)
        {
            ViewBag.type = type;
            
            List<MenuViewModel> model = new List<MenuViewModel>();

            if (type == 1)
            {
                var menus = menuService.GetMainMenus();
                if (!string.IsNullOrEmpty(search))
                {
                    menus = menus.Where(p => p.Name != null && p.Name.ToLower().Contains(search.ToLower())).ToList();
                }
                foreach (var menu in menus)
                {
                    MenuViewModel elem = new MenuViewModel();
                    elem.Id = menu.Id;
                    elem.Name = menu.Name;
                    elem.ActionName = menu.ActionName;
                    elem.ControllerName = menu.ControllerName;
                    elem.OrderId = menu.OrderId;
                    elem.SubMenus = menu.SubMenus;


                    //Resources
                    elem.NameResources = resourceService.GetResourcesByKey(menu.ResourceKey);
                    elem.ResourceCount = resourceService.GetResourcesCountByKey(menu.ResourceKey);

                    model.Add(elem);
                }

            }
            else
            {
                var menus = menuService.GetSubMenus();

                if (!string.IsNullOrEmpty(search))
                {
                    menus = menus.Where(p => p.Name != null && p.Name.ToLower().Contains(search.ToLower())).ToList();
                }

                foreach (var menu in menus)
                {
                    MenuViewModel elem = new MenuViewModel();
                    elem.Id = menu.Id;
                    elem.Name = menu.Name;
                    elem.ActionName = menu.ActionName;
                    elem.ControllerName = menu.ControllerName;
                    elem.OrderId = menu.OrderId;
                    elem.MainMenu = menu.MainMenu;

                    //Resources
                    elem.NameResources = resourceService.GetResourcesByKey(menu.ResourceKey);
                    elem.ResourceCount = resourceService.GetResourcesCountByKey(menu.ResourceKey);

                    model.Add(elem);
                }
            }
            
            return PartialView(model);
        }

        [HttpGet]
        public ActionResult Create(int type)
        {
            NewMenuViewModel model = new NewMenuViewModel();
            model.AvailableMainMenus = menuService.GetMainMenus();
            model.Type = type;
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Create(NewMenuViewModel model)
        {

            if (model.Type == 1)
            {
                var newMainMenu = new MainMenu();
                newMainMenu.Name = model.Name;
                newMainMenu.OrderId = model.OrderId;
                newMainMenu.ActionName = model.ActionName;
                newMainMenu.ControllerName = model.ControllerName;
                newMainMenu.ResourceKey = model.Name.Replace(" ", "") + "T" + model.Type + "O" + model.OrderId;

                menuService.SaveMainMenu(newMainMenu);

                //Resource
                var menuNameResource = new Resource();
                menuNameResource.Key = newMainMenu.ResourceKey;
                menuNameResource.Value = model.Name;
                menuNameResource.Culture = "en-us";

                resourceService.SaveResource(menuNameResource);
                
            }
            else
            {
                var newSubMenu = new SubMenu();
                newSubMenu.Name = model.Name;
                newSubMenu.OrderId = model.OrderId;
                newSubMenu.ActionName = model.ActionName;
                newSubMenu.ControllerName = model.ControllerName;
                newSubMenu.MainMenu = menuService.GetMainMenu(model.MainMenuId);
                newSubMenu.ResourceKey = model.Name.Replace(" ", "") + "T" + model.Type + "O" + model.OrderId;

                menuService.SaveSubMenu(newSubMenu);

                //Resource
                var menuNameResource = new Resource();
                menuNameResource.Key = newSubMenu.ResourceKey;
                menuNameResource.Value = model.Name;
                menuNameResource.Culture = "en-us";

                resourceService.SaveResource(menuNameResource);
            }

            return RedirectToAction("MenuTable", new { type = model.Type });
        }

        [HttpGet]
        public ActionResult Edit(int id, int type)
        {
            EditMenuViewModel model = new EditMenuViewModel();
            model.Type = type;

            if (type == 1)
            {
                var currentMenu = menuService.GetMainMenu(id);
                model.Id = currentMenu.Id;
                model.Name = currentMenu.Name;
                model.OrderId = currentMenu.OrderId;
                model.ActionName = currentMenu.ActionName;
                model.ControllerName = currentMenu.ControllerName;
                model.ResourceKey = currentMenu.ResourceKey;
                
            }
            else
            {
                var currentMenu = menuService.GetSubMenu(id);
                model.Id = currentMenu.Id;
                model.Name = currentMenu.Name;
                model.OrderId = currentMenu.OrderId;
                model.ActionName = currentMenu.ActionName;
                model.ControllerName = currentMenu.ControllerName;
                model.MainMenuId = currentMenu.MainMenuId;
                model.AvailableMainMenus = menuService.GetMainMenus();
                model.ResourceKey = currentMenu.ResourceKey;
            }
            
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Edit(EditMenuViewModel model)
        {
            if (model.Type == 1)
            {
                var currentMenu = menuService.GetMainMenu(model.Id);
                currentMenu.Name = model.Name;
                currentMenu.OrderId = model.OrderId;
                currentMenu.ActionName = model.ActionName;
                currentMenu.ControllerName = model.ControllerName;

                menuService.UpdateMainMenu(currentMenu);

                //Resource

                var menuNameResource = new Resource();
                menuNameResource = resourceService.GetResource(model.ResourceKey, "en-us");
                menuNameResource.Value = model.Name;

                resourceService.UpdateResource(menuNameResource);

            }
            else
            {
                var currentMenu = menuService.GetSubMenu(model.Id);
                currentMenu.Name = model.Name;
                currentMenu.OrderId = model.OrderId;
                currentMenu.ActionName = model.ActionName;
                currentMenu.ControllerName = model.ControllerName;
                currentMenu.MainMenuId = model.MainMenuId;

                menuService.UpdateSubMenu(currentMenu);

                //Resource

                var menuNameResource = new Resource();
                menuNameResource = resourceService.GetResource(model.ResourceKey, "en-us");
                menuNameResource.Value = model.Name;

                resourceService.UpdateResource(menuNameResource);
            }

            return RedirectToAction("MenuTable", new { type = model.Type });
        }

        [HttpPost]
        public ActionResult Delete(int id, int type)
        {
            if (type == 1)
            {
                var currentMenu = menuService.GetMainMenu(id);
                resourceService.DeleteResources(currentMenu.ResourceKey);

                menuService.DeleteMainMenu(id);

            }
            else
            {
                var currentMenu = menuService.GetSubMenu(id);
                resourceService.DeleteResources(currentMenu.ResourceKey);
                menuService.DeleteSubMenu(id);
            }
            return RedirectToAction("MenuTable", new { type = type });
        }

        [HttpGet]
        public ActionResult AddTranslation(int id, int type)
        {
            MenuResourcesViewModel model = new MenuResourcesViewModel();
            model.MenuId = id;
            model.MenuType = type;

            if (type == 1)
            {
                var currentMenu = menuService.GetMainMenu(id);
                model.Resources = resourceService.GetResourcesByKey(currentMenu.ResourceKey);
                model.ResourceCount = resourceService.GetResourcesCountByKey(currentMenu.ResourceKey);
            }
            else
            {
                var currentMenu = menuService.GetSubMenu(id);
                model.Resources = resourceService.GetResourcesByKey(currentMenu.ResourceKey);
                model.ResourceCount = resourceService.GetResourcesCountByKey(currentMenu.ResourceKey);
            }
            
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult AddTranslation(MenuResourceViewModel model)
        {
            if (model.Type == 1)
            {
                var currentMenu = menuService.GetMainMenu(model.Id);
                var menuResource = new Resource();
                menuResource.Key = currentMenu.ResourceKey;
                menuResource.Culture = model.Culture;
                menuResource.Value = model.Name;

                resourceService.SaveResource(menuResource);
            }
            else
            {
                var currentMenu = menuService.GetSubMenu(model.Id);
                var menuResource = new Resource();
                menuResource.Key = currentMenu.ResourceKey;
                menuResource.Culture = model.Culture;
                menuResource.Value = model.Name;

                resourceService.SaveResource(menuResource);
            }
            
            return RedirectToAction("MenuTable" , new { type = model.Type });
        }

        [HttpGet]
        public ActionResult EditTranslation(int id, int type, string culture)
        {
            MenuResourceViewModel model = new MenuResourceViewModel();
            model.Id = id;
            model.Type = type;
            model.Culture = culture;

            if (type == 1)
            {
                var currentMenu = menuService.GetMainMenu(id);
                model.Name = resourceService.GetResource(currentMenu.ResourceKey, culture).Value;

            }
            else
            {
                var currentMenu = menuService.GetSubMenu(id);
                model.Name = resourceService.GetResource(currentMenu.ResourceKey, culture).Value;
            }
            
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult EditTranslation(MenuResourceViewModel model)
        {
            var menuResource = new Resource();

            if (model.Type == 1)
            {
                var currentMenu = menuService.GetMainMenu(model.Id);
                menuResource = resourceService.GetResource(currentMenu.ResourceKey, model.Culture);
                
            }
            else
            {
                var currentMenu = menuService.GetSubMenu(model.Id);
                menuResource = resourceService.GetResource(currentMenu.ResourceKey, model.Culture);

            }

            menuResource.Value = model.Name;
            resourceService.UpdateResource(menuResource);
            
            return RedirectToAction("MenuTable", new { type = model.Type });
        }

        [HttpPost]
        public ActionResult DeleteTranslation(int id, int type, string culture)
        {
            if (type == 1)
            {
                var currentMenu = menuService.GetMainMenu(id);
                var menuResourceId = resourceService.GetResource(currentMenu.ResourceKey, culture).Id;
                resourceService.DeleteResource(menuResourceId);
            }
            else
            {
                var currentMenu = menuService.GetSubMenu(id);
                var menuResourceId = resourceService.GetResource(currentMenu.ResourceKey, culture).Id;
                resourceService.DeleteResource(menuResourceId);
            }

            return RedirectToAction("MenuTable");
        }
    }
}