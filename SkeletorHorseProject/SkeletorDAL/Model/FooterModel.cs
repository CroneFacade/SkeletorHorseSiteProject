using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkeletorDAL.Model
{
    public class FooterModel
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required, Url]
        public string Url { get; set; }
    }
}
