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
    public class SpeackersController : Controller
    {
        private PiPiPrestacionesDBContext db = new PiPiPrestacionesDBContext();
        private static List<Speacker> speackerList = new List<Speacker>();







        [HttpPost]
        public JsonResult PostSpeacker(Speacker speacker)
        {
            try
            {
                speackerList.Add(speacker);
                return Json(HttpStatusCode.Accepted);
            }
            catch (Exception)
            {
                return Json(HttpStatusCode.BadGateway);
            }
        }


        [HttpGet]
        public JsonResult GetAllSpeacker()
        {
            return (speackerList != null) ? Json(speackerList, JsonRequestBehavior.AllowGet) : Json(JsonRequestBehavior.DenyGet);
        }





        // GET: Speackers
        public ActionResult Index()
        {
            return View(db.Speackers.ToList());
        }

        // GET: Speackers/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Speacker speacker = db.Speackers.Find(id);
            if (speacker == null)
            {
                return HttpNotFound();
            }
            return View(speacker);
        }

        // GET: Speackers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Speackers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TitleModal,FullName,ImageUrl,NationalityUrl,WebUrl")] Speacker speacker)
        {
            if (ModelState.IsValid)
            {
                db.Speackers.Add(speacker);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(speacker);
        }

        // GET: Speackers/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Speacker speacker = db.Speackers.Find(id);
            if (speacker == null)
            {
                return HttpNotFound();
            }
            return View(speacker);
        }

        // POST: Speackers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TitleModal,FullName,ImageUrl,NationalityUrl,WebUrl")] Speacker speacker)
        {
            if (ModelState.IsValid)
            {
                db.Entry(speacker).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(speacker);
        }

        // GET: Speackers/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Speacker speacker = db.Speackers.Find(id);
            if (speacker == null)
            {
                return HttpNotFound();
            }
            return View(speacker);
        }

        // POST: Speackers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Speacker speacker = db.Speackers.Find(id);
            db.Speackers.Remove(speacker);
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
