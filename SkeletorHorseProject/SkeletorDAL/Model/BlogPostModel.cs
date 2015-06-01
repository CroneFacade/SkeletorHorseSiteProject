using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using SkeletorDAL;

namespace SkeletorHorseProject.Controllers
{
    public class BlogPostModel
    {
        public int ID { get; set; }
        public int BlogID { get; set; }
        [Required]
        public string Title { get; set; }
        public DateTime Created { get; set; }
        [Required]
        public string Content { get; set; }
        public bool IsActive { get; set; }

    }
}