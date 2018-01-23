using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PiPiPrestaciones.Models;

namespace PiPiPrestaciones.Controllers
{
    public class PantallaEstaticasController : Controller
    {
        private PiPiPrestacionesDBContext db = new PiPiPrestacionesDBContext();

        // GET: PantallaEstaticas
        public ActionResult Index()
        {
            return View(db.PantallaEstaticas.ToList());
        }

        // GET: PantallaEstaticas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PantallaEstatica pantallaEstatica = db.PantallaEstaticas.Find(id);
            if (pantallaEstatica == null)
            {
                return HttpNotFound();
            }
            return View(pantallaEstatica);
        }

        // GET: PantallaEstaticas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PantallaEstaticas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PantallaEstatica pantallaEstatica)
        {
            //if (ModelState.IsValid)
            //{
            //    //db.PantallaEstaticas.Add(pantallaEstatica);
            //    //db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            return View(pantallaEstatica);
        }

        // GET: PantallaEstaticas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PantallaEstatica pantallaEstatica = db.PantallaEstaticas.Find(id);
            if (pantallaEstatica == null)
            {
                return HttpNotFound();
            }
            return View(pantallaEstatica);
        }

        // POST: PantallaEstaticas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PantallaEstaticaId")] PantallaEstatica pantallaEstatica)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pantallaEstatica).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pantallaEstatica);
        }

        // GET: PantallaEstaticas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PantallaEstatica pantallaEstatica = db.PantallaEstaticas.Find(id);
            if (pantallaEstatica == null)
            {
                return HttpNotFound();
            }
            return View(pantallaEstatica);
        }

        // POST: PantallaEstaticas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PantallaEstatica pantallaEstatica = db.PantallaEstaticas.Find(id);
            db.PantallaEstaticas.Remove(pantallaEstatica);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        [HttpGet]
        public JsonResult GetStaticPages(int idPage)
        {
            List<StaticPage> staticPageList = new List<StaticPage>();
            StaticPage staticPage1 = new StaticPage();
            staticPage1.PageId = 1;
            staticPage1.PageTitle = "Pagina 1";
            staticPage1.StaticContentList = new List<StaticContent>();
            staticPage1.CssStaticPage = new CssStaticPage();
            staticPageList.Add(staticPage1);


            return Json(staticPageList, JsonRequestBehavior.AllowGet);
        }
    }
}
