using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkeletorDAL.Model
{
    public class HorseVideoModel
    {
        public int ID { get; set; }
        public string VideoName { get; set; }
        public string VideoURL { get; set; }
        public int HorseID { get; set; }
    }
}
