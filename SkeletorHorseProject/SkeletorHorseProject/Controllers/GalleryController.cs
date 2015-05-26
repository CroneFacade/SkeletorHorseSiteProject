using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SkeletorDAL;
using SkeletorDAL.Model;

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
    }
}