﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PiPiPrestaciones.Models
{
    [Table("Disertante")]
    public class Disertante
    {
        [Key]
        public int DisertanteId { get; set; }

        public string Title { get; set; }

        public string FullName { get; set; }

        public string ImageUrl { get; set; }

        public string NationalityUrl { get; set; }

        public string WebUrl { get; set; }


        [Column("AplicacionId")]
        public int? AplicacionId { get; set; }

        [ForeignKey("AplicacionId")]
        public virtual Aplicacion Aplicacion { get; set; }


    }
}