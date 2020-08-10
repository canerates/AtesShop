using AtesShop.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

    public class ContactViewModel
    {
        [Required]
        [Display(Name = "Name", ResourceType = typeof(Resources.Resources))]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email", ResourceType = typeof(Resources.Resources))]
        public string Email { get; set; }

        [Display(Name = "Website", ResourceType = typeof(Resources.Resources))]
        public string Website { get; set; }

        [Required]
        [Display(Name = "Subject", ResourceType = typeof(Resources.Resources))]
        public string Subject { get; set; }

        [Required]
        [Display(Name = "Message", ResourceType = typeof(Resources.Resources))]
        public string Message { get; set; }

    }


}