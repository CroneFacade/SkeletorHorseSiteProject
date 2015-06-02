using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SkeletorDAL;
using SkeletorDAL.Model;

namespace SkeletorHorseProject.Controllers
{
    [Authorize]
	public class EditPuffController : Controller
	{
		// GET: EditPuff
		public ActionResult Edit()
		{
			var currentPuffs = Repository.GetPuffs();
			return View(currentPuffs);
		}

		[HttpPost]
		public ActionResult Edit(EditPuffModel model)
		{
			if (ModelState.IsValid)
			{
				Repository.UpdatePuffs(model);
				return RedirectToAction("Index", "Home");
			}
			return View(model);
		}
	}
}