using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKütüphane.Models.Entity;

namespace MvcKütüphane.Controllers
{
    public class OduncController : Controller
    {
        // GET: Odunc
        KÜTÜPHANE_YONETİM_SİSTEMİEntities kÜTÜPHANE = new KÜTÜPHANE_YONETİM_SİSTEMİEntities();

        public ActionResult Index()
        {
            var degerler = kÜTÜPHANE.EMANET.Where(x => x.ISLEMDURUM == false).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult OduncVer()
        {
            List<SelectListItem> deger1 = (from x in kÜTÜPHANE.UYELER.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.UYE_AD + " " + x.UYE_SOYAD,
                                               Value = x.UYE_ID.ToString()
                                           }).ToList();
            List<SelectListItem> deger2 = (from y in kÜTÜPHANE.KITAPLAR.ToList()
                                           select new SelectListItem
                                           {
                                               Text = y.KITAP_ADI,
                                               Value = y.KITAP_ID.ToString()
                                           }).ToList();
            List<SelectListItem> deger3 = (from z in kÜTÜPHANE.PERSONEL.ToList()
                                           select new SelectListItem
                                           {
                                               Text = z.PERSONEL1,
                                               Value = z.PERSONEL_ID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            return View();
        }
        [HttpPost]
        public ActionResult OduncVer(EMANET e)
        {
            var d1 = kÜTÜPHANE.UYELER.Where(x => x.UYE_ID == e.UYELER.UYE_ID).FirstOrDefault();
            var d2 = kÜTÜPHANE.KITAPLAR.Where(y => y.KITAP_ID == e.KITAPLAR.KITAP_ID).FirstOrDefault();
            var d3 = kÜTÜPHANE.PERSONEL.Where(z => z.PERSONEL_ID == e.PERSONEL1.PERSONEL_ID).FirstOrDefault();
            e.UYELER = d1;
            e.KITAPLAR = d2;
            e.PERSONEL1 = d3;
            kÜTÜPHANE.EMANET.Add(e);
            kÜTÜPHANE.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult Odunciade(int id)
        {
            var odc = kÜTÜPHANE.EMANET.Find(id);
            return View("Odunciade", odc);
        }
        public ActionResult OduncGüncelle(EMANET e)
        {
            var emanet = kÜTÜPHANE.EMANET.Find(e.EMANET_ID);
            emanet.UYE_TESLIM_TARIHI = e.UYE_TESLIM_TARIHI;
            emanet.ISLEMDURUM = true;
            kÜTÜPHANE.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}