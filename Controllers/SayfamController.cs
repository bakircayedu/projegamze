using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Mvc;
using MvcKütüphane.Models.Entity;

namespace MvcKütüphane.Controllers
{
    
    public class SayfamController : Controller
    {
        // GET: Sayfam
        KÜTÜPHANE_YONETİM_SİSTEMİEntities kÜTÜPHANE = new KÜTÜPHANE_YONETİM_SİSTEMİEntities();
        private object formsauthentication;

        public object FormsAuthenctication { get; private set; }

        [HttpGet]
        [Authorize]
        public ActionResult Index()
        {
            var uyekullaniciadi = (string)Session["Kullanıcı Adı"];
            var degerler = kÜTÜPHANE.UYELER.FirstOrDefault(z => z.KULLANICIADI == uyekullaniciadi);
            return View(degerler);
        }

        [HttpPost]
        public ActionResult Index2(UYELER p)
        {
            var kullanici = (string)Session["Kullanıcı Adı"];
            var uye = kÜTÜPHANE.UYELER.FirstOrDefault(x => x.KULLANICIADI == kullanici);
            uye.SİFRE = p.SİFRE;
            uye.UYE_AD = p.UYE_AD;
            uye.UYE_SOYAD = p.UYE_SOYAD;
            uye.TELEFON = p.TELEFON;
            uye.E_POSTA = p.E_POSTA;
            uye.OKUL = p.OKUL;
            kÜTÜPHANE.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Kitaplarim()
        {
            var kullanici = (string)Session["Kullanıcı Adı"];
            var id = kÜTÜPHANE.UYELER.Where(x => x.KULLANICIADI == kullanici.ToString()).Select(z => z.UYE_ID).FirstOrDefault();
            var degerler = kÜTÜPHANE.EMANET.Where(x => x.UYE == id).ToList();
            return View(degerler);
        }
        public ActionResult CikisYap()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("GirisYap", "Login");
        }
    }
}