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

            List<SelectListItem> degerler = ((List<SelectListItem>)(from i in db.KATEGORILER.ToList()
                                                                    select new SelectListItem
                                                                    {
                                                                        Text = i.KATEGORİAD,
                                                                        Value = i.KATEGORIID.ToString()
                                                                    }));



            ViewBag.dgr = degerler;
            return View();
            
        }
        [HttpPost]
        public ActionResult YenıUrun(TBLURUNLER_ p7)
        {
            db.TBLURUNLER_.Add(p7);
            db.SaveChanges();
            return View();               

        }  
      
         
    }
}