using PiPiPrestaciones.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft;

namespace PiPiPrestaciones.Controllers.Api
{
    public class AplicacionesController : ApiController
    {
        private PiPiPrestacionesDBContext db = new PiPiPrestacionesDBContext();

        [HttpGet()]
        public Aplicacion Get(int aplicacionId)
        {
            try
            {
                return db.Aplicacion.Find(aplicacionId);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }


}
