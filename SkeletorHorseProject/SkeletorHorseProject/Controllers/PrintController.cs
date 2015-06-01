using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SkeletorDAL;
using SkeletorDAL.Model;

namespace SkeletorHorseProject.Controllers
{
    public class PrintController : Controller
    {
        // GET: Print
        public ActionResult Index(int id)
        {
            var model = Repository.GetHorseProfileById(id);
            return View(model);
        }
    }
}