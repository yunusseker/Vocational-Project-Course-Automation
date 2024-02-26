using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BitirmeProjesi.Models;
namespace BitirmeProjesi.Controllers

{
    public class ProfilController : Controller
    {
        // GET: Profil

        DbOTOMASYONEntities entitiess = new DbOTOMASYONEntities();

        [Authorize]
        public ActionResult OgrenciProfil()
        { 
            {
                
                return View();
            }
        }

       

    }
    

}

