using Mvc_Filters.Filtreler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_Filters.Controllers
{
    //[ActFilter]// Controller a yazarsak buradaki tüm actionsslarda geçerli olur
    [ActFilter, ResFilter,AuthFilter]
    public class HomeController : Controller
    {
        // GET: Home
       // [ActFilter]//[HttpPost] bunun gibi biz de bir filtre oluşturduk.
       [ResFilter,ExcFilter]
        public ActionResult Index()
        {
            int s1=0;
            int s2=1/s1;
            return View();
        }

       // [ActFilter]
        public ActionResult Index2()
        {


            return View();
        }

      
    }
}