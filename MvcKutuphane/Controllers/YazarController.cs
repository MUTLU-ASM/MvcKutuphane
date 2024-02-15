using MvcKutuphane.Models.Entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKutuphane.Controllers
{
    public class YazarController : Controller
    {
        DbKutuphane db = new DbKutuphane();
        // GET: Yazar
        public ActionResult Index()
        {
            var degerler = db.yazar.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YazarEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YazarEkle(yazar y)
        {
            db.yazar.Add(y);
            db.SaveChanges();
            return View();
        }
        public ActionResult YazarSil(int id)
        {
            var yzr= db.yazar.Find(id);
            db.yazar.Remove(yzr);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult YazarGetir(int id)
        {
            var yzr = db.yazar.Find(id);
            return View("YazarGetir",yzr);
        }
        public ActionResult YazarGuncelle(yazar y)
        {
            var yzr = db.yazar.Find(y.id);
            yzr.ad = y.ad;
            yzr.soyad = y.soyad;
            yzr.detay = y.detay;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}