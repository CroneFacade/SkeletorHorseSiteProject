using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using SkeletorDAL;
using SkeletorDAL.Model;

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
        public ActionResult HorseBlog(int id)
        {
            var facebookUrl = Repository.GetFacebookPath(id);
            var horseModel = new HorseModel()
            {
                FacebookPath = facebookUrl
            };
            return PartialView(horseModel);
        }
    }
}