using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKütüphane.Models.Entity;

namespace MvcKütüphane.Controllers
{
    public class İslemlerController : Controller
    {
        // GET: İslemler
        KÜTÜPHANE_YONETİM_SİSTEMİEntities kÜTÜPHANE = new KÜTÜPHANE_YONETİM_SİSTEMİEntities();
        public ActionResult Index()
        {
            var degerler = kÜTÜPHANE.EMANET.Where(x => x.ISLEMDURUM == true).ToList();
            return View(degerler);
        }
    }
}