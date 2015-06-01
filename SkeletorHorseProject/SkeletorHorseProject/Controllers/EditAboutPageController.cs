using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls.WebParts;
using SkeletorDAL;
using SkeletorDAL.Model;

namespace SkeletorHorseProject.Controllers
{
	public class EditAboutPageController : Controller
	{
		// GET: EditAboutPage
		public ActionResult EditAbout()
		{
			var currentAboutInfo = Repository.GetLatestAboutInformation();
			return View(currentAboutInfo);
		}
		[HttpPost]
		public ActionResult EditAbout(EditAboutModel model)
		{
			if (ModelState.IsValid)
			{
			var about = Repository.GetLatestAbout();
			about.ID = model.ID;
			about.Header1 = model.Header1;
			about.Header2 = model.Header2;
			about.Textfield1 = model.Textfield1;
			about.Textfield2 = model.Textfield2;
			Repository.UpdateAbouts(about);
				return RedirectToAction("Index", "About");
			}
			return View(model);
		}
	}
}