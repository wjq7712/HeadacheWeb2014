using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace HeadacheCDSSWeb.Filters
{
    public class AuthorizeActionFilter : ActionFilterAttribute 
    {
         public override void  OnActionExecuting(ActionExecutingContext filterContext)  
      {
           
          HttpCookie cookie = filterContext.HttpContext.Request.Cookies["username"];
          if (cookie == null)
          {
              string loginUrl = "DAccount/index";
              filterContext.HttpContext.Response.Redirect(loginUrl, true);
          }
          

          // if (!filterContext.HttpContext.User.Identity.IsAuthenticated)  
          //{
          //    string returnUrl = filterContext.HttpContext.Request.Url.AbsolutePath;
          //    string redirectUrl = string.Format("?ReturnUrl={0}", returnUrl);
          //    string loginUrl = FormsAuthentication.LoginUrl + redirectUrl;
          //    filterContext.HttpContext.Response.Redirect(loginUrl, true);  

          //}  
        }   

    }
      
}