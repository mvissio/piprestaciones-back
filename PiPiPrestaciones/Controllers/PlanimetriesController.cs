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
    public class PlanimetriesController : Controller
    {
        private PiPiPrestacionesDBContext db = new PiPiPrestacionesDBContext();

        // GET: Planimetries
        public ActionResult Index()
        {
            var planimetry = db.Planimetry.Include(p => p.Aplicacion).Include(p => p.CssModelPlanimetry);
            return View(planimetry.ToList());
        }

        // GET: Planimetries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Planimetry planimetry = db.Planimetry.Find(id);
            if (planimetry == null)
            {
                return HttpNotFound();
            }
            return View(planimetry);
        }

        // GET: Planimetries/Create
        public ActionResult Create()
        {
            ViewBag.AplicacionId = new SelectList(db.Aplicacion, "AplicacionId", "Titulo");
            ViewBag.CssModelPlanimetryId = new SelectList(db.CssModel, "CssModelId", "FontFamily");
            return View();
        }

        // POST: Planimetries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PlanimetryId,TitlePlanimetry,FooterPlanimetry,UrlImagePlanimetry,CssModelPlanimetryId,AplicacionId")] Planimetry planimetry)
        {
            if (ModelState.IsValid)
            {
                db.Planimetry.Add(planimetry);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AplicacionId = new SelectList(db.Aplicacion, "AplicacionId", "Titulo", planimetry.AplicacionId);
            ViewBag.CssModelPlanimetryId = new SelectList(db.CssModel, "CssModelId", "FontFamily", planimetry.CssModelPlanimetryId);
            return View(planimetry);
        }

        // GET: Planimetries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Planimetry planimetry = db.Planimetry.Find(id);
            if (planimetry == null)
            {
                return HttpNotFound();
            }
            ViewBag.AplicacionId = new SelectList(db.Aplicacion, "AplicacionId", "Titulo", planimetry.AplicacionId);
            ViewBag.CssModelPlanimetryId = new SelectList(db.CssModel, "CssModelId", "FontFamily", planimetry.CssModelPlanimetryId);
            return View(planimetry);
        }

        // POST: Planimetries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PlanimetryId,TitlePlanimetry,FooterPlanimetry,UrlImagePlanimetry,CssModelPlanimetryId,AplicacionId")] Planimetry planimetry)
        {
            if (ModelState.IsValid)
            {
                db.Entry(planimetry).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AplicacionId = new SelectList(db.Aplicacion, "AplicacionId", "Titulo", planimetry.AplicacionId);
            ViewBag.CssModelPlanimetryId = new SelectList(db.CssModel, "CssModelId", "FontFamily", planimetry.CssModelPlanimetryId);
            return View(planimetry);
        }

        // GET: Planimetries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Planimetry planimetry = db.Planimetry.Find(id);
            if (planimetry == null)
            {
                return HttpNotFound();
            }
            return View(planimetry);
        }

        // POST: Planimetries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Planimetry planimetry = db.Planimetry.Find(id);
            db.Planimetry.Remove(planimetry);
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

        public ActionResult AddPlanimetry(CreateViewPlanimetry planimetry) {

            if (ModelState.IsValid)
            {
                var plan = new Planimetry(planimetry);

                var order = db.Planimetry.Where(a => a.Status).ToList().Count;
               plan.OrderPlanimetry = order;
                
                

                db.Planimetry.Add(plan);

                db.SaveChanges();

                var app = new AplicacionesController();
                app.UpdateVersion(Convert.ToInt32(plan.AplicacionId));


                return PartialView("_ListPlanimetria", db.Planimetry.Where(a=>a.AplicacionId == planimetry.AplicacionId).ToList());

            }



            return Json("'Error': 'No se pudo guardar la planimetria'");

        }

        public ActionResult GetPlanimetries(int appId) {

            return PartialView("_ListPlanimetria", db.Planimetry.Where(a => a.AplicacionId == appId).ToList());
        }


        public ActionResult ChangePlanimetry(int planimetryId, int appId)
        {
            Planimetry planimetry = db.Planimetry.Where(a=>a.PlanimetryId==planimetryId).FirstOrDefault();
            planimetry.Status = !planimetry.Status;
            db.SaveChanges();
            var app = new AplicacionesController();
            app.UpdateVersion(Convert.ToInt32(planimetry.AplicacionId));

            return PartialView("_ListPlanimetria", db.Planimetry.Where(a => a.AplicacionId == appId).ToList());
        }
        public ActionResult RemovePlanimetry(int planimetryId, int appId)
        {
            List<DetailsPlanimetry> detailsPlanimetry = db.DetailsPlanimetry.Where(d => d.PlanimetryId == planimetryId).ToList();
            Planimetry planimetry = db.Planimetry.Where(p => p.PlanimetryId == planimetryId).FirstOrDefault();
            db.DetailsPlanimetry.RemoveRange(detailsPlanimetry);
            db.Planimetry.Remove(planimetry);
            db.SaveChanges();
            var app = new AplicacionesController();
            app.UpdateVersion(Convert.ToInt32(appId));
            return PartialView("_ListPlanimetria", db.Planimetry.Where(a => a.AplicacionId == appId).ToList());
        }
    }
}
