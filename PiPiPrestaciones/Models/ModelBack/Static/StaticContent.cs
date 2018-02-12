using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace PiPiPrestaciones.Models 
{
    [Table("StaticContent")]
    public class StaticContent
    {

        [Key]
        [Column("StaticContentId")]
        public int StaticContentId { get; set; }

        [Column("StaticContentType")]
        public string StaticContentType { get; set; }

        [Column("StaticContentOrder")]
        public int? StaticContentOrder { get; set; }

        [Column("StaticContentText")]
        public string StaticContentText { get; set; }

        [Column("cssStaticContentId")]
        public int? cssStaticContentId { get; set; }

        [ForeignKey("cssStaticContentId")]
        public virtual CssModel cssStaticContent{ get; set; }

         
    }
}