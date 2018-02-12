using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PiPiPrestaciones.Models.ModelApi.Disertante
{
    public class DescripcionDisertanteMob
    {
        public int IdDescription { get; set; }
        public string TextDescription { get; set; }
        public string ClassDescription { get; set; }
        public string TextAlingDescription { get; set; }
        public int OrderDescription { get; set; }
    }
}