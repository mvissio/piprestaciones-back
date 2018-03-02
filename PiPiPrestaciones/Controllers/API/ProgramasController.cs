using PiPiPrestaciones.Models.ModelApi.Programa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PiPiPrestaciones.Controllers.API
{
    public class ProgramasController : ApiController
    {
        [HttpGet]
        public List<AreaProgram> Get(int aplicacionId)
        {
            try
            {
                List<AreaProgram> areaProgramList = new List<AreaProgram>();
                AreaProgram areaProgram = new AreaProgram();
                areaProgram.IdArea = 1;
                areaProgram.NameArea = "Area 1";
                areaProgram.DateProgramList = new List<DateProgram>();

                DateProgram dateProgram1 = new DateProgram();
                dateProgram1.IdDate = 1;
                dateProgram1.NameDate = "Dia 1";
                dateProgram1.ActivityProgramList = new List<ActivityProgram>();

                ActivityProgram activityProgram1 = new ActivityProgram();
                activityProgram1.IdActivity = 1;
                activityProgram1.NameActivity = "Actividad 1";
                activityProgram1.SpeackerModelList = new List<int>();
                activityProgram1.SpeackerModelList.Add(1);
                activityProgram1.SpeackerModelList.Add(2);
                activityProgram1.SpeackerModelList.Add(3);

                dateProgram1.ActivityProgramList.Add(activityProgram1);
                areaProgram.DateProgramList.Add(dateProgram1);
                areaProgramList.Add(areaProgram);
                return areaProgramList;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
