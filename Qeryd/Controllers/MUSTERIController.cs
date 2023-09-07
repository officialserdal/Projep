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
        public ActionResult Index()
        {
            var degerler = db.TBLMUSTERILER_.ToList();
            return View(degerler);
        }
        [HttpPost]
        public ActionResult YenıMusterı(TBLMUSTERILER_ P4)
        {
            db.TBLMUSTERILER_.Add(P4);
            db.SaveChanges();
            return View();

        }
        [HttpGet]
        public ActionResult YenıMusterı()
        {
            return View();

        }

    }
}