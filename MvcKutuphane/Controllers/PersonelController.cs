using MvcKutuphane.Models.Entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKutuphane.Controllers
{
    public class PersonelController : Controller
    {
        DbKutuphane db = new DbKutuphane();
        // GET: Personel
        public ActionResult Index()
        {
            var degerler = db.personel.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult PersonelEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PersonelEkle(personel p)
        {
            if (!ModelState.IsValid)
            {
                return View("PersonelEkle");
            }
            db.personel.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelSil(int id)
        {
            var prs = db.personel.Find(id);
            db.personel.Remove(prs);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelGetir(int id)
        {
            var prs = db.personel.Find(id);
            return View("PersonelGetir", prs);
        }
        public ActionResult PersonelGuncelle(personel p)
        {
            var prs = db.personel.Find(p.id);
            prs.personelad1 = p.personelad1;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}