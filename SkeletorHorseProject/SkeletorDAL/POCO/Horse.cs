using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
         [Column(TypeName = "datetime2")]
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
	    public FamilyTree Tree { get; set; }
		public string ImagePath { get; set; }
		public string FacebookPath { get; set; }

         [Column(TypeName = "datetime2")]
        public DateTime LastUpdated { get; set; }
        public string Breeding { get; set; }
        public bool Sold { get; set; }
        public string Gender { get; set; }
        public bool Rent { get; set; }
	    public virtual Blog Blog { get; set; }
        public virtual List<YoutubeVideoURL> YoutubeVideoURLs { get; set; }
        public virtual List<User> AssignedEditors { get; set; } 

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
            YoutubeVideoURLs = new List<YoutubeVideoURL>();
            AssignedEditors = new List<User>(){};
		}

	
	}
}
