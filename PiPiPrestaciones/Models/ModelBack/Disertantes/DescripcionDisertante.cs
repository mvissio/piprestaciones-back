﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PiPiPrestaciones.Models.ModelBack.Disertantes
{
    [Table("DescripcionDisertante")]
    public class DescripcionDisertante
    {
        [Key]
        public int DescripcionDisertanteId { get; set; }
        public string TextDescription { get; set; }
        public string ClassDescription { get; set; }
        public string TextAlingDescription { get; set; }
        public int OrderDescription { get; set; }
        public int? DisertanteId { get; set; }
        [ForeignKey("DisertanteId")]
        public virtual Disertante Disertante { get; set; }
    }
}