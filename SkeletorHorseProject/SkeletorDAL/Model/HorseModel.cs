using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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
        public string Description { get; set; }
        public string Medicine { get; set; }
        public string FamilyTree { get; set; }
        public string Facebook { get; set; }

        public string ImagePath { get; set; }
        public string FacebookPath { get; set; }

    }
}
