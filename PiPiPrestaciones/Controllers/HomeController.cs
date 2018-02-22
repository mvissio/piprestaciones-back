using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PiPiPrestaciones.Controllers
{   
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "PI - Prestaciones Informáticas";    
            return View();
        }
    }
}
