using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Routing;
using System.Web.WebPages;

namespace AtesShop.Web.Helpers
{
    public static class SharedHelper
    {
        public static MvcHtmlString RawActionLink(this AjaxHelper ajaxHelper, string linkText, string actionName, string controllerName, object routeValues, AjaxOptions ajaxOptions, object htmlAttributes)
        {
            var repID = Guid.NewGuid().ToString();
            var lnk = ajaxHelper.ActionLink(repID, actionName, controllerName, routeValues, ajaxOptions, htmlAttributes);
            return MvcHtmlString.Create(lnk.ToString().Replace(repID, linkText));
        }

        [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
        public class NoDirectAccessAttribute : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                if (filterContext.HttpContext.Request.UrlReferrer == null ||
                            filterContext.HttpContext.Request.Url.Host != filterContext.HttpContext.Request.UrlReferrer.Host)
                {
                    filterContext.Result = new RedirectToRouteResult(new
                                   RouteValueDictionary(new { controller = "Home", action = "Error", area = "" }));

                    //filterContext.Result = new HttpStatusCodeResult(404);
                }
            }
        }
    }
    
    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString DescriptionFor<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, helper.ViewData);
            var description = metadata.Description;

            // fallback! We'll try to show something anyway.
            if (String.IsNullOrEmpty(description)) description = String.IsNullOrEmpty(metadata.DisplayName) ? metadata.PropertyName : metadata.DisplayName;

            return MvcHtmlString.Create(description);
        }
    }
}