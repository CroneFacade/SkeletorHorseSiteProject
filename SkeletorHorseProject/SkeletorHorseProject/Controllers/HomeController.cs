using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using SkeletorDAL;

namespace SkeletorHorseProject.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
	        var images =Repository.GetAllSlideShowImages();
            List<string> list = new List<string>();
            list.Add("~/SlideImages/11273579_10153379658529083_1657643802_o.jpg");
            list.Add("~/SlideImages/11273734_10153379658554083_662969880_o.jpg");
            list.Add("~/SlideImages/11281642_10153379658559083_1233648017_o.jpg");
            list.Add("~/SlideImages/11303908_10153379658549083_514197402_o.jpg");
            list.Add("~/SlideImages/11351072_10153379658534083_240410302_o.jpg");
            foreach (var SlideImage in images)
            {
                list.Add(SlideImage.ImagePath);
            }
            return View(list);
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
        
        [ChildActionOnly]
        public ActionResult LatestUpdates()
        {
            var latest = Repository.GetLatestUpdates();
            return PartialView(latest);
        }
    }
}