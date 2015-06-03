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
					Price = model.Price,
					Description = model.Description,
					Medicine = model.Medicine,
					FamilyTree = model.FamilyTree,
                    ImagePath = "~/ProfileImages/DefaultHead.jpg"
				};
				Repository.AddHorse(newHorse);
				return RedirectToAction("CreateHorse", "CreateHorse");
			}
			return View(model);
		}
	}
}