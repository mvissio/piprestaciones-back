using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PiPiPrestaciones.Models
{
    public class CssStaticPage
    {
        [Key]
        public int CssStaticPageId { get; set; }

        [Display(Name = "Fondo color")]
        public string BackGroundColor { get; set; }

        [Display(Name = "Icono")]
        public string Icon { get; set; }
    }


}

