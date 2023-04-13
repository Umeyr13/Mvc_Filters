using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_Filters.Filtreler
{
    public class ExcFilter : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;//bu olayı ben yöneticem demek.
            filterContext.Controller.TempData["Error_temp"]=filterContext.Exception;//Controler dan gelen hatayı aldık. Temp dataya attık
            filterContext.Result = new RedirectResult("/login/Error");//hata olursa bu sayfaya git dedik.
        }
    }
}