using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PiPiPrestaciones.Models.ModelApi.Programa
{
    public class AreaProgram
    {
        public int IdArea { get; set; }
        public string NameArea { get; set; }
        public List<DateProgram> DateProgramList { get; set; }
        public CssAreaProgram CssArea { get; set; }
    }
}