﻿using Foolproof;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AtesShop.Web.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
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
        [Display(Name = "E-mail address or Username")]
        public string EmailOrUserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        
        [Display(Name = "Mobile Phone")]
        public string PhoneNumber { get; set; }

        [Required]
        [MinimumLength]
        [AtLeastOneUpperCase]
        [AtLeastOneLowerCase]
        [AtLeastOneDigit]
        [AtLeastOneSpecial]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Business Type")]
        public string BusinessType { get; set; }

        [RequiredIfNot("BusinessType", "User", ErrorMessage = "Company Name must be filled.")]
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        //[RequiredIfNot("BusinessType", "User", ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "HomeT1O1")]
        [RequiredIfNot("BusinessType", "User", ErrorMessage = "Tax Number must be filled.")]
        [Display(Name = "Tax Number")]
        public string TaxNumber { get; set; }

        [Display(Name = "Subscription")]
        public bool Subscription { get; set; }


    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [MinimumLength]
        [AtLeastOneUpperCase]
        [AtLeastOneLowerCase]
        [AtLeastOneDigit]
        [AtLeastOneSpecial]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress]
        [Display(Name = "Email address")]
        public string Email { get; set; }
    }
}
