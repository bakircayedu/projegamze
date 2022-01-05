using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKütüphane.Models.Entity;
using System.Web.Security;

namespace MvcKütüphane.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        KÜTÜPHANE_YONETİM_SİSTEMİEntities kÜTÜPHANE = new KÜTÜPHANE_YONETİM_SİSTEMİEntities();
        public ActionResult GirisYap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GirisYap(UYELER u)
        {
            var bilgiler = kÜTÜPHANE.UYELER.FirstOrDefault(x => x.KULLANICIADI == u.KULLANICIADI && x.SİFRE == u.SİFRE);
            if(bilgiler!=null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.KULLANICIADI, false);
                Session["Kullanıcı Adı"] = bilgiler.KULLANICIADI.ToString();
                return RedirectToAction("Index", "Sayfam");
            }
            else
            {
                return View();
            }

            
        }
    }
}