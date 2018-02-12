using PiPiPrestaciones.Models.ModelApi.Planimetry;
using System.Collections.Generic;

namespace PiPiPrestaciones.Models
{
    public class PlanimetryMob
    {
        public int IdPlanimery { get; set; }
        public string TitlePlanimetry { get; set; }
        public string FooterPlanimetry { get; set; }
        public string UrlImagePlanimetry { get; set; }
        public List<DetailsPlanimetryMob> DetailsplanimetryList{ get; set; }
    }
}