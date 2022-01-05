using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcKütüphane.Models.Entity;

namespace MvcKütüphane.Controllers
{
    public class AdminLoginController : Controller
    {
        // GET: AdminLogin
        KÜTÜPHANE_YONETİM_SİSTEMİEntities kÜTÜPHANE = new KÜTÜPHANE_YONETİM_SİSTEMİEntities();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(PERSONEL p)
        {
            var bilgiler = kÜTÜPHANE.PERSONEL.FirstOrDefault(x => x.PERSONEL_EPOSTA == p.PERSONEL_EPOSTA &&
              x.PERSONEL_SİFRE == p.PERSONEL_SİFRE);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.PERSONEL_EPOSTA, false);
                Session["PERSONEL_EPOSTA"] = bilgiler.PERSONEL_EPOSTA.ToString();
                return RedirectToAction("Index", "Kategori");
            }
            else
            {
                return View();
            }
            return View();
        }
        
    }
}