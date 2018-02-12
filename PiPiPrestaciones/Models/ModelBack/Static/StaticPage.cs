using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PiPiPrestaciones.Models
{
    [Table("StaticPage")]
    public class StaticPage
    {
        [Key]
        [Column("StaticPageId")]
        public int StaticPageId { get; set; }

        [Column("PageTitle")]
        public string PageTitle { get; set; }

        public virtual List<StaticContent> StaticContentList { get; set; }

        public CssModel CssStaticPage { get; set; }

    }
}