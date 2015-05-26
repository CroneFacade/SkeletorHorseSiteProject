using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SkeletorDAL;

namespace SkeletorHorseProject.Controllers
{
    public class FilteredHorsePageController : Controller
    {
        // GET: FilteredHorsePage
        public ActionResult Index(int navigationId)
        {
            var model = Repository.GetHorsesDependingOnNavigation(navigationId);
            return View(model);
        }
    }
}