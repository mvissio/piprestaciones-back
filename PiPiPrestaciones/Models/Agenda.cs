using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PiPiPrestaciones.Models
{
    [Table("Agenda")]
    public class Agenda
    {
        [Key]
        [Column("AgendaId")]
        public int AgendaId { get; set; }

        [Column("FechaEvento")]
        [Display(Name = "FechaEvento")]
        public DateTime? FechaEvento { get; set; }

        [Column("ImagenPreview")]
        [Display(Name = "ImagenPreview")]
        public string ImagenPreview { get; set; }

        [Column("ContenidoPublicacion")]
        [Display(Name = "ContenidoPublicacion")]
        public string ContenidoPublicacion { get; set; }

        [Column("TituloPublicacion")]
        [Display(Name = "TituloPublicacion")]
        public string TituloPublicacion { get; set; }

    }

    public class AgendaCreateView
    {
        [Key]
        public int AgendaId { get; set; }

        [Display(Name = "Fecha realización evento")]
        public DateTime? FechaEvento { get; set; }
         
        [Display(Name = "ImagenPreview")]
        public string ImagenPreview { get; set; }
     
        [Display(Name = "Contenido Publicacion")]
        public string ContenidoPublicacion { get; set; }

        [Display(Name = "Título Publicacion")]
        public string TituloPublicacion { get; set; }

    }


}