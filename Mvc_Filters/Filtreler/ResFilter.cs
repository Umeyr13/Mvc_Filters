using Mvc_Filters.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_Filters.Filtreler
{

    public class ResFilter : FilterAttribute, IResultFilter
    {
        DatabaseContext db = new DatabaseContext();
        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
            Kullanici user = (Kullanici)filterContext.HttpContext.Session["Login"];

            string username = "noname";
            if (user != null)
            {
                username = user.KullaniciAdi ;
            }
            db.logs.Add(new Log()
            {
                KullaniciAdi = username
                ,ActionName = filterContext.RouteData.Values["action"].ToString()               
                ,ControllerName = filterContext.RouteData.Values["controller"].ToString()
                ,Tarih = DateTime.Now
                ,Aciklama = "View Executing"            });

            db.SaveChanges();
        }

        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
            Kullanici user = (Kullanici)filterContext.HttpContext.Session["Login"];

            string username = "noname";
            if (user != null)
            {
                username = user.KullaniciAdi;
            }
            db.logs.Add(new Log()
            {
                KullaniciAdi = username
    ,
                ActionName = filterContext.RouteData.Values["action"].ToString()
    ,
                ControllerName = filterContext.RouteData.Values["controller"].ToString()
    ,
                Tarih = DateTime.Now
    ,
                Aciklama = "View Executing"
            });

            db.SaveChanges();

        }
    }
}