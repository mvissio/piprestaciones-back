using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PiPiPrestaciones.Models
{
    public class FilesController : Controller
    {
        // GET: Images
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult HandleFileUpload()
        {
            if (!string.IsNullOrEmpty(Request.Headers["X-File-Name"]))
            {
                Guid guid = Guid.NewGuid();
                               
                var img = new Models.Image();
                img.Path = guid.ToString() + "." + Request.Headers["X-File-Name"];
                img.Root = "~/Images/";
                //string filePath = doc.DocumentoId.ToString() + "_" + Request.Headers["X-File-Name"];

                string path = Server.MapPath(string.Format("~/Images/{0}", img.Path));
                using (var fileStream = new FileStream(path, FileMode.OpenOrCreate))
                {
                    Request.InputStream.CopyTo(fileStream);
                }




                //var fileId = doc.DocumentoId;
                /*string filePath = Guid.NewGuid() + Path.GetExtension(file.FileName)*/



                //db.Database.Connection.Open();
                //doc.Ruta = filePath;
                //db.SaveChanges();
                //db.Database.Connection.Close();



                return Json( new { path =  img.Root.Replace("~","") + img.Path });
            }

            return Json(new { success = false });
        }

        [HttpPost]
        public ActionResult UpPlanimetryFile()
        {
            if (!string.IsNullOrEmpty(Request.Headers["X-File-Name"]))
            {
                Guid guid = Guid.NewGuid();

                var img = new Models.Image();
                img.Path = guid.ToString() + "." + Request.Headers["X-File-Name"];
                img.Root = "~/Images/Planimetry/";
                CreateIfMissing(img.Root);
                string path = Server.MapPath(string.Format("~/Images/Planimetry/{0}", img.Path));
                using (var fileStream = new FileStream(path, FileMode.OpenOrCreate))
                {
                    Request.InputStream.CopyTo(fileStream);
                }
                return Json(new { path = img.Root.Replace("~", "") + img.Path });
            }

            return Json(new { success = false });
        }
        private void CreateIfMissing(string path)
        {
            bool folderExists = Directory.Exists(Server.MapPath(path));
            if (!folderExists)
                Directory.CreateDirectory(Server.MapPath(path));
        }


    }
}