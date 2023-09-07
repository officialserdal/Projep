using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Qeryd.Models.Entity;


namespace Qeryd.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        MDbMvcStokEntities3 db=new MDbMvcStokEntities3();
        public ActionResult Index()
        {
            var degerler = db.KATEGORILER.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult Yenikategori()
        {
            return View();

        }

        [HttpPost]
        public ActionResult Yenikategori(KATEGORILER p1)
        {
            db.KATEGORILER.Add(p1);
            db.SaveChanges();
            return View();

        }
        [HttpPost]
        public ActionResult SIL(KATEGORILER p2)
        {
           var a= db.KATEGORILER.Remove(p2);
            db.SaveChanges();
            return View();

        }



    }
    
}