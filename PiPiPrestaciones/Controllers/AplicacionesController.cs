using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

using PiPiPrestaciones.Models;
using System.Xml.Linq;

namespace PiPiPrestaciones.Controllers
{
    public class AplicacionesController : Controller
    {
        private PiPiPrestacionesDBContext db = new PiPiPrestacionesDBContext();

        // GET: Aplicaciones
        public ActionResult Index()
        {
            return View(db.Aplicacion.ToList());
        }

        // GET: Aplicaciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aplicacion aplicacion = db.Aplicacion.Find(id);
            if (aplicacion == null)
            {
                return HttpNotFound();
            }
            return View(aplicacion);
        }

        // GET: Aplicaciones/Create
        public ActionResult Create()
        {
            AplicacionCreateView aplicacion = new AplicacionCreateView();
            var types = db.Type.Where(t => t.Status).ToList();
            if (types == null)
            {
                var type = new Models.Type();
                type.InflateType();
                types = db.Type.Where(t => t.Status).ToList();

            }
            else if (types.Count == 0)
            {
                var type = new Models.Type();
                type.InflateType();
                types = db.Type.Where(t => t.Status).ToList();
            }


            ViewBag.Types = types;

            aplicacion.Menus = new List<Menu>();
            return View(aplicacion);
        }

        // POST: Aplicaciones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AplicacionCreateView aplicacion)
        {
            var app = new Aplicacion(aplicacion);

            if (ModelState.IsValid)
            {

                db.Aplicacion.Add(app);

                var order = 0;

                if (aplicacion.Menus != null)
                {
                    foreach (var item in aplicacion.Menus)
                    {
                        if (item.Type != "")
                        {
                            var menu = new Menu();
                            var cssItemMenu = new CssModel();
                            cssItemMenu.BorderSize = item.CssModelItemMenu.BorderSize;
                            cssItemMenu.ColorBack = item.CssModelItemMenu.ColorBack;
                            cssItemMenu.ColorIcon = item.CssModelItemMenu.ColorIcon;
                            cssItemMenu.ColorText = item.CssModelItemMenu.ColorText;
                            cssItemMenu.FontFamily = item.CssModelItemMenu.FontFamily;
                            db.CssModel.Add(cssItemMenu);

                            menu.CssModelItemMenu = cssItemMenu;
                            menu.Aplicacion = app;
                            menu.Icon = item.Icon;
                            menu.Order = order;
                            menu.Status = true;
                            menu.TitleMenu = item.TitleMenu;
                            menu.Type = item.Type;

                            db.Menu.Add(menu);
                            order++;
                        }



                    }
                }




                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aplicacion);
        }

        // GET: Aplicaciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aplicacion aplicacion = db.Aplicacion.Find(id);
            if (aplicacion == null)
            {
                return HttpNotFound();
            }
            if (aplicacion.Menus != null)
            {
                aplicacion.Menus = aplicacion.Menus.OrderBy(m => m.Order).ToList();
            }
            return View(aplicacion);
        }

        // POST: Aplicaciones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AplicacionId,VersionId,LastModification,CreateAt,CreateBy")] Aplicacion aplicacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aplicacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aplicacion);
        }

        // GET: Aplicaciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aplicacion aplicacion = db.Aplicacion.Find(id);
            if (aplicacion == null)
            {
                return HttpNotFound();
            }
            return View(aplicacion);
        }

        // POST: Aplicaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Aplicacion aplicacion = db.Aplicacion.Find(id);
            //db.Aplicacion.Remove(aplicacion);
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

        public ActionResult AddMenu(string type, int order)
        {
            var menu = new Menu();
            menu.Order = order;
            menu.Type = type;

            return PartialView("_AddMenu", menu);
        }

        public ActionResult GetEditMenu(string type)
        {


            return PartialView("_Edit" + type);

        }

        public string UpdateMenuOrder(string menuId, string order)
        {
            try
            {
                var id = Convert.ToInt32(menuId);
                var menu_ = db.Menu.Find(id);
                menu_.Order = Convert.ToInt32(order); ;
                db.SaveChanges();
                UpdateVersion(Convert.ToInt32(menu_.AplicacionId));
                return "true";
            }
            catch (Exception ex)
            {

                return ex.ToString();
            }
        }

        public void UpdateVersion(int aplicacionId) {

           // var appId = Convert.ToInt32(aplicacionId);

            var app =db.Aplicacion.Find(aplicacionId);

            app.LastModification = DateTime.Now;

            app.VersionId = Guid.NewGuid().ToString();

            db.SaveChanges();

        }


    }


}

