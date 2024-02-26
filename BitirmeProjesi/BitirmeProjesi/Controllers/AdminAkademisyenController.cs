using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BitirmeProjesi.Models;

namespace BitirmeProjesi.Controllers
{
    public class AdminAkademisyenController : Controller
    {
        // GET: AdminAkademisyen
        DbOTOMASYONEntities db = new DbOTOMASYONEntities();

       
        public ActionResult AdminAkademisyen()
        {
            var akdgoster = db.Akademisyenler.ToList();
            return View(akdgoster);
        }
        
        
        public ActionResult AdminAkdEkle()
        {
            var bölümgetir = db.Bölümler.ToList();
            ViewBag.bölümlist = new SelectList(bölümgetir, "Bölüm_Id", "BölümAd");

            return View("AdminAkdEkle");
        }

        [HttpPost]
        public ActionResult AdminAkdEkle(Akademisyenler akd)

        {
            if (akd.Akademisyen_Id == 0)
            {
                db.Akademisyenler.Add(akd);
            }
            else
            {
                var guncelle = db.Akademisyenler.Find(akd.Akademisyen_Id);
                if (guncelle == null)
                {
                    return HttpNotFound();
                }
                guncelle.AkademisyenAd = akd.AkademisyenAd;
                guncelle.AkademisyenSoyad = akd.AkademisyenSoyad;
                guncelle.AkademisyenKullanıcı = akd.AkademisyenKullanıcı;
                guncelle.AkademisyenŞifre = akd.AkademisyenŞifre;
                guncelle.Bölüm_Id = akd.Bölüm_Id;
            }


            db.SaveChanges();

            return RedirectToAction("AdminAkademisyen");
        }

     
        public ActionResult AdminAkdGüncelle(int id)
        {
            var bölümgetir = db.Bölümler.ToList();
            ViewBag.bölümlist = new SelectList(bölümgetir, "Bölüm_Id", "BölümAd");

            var akd = db.Akademisyenler.Find(id);
            if (akd == null)
            {
                return HttpNotFound();
            }
            return View("AdminAkdEkle", akd);
        }


        public ActionResult AdminAkdSil(int id)
        {
            var akdsil = db.Akademisyenler.Find(id);
            var prsil = db.Projeler.Find(akdsil.Akademisyen_Id);
            if (akdsil == null)
            {
                return HttpNotFound();
            }
            db.Akademisyenler.Remove(akdsil);
            db.Projeler.Remove(prsil);
            
            db.SaveChanges();
            return RedirectToAction("AdminAkademisyen");
        }

       

    }
}