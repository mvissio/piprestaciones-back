using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PiPiPrestaciones.Models
{
    [Table("Map")]
    public class Map
    {
        [Key]
        public int MapId { get; set; }

        public int? Order { get; set; }
        public string Title { get; set; }
        public string Lat { get; set; }
        public string Lng { get; set; }
        public int? Zoom { get; set; }

        public int? CssModelMapId { get; set; }
        [ForeignKey("CssModelMapId")]
        public virtual CssModel CssModelMap { get; set; }

        public int? AplicacionId { get; set; }
        [ForeignKey("AplicacionId")]
        public virtual Aplicacion Aplicacion { get; set; }


        public Map() { }

        public Map(Map map) {
           

            this.AplicacionId = map.AplicacionId;
            this.CssModelMap = new CssModel(map.CssModelMap);
            this.Lat = map.Lat;
            this.Lng = map.Lng;
            this.Order = map.Order;
            this.Title = map.Title;
            this.Zoom = map.Zoom;


        }

    }
}