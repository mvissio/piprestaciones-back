using PiPiPrestaciones.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft;

namespace PiPiPrestaciones.Controllers.Api
{
    public class AplicacionesController : ApiController
    {
        private PiPiPrestacionesDBContext db = new PiPiPrestacionesDBContext();

        [HttpGet]
        public Aplicacion GetAplicacion(int aplicacionId) {

            var app_db = db.Aplicacion.Find(aplicacionId);
            var app = new Aplicacion();
            app.AplicacionId = app_db.AplicacionId;
            app.CssAplicacion = new CssModel(app_db.CssAplicacion);
            app.HashTagTwiter = app_db.HashTagTwiter;
            app.Idioma = app_db.Idioma;
            app.LastModification = app_db.LastModification;
            app.LenguajePorDefecto = app_db.LenguajePorDefecto;
            app.Menus = new List<Menu>();

            foreach (var item in app_db.Menus) {
                var menu = new Menu(item);
                app.Menus.Add(menu);
            }
            app.Titulo = app_db.Titulo;
            app.UrlImagen1 = app_db.UrlImagen1;
            app.UrlImagen2 = app_db.UrlImagen2;
            app.UrlImagenN = app_db.UrlImagenN;
            app.VersionId = app_db.VersionId;

            return (app);
        }





    }


}
