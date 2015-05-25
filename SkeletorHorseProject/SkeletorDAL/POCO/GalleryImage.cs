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
            public GalleryImage()
            {
                ImageList = new List<string>();
            }
            [Key]
            public Guid ID { get; set; }
            public string Name { get; set; }
            public string ImagePath { get; set; }
            public bool Active { get; set; }
            public List<string> ImageList { get; set; }
        }
    
}
