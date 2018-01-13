using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PiPiPrestaciones.Models
{
    [Table("PantallaAplicacion")]
    public class PantallaAplicacion
    {

        [Key]
        [Column("PantallaAplicacionId")]
        public int PantallaAplicacionId { get; set; }

        [Column("NroOrden")]
        [Display(Name = "Indice")]
        public int NroOrden { get; set; }


        [Column("AplicacionId")]
        [Display(Name = "AplicacionId")]
        public int AplicacionId { get; set; }

        [ForeignKey("AplicacionId")]
        [Column("Aplicacion")]
        [Display(Name = "Aplicacion")]
        public virtual Aplicacion Aplicacion { get; set; }




    }
}