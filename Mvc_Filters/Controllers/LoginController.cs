using Mvc_Filters.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_Filters.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(Kullanici model)
        {
            DatabaseContext db = new DatabaseContext();
            Kullanici kullanici = db.Kullanicilar.FirstOrDefault(x=>x.KullaniciAdi == model.KullaniciAdi && x.Sifre == model.Sifre);

                if (kullanici == null)
                {
                ModelState.AddModelError("","Kullanıcı adı yada sifre hatalı");
                return View(model);
                }
            else
            {

                Session["login"] = kullanici;

                return RedirectToAction ("Index","Home");
            }



        }

        public ActionResult Error()
        {
            //hatayı buraya göndermiştik
            if (TempData["Error_temp"] ==null)
            {//hata yoksa
                return RedirectToAction("Index","Home");//anasayfaya gönderdik

            }

            //Şimdi hatayı karşılayalım.
            Exception model = (Exception)TempData["Error_temp"];
            //hatayı aldık sayfaya model olarak göderdik. Gidip bakalım sayfaya => Error sayfası
            return View(model);
        }
    }
}