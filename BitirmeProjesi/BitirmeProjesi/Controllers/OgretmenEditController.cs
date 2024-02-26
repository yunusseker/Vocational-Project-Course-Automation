using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BitirmeProjesi.Models;

namespace BitirmeProjesi.Controllers
{
    public class OgretmenEditController : Controller
    {
        DbOTOMASYONEntities entitiess = new DbOTOMASYONEntities();

        // GET: OgretmenEdit
        [Authorize]
        public ActionResult OgretmenEdit(int id)
        {
            var og = entitiess.Akademisyenler.Find(id);
            return View("OgretmenEdit", og);
        }


        [HttpPost]
        public ActionResult OgretmenEdit(Akademisyenler akd)
        {
            var akademisyen = entitiess.Akademisyenler.Find(akd.Akademisyen_Id);
            if (akademisyen != null)
            {
                akademisyen.AkademisyenAd = akd.AkademisyenAd;
                akademisyen.AkademisyenSoyad = akd.AkademisyenSoyad;
                akademisyen.AkademisyenŞifre = akd.AkademisyenŞifre;
                entitiess.SaveChanges();
                return RedirectToAction("OgretmenEdit");
            }
            else
            {
                ViewBag.Hata = "AKADEMİSYEN ID'Yİ DEĞİŞTREMEZSİNİZ!!!";
                return View();
            }
        }
    }
}