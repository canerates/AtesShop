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

                menuService.SaveMainMenu(newMainMenu);
            }
            else
            {
                var newSubMenu = new SubMenu();
                newSubMenu.Name = model.Name;
                newSubMenu.OrderId = model.OrderId;
                newSubMenu.ActionName = model.ActionName;
                newSubMenu.ControllerName = model.ControllerName;
                newSubMenu.MainMenu = menuService.GetMainMenu(model.MainMenuId);

                menuService.SaveSubMenu(newSubMenu);

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
            }

            return RedirectToAction("MenuTable", new { type = model.Type });
        }

        [HttpPost]
        public ActionResult Delete(int id, int type)
        {
            if (type == 1)
            {
                menuService.DeleteMainMenu(id);

            }
            else
            {
                menuService.DeleteSubMenu(id);
            }
            return RedirectToAction("MenuTable", new { type = type });
        }
    }
}