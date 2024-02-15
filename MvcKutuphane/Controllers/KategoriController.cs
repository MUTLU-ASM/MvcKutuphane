using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entitiy;

namespace MvcKutuphane.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        DbKutuphane db = new DbKutuphane();
        public ActionResult Index()
        {
            var degerler = db.kategori.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KategoriEkle(kategori k)
        {
            db.kategori.Add(k);
            db.SaveChanges();
            return View();
        }
        public ActionResult KategoriSil(int id)
        {
            var ktg = db.kategori.Find(id);
            db.kategori.Remove(ktg);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGetir(int id)
        {
            var ktg = db.kategori.Find(id);
            return View("KategoriGetir",ktg);
        }
        public ActionResult KategoriGuncelle(kategori k)
        {
            var ktg = db.kategori.Find(k.id);
            ktg.ad = k.ad;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}