﻿using AtesShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AtesShop.Web.ViewModels
{
    public class HomeViewModel
    {
        public List<Product> Products { get; set; }
        public List<Category> Categories { get; set; }
        public List<Product> FeaturedProducts { get; set; }
        public List<Product> NewProducts { get; set; }
        public List<Product> TopRatedProducts { get; set; }
        public List<Product> BestSellerProducts { get; set; }
    }

    public class MenuViewModel
    {
        public List<MainMenu> MainMenuList { get; set; }
    }

    public class LangMenuViewModel
    {
        public Dictionary<string, string> Languages { get; set; }
        public Dictionary<string, string> Currencies { get; set; }

        public string SelectedLanguage { get; set; }
        public string SelectedCurrency { get; set; }

    }


}