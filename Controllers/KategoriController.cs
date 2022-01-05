using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKütüphane.Models.Entity;
namespace MvcKütüphane.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        KÜTÜPHANE_YONETİM_SİSTEMİEntities kÜTÜPHANE = new KÜTÜPHANE_YONETİM_SİSTEMİEntities();
        public ActionResult Index()
        {
            var degerler = kÜTÜPHANE.KATEGORI.Where(x => x.DURUM == true).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KategoriEkle(KATEGORI p)
        {
            kÜTÜPHANE.KATEGORI.Add(p);
            kÜTÜPHANE.SaveChanges();
            return View();
        }
        public ActionResult KategoriSil(int id)
        {
            var kategori = kÜTÜPHANE.KATEGORI.Find(id);
            //kÜTÜPHANE.KATEGORI.Remove(kategori);
            kategori.DURUM = false;
            kÜTÜPHANE.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGetir(int id)
        {
            var kategori = kÜTÜPHANE.KATEGORI.Find(id);
            return View("KategoriGetir", kategori);
        }
        public ActionResult KategoriGüncelle(KATEGORI p)
        {
            var kategori = kÜTÜPHANE.KATEGORI.Find(p.KATEGORI_ID);
            kategori.KATEGORI_AD = p.KATEGORI_AD;
            kÜTÜPHANE.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}