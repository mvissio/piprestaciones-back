using PiPiPrestaciones.Helpers;
using PiPiPrestaciones.Models;
using PiPiPrestaciones.Models.ModelApi.Disertante;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PiPiPrestaciones.Controllers.API
{
    public class PlanimetriasController : ApiController
    {
        private PiPiPrestacionesDBContext db = new PiPiPrestacionesDBContext();

        [HttpGet]
        public List<PlanimetryMob> Get(int aplicacionId)
        {
            try
            {
                List<PlanimetryMob> planimetryMobList = new List<PlanimetryMob>();
                List<Planimetry> planimetryList = db.Planimetry.Where(m => m.AplicacionId == aplicacionId && m.Status==true).OrderBy(p=>p.TitlePlanimetry).ToList();
                foreach (var planimetry in planimetryList)
                {
                    List<DetailsPlanimetry> detailsPlanimetryList = db.DetailsPlanimetry.Where(d => d.PlanimetryId == planimetry.PlanimetryId).OrderBy(p=>p.TitleDetails).ToList();
                    planimetryMobList.Add(HelperPlanimetry.GetInstance().ConvertPlanimetryToPlanimetryMob(planimetry, detailsPlanimetryList));
                }
                return planimetryMobList;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
