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
	        var updatedHorse = Repository.GetFullInformationOnSpecificHorseById(id, model);
	        
            return View(updatedHorse);
        }
		[HttpPost]
	    public ActionResult EditHorseProfile(int id, EditHorseProfileModel model)
	    {
		    var horseModel = Repository.GetFullInformationOnSpecificHorseById(id, model);
		    if (ModelState.IsValid)
		    {
				Repository.UpdateHorseProfile(id, model);

			    return RedirectToAction("Index", "HorseProfile", new { id = id});
		    }
		    return View(model);
	    }
    }
}