using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SkeletorDAL.Model;
using SkeletorDAL;

namespace SkeletorHorseProject.Controllers
{
    public class ManageAdminsController : Controller
    {
        // GET: ManageAdmins
        public ActionResult Index()
        {
            
            return View(Repository.GetAllAdmins());
        }

        public ActionResult Delete(int id)
        {
            try
            {
                Repository.RemoveAdminByID(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
    }
}
