using MvcKutuphane.Models.Entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKutuphane.Controllers
{
    public class OduncController : Controller
    {
        DbKutuphane db = new DbKutuphane();
        // GET: Odunc
        public ActionResult Index()
        {
            var values = db.hareket.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult OduncVer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult OduncVer(hareket h)
        {
            db.hareket.Add(h);
            db.SaveChanges();
            return View();
        }
    }
}