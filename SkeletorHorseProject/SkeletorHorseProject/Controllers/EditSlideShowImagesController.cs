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
    [Authorize]
    public class EditSlideShowImagesController : Controller
    {
        // GET: EditSlideShowImages
        public ActionResult Index()
        {
            var model = Repository.GetAllSlideShowImages();
            return View(model);

        }
        public ActionResult UploadSlideshowFile()
        {

            return View();
        }
        [ChildActionOnly]
        public ActionResult SliderGallery()
        {

            var model = Repository.GetAllSlideShowImages();
            return View(model);
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
                        var path = Path.Combine(Server.MapPath("~/SlideImages"), fileName);

                        file.SaveAs(path);
                        path = "~/SlideImages/" + fileName;
                        Repository.AddNewSlideShowFile(fileName, path);
                    }
                    else
                    {
                        ViewBag.Message = "Incorrect file type, please only upload jpg, jpeg, bmp, png or gif";
                        return RedirectToAction("UploadSlideshowFile");
                    }


                }
                ViewBag.Message = "Upload successful";


                return View("UploadSlideshowFile");


            }
            catch
            {
                ViewBag.Message = "Upload failed";
                return RedirectToAction("UploadSlideshowFile");
            }
        }
        public ActionResult DeleteImage(int id, string path)
        {
            string fullPath = Request.MapPath(path);
            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
            }
            Repository.DeleteSlideShowImage(id);
            return RedirectToAction("UploadSlideshowFile");
        }

        public ActionResult CropImage(int id, string path)
        {
            return RedirectToAction("UploadSlideshowFile");
        }
    }
}