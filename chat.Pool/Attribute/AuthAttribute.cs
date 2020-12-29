using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace chat.Pool.Attribute
{
    public class AuthAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var ctx = filterContext.HttpContext;
            if (ctx.Session["EmpCusSessionContext"] != null)
            {
                base.OnActionExecuting(filterContext);

            }
            else
            {
                //filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { action = "LoginIndex", controller = "PoolLogin" }));

                filterContext.Result = new RedirectResult("/PoolLogin/LoginIndex");
            }
        }

    }

}