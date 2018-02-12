using PiPiPrestaciones.Models.ModelBack.Disertantes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PiPiPrestaciones.Models.ModelApi.Disertante
{
    public class DisertanteMob
    {
        public int DisertanteId { get; set; }

        public string Title { get; set; }

        public string FullName { get; set; }

        public string ImageUrl { get; set; }

        public string NationalityUrl { get; set; }

        public string WebUrl { get; set; }
        public List<DescripcionDisertanteMob> DescriptionList { get; set; }
        public CssDisertanteMob CssDisertante { get; set; }
    }
}