using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PiPiPrestaciones.Models
{
    public class ItemPantallaEstatica
    {

        [Key]
        public int ItemPantallaEstaticaId { get; set; }

        public string Tipo { get; set; }

        public string  Contenido { get; set; }

        public int Orden { get; set; }

        public virtual CssStyle CssStyle { get; set; }




    }
}