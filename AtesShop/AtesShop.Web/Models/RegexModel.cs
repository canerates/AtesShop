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
            ErrorMessage = "Required at least one uppercase ('A'-'Z').";
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
            ErrorMessage = "Required at least one digit ('0'-'9').";
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
            ErrorMessage = "Required at least one non letter or digit character.";
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
            : base(@".{8,}")
        {
            ErrorMessage = "Required at least 8 characters long.";
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