using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BitirmeProjesi.Models;


namespace BitirmeProjesi.Controllers
{
    public class AdminProjeController : Controller
    {
        // GET: AdminProje
        DbOTOMASYONEntities db = new DbOTOMASYONEntities();

        public ActionResult AdminProje()
        {
            var getir = db.Bölümler.ToList();

            return View(getir);

        }

        public ActionResult AdminProjeSec(int id)
        {
            var projeblg = db.Projeler.Where(x => x.Bölüm_Id == id).ToList();

            return View(projeblg);
        }
  
        public ActionResult AdminProjeEkle()
        {
            var akdgetir = db.Akademisyenler.ToList();
            ViewBag.akdlist = new SelectList(akdgetir, "Akademisyen_Id", "AkademisyenKullanıcı");

            var blmgetir = db.Bölümler.ToList();
            ViewBag.blmlist = new SelectList(blmgetir, "Bölüm_Id", "BölümAd");
           
            return View("AdminProjeEkle");
        }

        [HttpPost]
        public ActionResult AdminProjeEkle(Projeler prj)
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

            return RedirectToAction("AdminProje");
        }
    
        public ActionResult AdminProjeGüncelle(int id)
        {
            var blmgetir = db.Bölümler.ToList();
            ViewBag.blmlist = new SelectList(blmgetir, "Bölüm_Id", "BölümAd");

            var akdgetir = db.Akademisyenler.ToList();
            ViewBag.akdlist = new SelectList(akdgetir, "Akademisyen_Id", "AkademisyenKullanıcı");

            var prj = db.Projeler.Find(id);
            if (prj == null)
            {
                return HttpNotFound();
            }
            return View("AdminProjeEkle", prj);
        }

        public ActionResult AdminProjeSil(int id)
        {
            var prjsil = db.Projeler.Find(id);
            
            if (prjsil == null)
            {
                return HttpNotFound();
            }
            db.Projeler.Remove(prjsil);
            

            db.SaveChanges();
            return RedirectToAction("AdminProje");
        }


    
    }
}