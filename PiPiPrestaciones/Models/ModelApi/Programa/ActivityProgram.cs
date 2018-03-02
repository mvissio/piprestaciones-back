using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PiPiPrestaciones.Models.ModelApi.Programa
{
    public class ActivityProgram
    {
        public int IdActivity { get; set; }
        public string NameActivity { get; set; }
        public List<int> SpeackerModelList { get; set; }
        public CssActivityProgram CssActivity { get; set; }
    }
}