using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SkeletorDAL;
using SkeletorDAL.Model;

namespace SkeletorHorseProject.Controllers
{
    public class BlogModel
    {
        public int ID { get; set; }
        public int HorseId { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public List<BlogPostModel> Posts { get; set; }


        public BlogModel()
        {
            Posts = new List<BlogPostModel>();
        }

    }
}