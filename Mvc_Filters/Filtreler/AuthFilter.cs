using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_Filters.Filtreler
{
    public class AuthFilter:FilterAttribute,IAuthorizationFilter
    {
  


        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Session["Login"]==null)
            {
                filterContext.Result = new RedirectResult("/Login/SignIn");
            }
        }
    }
}