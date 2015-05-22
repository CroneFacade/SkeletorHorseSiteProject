using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SkeletorDAL;

namespace SkeletorHorseProject.Controllers
{
    public class HorseSaleController : Controller
    {
        // GET: HorseSale
        public ActionResult Index()
        {
            var horsesForSale = Repository.GetHorsesForSale();
            return View(horsesForSale);
        }


        public ActionResult ForSale()
        {
            return PartialView("_ForSale");
        }
    }
}