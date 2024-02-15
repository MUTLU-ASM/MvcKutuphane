using MvcKutuphane.Models.Entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKutuphane.Controllers
{
    public class KitapController : Controller
    {
        DbKutuphane db = new DbKutuphane();
        // GET: Kitap
        public ActionResult Index(string k)
        {
            var kitaplar = from ktp in db.kitap select ktp;
            if (!string.IsNullOrEmpty(k))
            {
                kitaplar = kitaplar.Where(x => x.ad.Contains(k));
            }

            //var degerler = db.kitap.ToList();
            return View(kitaplar.ToList());
        }
        [HttpGet]
        public ActionResult KitapEkle()
        {
            List<SelectListItem> ktgdeger = (from i in db.kategori.ToList()
                                          select new SelectListItem
                                          {
                                              Text = i.ad,
                                              Value = i.id.ToString()
                                          }).ToList();
            ViewBag.ktgdgr = ktgdeger;
            List<SelectListItem> yzrdeger = (from i in db.yazar.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.ad + " " +i.soyad,
                                                 Value = i.id.ToString()
                                             }).ToList();
            ViewBag.yzrdgr = yzrdeger;
            return View();
        }
        [HttpPost]
        public ActionResult KitapEkle(kitap ktp)
        {
            var ktg = db.kategori.Where(k => k.id == ktp.kategori1.id).FirstOrDefault();
            var yzr = db.yazar.Where(y => y.id == ktp.yazar1.id).FirstOrDefault();
            ktp.kategori1 = ktg;
            ktp.yazar1 = yzr;
            db.kitap.Add(ktp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KitapSil(int id)
        {
            var ktp = db.kitap.Find(id);
            db.kitap.Remove(ktp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KitapGetir(int id)
        {
            var ktp = db.kitap.Find(id);
            List<SelectListItem> ktgdeger = (from i in db.kategori.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.ad,
                                                 Value = i.id.ToString()
                                             }).ToList();
            ViewBag.ktgdgr = ktgdeger;
            List<SelectListItem> yzrdeger = (from i in db.yazar.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.ad + " " + i.soyad,
                                                 Value = i.id.ToString()
                                             }).ToList();
            ViewBag.yzrdgr = yzrdeger;
            return View("KitapGetir",ktp);
        }
        public ActionResult KitapGuncelle(kitap k)
        {
            var ktp = db.kitap.Find(k.id);
            ktp.ad = k.ad;
            ktp.basımyil = k.basımyil;
            ktp.sayfa = k.sayfa;
            ktp.yayinevi = k.yayinevi;
            var ktg = db.kategori.Where(ktgr => ktgr.id == k.kategori1.id).FirstOrDefault();
            var yzr = db.kategori.Where(y => y.id == k.yazar1.id).FirstOrDefault();
            ktp.kategori = ktg.id;
            ktp.yazar = yzr.id;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}