using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Qeryd.Models.Entity;
using PagedList;
using PagedList.Mvc;



namespace Qeryd.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        MDbMvcStokEntities3 db=new MDbMvcStokEntities3();
        public ActionResult Index(int sayfa=1)
        {
            //  var degerler = db.KATEGORILER.ToList();
            var degerler = db.KATEGORILER.ToList().ToPagedList(sayfa,4);
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
            if (!ModelState.IsValid)
            {
                return View("Yenikategori");
            }
            db.KATEGORILER.Add(p1);
            db.SaveChanges();
            return View();

        }
        
        public ActionResult SIL(int id)
        {
            var kategorı = db.KATEGORILER.Find(id);
            db.KATEGORILER.Remove(kategorı);
            db.SaveChanges();
          return  RedirectToAction("Index");


        }
        public ActionResult KategorıGetır(int id)
        {
            var ktgr = db.KATEGORILER.Find(id);
            return View("KategorıGetır", ktgr);


            
        }
        public ActionResult Guncelle(KATEGORILER p1)
        {
            var ktg = db.KATEGORILER.Find(p1.KATEGORIID);
            ktg.KATEGORİAD = p1.KATEGORİAD;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
       



    }
    
}