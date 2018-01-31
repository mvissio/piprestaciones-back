﻿
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PiPiPrestaciones.Models
{   [Table("Menu")] 
    public class Menu
    {
        [Key]
        [Column("MenuId")]
        public int MenuId { get; set; }

        [Column("TitleMenu")]
        [Display(Name = "Título")]
        public string TitleMenu { get; set; }

        [Column("Status")]
        public bool Status { get; set; }

        [Column("Type")]
        public string Type { get; set; }

        [Column("Order")]
        public int? Order { get; set; }

        [Column("Icon")]
        public string Icon { get; set; }

        [Column("CssModelMenuId")]
        public int? CssModelMenuId { get; set; }

        [Column("CssModelItemMenuId")] // CSS dentro del menu de inicio de la aplicacion
        public int? CssModelItemMenuId { get; set; }

        [ForeignKey("CssModelItemMenuId")]
        public virtual CssModel CssModelItemMenu { get; set; }

        [ForeignKey("CssModelMenuId")]
        public virtual CssModel CssModelMenu { get; set; }

        [Column("AplicacionId")]
        public int? AplicacionId { get; set; }

        [ForeignKey("AplicacionId")]
        public virtual Aplicacion Aplicacion { get; set; }
    }
}
