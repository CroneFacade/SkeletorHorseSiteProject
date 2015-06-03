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
        public string HorseName { get; set; }
        public ParentModel Parents { get; set; }
        public List<ChildModel> Children { get; set; }
    }
}
