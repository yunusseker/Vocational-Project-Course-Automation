using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BitirmeProjesi.Models;

namespace BitirmeProjesi.Controllers
{
    public class BolumlerController : Controller
    {
        // GET: Bolumler

        DbOTOMASYONEntities entitiess = new DbOTOMASYONEntities();
        [Authorize]
        public ActionResult Bolumler()
        {
            var blmgoster = entitiess.Bölümler.ToList();
            return View(blmgoster);
        }
    }
}