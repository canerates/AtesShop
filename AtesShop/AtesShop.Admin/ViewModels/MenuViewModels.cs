﻿using AtesShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AtesShop.Admin.ViewModels
{
    public class MenuViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ActionName { get; set; }
        public string ControllerName { get; set; }
        public int OrderId { get; set; }
        public List<SubMenu> SubMenus { get; set; }
        public MainMenu MainMenu { get; set; }
        public List<Resource> NameResources { get; set; }
        public int ResourceCount { get; set; }

    }

    public class NewMenuViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ActionName { get; set; }
        public string ControllerName { get; set; }
        public int OrderId { get; set; }
        public int MainMenuId { get; set; }
        public int Type { get; set; }

        public List<MainMenu> AvailableMainMenus { get; set; }
    }

    public class EditMenuViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ActionName { get; set; }
        public string ControllerName { get; set; }
        public int OrderId { get; set; }
        public int MainMenuId { get; set; }
        public int Type { get; set; }

        public List<MainMenu> AvailableMainMenus { get; set; }

        public string ResourceKey { get; set; }
        
    }

    public class MenuResourcesViewModel
    {
        public int MenuId { get; set; }
        public int MenuType { get; set; }
        public List<Resource> Resources { get; set; }
        public int ResourceCount { get; set; }
    }

    public class MenuResourceViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Culture { get; set; }
        public int Type { get; set; }

    }


    
    

    
    
}