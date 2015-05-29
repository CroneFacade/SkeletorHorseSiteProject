using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SkeletorDAL;

namespace SkeletorHorseProject.Controllers
{
    public class BlogPostModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public DateTime Created { get; set; }
        public string Content { get; set; }
        public bool IsActive { get; set; }
        public Blog Blog { get; set; }
    }
}