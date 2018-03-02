using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PiPiPrestaciones.Models.ModelApi.Programa
{
    public class DateProgram
    {
        public int IdDate { get; set; }
        public string NameDate { get; set; }
        public string IconDate { get; set; }
        public List<ActivityProgram> ActivityProgramList { get; set; }
        public CssDateProgram CssDateProgram { get; set; }
    }
}