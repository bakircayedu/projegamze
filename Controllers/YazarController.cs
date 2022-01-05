using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKütüphane.Models.Entity;
namespace MvcKütüphane.Controllers
{
    public class YazarController : Controller
    {
        // GET: Yazar
        KÜTÜPHANE_YONETİM_SİSTEMİEntities kÜTÜPHANE = new KÜTÜPHANE_YONETİM_SİSTEMİEntities();
        public ActionResult Index()
        {
            var degerler = kÜTÜPHANE.YAZARLAR.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YazarEkle()
        {
            return View();
        }
        public ActionResult YazarEkle(YAZARLAR p)
        {
            if(!ModelState.IsValid)
            {
                return View("YazarEkle");
            }
            kÜTÜPHANE.YAZARLAR.Add(p);
            kÜTÜPHANE.SaveChanges();
            return View();
        }
        public ActionResult YazarSil(int id)
        {
            var yazar = kÜTÜPHANE.YAZARLAR.Find(id);
            kÜTÜPHANE.YAZARLAR.Remove(yazar);
            kÜTÜPHANE.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult YazarGetir(int id)
        {
            var yazar = kÜTÜPHANE.YAZARLAR.Find(id);
            return View("YazarGetir", yazar);
        }
        public ActionResult YazarGüncelle(YAZARLAR p)
        {
            var yazar = kÜTÜPHANE.YAZARLAR.Find(p.YAZAR_ID);
            yazar.YAZAR_ADI = p.YAZAR_ADI;
            yazar.YAZAR_SOYADI = p.YAZAR_SOYADI;
            yazar.YAZAR_DETAY = p.YAZAR_DETAY;
            kÜTÜPHANE.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult YazarKitaplar(int id)
        {
            var yazar = kÜTÜPHANE.KITAPLAR.Where(x => x.YAZAR == id).ToList();
            var yazaradi = kÜTÜPHANE.YAZARLAR.Where(y => y.YAZAR_ID == id).Select(z => z.YAZAR_ADI + " " + z.YAZAR_SOYADI).FirstOrDefault();
            ViewBag.yzr1 = yazaradi;
            return View(yazar);

        }
    }
}