using AtesShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AtesShop.Admin.ViewModels
{
    public class ProductViewModel
    {
        public Product Product { get; set; }

        public List<Resource> ProductNameResources { get; set; }
        public List<Resource> ProductDescriptionResources { get; set; }
        public List<Resource> ProductPriceResources { get; set; }
        public int ResourceCount { get; set; }

        public List<Image> Images { get; set; }

    }

    public class NewProductViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string ImageIdList { get; set; }

        public int CategoryId { get; set; }

        public bool isFeatured { get; set; }

        public bool isNew { get; set; }

        public bool isTopRated { get; set; }

        public bool isBestSeller { get; set; }

        public List<Category> AvailableCategories { get; set; }

        public List<Image> AvailableImages { get; set; }

        public List<int> SelectedImages { get; set; }
        

    }

    public class  EditProductViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string ImageIdList { get; set; }

        public int CategoryId { get; set; }

        public bool isFeatured { get; set; }

        public bool isNew { get; set; }

        public bool isTopRated { get; set; }

        public bool isBestSeller { get; set; }

        public List<Category> AvailableCategories { get; set; }

        public List<Image> AvailableImages { get; set; }

        public List<int> SelectedImages { get; set; }
            
    }

    public class NewProductTranslationModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Price { get; set; }
        
        public string Culture { get; set; }
        
    }

    public class EditProductTranslationViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Price { get; set; }

        public string Culture { get; set; }

    }

    public class ProductTranslationResources
    {
        public List<Resource> NameResources { get; set; }
        public List<Resource> DescriptionResources { get; set; }
        public List<Resource> PriceResources { get; set; }
        public int ResourceCount { get; set; }
        public int TranslationId { get; set; }
        
    }
    
}