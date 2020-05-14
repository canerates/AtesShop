using AtesShop.Admin.Models;
using AtesShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AtesShop.Admin.ViewModels
{
    public class PriceListViewModel
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string ProductDescription { get; set; }
        
        public int PriceCount { get; set; }

        public List<Price> Prices { get; set; }
        
    }

    public class NewPriceViewModel
    {
        public List<RoleViewModel> AvailableRoles { get; set; }
        public List<Product> AvailableProducts { get; set; }
        public string Culture { get; set; }
        public string Value { get; set; }
        public string PreValue { get; set; }
        public string RoleId { get; set; }
        public int ProductId { get; set; }
        
    }

    public class EditPriceViewModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Culture { get; set; }
        public string RoleName { get; set; }
        public string Value { get; set; }
        public string PreValue { get; set; }
        
    }
}