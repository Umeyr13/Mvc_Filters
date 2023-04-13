using Mvc_Filters.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_Filters.Filtreler
{
    public class ActFilter : FilterAttribute, IActionFilter//implement ettik
    {

        DatabaseContext db = new DatabaseContext();
        public void OnActionExecuted(ActionExecutedContext filterContext)//action çalıştıktan sonra bura tetiklenir.
        {
            Kullanici user =(Kullanici)filterContext.HttpContext.Session["Login"];

            string username = "noname";
            if (user != null)
            {
                username = user.KullaniciAdi;
            }
            db.logs.Add( new Log()
            {
                 KullaniciAdi = username
                ,ActionName=filterContext.ActionDescriptor.ActionName
                ,ControllerName=filterContext.ActionDescriptor.ControllerDescriptor.ControllerName
                ,Tarih=DateTime.Now
                ,Aciklama="Action Executed"  
            } );

            db.SaveChanges();

        }

        public void OnActionExecuting(ActionExecutingContext filterContext)//action tetiklendiğinde, çalışıyorken bura çalışır
        {
            Kullanici user = (Kullanici)filterContext.HttpContext.Session["Login"];
            string username = "noname";
            if (user == null)
            {
                username = user.KullaniciAdi;
            }
            db.logs.Add(new Log()
            {
                KullaniciAdi = user.KullaniciAdi
    ,
                ActionName = filterContext.ActionDescriptor.ActionName
    ,
                ControllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName
    ,
                Tarih = DateTime.Now
    ,
                Aciklama = "Action Executing"
            });

            db.SaveChanges();
        }
    }
}