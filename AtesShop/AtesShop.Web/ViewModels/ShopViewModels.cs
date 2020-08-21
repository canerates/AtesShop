using AtesShop.Entities;
using AtesShop.Web.Models;
using Foolproof;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public bool IsDiscount { get; set; }
        public int CategoryId { get; set; }
        public bool IsWished { get; set; }
        public List<Image> ProductImages { get; set; }
        public List<Product> RelatedProducts { get; set; }
        public Dictionary<AttributeSection, List<ProductAttribute>> Attributes { get; set; }
        public List<Feature> ProductFeatures { get; set; }
        public List<DocFile> SpecFiles { get; set; }
        public InventoryItem Stock { get; set; }

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
        public List<ProductsQuantityViewModel> Quantities { get; set; }

        public string CartTotalPrice { get; set; }
        public string CartTaxPrice { get; set; }
        public string CartTotalPriceWithTax { get; set; }
        public string ShipmentFee { get; set; }
        public Dictionary<int, string> CartProductsSubTotal { get; set; }

        public ApplicationUser User { get; set; }
        public List<UserAddress> UserAddressList { get; set; }

        public BillViewModel Bill { get; set; }
        public ShipViewModel Ship { get; set; }

        public NewAccountViewModel Account { get; set; }

        public string OrderNote { get; set; }

        public int SelectedAddress { get; set; }

        public List<string> CountryList { get; set; }

        // Account: Login Parameters
        [Required]
        [Display(Name = "UsernameOrEmail", ResourceType = typeof(Resources.Resources))]
        public string EmailOrUserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password", ResourceType = typeof(Resources.Resources))]
        public string Password { get; set; }

        [Display(Name = "RememberMe", ResourceType = typeof(Resources.Resources))]
        public bool RememberMe { get; set; }

    }

    public class CartViewModel
    {
        public List<Product> CartProducts { get; set; }
        public List<int> CartProductIdList { get; set; }
        public string CartTotalPrice { get; set; }
        public string CartTaxPrice { get; set; }
        public string CartTotalPriceWithTax { get; set; }
        
        public Dictionary<int, string> CartProductsSubTotal { get; set; }
        
    }
    
    public class NewAccountViewModel
    {
        public bool CreateAccount { get; set; }

        [RequiredIf("CreateAccount", true)]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [RequiredIf("CreateAccount", true)]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [RequiredIf("CreateAccount", true)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }

    public class ShipViewModel
    {
        [RequiredIf("isShipDifferent", true, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "FirstNameRequired")]
        [Display(Name = "FirstName", ResourceType = typeof(Resources.Resources))]
        public string FirstName { get; set; }

        [RequiredIf("isShipDifferent", true, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "LastNameRequired")]
        [Display(Name = "LastName", ResourceType = typeof(Resources.Resources))]
        public string LastName { get; set; }
        

        public string CompanyName { get; set; }

        [RequiredIf("isShipDifferent", true, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "EmailRequired")]
        [EmailAddress]
        [Display(Name = "Email", ResourceType = typeof(Resources.Resources))]
        public string Email { get; set; }

        [Display(Name = "MobilePhone", ResourceType = typeof(Resources.Resources))]
        public string PhoneNumber { get; set; }

        [Display(Name = "Country", ResourceType = typeof(Resources.Resources))]
        public string Country { get; set; }

        [RequiredIf("isShipDifferent", true, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "StateCountyRequired")]
        [Display(Name = "StateCounty", ResourceType = typeof(Resources.Resources))]
        public string State { get; set; }

        [RequiredIf("isShipDifferent", true, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "TownCityRequired")]
        [Display(Name = "TownCity", ResourceType = typeof(Resources.Resources))]
        public string City { get; set; }

        [RequiredIf("isShipDifferent", true, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "PostcodeZipRequired")]
        [Display(Name = "PostcodeZip", ResourceType = typeof(Resources.Resources))]
        public string ZipCode { get; set; }

        [RequiredIf("isShipDifferent", true, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "AddressRequired")]
        [Display(Name = "Address", ResourceType = typeof(Resources.Resources))]
        public string Address1 { get; set; }
        
        public string Address2 { get; set; }
        
        public bool isShipDifferent { get; set; }
    }
    
    public class BillViewModel
    {
        [Required]
        [Display(Name = "FirstName", ResourceType = typeof(Resources.Resources))]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "LastName", ResourceType = typeof(Resources.Resources))]
        public string LastName { get; set; }
        

        public string CompanyName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email", ResourceType = typeof(Resources.Resources))]
        public string Email { get; set; }

        [Required]
        [Display(Name = "MobilePhone", ResourceType = typeof(Resources.Resources))]
        public string PhoneNumber { get; set; }

        [Display(Name = "Country", ResourceType = typeof(Resources.Resources))]
        public string Country { get; set; }

        [Required]
        [Display(Name = "StateCounty", ResourceType = typeof(Resources.Resources))]
        public string State { get; set; }

        [Required]
        [Display(Name = "TownCity", ResourceType = typeof(Resources.Resources))]
        public string City { get; set; }

        [Required]
        [Display(Name = "PostcodeZip", ResourceType = typeof(Resources.Resources))]
        public string ZipCode { get; set; }

        [Required]
        [Display(Name = "Address", ResourceType = typeof(Resources.Resources))]
        public string Address1 { get; set; }
        

        public string Address2 { get; set; }
        
        public bool SaveAddress { get; set; }

    }
    
    public class ProductsQuantityViewModel
    {
        public int productId { get; set; }
        public int productQuantity { get; set; }
    }

    public class OrderSuccessViewModel
    {
        public string OrderId { get; set; }

    }

}