using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKütüphane.Models.Entity;

namespace MvcKütüphane.Controllers
{
    public class KitapController : Controller
    {
        // GET: Kitap
        KÜTÜPHANE_YONETİM_SİSTEMİEntities kÜTÜPHANE = new KÜTÜPHANE_YONETİM_SİSTEMİEntities();
        public ActionResult Index(string p)
        {
            var kitaplar = from k in kÜTÜPHANE.KITAPLAR select k;
            if(!string.IsNullOrEmpty(p))
            {
                kitaplar = kitaplar.Where(x => x.KITAP_ADI.Contains(p));
            }
            //var kitaplar = kÜTÜPHANE.KITAPLAR.ToList();
            return View(kitaplar.ToList());
        }
        [HttpGet]
        public ActionResult KitapEkle()
        {
            List<SelectListItem> deger1 = (from i in kÜTÜPHANE.KATEGORI.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.KATEGORI_AD,
                                               Value = i.KATEGORI_ID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            List<SelectListItem> deger2 = (from i in kÜTÜPHANE.YAZARLAR.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.YAZAR_ADI + ' ' + i.YAZAR_SOYADI,
                                               Value = i.YAZAR_ID.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;
            return View();
        }
        [HttpPost]
        public ActionResult KitapEkle(KITAPLAR p)
        {
            var ktg = kÜTÜPHANE.KATEGORI.Where(k => k.KATEGORI_ID == p.KATEGORI1.KATEGORI_ID).FirstOrDefault();
            var yzr = kÜTÜPHANE.YAZARLAR.Where(y => y.YAZAR_ID == p.YAZARLAR.YAZAR_ID).FirstOrDefault();
            p.KATEGORI1 = ktg;
            p.YAZARLAR = yzr;
            kÜTÜPHANE.KITAPLAR.Add(p);
            kÜTÜPHANE.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult KitapSil(int id)
        {
            var kitap = kÜTÜPHANE.KITAPLAR.Find(id);
            kÜTÜPHANE.KITAPLAR.Remove(kitap);
            kÜTÜPHANE.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KitapGetir(int id)
        {
            var kitap = kÜTÜPHANE.KITAPLAR.Find(id);
            List<SelectListItem> deger1 = (from i in kÜTÜPHANE.KATEGORI.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.KATEGORI_AD,
                                               Value = i.KATEGORI_ID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;


            List<SelectListItem> deger2 = (from i in kÜTÜPHANE.YAZARLAR.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.YAZAR_ADI + ' ' + i.YAZAR_SOYADI,
                                               Value = i.YAZAR_ID.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;
            return View("KitapGetir", kitap);
        }
        public ActionResult KitapGüncelle(KITAPLAR p)
        {
            var kitap = kÜTÜPHANE.KITAPLAR.Find(p.KITAP_ID);
            kitap.KITAP_ADI = p.KITAP_ADI;
            kitap.YAYINEVI = p.YAYINEVI;
            kitap.S_SAYISI = p.S_SAYISI;
            kitap.DURUM = p.DURUM;
            var kategori = kÜTÜPHANE.KATEGORI.Where(k => k.KATEGORI_ID == p.KATEGORI1.KATEGORI_ID).FirstOrDefault();
            var yazar = kÜTÜPHANE.YAZARLAR.Where(y => y.YAZAR_ID == p.YAZARLAR.YAZAR_ID).FirstOrDefault();
            kitap.KATEGORI = kategori.KATEGORI_ID;
            kitap.YAZAR = yazar.YAZAR_ID;
            kÜTÜPHANE.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}