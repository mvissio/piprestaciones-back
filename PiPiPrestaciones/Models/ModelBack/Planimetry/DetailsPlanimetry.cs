using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PiPiPrestaciones.Models
{
    [Table("DetaisPlanimetry")]
    public class DetailsPlanimetry
    {
        [Key]
        public int IdDetails { get; set; }
        public string TitleDetails { get; set; }
        public string DescriptionDetails { get; set; }
        public int? CssModelDetailsPlanimetryId { get; set; }
        [ForeignKey("CssModelDetailsPlanimetryId")]
        public virtual CssModel CssModelDetailsPlanimetry { get; set; }

        public int? PlanimetryId { get; set; }
        [ForeignKey("PlanimetryId")]
        public virtual Planimetry Planimetry { get; set; }
    }
}