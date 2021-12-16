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
    public class EquipeController : Controller
    {
        private DbContexto db = new DbContexto();

        //
        // GET: /Equipe/

        public ActionResult Index()
        {
            return View(db.Equipes.ToList());
        }

        //
        // GET: /Equipe/Details/5

        public ActionResult Details(int id = 0)
        {
            Equipe equipe = db.Equipes.Find(id);
            if (equipe == null)
            {
                return HttpNotFound();
            }
            return View(equipe);
        }

        //
        // GET: /Equipe/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Equipe/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Equipe equipe)
        {
            if (ModelState.IsValid)
            {
                db.Equipes.Add(equipe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(equipe);
        }

        //
        // GET: /Equipe/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Equipe equipe = db.Equipes.Find(id);
            if (equipe == null)
            {
                return HttpNotFound();
            }
            return View(equipe);
        }

        //
        // POST: /Equipe/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Equipe equipe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(equipe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(equipe);
        }

        //
        // GET: /Equipe/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Equipe equipe = db.Equipes.Find(id);
            if (equipe == null)
            {
                return HttpNotFound();
            }
            return View(equipe);
        }

        //
        // POST: /Equipe/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Equipe equipe = db.Equipes.Find(id);
            db.Equipes.Remove(equipe);
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