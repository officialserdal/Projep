using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Qeryd.Models.Entity;

namespace Qeryd.Controllers
{
    public class MUSTERIController : Controller
    {
        // GET: MUSTERI
        MDbMvcStokEntities3 db = new MDbMvcStokEntities3();
        public ActionResult Index(string p)
        {
            var degerler=from d in db.TBLMUSTERILER_ select d;
            if (!string.IsNullOrEmpty(p))
            {
                degerler = degerler.Where(m => m.MUSTERIAD.Contains(p));

            }
            return View(degerler.ToList());



            //var degerler = db.TBLMUSTERILER_.ToList();
            //return View(degerler);
        }
        [HttpPost]
        public ActionResult YenıMusterı(TBLMUSTERILER_ P4)
        {
            if (!ModelState.IsValid)
            {
                return View("YenıMusterı");
            }
            db.TBLMUSTERILER_.Add(P4);
            db.SaveChanges();
            return View();

        }
        [HttpGet]
        public ActionResult YenıMusterı()
        {
            return View();

        }
        public ActionResult SIL(int id)
        {
            var musterı = db.TBLMUSTERILER_.Find(id);
            db.TBLMUSTERILER_.Remove(musterı);
            db.SaveChanges();
            return RedirectToAction("Index");


        }
       public ActionResult MusterıGetır(int id)
        {
            var mus = db.TBLMUSTERILER_.Find(id);
            return View("MusterıGetır", mus);

        }
        public ActionResult Guncelle(TBLMUSTERILER_ p1)
        {
            var mus = db.TBLMUSTERILER_.Find(p1.MUSTERIID);
            mus.MUSTERIAD = p1.MUSTERIAD;
            mus.MUSTERISOYAD = p1.MUSTERISOYAD;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        

    }
}