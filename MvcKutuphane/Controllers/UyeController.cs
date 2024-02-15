using MvcKutuphane.Models.Entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace MvcKutuphane.Controllers
{
    public class UyeController : Controller
    {
        DbKutuphane db = new DbKutuphane();
        // GET: Uye
        public ActionResult Index(int sayfa = 1)
        {
            //var degerler = db.uye.ToList();
            var degerler = db.uye.ToList().ToPagedList(sayfa, 3);
            return View(degerler);
        }
        [HttpGet]
        public ActionResult UyeEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UyeEkle(uye u)
        {
            if (!ModelState.IsValid)
            {
                return View("UyeEkle");
            }
            db.uye.Add(u);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UyeSil(int id)
        {
            var uye = db.uye.Find(id);
            db.uye.Remove(uye);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UyeGetir(int id)
        {
            var uye = db.uye.Find(id);
            return View("UyeGetir", uye);
        }
        public ActionResult UyeGuncelle(uye u)
        {
            var uye = db.uye.Find(u.id);
            uye.ad = u.ad;
            uye.soyad = u.soyad;
            uye.mail = u.mail;
            uye.kullaniciad = u.kullaniciad;
            uye.sifre = u.sifre;
            uye.okul = u.okul;
            uye.telefon = u.telefon;
            uye.fotograf = u.fotograf;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}