using PiPiPrestaciones.Models;
using PiPiPrestaciones.Models.ModelApi.Planimetry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PiPiPrestaciones.Helpers
{
    public class HelperPlanimetry
    {
        private static HelperPlanimetry instance;

        public static HelperPlanimetry GetInstance()
        {
            return instance ?? (instance = new HelperPlanimetry());
        }

        public PlanimetryMob ConvertPlanimetryToPlanimetryMob(Planimetry planimetry, List<DetailsPlanimetry> detailsPlanimetryList)
        {
            PlanimetryMob planimetryMob = new PlanimetryMob();
            planimetryMob.IdPlanimery = planimetry.PlanimetryId;
            planimetryMob.TitlePlanimetry = planimetry.TitlePlanimetry;
            planimetryMob.UrlImagePlanimetry = planimetry.UrlImagePlanimetry;
            planimetryMob.FooterPlanimetry = planimetry.FooterPlanimetry;
            planimetryMob.DetailsplanimetryList= ConvertDetailsPlanimetryToDetailsPlanimetryMob(detailsPlanimetryList);
            return planimetryMob;
        }
        private List<DetailsPlanimetryMob> ConvertDetailsPlanimetryToDetailsPlanimetryMob(List<DetailsPlanimetry> detailsPlanimetryList)
        {
            List<DetailsPlanimetryMob> detailsPlanimetryMobList = new List<DetailsPlanimetryMob>();
            foreach (DetailsPlanimetry detailsPlanimetry in detailsPlanimetryList)
            {
                DetailsPlanimetryMob detailsPlanimetryMob = new DetailsPlanimetryMob();
                detailsPlanimetryMob.IdDetails = detailsPlanimetry.DetailsPlanimetryId;
                detailsPlanimetryMob.TitleDetails = detailsPlanimetry.TitleDetails;
                detailsPlanimetryMob.DescriptionDetails = detailsPlanimetry.DescriptionDetails;
                detailsPlanimetryMobList.Add(detailsPlanimetryMob);
            }
            return detailsPlanimetryMobList;
        }
    }
}