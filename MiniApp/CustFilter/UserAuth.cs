using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiniApp.CustFilter
{
    public class UserAuth:AuthorizeAttribute
    {

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.RouteData.Values["id"] != null)
            {
                filterContext.HttpContext.Session["ProdID"] = filterContext.RouteData.Values["id"].ToString();
            }
            if (filterContext.HttpContext.Session["UserID"] == null)
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { controller = "MangeUsers", action = "doLogin", area = "" }));
        }
    }
}