using PiPiPrestaciones.Helpers;
using PiPiPrestaciones.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PiPiPrestaciones.Controllers.API
{
    public class MapasController : ApiController
    {
        private PiPiPrestacionesDBContext db = new PiPiPrestacionesDBContext();

        [HttpGet]
        public List<MapaMob> Get(int aplicacionId)
        {
            try
            {
                List<MapaMob> mapaMobList = new List<MapaMob>();
                List<Map> mapList = db.Map.Where(m => m.AplicacionId == aplicacionId).ToList();
                foreach (var map in mapList)
                {
                    mapaMobList.Add(HelperMapa.getInstance().convertMapToMapMob(map));
                }
                return mapaMobList;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
