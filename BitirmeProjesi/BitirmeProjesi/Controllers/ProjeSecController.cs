using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BitirmeProjesi.Models;



namespace BitirmeProjesi.Controllers


{
    public class ProjeSecController : Controller
    {

        // GET: ProjeSec
        DbOTOMASYONEntities entitiess = new DbOTOMASYONEntities();

        [Authorize]
        public ActionResult ProjeSec(int id)
        {

            var projeblg = entitiess.Projeler.Where(x => x.Bölüm_Id == id).ToList();

            return View(projeblg);

        } 

        public ActionResult Sec(int id)
        {
            

            var prjsec = entitiess.Projeler.FirstOrDefault(x => x.Proje_Id == id);



            int gelenKullaniciId = (int)Session["KullaniciId"];

            
            var dbResult = entitiess.Öğrenciler.SingleOrDefault(Öğrenciler => Öğrenciler.Ogrenci_Id == gelenKullaniciId);

            if (dbResult.Proje_Id == null)
            {
                if (dbResult != null) // Kayıt bulundu
                {
                    dbResult.Proje_Id = id;

                    Response.Write("<script lang='JavaScript'>alert('Proje Başarıyla Seçildi');</script>");
                    entitiess.SaveChanges();
                }
               
            }
            else
            {
                Response.Write("<script lang='JavaScript'>alert('Projeniz Varken Başka Proje Seçemezsiniz!!!');</script>");
            }
            return View(prjsec);
        }
        
    } 
    

       




}


