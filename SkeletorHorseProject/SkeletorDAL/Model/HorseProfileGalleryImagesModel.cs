using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkeletorDAL.Model
{
    public class HorseProfileGalleryImagesModel
    {
        public int ID { get; set; }
        public int HorseID { get; set; }
        public string FileName { get; set; }
        public string ImagePath { get; set; }
        public bool Active { get; set; }
    }
}
