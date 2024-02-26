using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BitirmeProjesi.Models;
using System.Web.Security;

namespace BitirmeProjesi.Controllers
{
    public class OgretmenLoginController : Controller
    {
        DbOTOMASYONEntities entitiess = new DbOTOMASYONEntities();
        // GET: OgretmenLogin
        public ActionResult OgretmenLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult OgretmenLogin(Akademisyenler akademisyen)
        {
            var akds = entitiess.Akademisyenler.FirstOrDefault(x => x.AkademisyenKullanıcı == akademisyen.AkademisyenKullanıcı && x.AkademisyenŞifre == akademisyen.AkademisyenŞifre);

            if (akds != null)
            {

                FormsAuthentication.SetAuthCookie(akds.AkademisyenKullanıcı, false);

                Session["AkademisyenAdi"] = akds.AkademisyenAd;
                Session["AkademisyenSoyadi"] = akds.AkademisyenSoyad;
                Session["AkademisyenKAdi"] = akds.AkademisyenKullanıcı;
                Session["AkademisyenId"] = akds.Akademisyen_Id;

                return RedirectToAction("AkdProfil", "Akademisyenler");


            }
            else
            {
                ViewBag.Hata = "Kullanıcı adı veya Şifre Yanlış";
                return View();

            }
        }
        
    }
}
 