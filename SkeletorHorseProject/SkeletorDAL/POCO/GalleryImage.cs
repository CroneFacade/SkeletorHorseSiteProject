using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkeletorDAL.POCO
{

        public class GalleryImage
        {
            public int ID { get; set; }
            public string FileName { get; set; }
            public string ImagePath { get; set; }
            public bool Active { get; set; }
        }
    
}
