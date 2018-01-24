using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace PiPiPrestaciones.Models 
{
    public class StaticContent
    {

        [Key]
        public int StaticContentId { get; set; }

        public string StaticContentType { get; set; }

        public int StaticContentOrder { get; set; }

        public string StaticContentText { get; set; }

        public CssStaticContent cssStaticContent{ get; set; }

         
    }
}