using Foolproof;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AtesShop.Web.Models
{
    public class AtLeastOneUpperCase : RegularExpressionAttribute, IClientValidatable
    {
        public AtLeastOneUpperCase()
            : base(@"(.*[A-Z].*)")
        {
            ErrorMessage = Resources.Resources.PasswordAtLeastOneUppercase;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            yield return new ModelClientValidationRegexRule(this.ErrorMessage, this.Pattern)
            {
                ValidationType = "atleastoneuppercase"
            };
        }
    }
    public class AtLeastOneLowerCase : RegularExpressionAttribute, IClientValidatable
    {
        public AtLeastOneLowerCase()
            : base(@"(.*[a-z].*)")
        {
            ErrorMessage = "Required at least one lowercase ('a'-'z').";
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            yield return new ModelClientValidationRegexRule(this.ErrorMessage, this.Pattern)
            {
                ValidationType = "atleastonelowercase"
            };
        }
    }

    public class AtLeastOneDigit : RegularExpressionAttribute, IClientValidatable
    {
        public AtLeastOneDigit()
            : base(@"(.*\d.*)")
        {
            ErrorMessage = Resources.Resources.PasswordAtLeastOneDigit;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            yield return new ModelClientValidationRegexRule(this.ErrorMessage, this.Pattern)
            {
                ValidationType = "atleastonedigit"
            };
        }
    }

    public class AtLeastOneSpecial : RegularExpressionAttribute, IClientValidatable
    {
        public AtLeastOneSpecial()
            : base(@"(.*[#?!@$%^&*-].*)")
        {
            ErrorMessage = Resources.Resources.PasswordNonLetterOrDigit;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            yield return new ModelClientValidationRegexRule(this.ErrorMessage, this.Pattern)
            {
                ValidationType = "atleastonespecial"
            };
        }
    }

    public class MinimumLength : RegularExpressionAttribute, IClientValidatable
    {
        public MinimumLength()
            : base(@".{6,}")
        {
            ErrorMessage = Resources.Resources.PasswordSixCharactersLong;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            yield return new ModelClientValidationRegexRule(this.ErrorMessage, this.Pattern)
            {
                ValidationType = "minimumlength"
            };
        }
    }

    
}