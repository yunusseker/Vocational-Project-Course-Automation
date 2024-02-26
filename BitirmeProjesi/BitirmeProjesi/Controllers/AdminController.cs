using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BitirmeProjesi.Models;


namespace BitirmeProjesi.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        DbOTOMASYONEntities db = new DbOTOMASYONEntities();

        public ActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminLogin(Admin admin)
        {

            var adminl = db.Admin.FirstOrDefault(a => a.AdminUserName == admin.AdminUserName && a.AdminPassword == admin.AdminPassword);

            if (adminl != null)
            {
                return RedirectToAction("AdminProfil", "Admin");
            }

            else
            {
                ViewBag.Hata = "Kullanıcı adı veya Şifre Yanlış";
                return View();

            }

        }

        
        public ActionResult AdminProfil() 
        {


            return View();
        }



        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }



    }
}