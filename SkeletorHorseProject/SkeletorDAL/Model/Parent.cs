using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkeletorDAL.Model
{
    public class ParentModel
    {
        public int horseid { get; set; }
        public string HorseName { get; set; }
        [Required]
        public string MotherName { get; set; }
          [Required]
        public string MotherDescription { get; set; }
          [Required]
        public string FatherName { get; set; }
          [Required]
        public string FatherDescription { get; set; }
        
    }
}
