using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

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
		public Horse()
		{
			
		}
		public Horse(string name, DateTime birthday, string race, int withers, string prizes)
		{
			Name = name;
			Birthday = birthday;
			Race = race;
			Withers = withers;
			Prizes = prizes;
		}
	}
}
