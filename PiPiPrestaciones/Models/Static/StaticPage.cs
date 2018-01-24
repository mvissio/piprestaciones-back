using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PiPiPrestaciones.Models
{
    public class StaticPage
    {
        [Key]
        public int PageId { get; set; }

        public string PageTitle { get; set; }

        public virtual List<StaticContent> StaticContentList { get; set; }

        public CssStaticPage CssStaticPage { get; set; }

    }
}