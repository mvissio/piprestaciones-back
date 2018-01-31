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
    public class MapController : Controller
    {
        private PiPiPrestacionesDBContext db = new PiPiPrestacionesDBContext();

        private static List<Map> mapList = new List<Map>();

        [HttpGet]
        public JsonResult GetMap()
        {
            return Json(mapList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult PostMap(Map map)
        {
            try
            {
                mapList.Add(map);
                return Json(HttpStatusCode.Accepted);
            }
            catch (Exception)
            {
                return Json(HttpStatusCode.BadGateway);
            }
        }

        public JsonResult PostMapList(List<Map> mapLst)
        {
            try
            {
                mapLst.ForEach(
                    map => {
                        mapList.Add(map);
                        }
                );
                return Json(HttpStatusCode.Accepted);
            }
            catch (Exception)
            {
                return Json(HttpStatusCode.BadGateway);
            }
        }


        // GET: Map
        public ActionResult Index()
        {
            return View(db.Map.ToList());
        }

        // GET: Map/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Map map = db.Map.Find(id);
            if (map == null)
            {
                return HttpNotFound();
            }
            return View(map);
        }

        // GET: Map/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Map/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MapId,Lat,Lng,Zoom,IsMap,BorderColor, BorederSize")] Map map)
        {
            if (ModelState.IsValid)
            {
                db.Map.Add(map);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(map);
        }

        // GET: Map/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Map map = db.Map.Find(id);
            if (map == null)
            {
                return HttpNotFound();
            }
            return View(map);
        }

        // POST: Map/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MapId,Lat,Lng,Zoom,IsMap")] Map map)
        {
            if (ModelState.IsValid)
            {
                db.Entry(map).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(map);
        }

        // GET: Map/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Map map = db.Map.Find(id);
            if (map == null)
            {
                return HttpNotFound();
            }
            return View(map);
        }

        // POST: Map/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Map map = db.Map.Find(id);
            db.Map.Remove(map);
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
