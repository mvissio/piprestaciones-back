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
    public class DisertantesController : Controller
    {
        private PiPiPrestacionesDBContext db = new PiPiPrestacionesDBContext();

        // GET: Disertantes
        public ActionResult Index()
        {
            var disertante = db.Disertante.Include(d => d.Aplicacion).Include(d => d.CssDisertante);
            return View(disertante.ToList());
        }

        // GET: Disertantes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Disertante disertante = db.Disertante.Find(id);
            if (disertante == null)
            {
                return HttpNotFound();
            }
            return View(disertante);
        }

        // GET: Disertantes/Create
        public ActionResult Create()
        {
            ViewBag.AplicacionId = new SelectList(db.Aplicacion, "AplicacionId", "Titulo");
            ViewBag.CssModelDisertanteId = new SelectList(db.CssModel, "CssModelId", "FontFamily");
            return View();
        }

        // POST: Disertantes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create( Disertante disertante)
        {
            if (ModelState.IsValid)
            {
                //db.Disertante.Add(disertante);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AplicacionId = new SelectList(db.Aplicacion, "AplicacionId", "Titulo", disertante.AplicacionId);
            ViewBag.CssModelDisertanteId = new SelectList(db.CssModel, "CssModelId", "FontFamily", disertante.CssModelDisertanteId);
            return View(disertante);
        }

        // GET: Disertantes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Disertante disertante = db.Disertante.Find(id);
            if (disertante == null)
            {
                return HttpNotFound();
            }
            ViewBag.AplicacionId = new SelectList(db.Aplicacion, "AplicacionId", "Titulo", disertante.AplicacionId);
            ViewBag.CssModelDisertanteId = new SelectList(db.CssModel, "CssModelId", "FontFamily", disertante.CssModelDisertanteId);
            return View(disertante);
        }

        // POST: Disertantes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DisertanteId,Title,FullName,ImageUrl,NationalityUrl,WebUrl,CssModelDisertanteId,AplicacionId")] Disertante disertante)
        {
            if (ModelState.IsValid)
            {
                db.Entry(disertante).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AplicacionId = new SelectList(db.Aplicacion, "AplicacionId", "Titulo", disertante.AplicacionId);
            ViewBag.CssModelDisertanteId = new SelectList(db.CssModel, "CssModelId", "FontFamily", disertante.CssModelDisertanteId);
            return View(disertante);
        }

        // GET: Disertantes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Disertante disertante = db.Disertante.Find(id);
            if (disertante == null)
            {
                return HttpNotFound();
            }
            return View(disertante);
        }

        // POST: Disertantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Disertante disertante = db.Disertante.Find(id);
            db.Disertante.Remove(disertante);
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

        public ActionResult GetFlags() {

            return PartialView("_Flags", new Helpers.HelperFlag());
        }

        public ActionResult GetDisertantes(int aplicacionId) {
            var disertantes = db.Disertante.Where(d => d.Status && d.AplicacionId == aplicacionId).ToList();
            return View("_ListDisertantes",disertantes);
        }
        [ValidateInput(false)]
        public ActionResult AddDescripcion(string markDown,string htmlMd, string previewMd, string textAlign,string order)
        {
            var descripcion = new DescripcionDisertante();
            descripcion.OrderDescription = Convert.ToInt32(order);
            descripcion.TextAlingDescription = textAlign;
            descripcion.MarkDownDisertante = new MarkDownModel();
            descripcion.MarkDownDisertante.HtmlValue = htmlMd;
            descripcion.MarkDownDisertante.MarkDownValue = markDown;
            descripcion.MarkDownDisertante.PreviewValue = previewMd;


            return View("_AddDescripcion", descripcion);
        }
        [ValidateInput(false)]
        public ActionResult AddDisertante(Disertante disertante)
        {
            if (ModelState.IsValid)
            {
                var ds = new Disertante();
                ds.AplicacionId = disertante.Aplicacion.AplicacionId;
                ds.CssDisertante = new CssModel();
                ds.CssDisertante.ColorBack = ds.CssDisertante.ColorBack;
                db.CssModel.Add(ds.CssDisertante);
                ds.FullName = disertante.FullName;
                ds.ImageUrl = disertante.ImageUrl;
                ds.NationalityUrl = disertante.NationalityUrl;
                ds.Status = true;
                ds.Title = disertante.Title;
                ds.WebUrl = disertante.WebUrl;

                db.Disertante.Add(ds);


                if (disertante.Descripciones != null) {
                    if (disertante.Descripciones.Count > 0) {
                     
                        foreach (var item in disertante.Descripciones)
                        {
                            var desc = new DescripcionDisertante(item);
                            db.MarkDownModel.Add(desc.MarkDownDisertante);
                            db.DescripcionDisertante.Add(desc);

                        }

                    }
                }
                db.SaveChanges();
               

                return Json("true");
            }

            return Json("false");
        }
    }
}
