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
    public class FotoController : Controller
    {
        private DbContexto db = new DbContexto();

        //
        // GET: /Foto/

        public ActionResult Index()
        {
            var fotos = db.Fotos.Include(f => f.Noticia).Include(f => f.Equipe);
            return View(fotos.ToList());
        }

        //
        // GET: /Foto/Details/5

        public ActionResult Details(int id = 0)
        {
            Foto foto = db.Fotos.Find(id);
            if (foto == null)
            {
                return HttpNotFound();
            }
            return View(foto);
        }

        //
        // GET: /Foto/Create

        public ActionResult Create()
        {
            ViewBag.IDNOTICIA = new SelectList(db.Noticias, "IDNOTICIA", "TITULO_NOTICIA");
            ViewBag.IDEQUIPE = new SelectList(db.Equipes, "IDEQUIPE", "NOME");
            return View();
        }

        //
        // POST: /Foto/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Foto foto, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                db.Fotos.Add(foto);
                db.SaveChanges();
                if (file != null)
                {
                    String[] strName = file.FileName.Split('.');
                    String strExt = strName[strName.Count() - 1];
                    string pathSave = String.Format("{0}{1}.{2}", Server.MapPath("~/Images/"), foto.IDFOTO, strExt);
                    String pathBase = String.Format("/Images/{0}.{1}", foto.IDFOTO, strExt);
                    file.SaveAs(pathSave);
                    foto.CAMINHO = pathBase;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }

            ViewBag.IDNOTICIA = new SelectList(db.Noticias, "IDNOTICIA", "TITULO_NOTICIA", foto.IDNOTICIA);
            ViewBag.IDEQUIPE = new SelectList(db.Equipes, "IDEQUIPE", "NOME", foto.IDEQUIPE);
            return View(foto);
        }

        //
        // GET: /Foto/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Foto foto = db.Fotos.Find(id);
            if (foto == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDNOTICIA = new SelectList(db.Noticias, "IDNOTICIA", "TITULO_NOTICIA", foto.IDNOTICIA);
            ViewBag.IDEQUIPE = new SelectList(db.Equipes, "IDEQUIPE", "NOME", foto.IDEQUIPE);
            return View(foto);
        }

        //
        // POST: /Foto/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Foto foto, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                db.Entry(foto).State = EntityState.Modified;
                db.SaveChanges();
                if (file != null)
                {
                    if (foto.CAMINHO != null)
                    {
                        if (System.IO.File.Exists(Server.MapPath("~/" + foto.CAMINHO)))
                        {
                            System.IO.File.Delete(Server.MapPath("~/" + foto.CAMINHO));
                        }
                    }
                    String[] strName = file.FileName.Split('.');
                    String strExt = strName[strName.Count() - 1];
                    string pathSave = String.Format("{0}{1}.{2}", Server.MapPath("~/Images/"), foto.IDFOTO, strExt);
                    String pathBase = String.Format("/Images/{0}.{1}", foto.IDFOTO, strExt);
                    file.SaveAs(pathSave);
                    foto.CAMINHO = pathBase;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            ViewBag.IDNOTICIA = new SelectList(db.Noticias, "IDNOTICIA", "TITULO_NOTICIA", foto.IDNOTICIA);
            ViewBag.IDEQUIPE = new SelectList(db.Equipes, "IDEQUIPE", "NOME", foto.IDEQUIPE);
            return View(foto);
        }

        //
        // GET: /Foto/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Foto foto = db.Fotos.Find(id);
            if (foto == null)
            {
                return HttpNotFound();
            }
            return View(foto);
        }

        //
        // POST: /Foto/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Foto foto = db.Fotos.Find(id);
            db.Fotos.Remove(foto);
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