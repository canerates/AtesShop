using AtesShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AtesShop.Web.ViewModels
{
    public class ProductViewModel
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

    public class ProductDetailViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public string PrePrice { get; set; }
        public decimal Rate { get; set; }
        public bool IsDiscount { get; set; }
        public int CategoryId { get; set; }
        public bool IsWished { get; set; }
        public InventoryItem Stock { get; set; }
        public List<Image> ProductImages { get; set; }
        public List<Product> RelatedProducts { get; set; }
        public Dictionary<AttributeSection, List<ProductAttribute>> Attributes { get; set; }
        public List<Feature> ProductFeatures { get; set; }
        public List<DocFile> SpecFiles { get; set; }

    }

    public class ProductListViewModel
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

    public class ProductSetsViewModel
    {
        public Product Product { get; set; }
        public Product ProductExtra { get; set; }
    }
    
    public class PackageProductsViewModel
    {
        public int ProductId { get; set; }
        public string AddedOptionals { get; set; }
    }

    public class OfferPackageViewModel
    {
        public int SetId { get; set; }
        public List<ProductSetItemViewModel> PackageItems { get; set; }
        public List<OptionalSetItemViewModel> Extras { get; set; }

        public string IncItems { get; set; }
        
        public string SubTotal { get; set; }
        public string Total { get; set; }
    }

    public class ProductSetItemViewModel
    {
        public SetItem ProductSetItem { get; set; }
        public bool isVisible { get; set; }
        public int ImageId { get; set; }
    }

    public class OptionalSetItemViewModel
    {
        public int Id { get; set; }
        public int ProductSetId { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public bool isIncluded { get; set; }

    }
    
}