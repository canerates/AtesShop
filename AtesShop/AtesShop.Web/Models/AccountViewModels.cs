using AtesShop.Entities;
using Foolproof;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AtesShop.Web.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email", ResourceType = typeof(Resources.Resources))]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "EmailAddressOrUsername", ResourceType = typeof(Resources.Resources))]
        public string EmailOrUserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password", ResourceType = typeof(Resources.Resources))]
        public string Password { get; set; }

        [Display(Name = "RememberMe", ResourceType = typeof(Resources.Resources))]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email", ResourceType = typeof(Resources.Resources))]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Username", ResourceType = typeof(Resources.Resources))]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "FirstName", ResourceType = typeof(Resources.Resources))]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "LastName", ResourceType = typeof(Resources.Resources))]
        public string LastName { get; set; }
        
        [Display(Name = "MobilePhone", ResourceType = typeof(Resources.Resources))]
        public string PhoneNumber { get; set; }

        [Required]
        [MinimumLength]
        [AtLeastOneUpperCase]
        [AtLeastOneDigit]
        [AtLeastOneSpecial]
        [DataType(DataType.Password)]
        [Display(Name = "Password", ResourceType = typeof(Resources.Resources))]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "ConfirmPassword", ResourceType = typeof(Resources.Resources))]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Business Type")]
        public string BusinessType { get; set; }

        [RequiredIfNot("BusinessType", "User", ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "CompanyNameRequired")]
        [Display(Name = "CompanyName", ResourceType = typeof(Resources.Resources))]
        public string CompanyName { get; set; }

        [RequiredIfNot("BusinessType", "User", ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "TaxNumberRequired")]
        [Display(Name = "TaxNumber", ResourceType = typeof(Resources.Resources))]
        public string TaxNumber { get; set; }

        [Display(Name = "Subscription")]
        public bool Subscription { get; set; }
        
    }

    public class ResourceKeyViewModel
    {
        public string ResourceKey { get; set; }
        public List<Resource> Resources { get; set; }
        public int ResourceCount { get; set; }

    }

    public class ResourceViewModel
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public string Culture { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email", ResourceType = typeof(Resources.Resources))]
        public string Email { get; set; }

        [Required]
        [MinimumLength]
        [AtLeastOneUpperCase]
        [AtLeastOneLowerCase]
        [AtLeastOneDigit]
        [AtLeastOneSpecial]
        [DataType(DataType.Password)]
        [Display(Name = "Password", ResourceType = typeof(Resources.Resources))]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "ConfirmPassword", ResourceType = typeof(Resources.Resources))]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "EmailAddress", ResourceType = typeof(Resources.Resources))]
        public string Email { get; set; }
    }

    public class SubscriptionViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "EmailAddress", ResourceType = typeof(Resources.Resources))]
        public string Email { get; set; }
    }
}
