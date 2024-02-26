using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BitirmeProjesi.Models;
using System.Web.Security;

namespace BitirmeProjesi.Controllers
{
    public class OgrenciLoginController : Controller
    {
        // GET: OgrenciLogin
        DbOTOMASYONEntities db = new DbOTOMASYONEntities();


        public ActionResult Login()
        {
            return View();
        }


        [HttpPost] 
        public ActionResult Login(Öğrenciler ogrenci)
        { 
            
            var ogrencis = db.Öğrenciler.FirstOrDefault(x => x.KullanıcıAd == ogrenci.KullanıcıAd && x.Şifre == ogrenci.Şifre);
            
            if (ogrencis != null)
            {
                
                FormsAuthentication.SetAuthCookie(ogrencis.KullanıcıAd, false);

                Session["KullaniciAdi"] = ogrencis.OgrenciAd;
                Session["KullaniciSoyad"] = ogrencis.OgrenciSoyad;
                Session["KullaniciId"] = ogrencis.Ogrenci_Id;
                Session["BolumId"] = ogrencis.Bölüm_Id;
                Session["BolumAdi"] = ogrencis.Bölümler.BölümAd;
                if(ogrencis.Proje_Id >= 1) 
                {
                    Session["ProjeId"] = ogrencis.Proje_Id;
                    Session["ProjeAdi"] = ogrencis.Projeler.ProjeAd;
                }
                
                return RedirectToAction("OgrenciProfil", "Profil");                          
            }
            else
            {
                ViewBag.Hata = "Kullanıcı adı veya Şifre Yanlış";
                return View();
                
            }

        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

    }
}




 