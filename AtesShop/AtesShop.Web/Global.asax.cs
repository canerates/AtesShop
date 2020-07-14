﻿using AtesShop.Web.Helpers;
using AtesShop.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace AtesShop.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(AtLeastOneUpperCase), typeof(RegularExpressionAttributeAdapter));
            //DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(AtLeastOneLowerCase), typeof(RegularExpressionAttributeAdapter));
            //DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(AtLeastOneDigit), typeof(RegularExpressionAttributeAdapter));
            //DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(AtLeastOneSpecial), typeof(RegularExpressionAttributeAdapter));
            //DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(MinimumLength), typeof(RegularExpressionAttributeAdapter));

            //BundleTable.EnableOptimizations = true;
        }
    }
}
