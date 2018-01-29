using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PiPiPrestaciones.Models
{
    public class Type
    {
        [Key]
        public int TypeId { get; set; }

        public string TypeName { get; set; }
    }
}