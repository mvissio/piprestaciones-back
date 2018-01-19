using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PiPiPrestaciones.Models
{
    public class PantallaEstatica
    {
        [Key]
        public int PantallaEstaticaId { get; set; }

        public string Titulo { get; set; }

        public string Icono { get; set; }

        public virtual List<ItemPantallaEstatica> Items { get; set; }



    }
}