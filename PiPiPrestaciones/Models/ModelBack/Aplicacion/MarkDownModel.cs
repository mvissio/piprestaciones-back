using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PiPiPrestaciones.Models
{
    [Table("MarkDownModel")]
    public class MarkDownModel
    {
        [Key]
        public int MarkDownModelId { get; set; }

        public string HtmlValue { get; set; }

        public string MarkDownValue { get; set; }

        public string PreviewValue { get; set; }


        public MarkDownModel() { 
        }


        public MarkDownModel(MarkDownModel markDownModel)
        {

            this.HtmlValue = markDownModel.HtmlValue;
            this.MarkDownValue = markDownModel.MarkDownValue;
            this.PreviewValue = markDownModel.PreviewValue;
        }
    }
}