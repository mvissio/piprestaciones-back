using PiPiPrestaciones.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PiPiPrestaciones.Helpers
{
    public class HelperMapa
    {
        private static HelperMapa instance;
        
        public static HelperMapa getInstance()
        {
            return instance ?? (instance = new HelperMapa());
        }

        public MapaMob convertMapToMapMob(Map mapa)
        {
            MapaMob mapaMob = new MapaMob();
            mapaMob.MapId = mapa.MapId;
            mapaMob.Lat = mapa.Lat;
            mapaMob.Lng= mapa.Lng;
            mapaMob.Order= mapa.Order;
            mapaMob.Zoom= mapa.Zoom;
            mapaMob.CssModelMap= mapa.CssModelMap;
            return mapaMob;
        }
    }
}