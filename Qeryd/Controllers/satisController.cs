using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Qeryd.Models.Entity;


namespace Qeryd.Controllers
{
    public class satisController : Controller
    {
        // GET: satis
        MDbMvcStokEntities3 db = new MDbMvcStokEntities3();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Yenisatiş()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Yenisatiş(TBLSATISLAR p)
        {
            db.TBLSATISLAR.Add(p);
            db.SaveChanges();
            return View("Index");
            
        }
    }
}