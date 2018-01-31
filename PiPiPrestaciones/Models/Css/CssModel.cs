 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PiPiPrestaciones.Models
{
    [Table("CssModel")]
    public class CssModel
    {
        [Key]
        [Column("CssModelId")]
        public int CssModelId { get; set; }

        [Column("FontFamily")]
        public string FontFamily { get; set; }

        [Column("ColorText")]
        public string ColorText { get; set; }

        [Column("ColorBack")]
        public string ColorBack { get; set; }

        [Column("BorderSize")]
        public int? BorderSize { get; set; }

        [Column("ImageBack")]
        public string ImageBack { get; set; }

        [Column("ColorIcon")]
        public string ColorIcon { get; set; }

    }
}