using PiPiPrestaciones.Models;
using PiPiPrestaciones.Models.ModelApi.Disertante;
using PiPiPrestaciones.Models.ModelBack.Disertantes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PiPiPrestaciones.Helpers
{
    public class HelperDisertante
    {
        private static HelperDisertante instance;

        public static HelperDisertante getInstance()
        {
            return instance ?? (instance = new HelperDisertante());
        }

        public DisertanteMob convertDisertanteToDisertanteMob(Disertante disertante, List<DescripcionDisertante> descripcionDisertante)
        {
            DisertanteMob disertanteMob = new DisertanteMob
            {
                DisertanteId = disertante.DisertanteId,
                Title = disertante.Title,
                WebUrl = disertante.WebUrl,
                NationalityUrl = disertante.NationalityUrl,
                ImageUrl = disertante.ImageUrl,
                FullName = disertante.FullName,
                DescriptionList = convertDescripcionDisertanteToDetailsDisertanteMob(descripcionDisertante),
                CssDisertante = convertCssModelToCssDisertante(disertante.CssDisertante)
            };
            return disertanteMob;
        }

        private CssDisertanteMob convertCssModelToCssDisertante(CssModel cssModel)
        {
            CssDisertanteMob cssDisertanteMob = new CssDisertanteMob();
            cssDisertanteMob.CssSpeackerId = cssModel.CssModelId;
            cssDisertanteMob.BorderSize = cssModel.BorderSize??0;
            cssDisertanteMob.ColorText = cssModel.ColorText;
            cssDisertanteMob.ColorBack = cssModel.ColorBack;
            cssDisertanteMob.FontFamily = cssModel.FontFamily;
            return cssDisertanteMob;
        }
        private List<DescripcionDisertanteMob> convertDescripcionDisertanteToDetailsDisertanteMob(List<DescripcionDisertante> detailsPlanimetryList)
        {
            List<DescripcionDisertanteMob> descDisertMobList = new List<DescripcionDisertanteMob>();
            foreach (DescripcionDisertante detailsPlanimetry in detailsPlanimetryList)
            {
                DescripcionDisertanteMob descDisertMob = new DescripcionDisertanteMob();
                descDisertMob.IdDescription = detailsPlanimetry.IdDescription;
                descDisertMob.TextDescription = detailsPlanimetry.TextDescription;
                descDisertMob.TextAlingDescription = detailsPlanimetry.TextAlingDescription;
                descDisertMob.OrderDescription = detailsPlanimetry.OrderDescription;
                descDisertMob.ClassDescription = detailsPlanimetry.ClassDescription;
                descDisertMobList.Add(descDisertMob);
            }
            return descDisertMobList;
        }
    }
}