using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SkeletorHorseProject.Controllers
{
    public class HorseProfileController : Controller
    {
        // GET: HorseProfile
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult HorseBlog()
        {
            return PartialView();
        }
    }
}