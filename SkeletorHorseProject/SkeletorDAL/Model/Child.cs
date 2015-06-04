using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkeletorDAL.Model
{
    public class ChildModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public int horseid { get; set; }
        public string HorseName { get; set; }
    }
}
