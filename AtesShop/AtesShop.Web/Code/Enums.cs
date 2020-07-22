using AtesShop.Web.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AtesShop.Web.Code
{
    public enum ErrorType
    {
        invalidemail,
        invalidcode,
        emailconfirmation
    }

    public enum SuccessType
    {
        emailconfirmation,
        passwordreset,
        passwordresetemailsent
    }

    public enum OrderStatus
    {
        [Display(Description = "Pending", ResourceType = typeof(AtesShop.Resources.Resources))]
        Pending = 1,

        [Display(Description = "InProcess", ResourceType = typeof(AtesShop.Resources.Resources))]
        InProcess = 2,

        [Display(Description = "Shipped", ResourceType = typeof(AtesShop.Resources.Resources))]
        Shipped = 3,

        [Display(Description = "Delivered", ResourceType = typeof(AtesShop.Resources.Resources))]
        Delivered = 4,

        [Display(Description = "Completed", ResourceType = typeof(AtesShop.Resources.Resources))]
        Completed = 5,

        [Display(Description = "Cancelled", ResourceType = typeof(AtesShop.Resources.Resources))]
        Cancelled = 6
    }
}