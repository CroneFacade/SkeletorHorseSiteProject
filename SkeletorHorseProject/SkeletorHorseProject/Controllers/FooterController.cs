using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SkeletorDAL.Model;

namespace SkeletorHorseProject.Controllers
{
    public class FooterController : Controller
    {
        [ChildActionOnly]
        public ActionResult Index()
        {
            List<FooterModel> list = new List<FooterModel>()
            {
                new FooterModel()  {
                Name = "Triton",
                Url = "blogspot.com"
            },
             new FooterModel()  {
                Name = "Leila",
                Url = "blogspot.com"
            },
             new FooterModel()  {
                Name = "Flilip",
                Url = "blogspot.com"
            },
             new FooterModel()  {
                Name = "Stoffe",
                Url = "blogspot.com"
            },

            };
            
            return PartialView("Footer", list);
        }
    }
}