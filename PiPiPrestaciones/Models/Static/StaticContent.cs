using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PiPiPrestaciones.Models
{
    public class StaticContent
    {
        public int StaticContentId { get; set; }
        public string StaticContentType { get; set; }
        public int StaticContentOrder { get; set; }
        public string StaticContentText { get; set; }
        public CssStaticContent cssStaticContent{ get; set; }
    }
}