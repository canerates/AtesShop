using System.ComponentModel.DataAnnotations;

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
        [Display(Description = "Pending", ResourceType = typeof(Resources.Resources))]
        Pending = 1,

        [Display(Description = "WaitingForPayment", ResourceType = typeof(Resources.Resources))]
        WaitingForPayment = 2,

        [Display(Description = "InProcess", ResourceType = typeof(Resources.Resources))]
        InProcess = 3,
        
        [Display(Description = "Shipped", ResourceType = typeof(Resources.Resources))]
        Shipped = 4,

        [Display(Description = "Delivered", ResourceType = typeof(Resources.Resources))]
        Delivered = 5,

        [Display(Description = "Completed", ResourceType = typeof(Resources.Resources))]
        Completed = 6,

        [Display(Description = "Cancelled", ResourceType = typeof(Resources.Resources))]
        Cancelled = 7
    }
}