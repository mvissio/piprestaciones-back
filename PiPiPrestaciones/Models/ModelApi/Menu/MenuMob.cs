using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PiPiPrestaciones.Models
{
    public class MenuMob
    {
        public int MenuId { get; set; }
        public string TitleMenu { get; set; }
        public bool Status { get; set; }
        public string Type { get; set; }
        public int? Order { get; set; }
        public string Icon { get; set; }
        public virtual CssModel CssModelItemMenu { get; set; }
        public virtual CssModel CssModelMenu { get; set; }
    }
}