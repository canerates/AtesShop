using AtesShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AtesShop.Web.ViewModels
{
    public class ShopViewModel
    {
        public List<Category> Categories { get; set; }
        public Pager Pager { get; set; }
        public int ProductCount { get; set; }
        public int MaximumPrice { get; set; }
        public int MinimumPrice { get; set; }
        public int CategoryId { get; set; }
        public string SearchKey { get; set; }
    }

    public class ShopDetailViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public List<Image> ProductImages { get; set; }
        public List<Product> RelatedProducts { get; set; }

    }
    
    public class ShopListViewModel
    {
        public List<Product> Products { get; set; }
        public Pager Pager { get; set; }
        public int CategoryId { get; set; }
        public bool IsListView { get; set; }
        public int SortId { get; set; }
        public int SortType { get; set; }
    }
}