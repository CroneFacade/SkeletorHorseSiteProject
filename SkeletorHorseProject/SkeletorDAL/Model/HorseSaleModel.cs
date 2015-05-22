﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkeletorDAL.Model
{
   public class HorseSaleModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public string Race { get; set; }
        public int Withers { get; set; }
        public string Prices { get; set; }
        public bool IsForSale { get; set; }
    }
}
