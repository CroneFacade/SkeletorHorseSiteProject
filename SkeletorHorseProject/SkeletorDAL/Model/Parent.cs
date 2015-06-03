using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkeletorDAL.Model
{
    public class ParentModel
    {
        public int horseid { get; set; }
        public string HorseName { get; set; }
        public string MotherName { get; set; }
        public string MotherDescription { get; set; }
        public string FatherName { get; set; }
        public string FatherDescription { get; set; }
        
    }
}
