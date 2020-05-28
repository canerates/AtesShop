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
        public bool IsListView { get; set; }

    }

    public class ShopDetailViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public string PrePrice { get; set; }
        public decimal Rate { get; set; }
        public bool isDiscount { get; set; }
        public int CategoryId { get; set; }
        public List<Image> ProductImages { get; set; }
        public List<Product> RelatedProducts { get; set; }
        public Dictionary<AttributeSection, List<ProductAttribute>> Attributes { get; set; }
        public List<Feature> ProductFeatures { get; set; }

    }
    
    public class ShopListViewModel
    {
        public List<Product> Products { get; set; }
        public Pager Pager { get; set; }
        public int CategoryId { get; set; }
        public bool IsListView { get; set; }
        public int SortId { get; set; }
        public int SortType { get; set; }
        public int PageSize { get; set; }
        public string SearchKey { get; set; }
        public int MaximumPrice { get; set; }
        public int MinimumPrice { get; set; }
    }

    public class CheckoutViewModel
    {
        public List<Product> CartProducts { get; set; }
        public List<int> CartProductIdList { get; set; }
        public string CartTotalPrice { get; set; }
        public Dictionary<int, string> CartProductsSubTotal { get; set; }

    }

    public class CartViewModel
    {
        public List<Product> CartProducts { get; set; }
        public List<int> CartProductIdList { get; set; }
        public string CartTotalPrice { get; set; }
        public Dictionary<int, string> CartProductsSubTotal { get; set; }


    }
}