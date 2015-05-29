using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SkeletorDAL.Model;
using SkeletorDAL;

namespace SkeletorHorseProject.Controllers
{
    public class FooterController : Controller
    {
        [ChildActionOnly]
        public ActionResult Index()
        {
             var list = Repository.GetAllFooterLinks();
            
            return PartialView("Footer", list);
        }

        public ActionResult EditLinks()
        {
            return View(Repository.GetAllFooterLinks());
        }

        [ChildActionOnly]
        public ActionResult AddNewLink(FooterModel model)
        {
            return PartialView(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult AddNewFooterLink(FooterModel model)
        {
            if (ModelState.IsValid)
            {
                Repository.AddNewFooterLink(model);
                return RedirectToAction("EditLinks");
            }
            else
            {
                return RedirectToAction("EditLinks");
            }
        }
        public ActionResult DeleteFooterLink(int id)
        {
            Repository.DeleteFooterLink(id);
            return RedirectToAction("EditLinks");
        }
    }
}