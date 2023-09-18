using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Qeryd.Models.Entity;

namespace Qeryd.Controllers
{

    public class URUNLERController : Controller
    {
        // GET: URUNLER
        MDbMvcStokEntities3 db = new MDbMvcStokEntities3();
        public ActionResult Index()
        {
            var degerler = db.TBLURUNLER_.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YenıUrun()
        {

            List<SelectListItem> degerler = db.KATEGORILER.ToList()
     .Select(i => new SelectListItem
     {
         Text = i.KATEGORİAD,
         Value = i.KATEGORIID.ToString()
     })
     .ToList();




            ViewBag.dgr = degerler;
            return View();
            
        }
        [HttpPost]
        public ActionResult YenıUrun(TBLURUNLER_ p7)
        {
            var ktg = db.KATEGORILER.Where(m => m.KATEGORIID == p7.KATEGORILER.KATEGORIID).FirstOrDefault();
            p7.KATEGORILER = ktg;

            db.TBLURUNLER_.Add(p7);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SIL(int id)
        {
            var urun = db.TBLURUNLER_.Find( id);
            db.TBLURUNLER_.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Index");


        }
        public ActionResult UrunGetır(int id)
        {
            var urun = db.TBLURUNLER_.Find(id);

            List<SelectListItem> degerler = db.KATEGORILER.ToList()
     .Select(i => new SelectListItem
     {
         Text = i.KATEGORİAD,
         Value = i.KATEGORIID.ToString()
     })
     .ToList(); 
            ViewBag.dgr = degerler;
            return View("UrunGetır", urun);

        }
        public ActionResult Guncelle(TBLURUNLER_ p)
        {
            var urun = db.TBLURUNLER_.Find(p.URUNID);
            urun.URUNAD = p.URUNAD;
            urun.MARKA = p.MARKA;
            urun.STOK = p.STOK;
            urun.FIYAT = p.FIYAT;
            //urun.URUNKATEGORI = p.URUNKATEGORI;
            var ktg = db.KATEGORILER.Where(m => m.KATEGORIID == p.KATEGORILER.KATEGORIID).FirstOrDefault();
            urun.URUNKATEGORI = ktg.KATEGORIID;
            db.SaveChanges();
            return RedirectToAction("Index");



        }


    }
}