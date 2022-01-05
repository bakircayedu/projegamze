using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKütüphane.Models.Entity;

namespace MvcKütüphane.Controllers
{
    public class KayitOlController : Controller
    {
        // GET: KayitOl
        KÜTÜPHANE_YONETİM_SİSTEMİEntities kÜTÜPHANE = new KÜTÜPHANE_YONETİM_SİSTEMİEntities();
        public ActionResult Kayit()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Kayit(UYELER p)
        {
            if(!ModelState.IsValid)
            {
                return View("Kayit");
            }
            kÜTÜPHANE.UYELER.Add(p);
            kÜTÜPHANE.SaveChanges();
            return View();
        }
    }
}