using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BitirmeProjesi.Models;

namespace BitirmeProjesi.Controllers
{
    public class OgrenciEditController : Controller
    {
        DbOTOMASYONEntities entitiess = new DbOTOMASYONEntities();

        // GET: OgrenciEdit
        [Authorize]
        public ActionResult ogrenciEdit(int id)
        {
            var og = entitiess.Öğrenciler.Find(id);
            return View("ogrenciEdit", og);
        }
        [HttpPost]
        public ActionResult ogrenciEdit(Öğrenciler ogr)
        {
            var ogrenci = entitiess.Öğrenciler.Find(ogr.Ogrenci_Id);
            if (ogrenci != null)
            {
                ogrenci.OgrenciAd = ogr.OgrenciAd;
                ogrenci.OgrenciSoyad = ogr.OgrenciSoyad;
                ogrenci.Şifre = ogr.Şifre;
                entitiess.SaveChanges();
                return RedirectToAction("ogrenciEdit");
            } 
            else
            {
                ViewBag.Hata = "ÖĞRENCİ ID'Yİ DEĞİŞTREMEZSİNİZ!!!";
                return View();
            }
        }
    }
}