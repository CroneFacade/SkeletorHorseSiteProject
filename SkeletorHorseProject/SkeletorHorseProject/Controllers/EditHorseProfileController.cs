using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using SkeletorDAL;
using SkeletorDAL.Model;

namespace SkeletorHorseProject.Controllers
{
    public class EditHorseProfileController : Controller
    {
        // GET: EditHorseProfile
        public ActionResult EditHorseProfile(int id)
        {
	        var model = new EditHorseProfileModel();
	        var currentHorse = Repository.GetFullInformationOnSpecificHorseById(id);
	        model.ID = id;
	        model.Name = currentHorse.Name;
	        model.Birthday = currentHorse.Birthday;
	        model.Race = currentHorse.Race;
	        model.Withers = currentHorse.Withers;
	        model.Awards = currentHorse.Awards;
	        model.Description = currentHorse.Description;
	        model.Medicine = currentHorse.Medicine;
	        model.FamilyTree = currentHorse.FamilyTree;
	        model.IsForSale = !currentHorse.IsForSale;
	        model.Price = currentHorse.Price;
            model.IsActive = currentHorse.IsActive;
            model.FacebookPath = currentHorse.FacebookPath;
            model.IsSold = !currentHorse.IsSold;
            model.Gender = currentHorse.Gender;
            return View(model);
        }
		[HttpPost]
	    public ActionResult EditHorseProfile(int id, EditHorseProfileModel model)
	    {
		    var currentHorse = Repository.GetFullInformationOnSpecificHorseById(id);
		    if (ModelState.IsValid)
		    {
			    
				Repository.UpdateHorseProfile(currentHorse);
			    return RedirectToAction("Index", "HorseProfile", new { id = id});
		    }
		    return View(model);
	    }
    }
}