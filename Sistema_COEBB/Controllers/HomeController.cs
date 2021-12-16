using Sistema_COEBB.Filters;
using Sistema_COEBB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace Sistema_COEBB.Controllers
{
    [InitializeSimpleMembership]
    public class HomeController : Controller
    {
        private DbContexto db = new DbContexto();
        public ActionResult Index()
        {
            if (db.Usuarios.Count() == 0)
            {
                WebSecurity.CreateUserAndAccount("Admin", "123456");
            }
            return View();
        }


        public ActionResult Detalhe(long id)
        {

            var noticia = db.Noticias.ToList();
            foreach (var item in noticia)
            {

                item.Fotos = new List<Foto>();
                var foto = db.Fotos.Where(f => f.IDNOTICIA == item.IDNOTICIA).SingleOrDefault();
                if (foto != null)
                {
                    item.Fotos.Add(foto);
                }

            }
            return View(noticia.Where(n => n.IDNOTICIA == id).First());
        }

        public ActionResult DetalheGaleria(long id)
        {

            var noticia = db.Noticias.ToList();
            foreach (var item in noticia)
            {

                item.Fotos = new List<Foto>();
                var foto = db.Fotos.Where(f => f.IDNOTICIA == item.IDNOTICIA).SingleOrDefault();
                if (foto != null)
                {
                    item.Fotos.Add(foto);
                }

            }
            return View(noticia.Where(n => n.IDNOTICIA == id).First());
        }

        /*public ActionResult DetalheGaleria(old)()
        {

            var noticia = db.Noticias.ToList();
            foreach (var item in noticia)
            {

                item.Fotos = new List<Foto>();
                var foto = db.Fotos.Where(f => f.IDNOTICIA == item.IDNOTICIA).SingleOrDefault();
                if (foto != null)
                {
                    item.Fotos.Add(foto);
                }

            }
            return View(noticia);
        }*/

        public ActionResult Contato()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }
        public ActionResult Equipe()
        {
            var equipe = db.Equipes.OrderBy(e => e.NOME).ToList();
            foreach (var item in equipe)
            {
                item.Fotos = new List<Foto>();
                var foto = db.Fotos.Where(e => e.IDEQUIPE == item.IDEQUIPE).SingleOrDefault();
                if (foto != null)
                {
                    item.Fotos.Add(foto);
                }
            }
            return View(equipe);
        }
        public ActionResult Galeria()
        {
            var noticia = db.Noticias.OrderByDescending(n => n.DATANOTICIA).Take(10).ToList();
            foreach (var item in noticia)
            {
                item.Fotos = new List<Foto>();
                var foto = db.Fotos.Where(f => f.IDNOTICIA == item.IDNOTICIA).SingleOrDefault();
                if (foto != null)
                {
                    item.Fotos.Add(foto);
                }
            }
            return View(noticia);
        }

        public ActionResult Noticia()
        {
            var noticia = db.Noticias.OrderByDescending(n => n.DATANOTICIA).Take(10).ToList();
            foreach (var item in noticia)
            {
                
                item.Fotos = new List<Foto>();
                var foto = db.Fotos.Where(f => f.IDNOTICIA == item.IDNOTICIA).SingleOrDefault();
                if (foto != null)
                {
                    item.Fotos.Add(foto);
                }
            }
            return View(noticia);
        }
    }
}
