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
        public string MapId { get; set; }

        public int? Order { get; set; }
        public string Title { get; set; }
        public decimal? Lat { get; set; }
        public decimal? Lng { get; set; }
        public int? Zoom { get; set; }
        public bool? IsMap { get; set; }
        public List<string> ImageList { get; set; }
        public string BorderColor { get; set; }
        public int? BorderSize { get; set; }
    }
}