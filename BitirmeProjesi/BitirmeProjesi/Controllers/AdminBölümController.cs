using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BitirmeProjesi.Models;

namespace BitirmeProjesi.Controllers
{
    public class AdminBölümController : Controller
    {
        // GET: AdminBölüm
        DbOTOMASYONEntities db = new DbOTOMASYONEntities();

     
        public ActionResult AdminBölüm()
        {
            var blmgoster = db.Bölümler.ToList();
            return View(blmgoster);

        }


        public ActionResult AdminBölümEkle()
        {
            return View("AdminBölümEkle");
        }

        [HttpPost]
        public ActionResult AdminBölümEkle(Bölümler blm)
        {


            if (blm.Bölüm_Id == 0)
            {
                db.Bölümler.Add(blm);
            }
            else
            {
                var guncelle = db.Bölümler.Find(blm.Bölüm_Id);
                if (guncelle == null)
                {
                    return HttpNotFound();
                }
                guncelle.BölümAd = blm.BölümAd;
            }


            db.SaveChanges();

            return RedirectToAction("AdminBölüm");

        }

        public ActionResult AdminBölümGüncelle(int id)
        {
            var blm = db.Bölümler.Find(id);
            if (blm == null)
            {
                return HttpNotFound();
            }
            return View("AdminBölümEkle", blm);
        }

        public ActionResult AdminBölümSil(int id)
        {
            var blmsil = db.Bölümler.Find(id);
            if (blmsil == null)
            {
                return HttpNotFound();
            }
            db.Bölümler.Remove(blmsil);
            db.SaveChanges();
            return RedirectToAction("AdminBölüm");
        }



    }
}