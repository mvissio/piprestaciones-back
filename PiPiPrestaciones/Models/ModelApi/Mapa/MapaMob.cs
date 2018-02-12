using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PiPiPrestaciones.Models
{
    public class MapaMob
    {
        public int MapId { get; set; }
        public int? Order { get; set; }
        public string Title { get; set; }
        public string Lat { get; set; }
        public string Lng { get; set; }
        public int? Zoom { get; set; }
        public CssModel CssModelMap { get; set; }
    }
}