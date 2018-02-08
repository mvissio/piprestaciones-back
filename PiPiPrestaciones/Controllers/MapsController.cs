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
    public class MapsController : Controller
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
        public ActionResult Delete(int id)
        {
            Map map = db.Map.Find(id);
            CssModel css = db.CssModel.Find(map.CssModelMapId);
            int aplicacionId = (int)map.AplicacionId;
            db.Database.Connection.Open();
            db.Map.Remove(map);
            db.CssModel.Remove(css);
            db.SaveChanges();
            db.Database.Connection.Close();
            db.Database.Connection.Open();

            var listMaps = db.Map.Where(m => m.AplicacionId == aplicacionId).OrderBy(m => m.Order).ToList();
            db.Database.Connection.Close();
            if (listMaps != null)
            {
                return PartialView("_ListMapas", listMaps);

            }
            else {

                return JavaScript("alert('OCURRIO UN ERROR AL INTENTAR ELIMINAR VUELVA A INTENTAR')");
            }
        


        }

        // POST: Map/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Map map = db.Map.Find(id);
        //    db.Map.Remove(map);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult AddMap(MapDTO map) {

            if (ModelState.IsValid)
            {
                var latestOrder = db.Map.Where(m => m.AplicacionId == map.AplicacionId).OrderByDescending(m => m.Order).FirstOrDefault();
                int order = 1;

                if (latestOrder != null)
                {
                    order = (int)latestOrder.Order + 1;

                }
                var newMap = new Map();
                newMap.AplicacionId = map.AplicacionId;
                newMap.CssModelMap = new CssModel();
                newMap.CssModelMap.BorderColor = map.BorderColor;
                newMap.Lat = map.Lat;
                newMap.Lng = map.Lng;
                newMap.Order = order;
                newMap.Title = map.Title;
                db.Database.Connection.Open();
                db.CssModel.Add(newMap.CssModelMap);
                db.Map.Add(newMap);
                try
                {

                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    return JavaScript("Alert(" + ex.InnerException.ToString() + ")");

                  
                }

                db.Database.Connection.Close();

                db.Database.Connection.Open();

                var listMaps = (from m in db.Map where m.AplicacionId == map.AplicacionId select m).OrderBy(m=>m.Order).ToList();
                db.Database.Connection.Close();

                return PartialView("_ListMapas", listMaps);

            }


            return null;
        }

        public ActionResult GetMaps(int aplicacionId) {
            var listMaps = (from m in db.Map where m.AplicacionId == aplicacionId select m).OrderBy(m=>m.Order).ToList();
            if (listMaps != null)
            {

                if (listMaps.Count > 0)
                {
                    return PartialView("_ListMapas", listMaps);

                }
            }
            return null;

        }

        public ActionResult SubirBajarOrder(int mapId, string accion) {
            db.Database.Connection.Open();
            Map map = db.Map.Find(mapId);
            Map mapAntPost;

            switch (accion)
            {
                case "subir":
                    mapAntPost = db.Map.Where(m => m.AplicacionId == map.AplicacionId && m.Order == (map.Order - 1)).FirstOrDefault();
                    mapAntPost.Order += 1;
                    map.Order -= 1;


                        break;


                case "bajar":
                    mapAntPost = db.Map.Where(m => m.AplicacionId == map.AplicacionId && m.Order == (map.Order + 1)).FirstOrDefault();
                    mapAntPost.Order -= 1;
                    map.Order += 1;
                    break;

                default:
                    break;
            }
            db.SaveChanges();
            db.Database.Connection.Close();


            db.Database.Connection.Open();

            var listMaps = (from m in db.Map where m.AplicacionId == map.AplicacionId select m).OrderBy(m=> m.Order).ToList();
            db.Database.Connection.Close();

            return PartialView("_ListMapas", listMaps);

        }

        

        public class MapDTO {

            public int AplicacionId { get; set; }
            public string Title { get; set; }
            public string Lat { get; set; }
            public string Lng { get; set; }
            public string BorderColor { get; set; }

        }

    }
}
