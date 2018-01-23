using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PiPiPrestaciones.Models
{
    public class StaticPage
    {
        public int PageId { get; set; }
        public string PageTitle { get; set; }
        public List<StaticContent> StaticContentList { get; set; }
        public CssStaticPage CssStaticPage { get; set; }

    }
}