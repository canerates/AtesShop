using AtesShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AtesShop.Web.ViewModels
{
    public class WishlistViewModel
    {
        public List<Product> WishlistProducts { get; set; }
        public bool isPriceHidden { get; set; }
    }

    public class CompareViewModel
    {
        public List<Product> CompareProducts { get; set; }
        public bool isPriceHidden { get; set; }
        public List<ProSecViewModel> ProductSpecs { get; set; }
    }

    public class ProductSpecViewModel
    {
        public Product Product { get; set; }
        public Dictionary<AttributeSection, List<ProductAttribute>> Attributes { get; set; }
        
    }

    public class ProSecViewModel
    {
        public AttributeSection Section { get; set; }
        public List<Dictionary<int, ProductAttribute>> AttributesOfProducts { get; set; }
    }

    public class CompareSideBarViewModel
    {
        public List<Product> CompareProducts { get; set; }
        public bool isPriceHidden { get; set; }
    }
}