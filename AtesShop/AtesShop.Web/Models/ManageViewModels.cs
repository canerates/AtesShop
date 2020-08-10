using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using AtesShop.Entities;
using Foolproof;

namespace AtesShop.Web.Models
{
    public class IndexViewModel
    {
        public bool HasPassword { get; set; }
        public IList<UserLoginInfo> Logins { get; set; }
        public string PhoneNumber { get; set; }
        public bool TwoFactor { get; set; }
        public bool BrowserRemembered { get; set; }

        public string FullName { get; set; }
        public int ActiveTabId { get; set; }


    }

    public class ManageLoginsViewModel
    {
        public IList<UserLoginInfo> CurrentLogins { get; set; }
        public IList<AuthenticationDescription> OtherLogins { get; set; }
    }

    public class FactorViewModel
    {
        public string Purpose { get; set; }
    }

    public class SetPasswordViewModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class AddPhoneNumberViewModel
    {
        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string Number { get; set; }
    }

    public class VerifyPhoneNumberViewModel
    {
        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
    }

    public class ConfigureTwoFactorViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
    }

    public class OrdersViewModel
    {
        public List<Order> Orders { get; set; }
    }

    public class DownloadsViewModel
    {

    }

    public class AddressViewModel
    {
        public List<UserAddress> AddressList { get; set; }
    }

    public class AddressFieldViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "FirstName", ResourceType = typeof(Resources.Resources))]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "LastName", ResourceType = typeof(Resources.Resources))]
        public string LastName { get; set; }
        
        [Display(Name = "CompanyName", ResourceType = typeof(Resources.Resources))]
        public string CompanyName { get; set; }

        [Required]
        [Display(Name = "Address", ResourceType = typeof(Resources.Resources))]
        public string Line1 { get; set; }
        
        [Display(Name = " ")]
        public string Line2 { get; set; }

        [Required]
        [Display(Name = "TownCity", ResourceType = typeof(Resources.Resources))]
        public string City { get; set; }

        [Required]
        [Display(Name = "StateCounty", ResourceType = typeof(Resources.Resources))]
        public string State { get; set; }

        [Required]
        [Display(Name = "Country", ResourceType = typeof(Resources.Resources))]
        public string Country { get; set; }

        [Required]
        [Display(Name = "PostcodeZip", ResourceType = typeof(Resources.Resources))]
        public string ZipCode { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "EmailAddress", ResourceType = typeof(Resources.Resources))]
        public string Email { get; set; }

        [Required]
        [Display(Name = "MobilePhone", ResourceType = typeof(Resources.Resources))]
        public string PhoneNumber { get; set; }

        public List<string> CountryList { get; set; }

        [Display(Name = "Submit")]
        public string Submit { get; set; }

    }

    public class DetailsViewModel
    {
        [Display(Name = "SocialTitle", ResourceType = typeof(Resources.Resources))]
        public string Gender { get; set; }

        [Required]
        [Display(Name = "FirstName", ResourceType = typeof(Resources.Resources))]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "LastName", ResourceType = typeof(Resources.Resources))]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email", ResourceType = typeof(Resources.Resources))]
        public string Email { get; set; }
        
        [Display(Name = "MobilePhone", ResourceType = typeof(Resources.Resources))]
        public string PhoneNumber { get; set; }
        
        public bool UpdatePassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "CurrentPassword", ResourceType = typeof(Resources.Resources))]
        public string OldPassword { get; set; }
        
        [Required]
        [MinimumLength]
        [AtLeastOneUpperCase]
        [AtLeastOneLowerCase]
        [AtLeastOneDigit]
        [AtLeastOneSpecial]
        [DataType(DataType.Password)]
        [Display(Name = "NewPassword", ResourceType = typeof(Resources.Resources))]
        public string NewPassword { get; set; }
        
        [DataType(DataType.Password)]
        [Display(Name = "ConfirmNewPassword", ResourceType = typeof(Resources.Resources))]
        [Compare("NewPassword")]
        public string ConfirmPassword { get; set; }

        public bool UpdateRole { get; set; }

        [Required]
        [Display(Name = "NewBusinessType", ResourceType = typeof(Resources.Resources))]
        public string NewBusinessType { get; set; }
        
        [Required]
        [Display(Name = "BusinessType", ResourceType = typeof(Resources.Resources))]
        public string BusinessType { get; set; }

        [Required]
        [Display(Name = "CompanyName", ResourceType = typeof(Resources.Resources))]
        public string CompanyName { get; set; }

        [Required]
        [Display(Name = "TaxNumber", ResourceType = typeof(Resources.Resources))]
        public string TaxNumber { get; set; }


        //[Display(Name = "Birthdate")]
        //[DataType(DataType.Date)]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        //public string Birthdate { get; set; }

        [Display(Name = "Receive offers from our partners")]
        public bool isOffer { get; set; }
        
        [Display(Name = "SignUpOurNews", ResourceType = typeof(Resources.Resources))]
        public bool isSubscribed { get; set; }
    }

}