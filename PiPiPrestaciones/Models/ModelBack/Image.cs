using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PiPiPrestaciones.Models
{
    public class Image
    {
        [Key]
        public int ImageId { get; set; }

        public string Path { get; set; }

        public string Root { get; set; }


    }
}