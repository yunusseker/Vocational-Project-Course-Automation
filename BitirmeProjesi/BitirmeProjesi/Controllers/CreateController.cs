using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BitirmeProjesi.Models;

namespace BitirmeProjesi.Controllers
{
    public class CreateController : Controller
    {
        // GET: Create
        
       
        public ActionResult Create() 
        {


            DbOTOMASYONEntities entitiess = new DbOTOMASYONEntities();
            var bölümgetir = entitiess.Bölümler.ToList();
            ViewBag.bölümlist = new SelectList(bölümgetir, "Bölüm_Id", "BölümAd");

            return View();        
        }

        [HttpPost]
        public ActionResult Create(Öğrenciler ogr)
        {
            DbOTOMASYONEntities entitiess = new DbOTOMASYONEntities();

            var bölümgetir = entitiess.Bölümler.ToList();
            ViewBag.bölümlist = new SelectList(bölümgetir, "Bölüm_Id", "BölümAd");

            if (ModelState.IsValid)
            {
               
                entitiess.Öğrenciler.Add(new Öğrenciler() {OgrenciAd=ogr.OgrenciAd, OgrenciSoyad=ogr.OgrenciSoyad, KullanıcıAd=ogr.KullanıcıAd, Şifre=ogr.Şifre, Bölüm_Id=ogr.Bölüm_Id,  }  );
                var Kullanici = entitiess.Öğrenciler.Where(a => a.KullanıcıAd == ogr.KullanıcıAd).FirstOrDefault();

                if(Kullanici != null)
                {
                    Response.Write("<script lang='JavaScript'>alert('Kullanıcı Adı Başkasına Ait. Lütfen Tekrar Deneyiniz.');</script>");
                }
                else
                {
                    if (ogr.Bölüm_Id == null)
                    {
                        Response.Write("<script lang='JavaScript'>alert('Lütfen Bölüm Seçiniz.');</script>");
                    }
                    else
                    {
                        entitiess.SaveChanges();
                        return RedirectToAction("Login", "OgrenciLogin");
                    }

                }
               
            }
            return View();           
        }

    }
}