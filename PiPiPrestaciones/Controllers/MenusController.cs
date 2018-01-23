﻿using System;
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
    public class MenusController : Controller
    {
        private PiPiPrestacionesDBContext db = new PiPiPrestacionesDBContext();

        // GET: Menus
        public ActionResult Index()
        {
            return View(db.Menus.ToList());
        }

        // GET: Menus/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Menu menu = db.Menus.Find(id);
            if (menu == null)
            {
                return HttpNotFound();
            }
            return View(menu);
        }

        // GET: Menus/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetMenu() {
            Menu menu = new Menu();
            Menu menu2 = new Menu();

            menu.MenuId = 1.ToString();
            menu.CssModelMenu = new CssModelMenu();
            menu.CssModelMenu.BorderSize = 2;
            menu.CssModelMenu.ColorBack = "#990000";
            menu.CssModelMenu.ColorText = "#FFFFFF";
            menu.CssModelMenu.FontFamily = "Arial";
            menu.Icon = "md-done-all";
            menu.Order = 1;
            menu.Status = true;
            menu.TitleMenu = "Boton";
            menu.Type = "estatica"; //Ex --> Agenda abre patalla agenda ...

            menu2.MenuId = 1.ToString();
            menu2.CssModelMenu = new CssModelMenu();
            menu2.CssModelMenu.BorderSize = 2;
            menu2.CssModelMenu.ColorBack = "#990000";
            menu2.CssModelMenu.ColorText = "#FFFFFF";
            menu2.CssModelMenu.FontFamily = "Arial";
            menu2.Icon = "md-done-all";
            menu2.Order = 2;
            menu2.Status = true;
            menu2.TitleMenu = "Boton";
            menu2.Type = "programa"; //Ex --> Agenda abre patalla agenda ...

            List<Menu> listMenu = new List<Menu>();
            listMenu.Add(menu);
            listMenu.Add(menu2);

            return Json(listMenu, JsonRequestBehavior.AllowGet);
        }



        // POST: Menus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MenuId,TitleMenu,Status,Type,Order,Icon,CssModelMenu")] Menu menu)
        {
            if (ModelState.IsValid)
            {
                db.Menus.Add(menu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(menu);
        }

        // GET: Menus/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Menu menu = db.Menus.Find(id);
            if (menu == null)
            {
                return HttpNotFound();
            }
            return View(menu);
        }

        // POST: Menus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MenuId,TitleMenu,Status,Type,Order,Icon,CssModelMenu")] Menu menu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(menu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(menu);
        }

        // GET: Menus/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Menu menu = db.Menus.Find(id);
            if (menu == null)
            {
                return HttpNotFound();
            }
            return View(menu);
        }

        // POST: Menus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Menu menu = db.Menus.Find(id);
            db.Menus.Remove(menu);
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
