using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PiPiPrestaciones.Models
{
    [Table("Aplicacion")]
    public class Aplicacion 
    {
        [Key]
        [Column("AplicacionId")]
        public int AplicacionId { get; set; }

        [Column("NombreAplicacion")]
        [Display(Name = "Nombre Aplicación")]
        public string NombreAplicacion { get; set; }

        [Column("VersionId")]
        [Display(Name = "VersionId")]
        public int? VersionId { get; set; }

        [Column("LastModification")]
        [Display(Name = "Última modiicación")]
        public DateTime? LastModification { get; set; }

        [Column("CreateAt")]
        [Display(Name = "CreateAt")]
        public DateTime CreateAt { get; set; }

        [Column("CreateBy")]
        [Display(Name = "CreateBy")]
        public string CreateBy { get; set; }



    }


    public class AplicacionCreateView {

        [Key]
        [Column("AplicacionId")]
        public int AplicacionId { get; set; }

        [Column("NombreAplicacion")]
        [Display(Name = "Nombre Aplicación")]
        public string NombreAplicacion { get; set; }

        [Column("VersionId")]
        [Display(Name = "VersionId")]
        public int? VersionId { get; set; }

        [Column("LastModification")]
        [Display(Name = "Última modiicación")]
        public DateTime? LastModification { get; set; }

        [Column("CreateAt")]
        [Display(Name = "CreateAt")]
        public DateTime CreateAt { get; set; }

        [Column("CreateBy")]
        [Display(Name = "CreateBy")]
        public string CreateBy { get; set; }



    }
}