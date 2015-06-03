using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SkeletorDAL;
using SkeletorDAL.Model;

namespace SkeletorHorseProject.Controllers
{
    public class FilteredHorsePageController : Controller
    {
        // GET: FilteredHorsePage
        public ActionResult FilterPage(int navigationId)
        {
            try
            {
                TempData["myNavId"] = navigationId;
                var horses = TempData["myHorses"] as List<HorseModel>;
                
                if (horses != null)
                {
                    return View(horses);
                }
                var model = Repository.GetHorsesDependingOnNavigation(navigationId);
                return View(model);
            }
            catch (Exception)
            {

                return View();
            }

        }

        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }

        [ChildActionOnly]
        public ActionResult Search()
        {
            return PartialView("_Search");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search(string searchText)
        {
            var navigationId = int.Parse(TempData["myNavId"].ToString());

            if (ModelState.IsValid)
            {
                var result = Repository.GetSearchResult(searchText, navigationId);
                TempData["myHorses"] = result;
                return RedirectToAction("FilterPage", new { navigationId });
            }
            return RedirectToAction("FilterPage", new { navigationId });

        }
    }
}