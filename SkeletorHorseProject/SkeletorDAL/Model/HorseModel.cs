using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkeletorDAL.Model
{
    public class HorseModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public string Race { get; set; }
        public int Withers { get; set; }
        public string Awards { get; set; }
        public bool IsActive { get; set; }
        public bool IsForSale { get; set; }
        public string Price { get; set; }
        public bool IsSold { get; set; }
        public string State { get; set; }
    }
}
