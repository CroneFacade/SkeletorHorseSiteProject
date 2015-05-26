using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SkeletorDAL;

namespace SkeletorHorseProject.Controllers
{
    public class HorseProfileController : Controller
    {
        // GET: HorseProfile
        public ActionResult Index(int id)
        {
            var model = Repository.GetSpecificHorseById(id);
            return View(model);
        }

        [ChildActionOnly]
        public ActionResult HorseBlog()
        {
            return PartialView();
        }
    }
}