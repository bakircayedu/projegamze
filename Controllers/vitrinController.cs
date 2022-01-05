using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKütüphane.Models.Entity;
using MvcKütüphane.Models.classlar;

namespace MvcKütüphane.Controllers
{
    public class vitrinController : Controller
    {
        // GET: vitrin
        KÜTÜPHANE_YONETİM_SİSTEMİEntities kÜTÜPHANE = new KÜTÜPHANE_YONETİM_SİSTEMİEntities();

        [HttpGet]
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.deger = kÜTÜPHANE.KITAPLAR.ToList();
            return View(cs);
            //var degerler = kÜTÜPHANE.KITAPLAR.ToList();
            //return View(degerler);
        }

        [HttpPost]
        public ActionResult Index(ILETISIM i)
        {
            kÜTÜPHANE.ILETISIM.Add(i);
            kÜTÜPHANE.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}