using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BitirmeProjesi.Models;

namespace BitirmeProjesi.Controllers
{
    public class AdminOgrenciController : Controller
    {
        // GET: AdminOgrenci
        DbOTOMASYONEntities db = new DbOTOMASYONEntities();

        public ActionResult AdminOgrenci()
        {
            var ogrgoster = db.Öğrenciler.ToList();
            return View(ogrgoster);
        }
    
        public ActionResult AdminOgrenciEkle()
        {

            var bölümgetir = db.Bölümler.ToList();
            ViewBag.bölümlist = new SelectList(bölümgetir, "Bölüm_Id", "BölümAd");

            
                

            return View("AdminOgrenciEkle");
        }

        [HttpPost]
        public ActionResult AdminOgrenciEkle(Öğrenciler ogr)

        {
            if (ogr.Ogrenci_Id == 0)
            {
                db.Öğrenciler.Add(ogr);
            }
            else
            {
                var guncelle = db.Öğrenciler.Find(ogr.Ogrenci_Id);
                if (guncelle == null)
                {
                    return HttpNotFound();
                }
                guncelle.OgrenciAd = ogr.OgrenciAd;
                guncelle.OgrenciSoyad = ogr.OgrenciSoyad;
                guncelle.KullanıcıAd = ogr.KullanıcıAd;
                guncelle.Şifre = ogr.Şifre;
                guncelle.Bölüm_Id = ogr.Bölüm_Id;
                
            }


            db.SaveChanges();

            return RedirectToAction("AdminOgrenci");
        }
 
        public ActionResult AdminOgrenciGüncelle(int id)
        {
            var bölümgetir = db.Bölümler.ToList();
            ViewBag.bölümlist = new SelectList(bölümgetir, "Bölüm_Id", "BölümAd");

            

            var ogr = db.Öğrenciler.Find(id);
            if (ogr == null)
            {
                return HttpNotFound();
            }
            return View("AdminOgrenciEkle", ogr);
        }

        public ActionResult AdminOgrenciSil(int id)
        {
            var ogrsil = db.Öğrenciler.Find(id);
            
            if (ogrsil == null)
            {
                return HttpNotFound();
            }
            db.Öğrenciler.Remove(ogrsil);
            

            db.SaveChanges();
            return RedirectToAction("AdminOgrenci");
        }
    }
}