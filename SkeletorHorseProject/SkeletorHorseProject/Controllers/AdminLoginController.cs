using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using SkeletorHorseProject.Models;

namespace SkeletorHorseProject.Controllers
{
    public class AdminLoginController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(AdminLoginModel model)
        {

            if (ModelState.IsValid)
            {
                FormsAuthentication.SetAuthCookie(model.Username, false);
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }
    }
}