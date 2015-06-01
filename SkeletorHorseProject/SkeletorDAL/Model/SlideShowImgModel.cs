using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkeletorDAL.Model
{
    public class SlideShowImgModel
    {
        public int ID { get; set; }
        public string FileName { get; set; }
        public string ImagePath { get; set; }
        public bool Active { get; set; }
    }
}
