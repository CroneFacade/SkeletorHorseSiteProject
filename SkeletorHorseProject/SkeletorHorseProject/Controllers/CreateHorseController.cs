using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SkeletorDAL;
using SkeletorDAL.Model;
using SkeletorDAL.POCO;

namespace SkeletorHorseProject.Controllers
{
    [Authorize]
	public class CreateHorseController : Controller
	{
		// GET: CreateHorse

		public ActionResult CreateHorse()
		{
			return View();
		}
		[HttpPost]
		public ActionResult CreateHorse(CreateHorseModel model)
		{


			@TempData["CheckboxError"] = "The fields 'For sale' and 'Sold' can't both be checked";
			if (ModelState.IsValid && (model.IsForSale == true && model.IsSold == false) || (model.IsForSale == false && model.IsSold == true) || (model.IsForSale == false && model.IsSold == false))
			{
				TempData["CheckboxError"] = string.Empty;

				Repository.AddHorse(model);
				return RedirectToAction("Index", "Home");
			}
			return View(model);
		}
	}
}