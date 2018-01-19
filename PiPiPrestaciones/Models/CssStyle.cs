using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PiPiPrestaciones.Models
{
    public class CssStyle
    {
        [Key]
        public int CssStyleId { get; set; }

        public string FontFamily { get; set; }

        public string ColorText { get; set; }

        public string ColorBack { get; set; }

        public int BorderSize { get; set; }
    }
}