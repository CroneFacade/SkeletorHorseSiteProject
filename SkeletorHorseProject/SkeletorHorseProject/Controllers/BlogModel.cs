using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SkeletorDAL;

namespace SkeletorHorseProject.Controllers
{
    public class BlogModel
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public List<Post> Posts { get; set; }
        public Horse Horse { get; set; }

        public BlogModel()
        {
            Posts = new List<Post>();
        }

    }
}