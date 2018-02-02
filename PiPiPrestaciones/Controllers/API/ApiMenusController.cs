using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PiPiPrestaciones.Models;

namespace PiPiPrestaciones.Controllers
{
    public class ApiMenusController : ApiController
    {
        // GET: api/ApiMenus
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}
        private PiPiPrestacionesDBContext db = new PiPiPrestacionesDBContext();

        //[HttpGet]
        //public List<Menu> GetAplicationMenu(int id) {
        //    var menus = db.Menu.Where(m => m.AplicacionId == id).ToList();

        //    return menus;


        //}

        public List<Menu> Get() {
            Menu menu = new Menu();
            Menu menu2 = new Menu();

            menu.MenuId = 1;
            menu.CssModelMenu = new CssModel();
            menu.CssModelMenu.BorderSize = 2;
            menu.CssModelMenu.ColorBack = "#990000";
            menu.CssModelMenu.ColorText = "#FFFFFF";
            menu.CssModelMenu.FontFamily = "Arial";
            menu.Icon = "md-done-all";
            menu.Order = 1;
            menu.Status = true;
            menu.TitleMenu = "Boton";
            menu.Type = "agenda"; //Ex --> Agenda abre patalla agenda ...

            menu2.MenuId = 2;
            menu2.CssModelMenu = new CssModel();
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

            return listMenu;

        }


        // GET: api/ApiMenus/5
        public List<Menu> Get(int id)
        {
            var listMenus = db.Menu.Where(m => m.AplicacionId == id).ToList();
            var menus = new List<Menu>();
            foreach (var item in listMenus) {
                var menu = new Menu();
                var cssItemMenu = new CssModel();
                cssItemMenu.CssModelId = item.CssModelItemMenu.CssModelId;
                cssItemMenu.BorderSize = item.CssModelItemMenu.BorderSize;
                cssItemMenu.ColorBack = item.CssModelItemMenu.ColorBack;
                cssItemMenu.ColorIcon = item.CssModelItemMenu.ColorIcon;
                cssItemMenu.ColorText = item.CssModelItemMenu.ColorText;
                cssItemMenu.FontFamily = item.CssModelItemMenu.FontFamily;
               

                menu.CssModelItemMenu = cssItemMenu;
                menu.AplicacionId = item.AplicacionId;
                menu.Status = item.Status;
                menu.Icon = item.Icon;
                menu.Order = item.Order;               
                menu.TitleMenu = item.TitleMenu;
                menu.Type = item.Type;
                menu.MenuId = item.MenuId;
                menus.Add(menu);
            }

            return menus;
        }

        // POST: api/ApiMenus
        //public void Post([FromBody]string value)
        //{

        //}

        public void Post(Menu menu)
        {


        }
        // PUT: api/ApiMenus/5
        public void Put(int id, [FromBody]string value)
        {

        }

        // DELETE: api/ApiMenus/5
        public void Delete(int id)
        {

        }
    }
}
