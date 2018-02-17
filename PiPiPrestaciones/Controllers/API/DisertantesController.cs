using PiPiPrestaciones.Helpers;
using PiPiPrestaciones.Models;
using PiPiPrestaciones.Models.ModelApi.Disertante;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace PiPiPrestaciones.Controllers.API
{
    public class DisertantesController : ApiController
    {
        private PiPiPrestacionesDBContext db = new PiPiPrestacionesDBContext();

        [HttpGet]
        public List<DisertanteMob> Get(int aplicacionId)
        {
            try
            {
                List<DisertanteMob> disertanteMobList = new List<DisertanteMob>();
                List<Disertante> disertanteList = db.Disertante.Where(m => m.AplicacionId == aplicacionId ).OrderBy(m => m.FullName).ToList();
                foreach (var disertante in disertanteList)
                {
                    List<DescripcionDisertante> descDisertanteList = db.DescripcionDisertante.Where(d => d.DisertanteId == disertante.DisertanteId).OrderBy(m => m.OrderDescription).ToList();
                    disertanteMobList.Add(HelperDisertante.getInstance().convertDisertanteToDisertanteMob(disertante, descDisertanteList));
                }
                return disertanteMobList;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
