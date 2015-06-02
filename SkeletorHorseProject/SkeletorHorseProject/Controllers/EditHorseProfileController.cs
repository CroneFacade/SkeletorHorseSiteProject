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
    [Authorize]
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
		    @TempData["CheckboxError"] = "The fields 'For sale' and 'Sold' can't both be checked";
            if (ModelState.IsValid && (model.IsForSale == true && model.IsSold == false) || (model.IsForSale == false && model.IsSold == true))
		    {
				Repository.UpdateHorseProfile(id, model);

			    return RedirectToAction("Index", "HorseProfile", new { id = id});
		    }
		    return View(model);
	    }

        public ActionResult EditEditors(int id)
        {
            var Editors = Repository.GetEditorForSpecificHorse(id);
            return View(Editors);
        }

        [ChildActionOnly]
        public ActionResult AddEditor(int id)
        {
            var editor =  new EditorModel();
            editor.HorseId = id;
            return PartialView("_AddEditor",editor);
        }
        
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult AddEditor(EditorModel editor, int horseId)
        {
            if (ModelState.IsValid)
            {
                Repository.AddEditor(editor, horseId);
                return RedirectToAction("EditEditors", new{ id=horseId});
            }
            else
            {
                return RedirectToAction("EditEditors", new { id = horseId });
            }
        }

        public ActionResult DeleteEditorForHorse(int horseId, int editorid)
        {
            Repository.RemoveEditorFromHorse(horseId,editorid);
            return RedirectToAction("EditEditors", new { id = horseId });
        }
    }
}