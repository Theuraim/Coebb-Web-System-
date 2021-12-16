using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sistema_COEBB.Models;
using Sistema_COEBB.Filters;

namespace Sistema_COEBB.Controllers
{
    [Authorize]
    [InitializeSimpleMembership]
    public class NoticiaController : Controller
    {
        private DbContexto db = new DbContexto();

        //
        // GET: /Noticia/

        public ActionResult Index()
        {
            return View(db.Noticias.ToList());
        }

        //
        // GET: /Noticia/Details/5

        public ActionResult Details(int id = 0)
        {
            Noticia noticia = db.Noticias.Find(id);
            if (noticia == null)
            {
                return HttpNotFound();
            }
            return View(noticia);
        }

        //
        // GET: /Noticia/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Noticia/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Noticia noticia)
        {
            if (ModelState.IsValid)
            {
                db.Noticias.Add(noticia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(noticia);
        }

        //
        // GET: /Noticia/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Noticia noticia = db.Noticias.Find(id);
            if (noticia == null)
            {
                return HttpNotFound();
            }
            return View(noticia);
        }

        //
        // POST: /Noticia/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Noticia noticia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(noticia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(noticia);
        }

        //
        // GET: /Noticia/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Noticia noticia = db.Noticias.Find(id);
            if (noticia == null)
            {
                return HttpNotFound();
            }
            return View(noticia);
        }

        //
        // POST: /Noticia/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Noticia noticia = db.Noticias.Find(id);
            db.Noticias.Remove(noticia);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}