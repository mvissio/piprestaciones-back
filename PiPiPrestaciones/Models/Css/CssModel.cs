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


        public CssModel() { }

        public CssModel(CssModel css) {
            this.BorderSize = (css.BorderSize != 0) ? css.BorderSize : 0;
            this.ColorBack = css.ColorBack;
            this.ColorIcon = css.ColorIcon;
            this.ColorText = css.ColorText;
            this.CssModelId = (css.CssModelId != 0) ? css.CssModelId : 0;
            this.FontFamily = css.FontFamily;
            this.ImageBack = css.ImageBack;
        }
    }
}