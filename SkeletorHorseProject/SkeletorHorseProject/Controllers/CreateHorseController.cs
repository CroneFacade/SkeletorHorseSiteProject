using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SkeletorDAL;
using SkeletorDAL.Model;

namespace SkeletorHorseProject.Controllers
{
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
			if (ModelState.IsValid)
			{

				Horse newHorse = new Horse
				{
					Name = model.Name,
					Birthday = model.Birthday,
					Race = model.Race,
					Withers = model.Withers,
					Awards = model.Awards,
					IsActive = true,
					IsForSale = model.IsForSale,
					Price = model.Price
				};

				Repository.AddHorse(newHorse);
				ViewData["Error"] = "Successfully added " + model.Name;
			}
			return View();
		}
	}
}