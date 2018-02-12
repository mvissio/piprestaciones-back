using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Data.Entity;
using System.Text;
using System.Web.Http;
using PiPiPrestaciones.Models;
using PiPiPrestaciones.Helpers;

namespace PiPiPrestaciones.Controllers.Api
{
    public class MenusController : ApiController
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
        [HttpGet()]
        public List<MenuMob> Get(int aplicacionId)
        {
            try
            {
                List<MenuMob> menuMobList = new List<MenuMob>();
                List<Menu> menuList = db.Aplicacion.Find(aplicacionId).Menus.OrderBy(s => s.Order).ToList();
                foreach (var menu in menuList)
                {
                    menuMobList.Add(HelperMenu.getInstance().convertMapToMapMob(menu));
                }
                return menuMobList;
            }
            catch (Exception)
            {

                throw;
            }
        }

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
