using System;
using System.Collections.Generic;
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
}