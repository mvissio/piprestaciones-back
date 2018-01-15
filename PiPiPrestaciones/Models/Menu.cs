using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PiPiPrestaciones.Models
{  // [Table("Menu")] 
    public class Menu
    {
        [Key]
       // [Column("MenuId")]
        public string MenuId { get; set; }

        public string TitleMenu { get; set; }

        public bool Status { get; set; }

        public string Type { get; set; }

        public int Order { get; set; }

        public string Icon { get; set; }

        public CssModelMenu CssModelMenu { get; set; }




    }
//    CssModelMenu{
//fontFamily:string;
//colorText:string;
//colorBack:string;
//borderSize:int;
    public class CssModelMenu {

        public string FontFamily { get; set; }

        public string ColorText { get; set; }

        public string ColorBack { get; set; }

        public int BorderSize { get; set; }

    }
}
