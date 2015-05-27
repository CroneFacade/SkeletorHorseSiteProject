using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SkeletorDAL;
using System.IO;

namespace SkeletorHorseProject.Controllers
{
    public class HorseProfileController : Controller
    {
        // GET: HorseProfile
        public ActionResult Index(int id)
        {
            var idLength = id.ToString();
            var model = Repository.GetSpecificHorseById(id);
            if (model != null)
            {
                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }


        }

        [ChildActionOnly]
        public ActionResult HorseBlog()
        {
            return PartialView();
        }

        public ActionResult UploadProfilePicture(int id)
        {
            return View(id);
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file, int id)
        {

            string imageFileName = "";

            try
            {
                if (file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    fileName = id + fileName;

                    if (fileName.EndsWith(".jpg") ||
                        fileName.EndsWith(".png") ||
                        fileName.EndsWith(".bmp") ||
                        fileName.EndsWith(".gif") ||
                        fileName.EndsWith(".jpeg"))
                    {

                        RemoveOldImage(id);

                        var path = Path.Combine(Server.MapPath("~/ProfileImages"), fileName);
                        file.SaveAs(path);
                        Repository.AddNewFile(fileName, path);
                        imageFileName = fileName;
                    }
                    else
                    {
                        ViewBag.Message = "Incorrect file type, please only upload jpg, jpeg, bmp, png or gif";
                        return RedirectToAction("UploadProfilePicture", id);
                    }


                }
                ViewBag.Message = "Upload successful";

                Repository.AddNewFilePathToHorse(imageFileName, id);


                return RedirectToAction("Index", new { id = id });
            }
            catch
            {
                ViewBag.Message = "Upload failed";
                return RedirectToAction("UploadProfilePicture", id);
            }
        }

        private void RemoveOldImage(int id)
        {
            string path = Repository.RemoveOldProfileImage(id);

            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
        }
    }
}