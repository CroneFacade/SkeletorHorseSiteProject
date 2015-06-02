using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkeletorDAL.POCO
{
    class FamilyTree
    {
        public int ID { get; set; }
        public string MotherName { get; set; }
        public string MotherDescription { get; set; }
        public string FatherName { get; set; }
        public string FatherDescription { get; set; }
        public virtual List<Child> Children { get; set; }
    }
}
