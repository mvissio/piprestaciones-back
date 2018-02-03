using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;

namespace PiPiPrestaciones.Controllers.API
{
    public class StaticPagesController : ApiController
    {
        //[HttpGet]
        //public JsonResult GetStaticPage(int IdPage)
        //{
        //    return Json(staticPageList.Where(s => s.StaticPageId == IdPage).FirstOrDefault(), JsonRequestBehavior.AllowGet);
        //}

        //[HttpPost]
        //public JsonResult PostStaticPage(StaticPage staticPage)
        //{
        //    try
        //    {
        //        staticPageList.Add(staticPage);
        //        return Json(HttpStatusCode.Accepted);
        //    }
        //    catch (Exception)
        //    {
        //        return Json(HttpStatusCode.BadGateway);
        //    }
        //}

        //[HttpPost]
        //public JsonResult PostStaticList(List<StaticPage> staticPages)
        //{
        //    try
        //    {
        //        staticPages.ForEach(staticPage =>
        //        {
        //            staticPageList.Add(staticPage);
        //        });
        //        return Json(HttpStatusCode.Accepted);
        //    }
        //    catch (Exception)
        //    {
        //        return Json(HttpStatusCode.BadGateway);
        //    }
        //}
    }
}
