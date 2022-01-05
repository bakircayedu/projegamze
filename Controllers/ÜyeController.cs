using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKütüphane.Models.Entity;

namespace MvcKütüphane.Controllers
{
    public class ÜyeController : Controller
    {
        // GET: Üye
        KÜTÜPHANE_YONETİM_SİSTEMİEntities kÜTÜPHANE = new KÜTÜPHANE_YONETİM_SİSTEMİEntities();
        public ActionResult Index()
        {
            var degerler = kÜTÜPHANE.UYELER.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult ÜyeEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ÜyeEkle(UYELER p)
        {
            kÜTÜPHANE.UYELER.Add(p);
            kÜTÜPHANE.SaveChanges();
            return View();
        }
        public ActionResult ÜyeSil(int id)
        {
            var uye = kÜTÜPHANE.UYELER.Find(id);
            kÜTÜPHANE.UYELER.Remove(uye);
            kÜTÜPHANE.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ÜyeGetir(int id)
        {
            var uye = kÜTÜPHANE.UYELER.Find(id);
            return View("ÜyeGetir", uye);
        }
        public ActionResult ÜyeGüncelle(UYELER u)
        {
            var uye = kÜTÜPHANE.UYELER.Find(u.UYE_ID);
            uye.UYE_AD = u.UYE_AD;
            uye.UYE_SOYAD = u.UYE_SOYAD;
            uye.E_POSTA = u.E_POSTA;
            uye.TELEFON = u.TELEFON;
            uye.KULLANICIADI = u.KULLANICIADI;
            uye.SİFRE = u.SİFRE;
            uye.OKUL = u.OKUL;
            kÜTÜPHANE.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ÜyeKitapGecmis(int id)
        {
            var kgecmis = kÜTÜPHANE.EMANET.Where(x => x.UYE == id).ToList();
            var uykitap = kÜTÜPHANE.UYELER.Where(y => y.UYE_ID == id).Select(z => z.UYE_AD + " " + z.UYE_SOYAD).FirstOrDefault();
            ViewBag.uye1 = uykitap;
            return View(kgecmis);
        }
    }
}