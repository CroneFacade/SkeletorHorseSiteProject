using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkeletorDAL.Model
{
    public class HorseVideoModel
    {
        public int ID { get; set; }
        [Required]
        public string VideoName { get; set; }
        [Required, Url]
        public string VideoURL { get; set; }
        public int HorseID { get; set; }
    }
}
