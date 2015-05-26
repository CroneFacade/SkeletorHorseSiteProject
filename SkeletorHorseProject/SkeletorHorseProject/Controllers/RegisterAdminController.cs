using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SkeletorDAL;
using SkeletorDAL.Model;

namespace SkeletorHorseProject.Controllers
{
    public class RegisterAdminController : Controller
    {
        // GET: RegisterAdmin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterAdminModel model)
        {
            if (ModelState.IsValid)
            {
                Repository.RegisterAdmin(model);
                ModelState.Clear();
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}
