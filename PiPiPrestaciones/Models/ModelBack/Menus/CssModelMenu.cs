using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PiPiPrestaciones.Models
{
    public class CssModelMenu
    {
        [Key]
        public int CssMenuId { get; set; }

        public string FontFamily { get; set; }

        public string ColorText { get; set; }

        public string ColorBack { get; set; }

        public int BorderSize { get; set; }

        public string ImageBack { get; set; }

        public string ColorIcon { get; set; }

    }
}