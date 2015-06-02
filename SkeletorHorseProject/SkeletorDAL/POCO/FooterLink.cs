using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkeletorDAL.POCO
{
    public class FooterLink
    {
        public int ID { get; set; }
        public string LinkName { get; set; }
        public string LinkURL { get; set; }
        public int Column { get; set; }
    }
}
