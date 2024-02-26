using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BitirmeProjesi.Models;
using System.Web.Security;

namespace BitirmeProjesi.Controllers
{
    public class AkademisyenlerController : Controller
    {
        // GET: Bolumler

        DbOTOMASYONEntities db = new DbOTOMASYONEntities();
        [Authorize]
        public ActionResult AkdProfil()
        {
            return View();
        }
        [Authorize]
        public ActionResult Akademisyenler(int id)
        {
            
            var akdgoster = db.Akademisyenler.Where(x => x.Bölüm_Id == id).ToList();

            return View(akdgoster);
        }
        [Authorize]
        public ActionResult AkdProjelerim(int id)
        {
            var projelerim = db.Projeler.Where(x => x.Akademisyen_Id == id).ToList();

            return View(projelerim);
        }
        [Authorize]
        public ActionResult AkdProjeEkle()
        {
            

            var akdgetir = db.Akademisyenler.ToList();
            ViewBag.akdlist = new SelectList(akdgetir, "Akademisyen_Id", "AkademisyenKullanıcı");

            var blmgetir = db.Bölümler.ToList();
            ViewBag.blmlist = new SelectList(blmgetir, "Bölüm_Id", "BölümAd");

            return View("AkdProjeEkle");
        }

        [HttpPost]
        public ActionResult AkdProjeEkle(Projeler prj)
        {
            if (prj.Proje_Id == 0) 
            {

                var SonKayit = db.Projeler.ToList().Last(); 

                prj.Proje_Id = SonKayit.Proje_Id + 1;

                db.Projeler.Add(prj);
               

            }
            else 
            {
                var guncelle = db.Projeler.Find(prj.Proje_Id);
                if (guncelle == null)
                {
                    return HttpNotFound();
                }
                guncelle.ProjeAd = prj.ProjeAd;
                guncelle.ProjeTanimi = prj.ProjeTanimi;
                guncelle.Bölüm_Id = prj.Bölüm_Id;
                guncelle.Akademisyen_Id = prj.Akademisyen_Id;
            }
            db.SaveChanges();

            return RedirectToAction("AkdProfil");
        }

        public ActionResult AkdProjeGüncelle(int id)
        {
            var blmgetir = db.Bölümler.ToList();
            ViewBag.blmlist = new SelectList(blmgetir, "Bölüm_Id", "BölümAd");

            var akdgetir = db.Akademisyenler.ToList();
            ViewBag.akdlist = new SelectList(akdgetir, "Akademisyen_Id", "AkademisyenKullanıcı");

            var ogrgetir = db.Öğrenciler.ToList();
            ViewBag.ogrlist = new SelectList(ogrgetir, "Ogrenci_Id", "OgrenciAd");

            var prj = db.Projeler.Find(id);
            if (prj == null)
            {
                return HttpNotFound();
            }
            return View("AkdProjeEkle", prj);
        }

        public ActionResult AkdProjeSil(int id)
        {
            var prjsil = db.Projeler.Find(id);

            if (prjsil == null)
            {
                return HttpNotFound();
            }
            

            db.Projeler.Remove(prjsil);
            
            db.SaveChanges();
            return View("AkdProfil");
        }

    }
}