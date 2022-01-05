using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcKütüphane.Models.Entity;

namespace MvcKütüphane.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        KÜTÜPHANE_YONETİM_SİSTEMİEntities kÜTÜPHANE = new KÜTÜPHANE_YONETİM_SİSTEMİEntities();
        public ActionResult Index()
        {
            var degerler = kÜTÜPHANE.PERSONEL.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult PersonelEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PersonelEkle(PERSONEL p)
        {
            if(!ModelState.IsValid)
            {
                return View("PersonelEkle");
            }
            kÜTÜPHANE.PERSONEL.Add(p);
            kÜTÜPHANE.SaveChanges();
            return View();
        }
        public ActionResult PersonelSil(int id)
        {
            var personel = kÜTÜPHANE.PERSONEL.Find(id);
            kÜTÜPHANE.PERSONEL.Remove(personel);
            kÜTÜPHANE.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelGetir(int id)
        {
            var personel = kÜTÜPHANE.PERSONEL.Find(id);
            return View("PersonelGetir", personel);
        }
        public ActionResult PersonelGüncelle(PERSONEL p)
        {
            var personel = kÜTÜPHANE.PERSONEL.Find(p.PERSONEL_ID);
            personel.PERSONEL1 = p.PERSONEL1;
            kÜTÜPHANE.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CikisYapAdmin()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "AdminLogin");
        }
    }
}