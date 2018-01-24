using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PiPiPrestaciones.Models
{
    public class CssAplicacion
    {
        [Key]
        public int CssAplicacionId { get; set; }


        public string BackGroundColor { get; set; }



    }
}