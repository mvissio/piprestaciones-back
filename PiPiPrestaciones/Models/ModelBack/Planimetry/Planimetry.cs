using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PiPiPrestaciones.Models
{
    [Table("Planimetry")]
    public class Planimetry
    {
        [Key]
        public int IdPlanimery { get; set; }
        public string TitlePlanimetry { get; set; }
        public string FooterPlanimetry { get; set; }
        public string UrlImagePlanimetry { get; set; }
        public int? CssModelPlanimetryId { get; set; }
        [ForeignKey("CssModelPlanimetryId")]
        public virtual CssModel CssModelPlanimetry { get; set; }
        public int? AplicacionId { get; set; }
        [ForeignKey("AplicacionId")]
        public virtual Aplicacion Aplicacion { get; set; }
    }
}