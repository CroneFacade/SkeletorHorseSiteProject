using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkeletorDAL.Model
{
   public class HorseSaleModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
		[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Birthday { get; set; }
        public string Race { get; set; }
        public int Withers { get; set; }
        public string Prices { get; set; }
        public bool IsForSale { get; set; }
    }
}
