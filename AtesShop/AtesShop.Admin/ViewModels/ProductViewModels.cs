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

        public List<Category> AvailableCategories { get; set; }

        public List<Image> AvailableImages { get; set; }

        public List<int> SelectedImages { get; set; }
            
    }
}