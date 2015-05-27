using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using SkeletorDAL.POCO;

namespace SkeletorDAL
{
	public class Horse
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
		public string Description { get; set; }
		public string Medicine { get; set; }
		public string FamilyTree { get; set; }
		public string ImagePath { get; set; }
		public string FacebookPath { get; set; }

		public Horse()
		{
			
		}
		public Horse(string name, DateTime birthday, string race, int withers, string awards, string price, string url)
		{
			Name = name;
			Birthday = birthday;
			Race = race;
			Withers = withers;
			Awards = awards;
			IsForSale = false;
			Price = price;
			IsActive = true;
		    FacebookPath = url;
		}

	
	}
}
