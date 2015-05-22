using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SkeletorHorseProject.Models;
using SkeletorDAL;
using SkeletorDAL.Model;
namespace SkeletorHorseProject.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        public ActionResult Index()
        {
            var model = Repository.AboutReadOnly();
            return View(model);
        }


    }
}