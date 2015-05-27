using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SkeletorDAL;
using SkeletorDAL.Model;
using System.IO;

namespace SkeletorHorseProject.Controllers
{
    public class GalleryController : Controller
    {
        // GET: Gallery
        public ActionResult Index()
        {
            var model = Repository.GetAllGalleryImages();
            return View(model);
        }

        public ActionResult UploadFile()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            try
            {
                if (file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);

                    if (fileName.EndsWith(".jpg") ||
                        fileName.EndsWith(".png") ||
                        fileName.EndsWith(".bmp") ||
                        fileName.EndsWith(".gif") ||
                        fileName.EndsWith(".jpeg"))
                    {
                        var path = Path.Combine(Server.MapPath("~/Images"), fileName);
                        file.SaveAs(path);
                        Repository.AddNewFile(fileName);
                    }
                    else
                    {
                        ViewBag.Message = "Incorrect file type, please only upload jpg, jpeg, bmp, png or gif";
                        return RedirectToAction("UploadFile");
                    }


                }
                ViewBag.Message = "Upload successful";




                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.Message = "Upload failed";
                return RedirectToAction("UploadFile");
            }
        }
    }
}