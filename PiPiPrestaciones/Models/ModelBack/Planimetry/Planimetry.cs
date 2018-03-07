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
        public int PlanimetryId { get; set; }
        public string TitlePlanimetry { get; set; }
        public string FooterPlanimetry { get; set; }
        public string UrlImagePlanimetry { get; set; }
        public int OrderPlanimetry { get; set; }
        public bool Status { get; set; }
        public int? CssModelPlanimetryId { get; set; }
        [ForeignKey("CssModelPlanimetryId")]
        public virtual CssModel CssModelPlanimetry { get; set; }
        public int? AplicacionId { get; set; }
        [ForeignKey("AplicacionId")]
        public virtual Aplicacion Aplicacion { get; set; }


        public Planimetry() {

        }

        public Planimetry(CreateViewPlanimetry planimetry) {
            this.TitlePlanimetry = planimetry.TitlePlanimetry;
            this.UrlImagePlanimetry = planimetry.UrlImagePlanimetry;
            this.FooterPlanimetry = planimetry.FooterPlanimetry;
            this.AplicacionId = planimetry.AplicacionId;
            this.Status = true;
        }

    }


    public class CreateViewPlanimetry {

        [Key]
        public int PlanimetryId { get; set; }
        public string TitlePlanimetry { get; set; }
        public string FooterPlanimetry { get; set; }
        [Required(ErrorMessage = "Debes adjuntar una imagen de planimetría")]
        public string UrlImagePlanimetry { get; set; }  
        public int? AplicacionId { get; set; }
     

    }
}

