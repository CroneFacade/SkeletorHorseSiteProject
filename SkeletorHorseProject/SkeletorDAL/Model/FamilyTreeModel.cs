using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkeletorDAL.Model
{
    public class FamilyTreeModel
    {
        public int horseid { get; set; }
        public Parent Mother { get; set; }
        public Parent Father { get; set; }
        public List<Child> Children { get; set; }
    }
}
