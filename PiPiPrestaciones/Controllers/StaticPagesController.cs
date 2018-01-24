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
    public class StaticPagesController : Controller
    {
        private PiPiPrestacionesDBContext db = new PiPiPrestacionesDBContext();

        // GET: StaticPages
        public ActionResult Index()
        {
            return View(db.StaticPages.ToList());
        }

        // GET: StaticPages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StaticPage staticPage = db.StaticPages.Find(id);
            if (staticPage == null)
            {
                return HttpNotFound();
            }
            return View(staticPage);
        }

        // GET: StaticPages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StaticPages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PageId,PageTitle")] StaticPage staticPage)
        {
            if (ModelState.IsValid)
            {
                db.StaticPages.Add(staticPage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(staticPage);
        }

        // GET: StaticPages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StaticPage staticPage = db.StaticPages.Find(id);
            if (staticPage == null)
            {
                return HttpNotFound();
            }
            return View(staticPage);
        }

        // POST: StaticPages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PageId,PageTitle")] StaticPage staticPage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(staticPage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(staticPage);
        }

        // GET: StaticPages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StaticPage staticPage = db.StaticPages.Find(id);
            if (staticPage == null)
            {
                return HttpNotFound();
            }
            return View(staticPage);
        }

        // POST: StaticPages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StaticPage staticPage = db.StaticPages.Find(id);
            db.StaticPages.Remove(staticPage);
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
    }
}
